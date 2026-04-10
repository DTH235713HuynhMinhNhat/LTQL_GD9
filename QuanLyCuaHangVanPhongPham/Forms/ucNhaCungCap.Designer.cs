namespace QuanLyCuaHangVanPhongPham.Forms
{
    partial class ucNhaCungCap
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
            txtDiaChi = new TextBox();
            lblDiaChi = new Label();
            txtDienThoai = new TextBox();
            lblDienThoai = new Label();
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtTenNCC = new TextBox();
            lblTenNCC = new Label();
            txtMaNCC = new TextBox();
            lblMaNCC = new Label();
            lblTitle = new Label();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            dgvNhaCungCap = new DataGridView();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(txtTimKiem);
            pnlTop.Controls.Add(lblTimKiem);
            pnlTop.Controls.Add(txtDiaChi);
            pnlTop.Controls.Add(lblDiaChi);
            pnlTop.Controls.Add(txtDienThoai);
            pnlTop.Controls.Add(lblDienThoai);
            pnlTop.Controls.Add(btnHuy);
            pnlTop.Controls.Add(btnLuu);
            pnlTop.Controls.Add(btnXoa);
            pnlTop.Controls.Add(btnSua);
            pnlTop.Controls.Add(btnThem);
            pnlTop.Controls.Add(txtTenNCC);
            pnlTop.Controls.Add(lblTenNCC);
            pnlTop.Controls.Add(txtMaNCC);
            pnlTop.Controls.Add(lblMaNCC);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(950, 230);
            pnlTop.TabIndex = 0;
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
            btnHuy.BackColor = Color.FromArgb(149, 165, 166);
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatAppearance.MouseDownBackColor = Color.FromArgb(127, 140, 141);
            btnHuy.FlatAppearance.MouseOverBackColor = Color.FromArgb(189, 195, 199);
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(540, 170);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(90, 40);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "✖ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(46, 204, 113);
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatAppearance.MouseDownBackColor = Color.FromArgb(39, 174, 96);
            btnLuu.FlatAppearance.MouseOverBackColor = Color.FromArgb(88, 214, 141);
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(430, 170);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(90, 40);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 57, 43);
            btnXoa.FlatAppearance.MouseOverBackColor = Color.FromArgb(236, 112, 99);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(320, 170);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 40);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "🗑 Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(241, 196, 15);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatAppearance.MouseDownBackColor = Color.FromArgb(212, 172, 13);
            btnSua.FlatAppearance.MouseOverBackColor = Color.FromArgb(247, 220, 111);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(210, 170);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 40);
            btnSua.TabIndex = 6;
            btnSua.Text = "✎ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(52, 152, 219);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 128, 185);
            btnThem.FlatAppearance.MouseOverBackColor = Color.FromArgb(93, 173, 226);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(100, 170);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 40);
            btnThem.TabIndex = 5;
            btnThem.Text = "✚ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtTenNCC
            // 
            txtTenNCC.Font = new Font("Segoe UI", 10F);
            txtTenNCC.Location = new Point(420, 70);
            txtTenNCC.Name = "txtTenNCC";
            txtTenNCC.Size = new Size(300, 30);
            txtTenNCC.TabIndex = 4;
            // 
            // lblTenNCC
            // 
            lblTenNCC.AutoSize = true;
            lblTenNCC.Font = new Font("Segoe UI", 10F);
            lblTenNCC.Location = new Point(340, 73);
            lblTenNCC.Name = "lblTenNCC";
            lblTenNCC.Size = new Size(80, 23);
            lblTenNCC.TabIndex = 3;
            lblTenNCC.Text = "Tên NCC:";
            // 
            // txtMaNCC
            // 
            txtMaNCC.Font = new Font("Segoe UI", 10F);
            txtMaNCC.Location = new Point(130, 70);
            txtMaNCC.Name = "txtMaNCC";
            txtMaNCC.ReadOnly = true;
            txtMaNCC.Size = new Size(180, 30);
            txtMaNCC.TabIndex = 2;
            // 
            // lblMaNCC
            // 
            lblMaNCC.AutoSize = true;
            lblMaNCC.Font = new Font("Segoe UI", 10F);
            lblMaNCC.Location = new Point(50, 73);
            lblMaNCC.Name = "lblMaNCC";
            lblMaNCC.Size = new Size(78, 23);
            lblMaNCC.TabIndex = 1;
            lblMaNCC.Text = "Mã NCC:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(308, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(620, 15);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(280, 30);
            txtTimKiem.TabIndex = 14;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTimKiem.Location = new Point(520, 18);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(91, 23);
            lblTimKiem.TabIndex = 15;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // dgvNhaCungCap
            // 
            dgvNhaCungCap.AllowUserToAddRows = false;
            dgvNhaCungCap.AllowUserToDeleteRows = false;
            dgvNhaCungCap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhaCungCap.BackgroundColor = Color.White;
            dgvNhaCungCap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhaCungCap.Dock = DockStyle.Fill;
            dgvNhaCungCap.Location = new Point(0, 230);
            dgvNhaCungCap.Name = "dgvNhaCungCap";
            dgvNhaCungCap.ReadOnly = true;
            dgvNhaCungCap.RowHeadersWidth = 51;
            dgvNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhaCungCap.Size = new Size(950, 470);
            dgvNhaCungCap.TabIndex = 1;
            dgvNhaCungCap.CellClick += dgvNhaCungCap_CellClick;
            // 
            // ucNhaCungCap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvNhaCungCap);
            Controls.Add(pnlTop);
            Name = "ucNhaCungCap";
            Size = new Size(950, 700);
            Load += ucNhaCungCap_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtMaNCC;
        private System.Windows.Forms.Label lblMaNCC;
        private System.Windows.Forms.TextBox txtTenNCC;
        private System.Windows.Forms.Label lblTenNCC;
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
        private System.Windows.Forms.DataGridView dgvNhaCungCap;
    }
}