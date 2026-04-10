using System.Drawing;
using System.Windows.Forms;

namespace QuanLyVanPhongPham.Forms
{
    partial class frmMain : Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            pnlLogo = new Panel();
            lblRole = new Label();
            lblName = new Label();
            btnTrangChu = new Button();
            btnHoaDon = new Button();
            btnNhapKho = new Button();
            btnSanPham = new Button();
            btnLoaiHang = new Button();
            btnThuongHieu = new Button();
            btnKhachHang = new Button();
            btnNhanVien = new Button();
            btnNhaCungCap = new Button();
            btnLichSuNhapKho = new Button();
            btnDangXuat = new Button();
            pnlMain = new Panel();
            pnlSidebar.SuspendLayout();
            pnlLogo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(44, 46, 62);
            // Thứ tự Controls.Add ngược với thứ tự hiển thị vì DockStyle.Top
            // (control thêm sau sẽ hiển thị cao hơn trên màn hình)
            pnlSidebar.Controls.Add(btnNhanVien);       // hiển thị cuối (nhóm quản lý)
            pnlSidebar.Controls.Add(btnKhachHang);      // hiển thị thứ 10
            pnlSidebar.Controls.Add(btnNhaCungCap);     // hiển thị thứ 9
            pnlSidebar.Controls.Add(btnThuongHieu);     // hiển thị thứ 8
            pnlSidebar.Controls.Add(btnLoaiHang);       // hiển thị thứ 7
            pnlSidebar.Controls.Add(btnSanPham);        // hiển thị thứ 6
            pnlSidebar.Controls.Add(btnLichSuNhapKho);  // hiển thị thứ 5 (nhóm kho)
            pnlSidebar.Controls.Add(btnNhapKho);        // hiển thị thứ 4
            pnlSidebar.Controls.Add(btnHoaDon);         // hiển thị thứ 3 (nhóm vận hành)
            pnlSidebar.Controls.Add(btnTrangChu);       // hiển thị thứ 2
            pnlSidebar.Controls.Add(pnlLogo);           // hiển thị trên cùng
            pnlSidebar.Controls.Add(btnDangXuat);       // DockStyle.Bottom - luôn cuối
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 700);
            pnlSidebar.TabIndex = 0;
            // 
            // pnlLogo
            // 
            pnlLogo.Controls.Add(lblRole);
            pnlLogo.Controls.Add(lblName);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 500);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(250, 140);
            pnlLogo.TabIndex = 0;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.ForeColor = Color.Silver;
            lblRole.Location = new Point(82, 85);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(69, 23);
            lblRole.TabIndex = 1;
            lblRole.Text = "Quản lý";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(40, 50);
            lblName.Name = "lblName";
            lblName.Size = new Size(117, 28);
            lblName.TabIndex = 0;
            lblName.Text = "VPP Admin";
            // 
            // btnTrangChu
            // 
            btnTrangChu.Dock = DockStyle.Top;
            btnTrangChu.FlatAppearance.BorderSize = 0;
            btnTrangChu.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnTrangChu.FlatStyle = FlatStyle.Flat;
            btnTrangChu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTrangChu.ForeColor = Color.White;
            btnTrangChu.Location = new Point(0, 450);
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.Padding = new Padding(20, 0, 0, 0);
            btnTrangChu.Size = new Size(250, 50);
            btnTrangChu.TabIndex = 1;
            btnTrangChu.Text = "🏠 Trang chủ";
            btnTrangChu.TextAlign = ContentAlignment.MiddleLeft;
            btnTrangChu.UseVisualStyleBackColor = true;
            btnTrangChu.Click += btnTrangChu_Click;
            // 
            // btnHoaDon
            // 
            btnHoaDon.Dock = DockStyle.Top;
            btnHoaDon.FlatAppearance.BorderSize = 0;
            btnHoaDon.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnHoaDon.FlatStyle = FlatStyle.Flat;
            btnHoaDon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHoaDon.ForeColor = Color.White;
            btnHoaDon.Location = new Point(0, 400);
            btnHoaDon.Name = "btnHoaDon";
            btnHoaDon.Padding = new Padding(20, 0, 0, 0);
            btnHoaDon.Size = new Size(250, 50);
            btnHoaDon.TabIndex = 2;
            btnHoaDon.Text = "📄 Hóa đơn bán hàng";
            btnHoaDon.TextAlign = ContentAlignment.MiddleLeft;
            btnHoaDon.UseVisualStyleBackColor = true;
            btnHoaDon.Click += btnHoaDon_Click;
            // 
            // btnNhapKho
            // 
            btnNhapKho.Dock = DockStyle.Top;
            btnNhapKho.FlatAppearance.BorderSize = 0;
            btnNhapKho.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnNhapKho.FlatStyle = FlatStyle.Flat;
            btnNhapKho.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNhapKho.ForeColor = Color.White;
            btnNhapKho.Location = new Point(0, 350);
            btnNhapKho.Name = "btnNhapKho";
            btnNhapKho.Padding = new Padding(20, 0, 0, 0);
            btnNhapKho.Size = new Size(250, 50);
            btnNhapKho.TabIndex = 3;
            btnNhapKho.Text = "📦 Quản lý nhập kho";
            btnNhapKho.TextAlign = ContentAlignment.MiddleLeft;
            btnNhapKho.UseVisualStyleBackColor = true;
            btnNhapKho.Click += btnNhapKho_Click;
            // 
            // btnSanPham
            // 
            btnSanPham.Dock = DockStyle.Top;
            btnSanPham.FlatAppearance.BorderSize = 0;
            btnSanPham.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnSanPham.FlatStyle = FlatStyle.Flat;
            btnSanPham.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSanPham.ForeColor = Color.White;
            btnSanPham.Location = new Point(0, 300);
            btnSanPham.Name = "btnSanPham";
            btnSanPham.Padding = new Padding(20, 0, 0, 0);
            btnSanPham.Size = new Size(250, 50);
            btnSanPham.TabIndex = 4;
            btnSanPham.Text = "🛍 Sản phẩm";
            btnSanPham.TextAlign = ContentAlignment.MiddleLeft;
            btnSanPham.UseVisualStyleBackColor = true;
            btnSanPham.Click += btnSanPham_Click;
            // 
            // btnLoaiHang
            // 
            btnLoaiHang.Dock = DockStyle.Top;
            btnLoaiHang.FlatAppearance.BorderSize = 0;
            btnLoaiHang.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnLoaiHang.FlatStyle = FlatStyle.Flat;
            btnLoaiHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLoaiHang.ForeColor = Color.White;
            btnLoaiHang.Location = new Point(0, 250);
            btnLoaiHang.Name = "btnLoaiHang";
            btnLoaiHang.Padding = new Padding(20, 0, 0, 0);
            btnLoaiHang.Size = new Size(250, 50);
            btnLoaiHang.TabIndex = 5;
            btnLoaiHang.Text = "📁 Loại sản phẩm";
            btnLoaiHang.TextAlign = ContentAlignment.MiddleLeft;
            btnLoaiHang.UseVisualStyleBackColor = true;
            btnLoaiHang.Click += btnLoaiHang_Click;
            // 
            // btnThuongHieu
            // 
            btnThuongHieu.Dock = DockStyle.Top;
            btnThuongHieu.FlatAppearance.BorderSize = 0;
            btnThuongHieu.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnThuongHieu.FlatStyle = FlatStyle.Flat;
            btnThuongHieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThuongHieu.ForeColor = Color.White;
            btnThuongHieu.Location = new Point(0, 200);
            btnThuongHieu.Name = "btnThuongHieu";
            btnThuongHieu.Padding = new Padding(20, 0, 0, 0);
            btnThuongHieu.Size = new Size(250, 50);
            btnThuongHieu.TabIndex = 6;
            btnThuongHieu.Text = "🏷 Thương hiệu";
            btnThuongHieu.TextAlign = ContentAlignment.MiddleLeft;
            btnThuongHieu.UseVisualStyleBackColor = true;
            btnThuongHieu.Click += btnThuongHieu_Click;
            // 
            // btnKhachHang
            // 
            btnKhachHang.Dock = DockStyle.Top;
            btnKhachHang.FlatAppearance.BorderSize = 0;
            btnKhachHang.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnKhachHang.FlatStyle = FlatStyle.Flat;
            btnKhachHang.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKhachHang.ForeColor = Color.White;
            btnKhachHang.Location = new Point(0, 150);
            btnKhachHang.Name = "btnKhachHang";
            btnKhachHang.Padding = new Padding(20, 0, 0, 0);
            btnKhachHang.Size = new Size(250, 50);
            btnKhachHang.TabIndex = 7;
            btnKhachHang.Text = "👥 Khách hàng";
            btnKhachHang.TextAlign = ContentAlignment.MiddleLeft;
            btnKhachHang.UseVisualStyleBackColor = true;
            btnKhachHang.Click += btnKhachHang_Click;
            // 
            // btnNhanVien
            // 
            btnNhanVien.Dock = DockStyle.Top;
            btnNhanVien.FlatAppearance.BorderSize = 0;
            btnNhanVien.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnNhanVien.FlatStyle = FlatStyle.Flat;
            btnNhanVien.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNhanVien.ForeColor = Color.White;
            btnNhanVien.Location = new Point(0, 100);
            btnNhanVien.Name = "btnNhanVien";
            btnNhanVien.Padding = new Padding(20, 0, 0, 0);
            btnNhanVien.Size = new Size(250, 50);
            btnNhanVien.TabIndex = 8;
            btnNhanVien.Text = "👮 Nhân viên";
            btnNhanVien.TextAlign = ContentAlignment.MiddleLeft;
            btnNhanVien.UseVisualStyleBackColor = true;
            btnNhanVien.Click += btnNhanVien_Click;
            // 
            // btnNhaCungCap
            // 
            btnNhaCungCap.Dock = DockStyle.Top;
            btnNhaCungCap.FlatAppearance.BorderSize = 0;
            btnNhaCungCap.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnNhaCungCap.FlatStyle = FlatStyle.Flat;
            btnNhaCungCap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNhaCungCap.ForeColor = Color.White;
            btnNhaCungCap.Location = new Point(0, 50);
            btnNhaCungCap.Name = "btnNhaCungCap";
            btnNhaCungCap.Padding = new Padding(20, 0, 0, 0);
            btnNhaCungCap.Size = new Size(250, 50);
            btnNhaCungCap.TabIndex = 9;
            btnNhaCungCap.Text = "🏭 Nhà cung cấp";
            btnNhaCungCap.TextAlign = ContentAlignment.MiddleLeft;
            btnNhaCungCap.UseVisualStyleBackColor = true;
            btnNhaCungCap.Click += btnNhaCungCap_Click;
            // 
            // btnLichSuNhapKho
            // 
            btnLichSuNhapKho.Dock = DockStyle.Top;
            btnLichSuNhapKho.FlatAppearance.BorderSize = 0;
            btnLichSuNhapKho.FlatAppearance.MouseDownBackColor = Color.FromArgb(210, 117, 122, 131);
            btnLichSuNhapKho.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            btnLichSuNhapKho.FlatStyle = FlatStyle.Flat;
            btnLichSuNhapKho.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLichSuNhapKho.ForeColor = Color.White;
            btnLichSuNhapKho.Location = new Point(0, 0);
            btnLichSuNhapKho.Name = "btnLichSuNhapKho";
            btnLichSuNhapKho.Padding = new Padding(20, 0, 0, 0);
            btnLichSuNhapKho.Size = new Size(250, 50);
            btnLichSuNhapKho.TabIndex = 11;
            btnLichSuNhapKho.Text = "📜 Lịch sử nhập kho ";
            btnLichSuNhapKho.TextAlign = ContentAlignment.MiddleLeft;
            btnLichSuNhapKho.UseVisualStyleBackColor = true;
            btnLichSuNhapKho.Click += btnLichSuNhapKho_Click;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Dock = DockStyle.Bottom;
            btnDangXuat.FlatAppearance.BorderSize = 0;
            btnDangXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(231, 76, 60);
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDangXuat.ForeColor = Color.White;
            btnDangXuat.Location = new Point(0, 650);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Padding = new Padding(20, 0, 0, 0);
            btnDangXuat.Size = new Size(250, 50);
            btnDangXuat.TabIndex = 10;
            btnDangXuat.Text = "🚪 Đăng xuất";
            btnDangXuat.TextAlign = ContentAlignment.MiddleLeft;
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(245, 246, 250);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(250, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.Size = new Size(950, 700);
            pnlMain.TabIndex = 1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(pnlMain);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Cửa hàng Văn phòng phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            pnlSidebar.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnNhaCungCap;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnKhachHang;
        private System.Windows.Forms.Button btnThuongHieu;
        private System.Windows.Forms.Button btnLoaiHang;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnNhapKho;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRole;
        private Button btnLichSuNhapKho;
    }
}