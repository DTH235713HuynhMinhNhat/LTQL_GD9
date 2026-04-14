using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyVanPhongPham.Data;
using QuanLyCuaHangVanPhongPham.Utilities;

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
            string maNV = txtMaNV.Text.Trim();
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string xacNhanMatKhau = txtXacNhanMatKhau.Text;

            // 2. Kiểm tra tính hợp lệ của dữ liệu (Validation)
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
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
                using (var db = new QLCHVPPDbContext())
                {
                    // Kiểm tra xem nhân viên có tồn tại không
                    var nhanVien = db.NhanVien.FirstOrDefault(nv => nv.MaNV == maNV);
                    if (nhanVien == null)
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaNV.Focus();
                        return;
                    }

                    // Kiểm tra xem mã nhân viên này đã có tài khoản chưa
                    if (db.TaiKhoan.Any(tk => tk.MaNV == maNV))
                    {
                        MessageBox.Show("Mã nhân viên này đã được đăng ký tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Kiểm tra xem tên đăng nhập đã tồn tại chưa
                    if (db.TaiKhoan.Any(tk => tk.TenDangNhap == tenDangNhap))
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTenDangNhap.Focus();
                        return;
                    }

                    // Tạo tài khoản mới
                    var newAccount = new TaiKhoan
                    {
                        MaNV = maNV,
                        TenDangNhap = tenDangNhap,
                        MatKhau = SecurityHelper.HashPassword(matKhau),
                        QuyenHan = "User" // Mặc định là User
                    };

                    db.TaiKhoan.Add(newAccount);
                    db.SaveChanges();

                    MessageBox.Show("Đăng ký tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Đóng form sau khi thành công
                    this.Close();
                }
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