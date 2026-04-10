using System;
using System.Drawing; // Cần có thư viện này để dùng Color
using System.Windows.Forms;
using QuanLyCuaHangVanPhongPham.Forms;

namespace QuanLyVanPhongPham.Forms
{
    public partial class frmMain : Form
    {
        #region 1. Khai báo biến & Khởi tạo (Fields & Constructor)

        // Biến lưu trữ nút (menu) đang được chọn
        private Button currentButton;

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion


        #region 2. Các hàm xử lý giao diện (UI Helper Methods)

        // Hàm xử lý nhúng UserControl vào Panel chính
        private void AddUserControl(UserControl uc, object btnSender)
        {
            // Đổi màu nút được click
            ActivateButton(btnSender);

            // Xóa control cũ và nhúng control mới
            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }

        // Hàm đổi màu nút đang chọn sang màu nổi bật
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    // Trả nút cũ về màu mặc định trước
                    DisableButton();

                    // Gán nút mới và đổi màu (Ví dụ: Màu xanh dương)
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(52, 152, 219);
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        // Hàm trả nút về màu mặc định của Menu
        private void DisableButton()
        {
            if (currentButton != null)
            {
                // MÀU MẶC ĐỊNH CỦA MENU BÊN TRÁI 
                currentButton.BackColor = Color.FromArgb(41, 45, 62);
                currentButton.ForeColor = Color.White;
            }
        }

        #endregion


        #region 3. Sự kiện Click nút Menu (Menu Click Events)

        // ==========================================
        // NHÓM 1: HỆ THỐNG & BÁN HÀNG
        // ==========================================
        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            pnlMain.Controls.Clear();
            // Optional: Thêm Dashboard hoặc Welcome Label vào đây
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            AddUserControl(new ucBanHang(), sender);
        }

        // ==========================================
        // NHÓM 2: QUẢN LÝ SẢN PHẨM
        // ==========================================
        private void btnSanPham_Click(object sender, EventArgs e)
        {
            AddUserControl(new ucSanPham(), sender);
        }

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            AddUserControl(new ucLoaiSanPham(), sender);
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
            AddUserControl(new ucThuongHieu(), sender);
        }

        // ==========================================
        // NHÓM 3: QUẢN LÝ KHO TÀNG
        // ==========================================
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            AddUserControl(new ucNhapKho(), sender);
        }

        private void btnLichSuNhapKho_Click(object sender, EventArgs e)
        {
            AddUserControl(new ucLichSuNhapKho(), sender);
        }

        // ==========================================
        // NHÓM 4: ĐỐI TÁC & NHÂN SỰ
        // ==========================================
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            AddUserControl(new ucKhachHang(), sender);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            AddUserControl(new ucNhaCungCap(), sender);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            AddUserControl(new ucNhanVien(), sender);
        }

        #endregion
    }
}