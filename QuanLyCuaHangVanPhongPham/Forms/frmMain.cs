using System;
using System.Windows.Forms;
using QuanLyCuaHangVanPhongPham.Forms;

namespace QuanLyVanPhongPham.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            // Gắn sự kiện click cho nút Sản phẩm
            btnSanPham.Click += BtnSanPham_Click;
        }

        // Hàm xử lý nhúng UserControl
        private void AddUserControl(UserControl uc)
        {
            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
            uc.BringToFront();
        }

        // Sự kiện khi bấm nút Sản phẩm
        private void BtnSanPham_Click(object? sender, EventArgs e)
        {
            ucSanPham uc = new ucSanPham();
            AddUserControl(uc);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo UserControl bán hàng
            ucBanHang uc = new ucBanHang();

            // 2. Cho phép UserControl phình to lấp đầy khoảng trống
            uc.Dock = DockStyle.Fill;

            // 3. Xóa màn hình cũ đang hiển thị (ví dụ đang hiện Sản phẩm thì xóa đi)
            // LƯU Ý: Thay "pnlContent" bằng tên chuẩn xác của cái Panel bự màu trắng trên máy bạn nhé!
            AddUserControl(uc);
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
            ucThuongHieu uc = new ucThuongHieu();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ucNhanVien uc = new ucNhanVien();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);
        }

        private void btnSanPham_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            ucLoaiSanPham uc = new ucLoaiSanPham();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ucKhachHang uc = new ucKhachHang();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            ucNhaCungCap uc = new ucNhaCungCap();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            ucNhapKho uc = new ucNhapKho();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(uc);

        }
    }

}
