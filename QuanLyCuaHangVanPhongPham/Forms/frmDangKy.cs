using System;
using System.Windows.Forms;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện khi click nút Đăng Ký
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ giao diện và xóa khoảng trắng thừa
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string xacNhanMatKhau = txtXacNhanMatKhau.Text;

            // 2. Kiểm tra tính hợp lệ của dữ liệu (Validation)
            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus(); // Đưa trỏ chuột về ô Tên đăng nhập
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            if (matKhau != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtXacNhanMatKhau.Focus();
                return;
            }

            // 3. Xử lý lưu vào Cơ Sở Dữ Liệu (CSDL)
            try
            {
                // TODO: Viết code gọi hàm Insert vào CSDL (SQL Server, MySQL...) ở đây.
                // Ví dụ: 
                // bool isSuccess = TaiKhoanDAO.Instance.DangKy(tenDangNhap, matKhau);
                // if (isSuccess) { ... }

                // Tạm thời giả lập đăng ký thành công
                MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa trắng form hoặc đóng form sau khi đăng ký thành công
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện khi click nút Hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại hỏi đáp trước khi thoát (Tùy chọn)
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy đăng ký?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng form hiện tại
            }
        }
    }
}