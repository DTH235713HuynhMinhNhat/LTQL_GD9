namespace QuanLyCuaHangVanPhongPham.Forms
{
    partial class ucThuongHieu
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
            btnHuy = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            txtTenThuongHieu = new TextBox();
            lblTenThuongHieu = new Label();
            txtMaThuongHieu = new TextBox();
            lblMaThuongHieu = new Label();
            lblTitle = new Label();
            dgvThuongHieu = new DataGridView();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThuongHieu).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(btnHuy);
            pnlTop.Controls.Add(btnLuu);
            pnlTop.Controls.Add(btnXoa);
            pnlTop.Controls.Add(btnSua);
            pnlTop.Controls.Add(btnThem);
            pnlTop.Controls.Add(txtTenThuongHieu);
            pnlTop.Controls.Add(lblTenThuongHieu);
            pnlTop.Controls.Add(txtMaThuongHieu);
            pnlTop.Controls.Add(lblMaThuongHieu);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(950, 200);
            pnlTop.TabIndex = 0;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Gray;
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(540, 130);
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
            btnLuu.Location = new Point(430, 130);
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
            btnXoa.Location = new Point(320, 130);
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
            btnSua.Location = new Point(210, 130);
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
            btnThem.Location = new Point(100, 130);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 40);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtTenThuongHieu
            // 
            txtTenThuongHieu.Font = new Font("Segoe UI", 10F);
            txtTenThuongHieu.Location = new Point(420, 70);
            txtTenThuongHieu.Name = "txtTenThuongHieu";
            txtTenThuongHieu.Size = new Size(300, 30);
            txtTenThuongHieu.TabIndex = 4;
            txtTenThuongHieu.TextChanged += txtTenThuongHieu_TextChanged;
            // 
            // lblTenThuongHieu
            // 
            lblTenThuongHieu.AutoSize = true;
            lblTenThuongHieu.Font = new Font("Segoe UI", 10F);
            lblTenThuongHieu.Location = new Point(280, 73);
            lblTenThuongHieu.Name = "lblTenThuongHieu";
            lblTenThuongHieu.Size = new Size(139, 23);
            lblTenThuongHieu.TabIndex = 3;
            lblTenThuongHieu.Text = "Tên thương hiệu:";
            // 
            // txtMaThuongHieu
            // 
            txtMaThuongHieu.Font = new Font("Segoe UI", 10F);
            txtMaThuongHieu.Location = new Point(130, 70);
            txtMaThuongHieu.Name = "txtMaThuongHieu";
            txtMaThuongHieu.ReadOnly = true;
            txtMaThuongHieu.Size = new Size(120, 30);
            txtMaThuongHieu.TabIndex = 2;
            txtMaThuongHieu.TextChanged += txtMaThuongHieu_TextChanged;
            // 
            // lblMaThuongHieu
            // 
            lblMaThuongHieu.AutoSize = true;
            lblMaThuongHieu.Font = new Font("Segoe UI", 10F);
            lblMaThuongHieu.Location = new Point(50, 73);
            lblMaThuongHieu.Name = "lblMaThuongHieu";
            lblMaThuongHieu.Size = new Size(64, 23);
            lblMaThuongHieu.TabIndex = 1;
            lblMaThuongHieu.Text = "Mã TH:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(294, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ THƯƠNG HIỆU";
            // 
            // dgvThuongHieu
            // 
            dgvThuongHieu.AllowUserToAddRows = false;
            dgvThuongHieu.AllowUserToDeleteRows = false;
            dgvThuongHieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvThuongHieu.BackgroundColor = Color.White;
            dgvThuongHieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThuongHieu.Dock = DockStyle.Fill;
            dgvThuongHieu.Location = new Point(0, 200);
            dgvThuongHieu.Name = "dgvThuongHieu";
            dgvThuongHieu.ReadOnly = true;
            dgvThuongHieu.RowHeadersWidth = 51;
            dgvThuongHieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvThuongHieu.Size = new Size(950, 500);
            dgvThuongHieu.TabIndex = 1;
            dgvThuongHieu.CellClick += dgvThuongHieu_CellClick;
            // 
            // ucThuongHieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvThuongHieu);
            Controls.Add(pnlTop);
            Name = "ucThuongHieu";
            Size = new Size(950, 700);
            Load += ucThuongHieu_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThuongHieu).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtMaThuongHieu;
        private System.Windows.Forms.Label lblMaThuongHieu;
        private System.Windows.Forms.TextBox txtTenThuongHieu;
        private System.Windows.Forms.Label lblTenThuongHieu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvThuongHieu;
    }
}