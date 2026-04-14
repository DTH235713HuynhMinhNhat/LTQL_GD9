using System;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyVanPhongPham.Data;
using QuanLyVanPhongPham.Utilities;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucTrangChu : UserControl
    {
        private List<decimal> _doanhThu6Thang = new List<decimal>();
        private List<string> _thangLabels = new List<string>();

        // Bổ sung cho nâng cấp
        private List<decimal> _doanhThu7Ngay = new List<decimal>();
        private List<string> _ngayLabels = new List<string>();
        private bool _isMonthView = true; // Mặc định xem theo tháng

        public ucTrangChu()
        {
            InitializeComponent();
        }

        private async void ucTrangChu_Load(object sender, EventArgs e)
        {
            await LoadDashboardAsync();
        }

        protected override async void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                await LoadDashboardAsync();
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            btnRefresh.Text = "Đang tải...";
            await LoadDashboardAsync();
            btnRefresh.Text = "Làm mới";
            btnRefresh.Enabled = true;
        }

        // ─────────────────────────────────────────────
        //  LOAD DỮ LIỆU (BẤT ĐỒNG BỘ - KHÔNG ĐƠ UI)
        // ─────────────────────────────────────────────
        private async Task LoadDashboardAsync()
        {
            try
            {
                // Dùng Task.Run để đẩy toàn bộ truy vấn DB xuống Background Thread
                var data = await Task.Run(() => GetDashboardData());

                // --- CẬP NHẬT UI (Chạy trên Main UI Thread sau khi có data) ---

                // 1. Cập nhật Labels KPI
                lblDoanhThuValue.Text = FormatMoney(data.DoanhThuThang);
                lblChiPhiValue.Text = FormatMoney(data.ChiPhiNhap);
                lblLoiNhuanValue.Text = FormatMoney(data.LoiNhuan);
                lblSoHoaDonValue.Text = data.SoHoaDon.ToString("N0");

                lblLoiNhuanValue.ForeColor = data.LoiNhuan >= 0
                    ? Color.FromArgb(39, 174, 96)   // Xanh
                    : Color.FromArgb(231, 76, 60);  // Đỏ

                // 2. Cập nhật Tổng quan
                lblSanPhamValue.Text = data.TongSanPham.ToString("N0");
                lblKhachHangValue.Text = data.TongKhachHang.ToString("N0");
                lblNhanVienValue.Text = data.TongNhanVien.ToString("N0");
                lblNhaCungCapValue.Text = data.TongNhaCungCap.ToString("N0");
                lblSapHetValue.Text = data.SpSapHet.ToString("N0");

                lblSapHetValue.ForeColor = data.SpSapHet > 0
                    ? Color.FromArgb(231, 76, 60)
                    : Color.Black;

                // 3. Cập nhật DataGridView
                dgvTopSanPham.DataSource = data.TopSanPham;
                dgvHoaDonGanDay.DataSource = data.HoaDonGanDay;
                dgvSapHetHang.DataSource = data.DanhSachSapHet;

                // 4. Cập nhật Biểu đồ
                _doanhThu6Thang = data.DoanhThuChart;
                _thangLabels = data.LabelsChart;
                _doanhThu7Ngay = data.DoanhThu7Ngay;
                _ngayLabels = data.Labels7Ngay;

                pnlChart.Invalidate(); // Vẽ lại biểu đồ

                lblNgayCapNhat.Text = "Cập nhật lúc: " + DateTime.Now.ToString("HH:mm dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Dashboard: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────
        //  HÀM TRUY VẤN DATABASE DÀNH CHO BACKGROUND THREAD
        // ─────────────────────────────────────────────
        private DashboardDTO GetDashboardData()
        {
            var dto = new DashboardDTO();
            DateTime now = DateTime.Now;
            DateTime dauThang = new DateTime(now.Year, now.Month, 1);
            DateTime cuoiThang = dauThang.AddMonths(1).AddTicks(-1);

            using (var db = new QLCHVPPDbContext())
            {
                // 1. Truy vấn KPI Tháng
                dto.DoanhThuThang = db.HoaDon
                    .Where(h => h.NgayLap >= dauThang && h.NgayLap <= cuoiThang)
                    .Sum(h => (decimal?)h.TongTien) ?? 0;

                dto.ChiPhiNhap = db.PhieuNhap
                    .Where(p => p.NgayNhap >= dauThang && p.NgayNhap <= cuoiThang)
                    .Sum(p => (decimal?)p.TongTien) ?? 0;

                dto.LoiNhuan = dto.DoanhThuThang - dto.ChiPhiNhap;

                dto.SoHoaDon = db.HoaDon
                    .Count(h => h.NgayLap >= dauThang && h.NgayLap <= cuoiThang);

                // 2. Truy vấn Tổng quan
                dto.TongSanPham = db.SanPham.Count();
                dto.TongKhachHang = db.KhachHang.Count();
                dto.TongNhanVien = db.NhanVien.Count();
                dto.TongNhaCungCap = db.NhaCungCap.Count();
                dto.SpSapHet = db.SanPham.Count(s => s.SoLuong <= 5);

                // 3. Truy vấn Top Sản phẩm
                dto.TopSanPham = (from ct in db.ChiTietHoaDon
                                  join sp in db.SanPham on ct.MaSP equals sp.MaSP
                                  group ct by new { sp.MaSP, sp.TenSanPham } into g
                                  orderby g.Sum(x => x.SoLuong) descending
                                  select new
                                  {
                                      TenSanPham = g.Key.TenSanPham,
                                      SoLuong = g.Sum(x => x.SoLuong),
                                      DoanhThu = g.Sum(x => x.SoLuong * x.DonGia)
                                  })
                                  .Take(5).ToList()
                                  .Select((x, i) => new
                                  {
                                      STT = i + 1,
                                      TenSanPham = x.TenSanPham,
                                      SoLuong = x.SoLuong,
                                      DoanhThu = FormatMoney(x.DoanhThu)
                                  }).ToList();

                // 4. Truy vấn Hóa đơn gần đây
                dto.HoaDonGanDay = (from hd in db.HoaDon
                                    join kh in db.KhachHang on hd.MaKH equals kh.MaKH
                                    orderby hd.NgayLap descending
                                    select new
                                    {
                                        hd.MaHD,
                                        hd.NgayLap,
                                        kh.TenKhachHang,
                                        hd.TongTien
                                    })
                                    .Take(8).ToList()
                                    .Select(x => new
                                    {
                                        MaHD = x.MaHD,
                                        NgayLap = x.NgayLap.ToString("dd/MM/yyyy HH:mm"),
                                        TenKH = x.TenKhachHang,
                                        TongTien = FormatMoney(x.TongTien)
                                    }).ToList();

                // 5. Truy vấn Biểu đồ 6 tháng
                dto.DoanhThuChart = new List<decimal>();
                dto.LabelsChart = new List<string>();

                for (int i = 5; i >= 0; i--)
                {
                    DateTime thang = now.AddMonths(-i);
                    DateTime dauT = new DateTime(thang.Year, thang.Month, 1);
                    DateTime cuoiT = dauT.AddMonths(1).AddTicks(-1);

                    decimal dt = db.HoaDon
                        .Where(h => h.NgayLap >= dauT && h.NgayLap <= cuoiT)
                        .Sum(h => (decimal?)h.TongTien) ?? 0;

                    dto.DoanhThuChart.Add(dt);
                    dto.LabelsChart.Add("T" + thang.Month + "/" + thang.Year.ToString().Substring(2));
                }

                // 6. Truy vấn Biểu đồ 7 ngày gần nhất
                dto.DoanhThu7Ngay = new List<decimal>();
                dto.Labels7Ngay = new List<string>();
                for (int i = 6; i >= 0; i--)
                {
                    DateTime ngay = now.AddDays(-i).Date;
                    DateTime hetNgay = ngay.AddDays(1).AddTicks(-1);

                    decimal dt = db.HoaDon
                        .Where(h => h.NgayLap >= ngay && h.NgayLap <= hetNgay)
                        .Sum(h => (decimal?)h.TongTien) ?? 0;

                    dto.DoanhThu7Ngay.Add(dt);
                    dto.Labels7Ngay.Add(ngay.ToString("dd/MM"));
                }

                // 7. Truy vấn Chi tiết Sản phẩm sắp hết (tồn kho <= 5)
                dto.DanhSachSapHet = db.SanPham
                    .Where(s => s.SoLuong <= 5)
                    .OrderBy(s => s.SoLuong)
                    .Select(s => new
                    {
                        s.MaSP,
                        s.TenSanPham,
                        Tồn = s.SoLuong,
                        ĐơnVị = s.DonViTinh
                    })
                    .ToList();
            }
            return dto;
        }

        // ─────────────────────────────────────────────
        //  VẼ BIỂU ĐỒ CỘT GDI+
        // ─────────────────────────────────────────────
        private void pnlChart_Paint(object sender, PaintEventArgs e)
        {
            var activeData = _isMonthView ? _doanhThu6Thang : _doanhThu7Ngay;
            var activeLabels = _isMonthView ? _thangLabels : _ngayLabels;

            if (activeData == null || activeData.Count == 0)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int w = pnlChart.Width;
            int h = pnlChart.Height;
            int padLeft = 70, padRight = 20, padTop = 20, padBot = 50;

            int chartW = w - padLeft - padRight;
            int chartH = h - padTop - padBot;

            g.Clear(Color.White);

            decimal maxVal = activeData.Max();
            if (maxVal == 0) maxVal = 1;

            int gridLines = 5;
            using (Pen gridPen = new Pen(Color.FromArgb(230, 230, 230), 1))
            using (Font fSmall = new Font("Segoe UI", 8f))
            using (SolidBrush grayBrush = new SolidBrush(Color.FromArgb(120, 120, 120)))
            {
                for (int i = 0; i <= gridLines; i++)
                {
                    int y = padTop + chartH - (int)(chartH * i / (double)gridLines);
                    g.DrawLine(gridPen, padLeft, y, padLeft + chartW, y);

                    decimal val = maxVal * i / gridLines;
                    string label = val >= 1_000_000
                        ? (val / 1_000_000m).ToString("0.#") + "M"
                        : val >= 1_000
                        ? (val / 1_000m).ToString("0.#") + "K"
                        : val.ToString("0");
                    g.DrawString(label, fSmall, grayBrush, 2, y - 8);
                }
            }

            int n = activeData.Count;
            float barW = chartW / (float)(n * 2);

            using (Font fLabel = new Font("Segoe UI", 8.5f, FontStyle.Bold))
            using (SolidBrush labelBrush = new SolidBrush(Color.FromArgb(52, 73, 94)))
            {
                for (int i = 0; i < n; i++)
                {
                    float x = padLeft + i * (chartW / (float)n) + barW * 0.5f;
                    int barH = (int)(chartH * (activeData[i] / maxVal));
                    int topY = padTop + chartH - barH;

                    Rectangle barRect = new Rectangle((int)x, topY, (int)barW, barH);
                    if (barH > 0)
                    {
                        using (LinearGradientBrush grad = new LinearGradientBrush(
                            barRect,
                            Color.FromArgb(52, 152, 219),
                            Color.FromArgb(41, 128, 185),
                            LinearGradientMode.Vertical))
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            int radius = Math.Min(6, barH);
                            path.AddArc(barRect.X, barRect.Y, radius * 2, radius * 2, 180, 90);
                            path.AddArc(barRect.Right - radius * 2, barRect.Y, radius * 2, radius * 2, 270, 90);
                            path.AddLine(barRect.Right, barRect.Bottom, barRect.X, barRect.Bottom);
                            path.CloseFigure();
                            g.FillPath(grad, path);
                        }
                    }

                    if (activeData[i] > 0)
                    {
                        string val = activeData[i] >= 1_000_000m
                            ? (activeData[i] / 1_000_000m).ToString("0.#") + "M"
                            : (activeData[i] / 1_000m).ToString("0.#") + "K";
                        SizeF sz = g.MeasureString(val, fLabel);
                        g.DrawString(val, fLabel, labelBrush, x + barW / 2 - sz.Width / 2, topY - sz.Height - 2);
                    }

                    SizeF lsz = g.MeasureString(activeLabels[i], fLabel);
                    g.DrawString(activeLabels[i], fLabel, labelBrush,
                        x + barW / 2 - lsz.Width / 2,
                        padTop + chartH + 8);
                }
            }

            using (Pen axisPen = new Pen(Color.FromArgb(180, 180, 180), 1.5f))
                g.DrawLine(axisPen, padLeft, padTop + chartH, padLeft + chartW, padTop + chartH);
        }

        private void ChartView_Toggle(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _isMonthView = (btn == btn6Thang);

            btn6Thang.BackColor = _isMonthView ? Color.FromArgb(52, 152, 219) : Color.FromArgb(189, 195, 199);
            btn6Thang.ForeColor = _isMonthView ? Color.White : Color.Black;

            btn7Ngay.BackColor = !_isMonthView ? Color.FromArgb(52, 152, 219) : Color.FromArgb(189, 195, 199);
            btn7Ngay.ForeColor = !_isMonthView ? Color.White : Color.Black;

            label12.Text = _isMonthView ? "Biểu Đồ Doanh Thu 6 Tháng Gần Nhất" : "Biểu Đồ Doanh Thu 7 Ngày Gần Nhất";
            pnlChart.Invalidate();
        }

        private void Tab_Toggle(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            bool isHoaDon = (btn == btnShowHoaDon);

            btnShowHoaDon.BackColor = isHoaDon ? Color.FromArgb(52, 152, 219) : Color.FromArgb(189, 195, 199);
            btnShowHoaDon.ForeColor = isHoaDon ? Color.White : Color.Black;

            btnShowSapHet.BackColor = !isHoaDon ? Color.FromArgb(231, 76, 60) : Color.FromArgb(189, 195, 199);
            btnShowSapHet.ForeColor = !isHoaDon ? Color.White : Color.Black;

            dgvHoaDonGanDay.Visible = isHoaDon;
            dgvSapHetHang.Visible = !isHoaDon;

            label11.Text = isHoaDon ? "Hóa Đơn Mới Thêm Gần Đây" : "Danh Sách Sản Phẩm Sắp Hết Hàng";
        }

        private string FormatMoney(decimal value)
        {
            if (value >= 1_000_000_000)
                return (value / 1_000_000_000m).ToString("0.##") + " tỷ ₫";
            if (value >= 1_000_000)
                return (value / 1_000_000m).ToString("0.##") + " tr ₫";
            return value.ToString("N0") + " ₫";
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new QLCHVPPDbContext())
                {
                    var data = (from hd in db.HoaDon
                                join kh in db.KhachHang on hd.MaKH equals kh.MaKH
                                join nv in db.NhanVien on hd.MaNV equals nv.MaNV
                                where hd.NgayLap >= tuNgay && hd.NgayLap <= denNgay
                                orderby hd.NgayLap ascending
                                select new
                                {
                                    MaHD = hd.MaHD,
                                    NgayLap = hd.NgayLap,
                                    KhachHang = kh.TenKhachHang,
                                    NhanVien = nv.HoTen,
                                    TongTien = hd.TongTien
                                }).ToList();

                    if (data.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu hóa đơn trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    // Sử dụng DataTable để tránh lỗi hiển thị của DataGridView
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Mã Hóa Đơn");
                    dt.Columns.Add("Ngày Lập", typeof(DateTime));
                    dt.Columns.Add("Khách Hàng");
                    dt.Columns.Add("Nhân Viên Bán");
                    dt.Columns.Add("Tổng Tiền (VNĐ)", typeof(decimal));

                    foreach (var item in data)
                    {
                        dt.Rows.Add(item.MaHD, item.NgayLap, item.KhachHang, item.NhanVien, item.TongTien);
                    }

                    string fileName = $"BaoCaoDoanhThu_{tuNgay:ddMMyy}_to_{dtpDenNgay.Value:ddMMyy}";
                    ExcelHelper.ExportDataTableToExcel(dt, fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // ─────────────────────────────────────────────
    // LỚP DTO (Data Transfer Object) ĐỂ CHUYỂN DỮ LIỆU
    // ─────────────────────────────────────────────
    public class DashboardDTO
    {
        public decimal DoanhThuThang { get; set; }
        public decimal ChiPhiNhap { get; set; }
        public decimal LoiNhuan { get; set; }
        public int SoHoaDon { get; set; }

        public int TongSanPham { get; set; }
        public int TongKhachHang { get; set; }
        public int TongNhanVien { get; set; }
        public int TongNhaCungCap { get; set; }
        public int SpSapHet { get; set; }

        public object TopSanPham { get; set; }
        public object HoaDonGanDay { get; set; }

        public List<decimal> DoanhThuChart { get; set; }
        public List<string> LabelsChart { get; set; }

        // Bổ sung cho nâng cấp
        public List<decimal> DoanhThu7Ngay { get; set; }
        public List<string> Labels7Ngay { get; set; }
        public object DanhSachSapHet { get; set; }
    }
}