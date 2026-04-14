using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangVanPhongPham.Forms;
using QuanLyVanPhongPham.Data;
using QuanLyCuaHangVanPhongPham.Utilities;
 // Thay bằng namespace chứa DbContext của bạn nếu cần

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
                // Mã hóa mật khẩu người dùng nhập vào để so sánh với Hash trong DB
                string hashedMatKhau = SecurityHelper.HashPassword(matKhau);

                // Kết nối tới Database để kiểm tra
                using (var db = new QLCHVPPDbContext())
                {
                    // Tìm tài khoản khớp với Tên đăng nhập
                    // Sử dụng Include để lấy thông tin nhân viên đi kèm
                    var user = db.TaiKhoan
                        .Include(t => t.NhanVien)
                        .FirstOrDefault(t => t.TenDangNhap == tenDangNhap);

                    if (user != null)
                    {
                        bool isPasswordCorrect = false;

                        // Kiểm tra mật khẩu đã được mã hóa Hash chưa
                        if (SecurityHelper.VerifyPassword(matKhau, user.MatKhau))
                        {
                            isPasswordCorrect = true;
                        }
                        else if (user.MatKhau == matKhau) // Dành cho các tài khoản cũ chưa mã hóa
                        {
                            isPasswordCorrect = true;
                            // Cập nhật lại mật khẩu thành dạng mã hóa (Migration)
                            user.MatKhau = hashedMatKhau;
                            db.SaveChanges();
                        }

                        if (isPasswordCorrect)
                        {
                            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Khởi tạo và mở Form Main
                            // Truyền object user sang Form Main để phân quyền
                            frmMain fMain = new frmMain(user);
                            this.Hide(); // Ẩn form đăng nhập đi

                            // Nếu ShowDialog trả về OK nghĩa là user bấm "Đăng xuất"
                            if (fMain.ShowDialog() == DialogResult.OK)
                            {
                                txtMatKhau.Clear();
                                this.Show();
                            }
                            else
                            {
                                this.Close(); // Thoát hẳn chương trình nếu đóng X
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            
            frmDangKy fDangKy = new frmDangKy();
            this.Hide(); // Ẩn form đăng nhập
            fDangKy.ShowDialog(); // Mở form đăng ký lên
            this.Show(); // Sau khi tắt form đăng ký thì hiện lại form đăng nhập   
        }
    }
}