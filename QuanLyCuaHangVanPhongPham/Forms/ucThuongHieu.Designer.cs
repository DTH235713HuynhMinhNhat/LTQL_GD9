namespace QuanLyCuaHangVanPhongPham.Forms
{
    partial class ucThuongHieu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlTop = new System.Windows.Forms.Panel();
            btnHuy = new System.Windows.Forms.Button();
            btnLuu = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            btnSua = new System.Windows.Forms.Button();
            btnThem = new System.Windows.Forms.Button();
            txtTenThuongHieu = new System.Windows.Forms.TextBox();
            lblTenThuongHieu = new System.Windows.Forms.Label();
            txtMaThuongHieu = new System.Windows.Forms.TextBox();
            lblMaThuongHieu = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            dgvThuongHieu = new System.Windows.Forms.DataGridView();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvThuongHieu).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = System.Drawing.Color.White;
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
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new System.Drawing.Size(950, 200);
            pnlTop.TabIndex = 0;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnHuy.FlatAppearance.BorderSize = 0;
            btnHuy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            btnHuy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHuy.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnHuy.ForeColor = System.Drawing.Color.White;
            btnHuy.Location = new System.Drawing.Point(540, 130);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new System.Drawing.Size(90, 40);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "✖ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnLuu.FlatAppearance.BorderSize = 0;
            btnLuu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(88, 214, 141);
            btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnLuu.ForeColor = System.Drawing.Color.White;
            btnLuu.Location = new System.Drawing.Point(430, 130);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new System.Drawing.Size(90, 40);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            btnXoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(236, 112, 99);
            btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnXoa.ForeColor = System.Drawing.Color.White;
            btnXoa.Location = new System.Drawing.Point(320, 130);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(90, 40);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "🗑 Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(212, 172, 13);
            btnSua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(247, 220, 111);
            btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSua.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnSua.ForeColor = System.Drawing.Color.White;
            btnSua.Location = new System.Drawing.Point(210, 130);
            btnSua.Name = "btnSua";
            btnSua.Size = new System.Drawing.Size(90, 40);
            btnSua.TabIndex = 6;
            btnSua.Text = "✎ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(93, 173, 226);
            btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnThem.ForeColor = System.Drawing.Color.White;
            btnThem.Location = new System.Drawing.Point(100, 130);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(90, 40);
            btnThem.TabIndex = 5;
            btnThem.Text = "✚ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtTenThuongHieu
            // 
            txtTenThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtTenThuongHieu.Location = new System.Drawing.Point(420, 70);
            txtTenThuongHieu.Name = "txtTenThuongHieu";
            txtTenThuongHieu.Size = new System.Drawing.Size(300, 30);
            txtTenThuongHieu.TabIndex = 4;
            // 
            // lblTenThuongHieu
            // 
            lblTenThuongHieu.AutoSize = true;
            lblTenThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTenThuongHieu.Location = new System.Drawing.Point(280, 73);
            lblTenThuongHieu.Name = "lblTenThuongHieu";
            lblTenThuongHieu.Size = new System.Drawing.Size(139, 23);
            lblTenThuongHieu.TabIndex = 3;
            lblTenThuongHieu.Text = "Tên thương hiệu:";
            // 
            // txtMaThuongHieu
            // 
            txtMaThuongHieu.Enabled = false;
            txtMaThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtMaThuongHieu.Location = new System.Drawing.Point(130, 70);
            txtMaThuongHieu.Name = "txtMaThuongHieu";
            txtMaThuongHieu.ReadOnly = true;
            txtMaThuongHieu.Size = new System.Drawing.Size(120, 30);
            txtMaThuongHieu.TabIndex = 2;
            // 
            // lblMaThuongHieu
            // 
            lblMaThuongHieu.AutoSize = true;
            lblMaThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblMaThuongHieu.Location = new System.Drawing.Point(50, 73);
            lblMaThuongHieu.Name = "lblMaThuongHieu";
            lblMaThuongHieu.Size = new System.Drawing.Size(64, 23);
            lblMaThuongHieu.TabIndex = 1;
            lblMaThuongHieu.Text = "Mã TH:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(294, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ THƯƠNG HIỆU";
            // 
            // dgvThuongHieu
            // 
            dgvThuongHieu.AllowUserToAddRows = false;
            dgvThuongHieu.AllowUserToDeleteRows = false;
            dgvThuongHieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvThuongHieu.BackgroundColor = System.Drawing.Color.White;
            dgvThuongHieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvThuongHieu.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvThuongHieu.Location = new System.Drawing.Point(0, 200);
            dgvThuongHieu.Name = "dgvThuongHieu";
            dgvThuongHieu.ReadOnly = true;
            dgvThuongHieu.RowHeadersWidth = 51;
            dgvThuongHieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvThuongHieu.Size = new System.Drawing.Size(950, 500);
            dgvThuongHieu.TabIndex = 1;
            dgvThuongHieu.CellClick += dgvThuongHieu_CellClick;
            // 
            // ucThuongHieu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(dgvThuongHieu);
            Controls.Add(pnlTop);
            Name = "ucThuongHieu";
            Size = new System.Drawing.Size(950, 700);
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