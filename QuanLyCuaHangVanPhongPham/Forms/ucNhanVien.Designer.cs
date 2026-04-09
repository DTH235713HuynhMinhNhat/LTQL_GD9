namespace QuanLyCuaHangVanPhongPham.Forms
{
    partial class ucNhanVien
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            cboChucVu = new ComboBox();
            lblChucVu = new Label();
            txtDiaChi = new TextBox();
            lblDiaChi = new Label();
            txtDienThoai = new TextBox();
            lblDienThoai = new Label();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtTenNV = new TextBox();
            lblTenNV = new Label();
            txtMaNV = new TextBox();
            lblMaNV = new Label();
            lblTitle = new Label();
            dgvNhanVien = new DataGridView();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(txtTimKiem);
            pnlTop.Controls.Add(lblTimKiem);
            pnlTop.Controls.Add(cboChucVu);
            pnlTop.Controls.Add(lblChucVu);
            pnlTop.Controls.Add(txtDiaChi);
            pnlTop.Controls.Add(lblDiaChi);
            pnlTop.Controls.Add(txtDienThoai);
            pnlTop.Controls.Add(lblDienThoai);
            pnlTop.Controls.Add(btnHuy);
            pnlTop.Controls.Add(btnLuu);
            pnlTop.Controls.Add(btnXoa);
            pnlTop.Controls.Add(btnSua);
            pnlTop.Controls.Add(btnThem);
            pnlTop.Controls.Add(txtTenNV);
            pnlTop.Controls.Add(lblTenNV);
            pnlTop.Controls.Add(txtMaNV);
            pnlTop.Controls.Add(lblMaNV);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(950, 230);
            pnlTop.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(638, 15);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(280, 30);
            txtTimKiem.TabIndex = 16;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTimKiem.Location = new Point(538, 18);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(91, 23);
            lblTimKiem.TabIndex = 17;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // cboChucVu
            // 
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Font = new Font("Segoe UI", 10F);
            cboChucVu.FormattingEnabled = true;
            cboChucVu.Location = new Point(420, 33);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(110, 31);
            cboChucVu.TabIndex = 15;
            // 
            // lblChucVu
            // 
            lblChucVu.AutoSize = true;
            lblChucVu.Font = new Font("Segoe UI", 10F);
            lblChucVu.Location = new Point(340, 36);
            lblChucVu.Name = "lblChucVu";
            lblChucVu.Size = new Size(76, 23);
            lblChucVu.TabIndex = 14;
            lblChucVu.Text = "Chức vụ:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.Location = new Point(420, 110);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(400, 30);
            txtDiaChi.TabIndex = 13;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Font = new Font("Segoe UI", 10F);
            lblDiaChi.Location = new Point(340, 113);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(66, 23);
            lblDiaChi.TabIndex = 12;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Font = new Font("Segoe UI", 10F);
            txtDienThoai.Location = new Point(130, 110);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(180, 30);
            txtDienThoai.TabIndex = 11;
            // 
            // lblDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Font = new Font("Segoe UI", 10F);
            lblDienThoai.Location = new Point(30, 113);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(93, 23);
            lblDienThoai.TabIndex = 10;
            lblDienThoai.Text = "Điện thoại:";
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Gray;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(540, 170);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(90, 40);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(46, 204, 113);
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(430, 170);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(90, 40);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(320, 170);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 40);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(241, 196, 15);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(210, 170);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 40);
            btnSua.TabIndex = 6;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(100, 170);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 40);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtTenNV
            // 
            txtTenNV.Font = new Font("Segoe UI", 10F);
            txtTenNV.Location = new Point(420, 70);
            txtTenNV.Name = "txtTenNV";
            txtTenNV.Size = new Size(300, 30);
            txtTenNV.TabIndex = 4;
            // 
            // lblTenNV
            // 
            lblTenNV.AutoSize = true;
            lblTenNV.Font = new Font("Segoe UI", 10F);
            lblTenNV.Location = new Point(340, 73);
            lblTenNV.Name = "lblTenNV";
            lblTenNV.Size = new Size(69, 23);
            lblTenNV.TabIndex = 3;
            lblTenNV.Text = "Tên NV:";
            // 
            // txtMaNV
            // 
            txtMaNV.Font = new Font("Segoe UI", 10F);
            txtMaNV.Location = new Point(130, 70);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.ReadOnly = true;
            txtMaNV.Size = new Size(180, 30);
            txtMaNV.TabIndex = 2;
            // 
            // lblMaNV
            // 
            lblMaNV.AutoSize = true;
            lblMaNV.Font = new Font("Segoe UI", 10F);
            lblMaNV.Location = new Point(50, 73);
            lblMaNV.Name = "lblMaNV";
            lblMaNV.Size = new Size(67, 23);
            lblMaNV.TabIndex = 1;
            lblMaNV.Text = "Mã NV:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(261, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÂN VIÊN";
            // 
            // dgvNhanVien
            // 
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.AllowUserToDeleteRows = false;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.BackgroundColor = Color.White;
            dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.Location = new Point(0, 230);
            dgvNhanVien.Name = "dgvNhanVien";
            dgvNhanVien.ReadOnly = true;
            dgvNhanVien.RowHeadersWidth = 51;
            dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhanVien.Size = new Size(950, 470);
            dgvNhanVien.TabIndex = 1;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            // 
            // ucNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvNhanVien);
            Controls.Add(pnlTop);
            Name = "ucNhanVien";
            Size = new Size(950, 700);
            Load += ucNhanVien_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label lblTenNV;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.DataGridView dgvNhanVien;

        // Thêm 2 components mới cho Chức Vụ
        private System.Windows.Forms.Label lblChucVu;
        public System.Windows.Forms.ComboBox cboChucVu;
    }
}