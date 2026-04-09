using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyVanPhongPham.Data;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucLichSuNhapKho : UserControl
    {
        public ucLichSuNhapKho()
        {
            InitializeComponent();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            // Mỗi khi UserControl này được hiển thị lên, tự động nạp lại danh sách mới nhất
            if (this.Visible)
            {
                // Gọi lại hàm load dữ liệu của bạn
                LoadDanhSachPhieuNhap();
            }
        }

        private void ucLichSuNhapKho_Load(object sender, EventArgs e)
        {
            // Mặc định load dữ liệu trong tháng hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now.Date.AddDays(1).AddTicks(-1);

            LoadDanhSachPhieuNhap();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhieuNhap();
        }

        private void LoadDanhSachPhieuNhap()
        {
            try
            {
                using (var db = new QLCHVPPDbContext())
                {
                    DateTime tuNgay = dtpTuNgay.Value.Date;
                    DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1); // Lấy đến hết ngày hôm đó

                    string keyword = txtTimKiem.Text.Trim();

                    var query = from pn in db.PhieuNhap
                                join ncc in db.NhaCungCap on pn.MaNCC equals ncc.MaNCC
                                where pn.NgayNhap >= tuNgay && pn.NgayNhap <= denNgay
                                orderby pn.NgayNhap descending
                                select new
                                {
                                    MaPN = pn.MaPN,
                                    NgayNhap = pn.NgayNhap,
                                    TenNCC = ncc.TenNhaCungCap,
                                    TongTien = pn.TongTien
                                };

                    if (!string.IsNullOrEmpty(keyword))
                    {
                        query = query.Where(pn => pn.MaPN.Contains(keyword) || pn.TenNCC.Contains(keyword));
                    }

                    dgvPhieuNhap.DataSource = query.ToList();

                    // Format lại lưới
                    if (dgvPhieuNhap.Columns.Count > 0)
                    {
                        dgvPhieuNhap.Columns["MaPN"].HeaderText = "Mã Phiếu";
                        dgvPhieuNhap.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
                        dgvPhieuNhap.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                        dgvPhieuNhap.Columns["TenNCC"].HeaderText = "Nhà Cung Cấp";
                        dgvPhieuNhap.Columns["TongTien"].HeaderText = "Tổng Tiền";
                        dgvPhieuNhap.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                    }

                    // Nếu không có phiếu nào, xóa rỗng lưới chi tiết
                    if (dgvPhieuNhap.Rows.Count == 0)
                    {
                        dgvChiTiet.DataSource = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện: Khi click chọn 1 dòng ở bảng PhieuNhap, sẽ load chi tiết xuống bảng dgvChiTiet
        private void dgvPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow != null && dgvPhieuNhap.CurrentRow.Index > -1)
            {
                string maPN = dgvPhieuNhap.CurrentRow.Cells["MaPN"].Value.ToString();
                LoadChiTietPhieu(maPN);
            }
        }

        private void LoadChiTietPhieu(string maPN)
        {
            try
            {
                using (var db = new QLCHVPPDbContext())
                {
                    var query = from ct in db.ChiTietPhieuNhap
                                join sp in db.SanPham on ct.MaSP equals sp.MaSP
                                where ct.MaPN == maPN
                                select new
                                {
                                    MaSP = ct.MaSP,
                                    TenSanPham = sp.TenSanPham,
                                    SoLuong = ct.SoLuong,
                                    GiaNhap = ct.GiaNhap,
                                    ThanhTien = ct.SoLuong * ct.GiaNhap
                                };

                    dgvChiTiet.DataSource = query.ToList();

                    // Format lại lưới
                    if (dgvChiTiet.Columns.Count > 0)
                    {
                        dgvChiTiet.Columns["MaSP"].HeaderText = "Mã SP";
                        dgvChiTiet.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                        dgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng";
                        dgvChiTiet.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                        dgvChiTiet.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
                        dgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                        dgvChiTiet.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachPhieuNhap();
        }
    }
}