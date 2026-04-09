using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyVanPhongPham.Data;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucBanHang : UserControl
    {
        private QLCHVPPDbContext db = new QLCHVPPDbContext();

        // Tạo biến hộp số có mũi tên lên xuống
        private NumericUpDown nudSoLuong;

        public ucBanHang()
        {
            InitializeComponent();

            // Khởi tạo control NumericUpDown ẩn
            nudSoLuong = new NumericUpDown();
            nudSoLuong.Minimum = 1;
            nudSoLuong.Maximum = 9999;
            nudSoLuong.Visible = false;
            nudSoLuong.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular); // Cho đồng bộ font chữ

            // Thêm các sự kiện cho hộp số
            nudSoLuong.ValueChanged += NudSoLuong_ValueChanged;
            nudSoLuong.Leave += NudSoLuong_Leave;

            // Thêm hộp số này vào trong DataGridView
            dgvGioHang.Controls.Add(nudSoLuong);

            // 1. Khởi tạo & Tìm kiếm
            this.Load -= UcBanHang_Load;
            this.Load += UcBanHang_Load;

            txtTimKiem.TextChanged -= TxtTimKiem_TextChanged;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;

            cboLoaiSP.SelectedIndexChanged -= CboLoaiSP_SelectedIndexChanged;
            cboLoaiSP.SelectedIndexChanged += CboLoaiSP_SelectedIndexChanged;

            // 2. Nút bấm Mới Thêm
            btnThemVaoGio.Click -= btnThemVaoGio_Click_1;
            btnThemVaoGio.Click += btnThemVaoGio_Click_1;

            

            

            // 3. Giỏ hàng & Thanh toán
            dgvSanPham.CellDoubleClick -= DgvSanPham_CellDoubleClick;
            dgvSanPham.CellDoubleClick += DgvSanPham_CellDoubleClick;

            // Đăng ký sự kiện Click để hiện hộp số mũi tên
            dgvGioHang.CellClick -= DgvGioHang_CellClick;
            dgvGioHang.CellClick += DgvGioHang_CellClick;

            // Ẩn hộp số khi cuộn chuột để tránh bị lóa
            dgvGioHang.Scroll -= DgvGioHang_Scroll;
            dgvGioHang.Scroll += DgvGioHang_Scroll;

            btnXoaKhaiGio.Click -= btnXoaKhaiGio_Click_1;
            btnXoaKhaiGio.Click += btnXoaKhaiGio_Click_1;

            btnThanhToan.Click -= btnThanhToan_Click_1;
            btnThanhToan.Click += btnThanhToan_Click_1;
        }

        private void UcBanHang_Load(object sender, EventArgs e)
        {
            LoadLoaiSanPham();
            LoadKhachHang();
            LoadDanhSachSanPham();
        }

        private void CboLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDanhSachSanPham(txtTimKiem.Text.Trim());
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count > 0)
            {
                if (MessageBox.Show("Xóa toàn bộ giỏ hàng để tạo hóa đơn mới?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }
            LamMoiHoaDon();
        }

        private void LamMoiHoaDon()
        {
            dgvGioHang.Rows.Clear();
            nudQuantityAdd.Value = 1;
            TinhTongTien();
            txtTimKiem.Clear();
            if (cboKhachHang.Items.Count > 0) cboKhachHang.SelectedIndex = 0;
            if (cboLoaiSP.Items.Count > 0) cboLoaiSP.SelectedIndex = 0;
        }

        // --- 1. TẢI DỮ LIỆU ---
        private void LoadDanhSachSanPham(string keyword = "")
        {
            try
            {
                var query = db.SanPham.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    keyword = keyword.ToLower();
                    query = query.Where(sp => sp.TenSanPham.ToLower().Contains(keyword) || sp.MaSP.ToLower().Contains(keyword));
                }

                if (cboLoaiSP.SelectedValue != null && cboLoaiSP.SelectedValue.ToString() != "ALL")
                {
                    string maLoai = cboLoaiSP.SelectedValue.ToString();
                    query = query.Where(sp => sp.MaLoai == maLoai);
                }

                var data = query.Select(sp => new
                {
                    ID = sp.MaSP,
                    TenSanPham = sp.TenSanPham,
                    TonKho = sp.SoLuong,
                    GiaBan = sp.GiaBan,
                    Loai = sp.LoaiSanPham.TenLoai
                }).ToList();

                dgvSanPham.DataSource = data;

                if (dgvSanPham.Columns.Count > 0)
                {
                    dgvSanPham.Columns["ID"].Width = 60;
                    dgvSanPham.Columns["ID"].HeaderText = "Mã";
                    dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";

                    dgvSanPham.Columns["TonKho"].Width = 60;
                    dgvSanPham.Columns["TonKho"].HeaderText = "Tồn";
                    dgvSanPham.Columns["TonKho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvSanPham.Columns["GiaBan"].Width = 90;
                    dgvSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
                    dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                    dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvSanPham.Columns["Loai"].HeaderText = "Loại";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void LoadKhachHang()
        {
            try
            {
                var listKH = db.KhachHang.Select(kh => new { kh.MaKH, DisplayName = kh.TenKhachHang + " (" + kh.SoDienThoai + ")" }).ToList();
                cboKhachHang.DataSource = listKH;
                cboKhachHang.DisplayMember = "DisplayName";
                cboKhachHang.ValueMember = "MaKH";

                if (listKH.Count > 0) cboKhachHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải khách hàng: " + ex.Message);
            }
        }

        private void LoadLoaiSanPham()
        {
            try
            {
                var listLoai = db.LoaiSanPham.Select(l => new { l.MaLoai, l.TenLoai }).ToList();
                // Thêm tùy chọn Tất cả
                var allItem = new { MaLoai = "ALL", TenLoai = "--- Tất cả ---" };
                var finalSubList = new[] { allItem }.Concat(listLoai.Select(l => new { l.MaLoai, l.TenLoai })).ToList();

                cboLoaiSP.DataSource = finalSubList;
                cboLoaiSP.DisplayMember = "TenLoai";
                cboLoaiSP.ValueMember = "MaLoai";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message);
            }
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachSanPham(txtTimKiem.Text.Trim());
        }

        private void BtnLamMoiKH_Click(object sender, EventArgs e)
        {
            LoadKhachHang();
            MessageBox.Show("Đã làm mới danh sách khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- 3. XỬ LÝ GIỎ HÀNG (THÊM VÀO GIỎ) ---
        private void btnThemVaoGio_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvSanPham.CurrentRow != null && dgvSanPham.CurrentRow.Index >= 0)
                {
                    ThemSanPhamVaoGio(dgvSanPham.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm bên danh sách để thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi click thêm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ThemSanPhamVaoGio(e.RowIndex);
            }
        }

        private void ThemSanPhamVaoGio(int rowIndex)
        {
            try
            {
                var rowInfo = dgvSanPham.Rows[rowIndex];

                string maSP = rowInfo.Cells["ID"].Value?.ToString() ?? "";
                string tenSP = rowInfo.Cells["TenSanPham"].Value?.ToString() ?? "";
                int tonKho = Convert.ToInt32(rowInfo.Cells["TonKho"].Value);
                int donGia = Convert.ToInt32(rowInfo.Cells["GiaBan"].Value);
                int soLuongThem = (int)nudQuantityAdd.Value;

                if (soLuongThem > tonKho)
                {
                    MessageBox.Show($"Số lượng yêu cầu ({soLuongThem}) vượt quá tồn kho hiện tại ({tonKho})!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool daCoTrongGio = false;
                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    if (row.Cells["colMaSP"].Value != null && row.Cells["colMaSP"].Value.ToString() == maSP)
                    {
                        int soLuongHienTai = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                        int tongSoLuongMoi = soLuongHienTai + soLuongThem;

                        if (tongSoLuongMoi <= tonKho)
                        {
                            row.Cells["colSoLuong"].Value = tongSoLuongMoi;
                            row.Cells["colThanhTien"].Value = tongSoLuongMoi * donGia;
                        }
                        else
                        {
                            MessageBox.Show($"Tổng số lượng trong giỏ ({tongSoLuongMoi}) vượt quá tồn kho ({tonKho})!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        daCoTrongGio = true;
                        break;
                    }
                }

                if (!daCoTrongGio)
                {
                    dgvGioHang.Rows.Add(maSP, tenSP, soLuongThem, donGia, soLuongThem * donGia);
                }

                TinhTongTien();
                nudQuantityAdd.Value = 1; // Reset số lượng sau khi thêm thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chi tiết khi thêm vào giỏ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 4. TÍNH TOÁN VỚI MŨI TÊN LÊN XUỐNG ---

        // Khi click vào ô số lượng, hiển thị hộp số lên
        private void DgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvGioHang.Columns[e.ColumnIndex].Name == "colSoLuong")
            {
                // Lấy tọa độ và kích thước của ô đang click
                Rectangle rect = dgvGioHang.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                nudSoLuong.Size = new Size(rect.Width, rect.Height);
                nudSoLuong.Location = new Point(rect.X, rect.Y);

                // Gán giá trị hiện tại của ô vào hộp số
                nudSoLuong.Value = Convert.ToDecimal(dgvGioHang.Rows[e.RowIndex].Cells["colSoLuong"].Value);
                nudSoLuong.Tag = e.RowIndex; // Ghi nhớ lại đang sửa ở dòng nào

                nudSoLuong.Visible = true;
                nudSoLuong.BringToFront();
                nudSoLuong.Focus();
            }
            else
            {
                nudSoLuong.Visible = false; // Click ra chỗ khác thì ẩn đi
            }
        }

        // Khi người dùng bấm mũi tên lên/xuống hoặc gõ số
        private void NudSoLuong_ValueChanged(object sender, EventArgs e)
        {
            if (nudSoLuong.Visible && nudSoLuong.Tag != null)
            {
                int rowIndex = (int)nudSoLuong.Tag;
                string maSP = dgvGioHang.Rows[rowIndex].Cells["colMaSP"].Value?.ToString() ?? "";
                int soLuongMoi = (int)nudSoLuong.Value;

                var sp = db.SanPham.Find(maSP);
                if (sp != null && soLuongMoi > sp.SoLuong)
                {
                    MessageBox.Show($"Sản phẩm này chỉ còn {sp.SoLuong} cái trong kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudSoLuong.Value = sp.SoLuong; // Giới hạn không cho tăng quá tồn kho
                    soLuongMoi = sp.SoLuong;
                }

                int donGia = Convert.ToInt32(dgvGioHang.Rows[rowIndex].Cells["colDonGia"].Value);
                dgvGioHang.Rows[rowIndex].Cells["colSoLuong"].Value = soLuongMoi;
                dgvGioHang.Rows[rowIndex].Cells["colThanhTien"].Value = soLuongMoi * donGia;

                TinhTongTien();
            }
        }

        // Ẩn hộp số khi con trỏ chuột rời đi hoặc cuộn bảng
        private void NudSoLuong_Leave(object sender, EventArgs e)
        {
            nudSoLuong.Visible = false;
        }

        private void DgvGioHang_Scroll(object sender, ScrollEventArgs e)
        {
            nudSoLuong.Visible = false;
        }

        private void btnXoaKhaiGio_Click_1(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                dgvGioHang.Rows.RemoveAt(dgvGioHang.SelectedRows[0].Index);
                TinhTongTien();
            }
        }

        private void TinhTongTien()
        {
            double tongTien = 0;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                tongTien += Convert.ToDouble(row.Cells["colThanhTien"].Value);
            }
            lblTongTienValue.Text = tongTien.ToString("N0") + " VNĐ";
        }

        // --- 5. THANH TOÁN ---
        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận thanh toán hóa đơn này?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    // 1. Tạo mã hóa đơn dựa trên thời gian
                    string maHD = "HD" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    string maKH = cboKhachHang.SelectedValue.ToString();

                    // Lấy mã nhân viên đầu tiên nếu không có session
                    var checkNV = db.NhanVien.FirstOrDefault();
                    if (checkNV == null)
                    {
                        throw new Exception("Hệ thống chưa có nhân viên nào. Vui lòng thêm nhân viên trước!");
                    }
                    string maNV = checkNV.MaNV;

                    decimal tongTien = 0;
                    foreach (DataGridViewRow row in dgvGioHang.Rows)
                    {
                        tongTien += Convert.ToDecimal(row.Cells["colThanhTien"].Value);
                    }

                    // 2. Tạo đối tượng HoaDon
                    HoaDon hd = new HoaDon
                    {
                        MaHD = maHD,
                        MaKH = maKH,
                        MaNV = maNV,
                        NgayLap = DateTime.Now,
                        TongTien = tongTien
                    };
                    db.HoaDon.Add(hd);

                    // 3. Tạo các ChiTietHoaDon và cập nhật kho
                    foreach (DataGridViewRow row in dgvGioHang.Rows)
                    {
                        string maSP = row.Cells["colMaSP"].Value?.ToString() ?? "";
                        int soLuongBan = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                        decimal donGia = Convert.ToDecimal(row.Cells["colDonGia"].Value);

                        ChiTietHoaDon cthd = new ChiTietHoaDon
                        {
                            MaHD = maHD,
                            MaSP = maSP,
                            SoLuong = soLuongBan,
                            DonGia = donGia
                        };
                        db.ChiTietHoaDon.Add(cthd);

                        // Cập nhật kho
                        var sp = db.SanPham.Find(maSP);
                        if (sp != null)
                        {
                            if (sp.SoLuong < soLuongBan)
                            {
                                throw new Exception($"Sản phẩm '{sp.TenSanPham}' vừa bị thay đổi tồn kho, không đủ để bán!");
                            }
                            sp.SoLuong -= soLuongBan;
                        }
                    }

                    db.SaveChanges();
                    transaction.Commit();

                    MessageBox.Show($"Thanh toán thành công!\nMã hóa đơn: {maHD}\nTổng tiền: {hd.TongTien:N0} VNĐ", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LamMoiHoaDon();
                    LoadDanhSachSanPham();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoiKH_Click_1(object sender, EventArgs e)
        {

        }
    }
}