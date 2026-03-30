using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyVanPhongPham.Data; // Thay đổi không gian tên (namespace) Data nếu cần

namespace QuanLyVanPhongPham.Forms
{
    public partial class ucSanPham : UserControl
    {
        private QLCHVPPDbContext db = new QLCHVPPDbContext();

        public ucSanPham()
        {
            InitializeComponent();

            // Đăng ký sự kiện Load và Tìm kiếm
            this.Load += UcSanPham_Load;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
        }

        private void UcSanPham_Load(object sender, EventArgs e)
        {
            // Thêm placeholder text cho ô tìm kiếm
            txtTimKiem.Text = "Nhập tên, loại SP...";
            txtTimKiem.ForeColor = Color.Gray;
            txtTimKiem.Enter += TxtTimKiem_Enter;
            txtTimKiem.Leave += TxtTimKiem_Leave;

            LoadData();
        }

        // --- 1. HÀM ĐỔ DỮ LIỆU LÊN DATAGRIDVIEW ---
        private void LoadData(string keyword = "")
        {
            try
            {
                // Sử dụng Select để tạo ra một danh sách đối tượng ẩn danh (Anonymous Type)
                // Việc này giúp ta lấy được Tên thay vì ID từ các bảng liên kết
                var query = db.SanPham.AsQueryable();

                // Nếu có từ khóa tìm kiếm
                if (!string.IsNullOrEmpty(keyword) && keyword != "Nhập tên, loại SP...")
                {
                    keyword = keyword.ToLower();
                    query = query.Where(sp => sp.TenSanPham.ToLower().Contains(keyword) ||
                                              sp.LoaiSanPham.TenLoai.ToLower().Contains(keyword) ||
                                              sp.ThuongHieu.TenThuongHieu.ToLower().Contains(keyword));
                }

                var data = query.Select(sp => new
                {
                    ID = sp.ID,
                    TenSanPham = sp.TenSanPham,
                    LoaiSP = sp.LoaiSanPham.TenLoai,           // Lấy tên Loại SP
                    ThuongHieu = sp.ThuongHieu.TenThuongHieu, // Lấy tên Thương hiệu
                    SoLuong = sp.SoLuong,
                    GiaBan = sp.GiaBan
                }).ToList();

                dgvSanPham.DataSource = data;

                // Đổi tên cột cho đẹp và chuyên nghiệp
                if (dgvSanPham.Columns.Count > 0)
                {
                    dgvSanPham.Columns["ID"].HeaderText = "Mã SP";
                    dgvSanPham.Columns["ID"].Width = 70;

                    dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";

                    dgvSanPham.Columns["LoaiSP"].HeaderText = "Loại SP";
                    dgvSanPham.Columns["LoaiSP"].Width = 150;

                    dgvSanPham.Columns["ThuongHieu"].HeaderText = "Thương Hiệu";
                    dgvSanPham.Columns["ThuongHieu"].Width = 150;

                    dgvSanPham.Columns["SoLuong"].HeaderText = "Tồn Kho";
                    dgvSanPham.Columns["SoLuong"].Width = 100;
                    dgvSanPham.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
                    dgvSanPham.Columns["GiaBan"].Width = 120;
                    dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0"; // Định dạng tiền tệ 1.000.000
                    dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 2. HÀM TÌM KIẾM ---
        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text.Trim());
        }

        // --- Xử lý giao diện cho thanh tìm kiếm (Placeholder) ---
        private void TxtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập tên, loại SP...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void TxtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Nhập tên, loại SP...";
                txtTimKiem.ForeColor = Color.Gray;
                LoadData(); // Load lại toàn bộ khi bỏ trống
            }
        }

        // --- 3. CÁC NÚT CHỨC NĂNG ---
        private void btnThemMoi_Click_1(object sender, EventArgs e)
        {
            // Mở form chi tiết ở chế độ Thêm mới
            frmChiTietSanPham frm = new frmChiTietSanPham();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Cập nhật lại lưới sau khi thêm
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                // Lấy ID của dòng đang chọn
                int id = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["ID"].Value);

                // Mở form chi tiết truyền vào ID để sửa
                frmChiTietSanPham frm = new frmChiTietSanPham(id);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Cập nhật lại lưới sau khi sửa
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["ID"].Value);
                string tenSP = dgvSanPham.SelectedRows[0].Cells["TenSanPham"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{tenSP}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var sp = db.SanPham.Find(id);
                        if (sp != null)
                        {
                            db.SanPham.Remove(sp);
                            db.SaveChanges();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Cập nhật lại lưới
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa (Có thể sản phẩm này đã phát sinh hóa đơn):\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }         

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Tính năng xuất Excel sẽ code ở đây
            MessageBox.Show("Tính năng đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}