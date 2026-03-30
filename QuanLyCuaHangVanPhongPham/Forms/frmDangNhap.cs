using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyVanPhongPham.Data; // Thay bằng namespace chứa DbContext của bạn nếu cần

namespace QuanLyVanPhongPham.Forms
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện khi bấm nút "Đăng nhập"
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            // Kiểm tra xem người dùng đã nhập đủ thông tin chưa
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kết nối tới Database để kiểm tra
                using (var db = new QLCHVPPDbContext()) // Đổi tên Context cho khớp với project của bạn
                {
                    // Tìm tài khoản khớp với Tên đăng nhập và Mật khẩu
                    // Đổi 'TaiKhoan', 'TenDangNhap', 'MatKhau' cho khớp với Database của bạn
                    var user = db.TaiKhoan.FirstOrDefault(t => t.TenDangNhap == tenDangNhap && t.MatKhau == matKhau);

                    if (user != null)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Khởi tạo và mở Form Main
                        frmMain fMain = new frmMain();
                        this.Hide(); // Ẩn form đăng nhập đi
                        fMain.ShowDialog();

                        // Sau khi Form Main bị đóng, thì đóng luôn chương trình
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện khi bấm nút "Thoát"
        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại hỏi đáp trước khi thoát
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Xử lý sự kiện khi bấm vào dòng chữ "Chưa có tài khoản? Đăng ký"
        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mở form đăng ký (Đảm bảo bạn đã tạo form frmDangKy)
            frmDangKy fDangKy = new frmDangKy();
            this.Hide(); // Ẩn form đăng nhập
            fDangKy.ShowDialog(); // Mở form đăng ký lên
            this.Show(); // Sau khi tắt form đăng ký thì hiện lại form đăng nhập
        }
    }
}