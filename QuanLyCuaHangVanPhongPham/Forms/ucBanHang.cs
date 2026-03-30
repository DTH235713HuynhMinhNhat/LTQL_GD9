using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using QuanLyVanPhongPham.Data;


namespace QuanLyCuaHangVanPhongPham.Forms // Đã thêm chữ "CuaHang" vào namespace
{
    public partial class ucBanHang : UserControl
    {
        private QLCHVPPDbContext db = new QLCHVPPDbContext();

        public ucBanHang()
        {
            InitializeComponent();

            // Đăng ký các sự kiện
            this.Load += UcBanHang_Load;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;

            // Xử lý giỏ hàng
            dgvSanPham.CellDoubleClick += DgvSanPham_CellDoubleClick;
            dgvGioHang.CellEndEdit += DgvGioHang_CellEndEdit;
            btnXoaKhaiGio.Click += BtnXoaKhaiGio_Click;
            btnThanhToan.Click += BtnThanhToan_Click;
        }

        private void UcBanHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachSanPham();
            LoadKhachHang();
        }

        // --- 1. TẢI DỮ LIỆU ---
        private void LoadDanhSachSanPham(string keyword = "")
        {
            try
            {
                var query = db.SanPham.Where(sp => sp.SoLuong > 0); // Chỉ hiển thị SP còn hàng

                if (!string.IsNullOrEmpty(keyword))
                {
                    keyword = keyword.ToLower();
                    query = query.Where(sp => sp.TenSanPham.ToLower().Contains(keyword));
                }

                var data = query.Select(sp => new
                {
                    ID = sp.ID,
                    TenSanPham = sp.TenSanPham,
                    TonKho = sp.SoLuong,
                    GiaBan = sp.GiaBan
                }).ToList();

                dgvSanPham.DataSource = data;

                if (dgvSanPham.Columns.Count > 0)
                {
                    dgvSanPham.Columns["ID"].Width = 60;
                    dgvSanPham.Columns["ID"].HeaderText = "Mã";
                    dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";

                    dgvSanPham.Columns["TonKho"].Width = 80;
                    dgvSanPham.Columns["TonKho"].HeaderText = "Tồn";
                    dgvSanPham.Columns["TonKho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvSanPham.Columns["GiaBan"].Width = 100;
                    dgvSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
                    dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                    dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                // Giả sử bạn có bảng KhachHang, nếu chưa có thì cbo này tạm thời trống
                // var kh = db.KhachHang.ToList();
                // kh.Insert(0, new KhachHang { ID = 0, TenKhachHang = "-- Khách vãng lai --" });
                // cboKhachHang.DataSource = kh;
                // cboKhachHang.DisplayMember = "TenKhachHang";
                // cboKhachHang.ValueMember = "ID";
            }
            catch { }
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDanhSachSanPham(txtTimKiem.Text.Trim());
        }

        // --- 2. XỬ LÝ GIỎ HÀNG ---
        private void DgvSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maSP = Convert.ToInt32(dgvSanPham.Rows[e.RowIndex].Cells["ID"].Value);
                string tenSP = dgvSanPham.Rows[e.RowIndex].Cells["TenSanPham"].Value.ToString();
                int tonKho = Convert.ToInt32(dgvSanPham.Rows[e.RowIndex].Cells["TonKho"].Value);
                int donGia = Convert.ToInt32(dgvSanPham.Rows[e.RowIndex].Cells["GiaBan"].Value);

                // Kiểm tra xem SP đã có trong giỏ chưa
                bool daCoTrongGio = false;
                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    if (Convert.ToInt32(row.Cells["colMaSP"].Value) == maSP)
                    {
                        int soLuongHienTai = Convert.ToInt32(row.Cells["colSoLuong"].Value);
                        if (soLuongHienTai < tonKho)
                        {
                            row.Cells["colSoLuong"].Value = soLuongHienTai + 1;
                            row.Cells["colThanhTien"].Value = (soLuongHienTai + 1) * donGia;
                        }
                        else
                        {
                            MessageBox.Show("Không đủ số lượng tồn kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        daCoTrongGio = true;
                        break;
                    }
                }

                // Nếu chưa có thì thêm dòng mới
                if (!daCoTrongGio)
                {
                    dgvGioHang.Rows.Add(maSP, tenSP, 1, donGia, donGia);
                }

                TinhTongTien();
            }
        }

        private void DgvGioHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Cho phép người dùng sửa trực tiếp cột Số lượng trên giỏ hàng
            if (dgvGioHang.Columns[e.ColumnIndex].Name == "colSoLuong")
            {
                int maSP = Convert.ToInt32(dgvGioHang.Rows[e.RowIndex].Cells["colMaSP"].Value);
                int soLuong = 0;

                // Kiểm tra nhập số hợp lệ
                if (!int.TryParse(dgvGioHang.Rows[e.RowIndex].Cells["colSoLuong"].Value?.ToString(), out soLuong) || soLuong <= 0)
                {
                    dgvGioHang.Rows[e.RowIndex].Cells["colSoLuong"].Value = 1;
                    soLuong = 1;
                }

                // Kiểm tra tồn kho
                var sp = db.SanPham.Find(maSP);
                if (sp != null && soLuong > sp.SoLuong)
                {
                    MessageBox.Show($"Sản phẩm này chỉ còn {sp.SoLuong} cái trong kho!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    soLuong = sp.SoLuong; // Trả về tối đa kho
                    dgvGioHang.Rows[e.RowIndex].Cells["colSoLuong"].Value = soLuong;
                }

                // Tính lại thành tiền
                int donGia = Convert.ToInt32(dgvGioHang.Rows[e.RowIndex].Cells["colDonGia"].Value);
                dgvGioHang.Rows[e.RowIndex].Cells["colThanhTien"].Value = soLuong * donGia;

                TinhTongTien();
            }
        }

        private void BtnXoaKhaiGio_Click(object sender, EventArgs e)
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

        // --- 3. THANH TOÁN ---
        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.Rows.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận thanh toán hóa đơn này?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // TẠM THỜI: Chỉ trừ tồn kho sản phẩm để demo chức năng cốt lõi.
                    // (Sau này bạn có thể thêm code lưu vào bảng HoaDon và ChiTietHoaDon ở đây)

                    foreach (DataGridViewRow row in dgvGioHang.Rows)
                    {
                        int maSP = Convert.ToInt32(row.Cells["colMaSP"].Value);
                        int soLuongBan = Convert.ToInt32(row.Cells["colSoLuong"].Value);

                        var sp = db.SanPham.Find(maSP);
                        if (sp != null)
                        {
                            sp.SoLuong -= soLuongBan; // Trừ tồn kho
                        }
                    }

                    db.SaveChanges(); // Lưu thay đổi tồn kho xuống DB

                    MessageBox.Show("Thanh toán thành công! Đã cập nhật lại kho.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reset lại form
                    dgvGioHang.Rows.Clear();
                    TinhTongTien();
                    LoadDanhSachSanPham(); // Cập nhật lại số lượng trên lưới bên trái
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaKhaiGio_Click_1(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                dgvGioHang.Rows.RemoveAt(dgvGioHang.SelectedRows[0].Index);
                TinhTongTien();
            }
        }

        private void btnThanhToan_Click_1(object sender, EventArgs e)
        {

        }
    }
}