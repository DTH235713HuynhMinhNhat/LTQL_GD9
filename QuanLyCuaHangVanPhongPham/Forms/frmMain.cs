using System;
using System.Drawing; // Cần có thư viện này để dùng Color
using System.Windows.Forms;
using QuanLyCuaHangVanPhongPham.Forms;

namespace QuanLyVanPhongPham.Forms
{
    public partial class frmMain : Form
    {
        // 1. Khai báo biến lưu trữ nút (menu) đang được chọn
        private Button currentButton;

        public frmMain()
        {
            InitializeComponent();
            btnSanPham.Click += BtnSanPham_Click;
        }

        // 2. Hàm xử lý nhúng UserControl đã được nâng cấp
        private void AddUserControl(UserControl uc, object btnSender)
        {
            // Gọi hàm đổi màu nút
            ActivateButton(btnSender);

            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }

        // 3. Hàm đổi màu nút đang chọn sang màu nổi bật
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    // Trả nút cũ về màu mặc định trước
                    DisableButton();

                    // Gán nút mới và đổi màu
                    currentButton = (Button)btnSender;

                    // ĐỔI MÀU NÚT ĐANG CHỌN (Ví dụ: Màu xanh dương giống nút Tìm kiếm của bạn)
                    currentButton.BackColor = Color.FromArgb(52, 152, 219);
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        // 4. Hàm trả nút về màu mặc định của Menu
        private void DisableButton()
        {
            if (currentButton != null)
            {
                // MÀU MẶC ĐỊNH CỦA MENU BÊN TRÁI 
                // (Bạn xem màu nền của Menu đang dùng là mã RGB bao nhiêu thì thay vào đây nhé)
                currentButton.BackColor = Color.FromArgb(41, 45, 62);
                currentButton.ForeColor = Color.White;
            }
        }

        // =========================================================
        // CÁC SỰ KIỆN CLICK NÚT MENU (Đã được làm gọn)
        // =========================================================

        private void BtnSanPham_Click(object sender, EventArgs e)
        {
            ucSanPham uc = new ucSanPham();
            AddUserControl(uc, sender); // Truyền thêm chữ 'sender' vào để hàm nhận diện được nút nào vừa bấm
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            ucBanHang uc = new ucBanHang();
            AddUserControl(uc, sender);
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
            ucThuongHieu uc = new ucThuongHieu();
            AddUserControl(uc, sender);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ucNhanVien uc = new ucNhanVien();
            AddUserControl(uc, sender);
        }

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            ucLoaiSanPham uc = new ucLoaiSanPham();
            AddUserControl(uc, sender);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ucKhachHang uc = new ucKhachHang();
            AddUserControl(uc, sender);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            ucNhaCungCap uc = new ucNhaCungCap();
            AddUserControl(uc, sender);
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            ucNhapKho uc = new ucNhapKho();
            AddUserControl(uc, sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ucLichSuNhapKho uc = new ucLichSuNhapKho();
            AddUserControl(uc, sender);
        }
    }
}