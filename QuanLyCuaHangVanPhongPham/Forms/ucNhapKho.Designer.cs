namespace QuanLyCuaHangVanPhongPham.Forms
{
    partial class ucNhapKho
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
            pnlHeader = new Panel();
            cboNhaCungCap = new ComboBox();
            lblNCC = new Label();
            dtpNgayNhap = new DateTimePicker();
            lblNgayNhap = new Label();
            txtMaPN = new TextBox();
            lblMaPN = new Label();
            lblTitle = new Label();
            pnlDetailInput = new Panel();
            btnXoaSP = new Button();
            btnThemSP = new Button();
            txtGiaNhap = new TextBox();
            lblGiaNhap = new Label();
            txtSoLuong = new TextBox();
            lblSoLuong = new Label();
            cboSanPham = new ComboBox();
            lblSanPham = new Label();
            pnlFooter = new Panel();
            lblTongTien = new Label();
            txtTongTien = new TextBox();
            btnHuyPhieu = new Button();
            btnLuuPhieu = new Button();
            dgvChiTietNhap = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlDetailInput.SuspendLayout();
            pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(cboNhaCungCap);
            pnlHeader.Controls.Add(lblNCC);
            pnlHeader.Controls.Add(dtpNgayNhap);
            pnlHeader.Controls.Add(lblNgayNhap);
            pnlHeader.Controls.Add(txtMaPN);
            pnlHeader.Controls.Add(lblMaPN);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(950, 120);
            pnlHeader.TabIndex = 0;
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhaCungCap.Font = new Font("Segoe UI", 10F);
            cboNhaCungCap.FormattingEnabled = true;
            cboNhaCungCap.Location = new Point(620, 65);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(250, 31);
            cboNhaCungCap.TabIndex = 6;
            // 
            // lblNCC
            // 
            lblNCC.AutoSize = true;
            lblNCC.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNCC.Location = new Point(490, 68);
            lblNCC.Name = "lblNCC";
            lblNCC.Size = new Size(124, 23);
            lblNCC.TabIndex = 5;
            lblNCC.Text = "Nhà cung cấp:";
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Font = new Font("Segoe UI", 10F);
            dtpNgayNhap.Format = DateTimePickerFormat.Short;
            dtpNgayNhap.Location = new Point(330, 65);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(140, 30);
            dtpNgayNhap.TabIndex = 4;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNgayNhap.Location = new Point(220, 68);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(102, 23);
            lblNgayNhap.TabIndex = 3;
            lblNgayNhap.Text = "Ngày nhập:";
            // 
            // txtMaPN
            // 
            txtMaPN.Font = new Font("Segoe UI", 10F);
            txtMaPN.Location = new Point(80, 65);
            txtMaPN.Name = "txtMaPN";
            txtMaPN.ReadOnly = true;
            txtMaPN.Size = new Size(120, 30);
            txtMaPN.TabIndex = 2;
            // 
            // lblMaPN
            // 
            lblMaPN.AutoSize = true;
            lblMaPN.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaPN.Location = new Point(20, 68);
            lblMaPN.Name = "lblMaPN";
            lblMaPN.Size = new Size(68, 23);
            lblMaPN.TabIndex = 1;
            lblMaPN.Text = "Mã PN:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(277, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "NHẬP HÀNG VÀO KHO";
            // 
            // pnlDetailInput
            // 
            pnlDetailInput.BackColor = Color.FromArgb(236, 240, 241);
            pnlDetailInput.Controls.Add(btnXoaSP);
            pnlDetailInput.Controls.Add(btnThemSP);
            pnlDetailInput.Controls.Add(txtGiaNhap);
            pnlDetailInput.Controls.Add(lblGiaNhap);
            pnlDetailInput.Controls.Add(txtSoLuong);
            pnlDetailInput.Controls.Add(lblSoLuong);
            pnlDetailInput.Controls.Add(cboSanPham);
            pnlDetailInput.Controls.Add(lblSanPham);
            pnlDetailInput.Dock = DockStyle.Top;
            pnlDetailInput.Location = new Point(0, 120);
            pnlDetailInput.Name = "pnlDetailInput";
            pnlDetailInput.Size = new Size(950, 80);
            pnlDetailInput.TabIndex = 1;
            // 
            // btnXoaSP
            // 
            btnXoaSP.BackColor = Color.FromArgb(231, 76, 60);
            btnXoaSP.FlatAppearance.BorderSize = 0;
            btnXoaSP.FlatStyle = FlatStyle.Flat;
            btnXoaSP.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoaSP.ForeColor = Color.White;
            btnXoaSP.Location = new Point(810, 23);
            btnXoaSP.Name = "btnXoaSP";
            btnXoaSP.Size = new Size(88, 35);
            btnXoaSP.TabIndex = 13;
            btnXoaSP.Text = "Xóa SP";
            btnXoaSP.UseVisualStyleBackColor = false;
            btnXoaSP.Click += btnXoaSP_Click;
            // 
            // btnThemSP
            // 
            btnThemSP.BackColor = Color.FromArgb(52, 152, 219);
            btnThemSP.FlatAppearance.BorderSize = 0;
            btnThemSP.FlatStyle = FlatStyle.Flat;
            btnThemSP.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThemSP.ForeColor = Color.White;
            btnThemSP.Location = new Point(710, 23);
            btnThemSP.Name = "btnThemSP";
            btnThemSP.Size = new Size(88, 35);
            btnThemSP.TabIndex = 12;
            btnThemSP.Text = "Thêm SP";
            btnThemSP.UseVisualStyleBackColor = false;
            btnThemSP.Click += btnThemSP_Click;
            // 
            // txtGiaNhap
            // 
            txtGiaNhap.Font = new Font("Segoe UI", 10F);
            txtGiaNhap.Location = new Point(570, 25);
            txtGiaNhap.Name = "txtGiaNhap";
            txtGiaNhap.Size = new Size(120, 30);
            txtGiaNhap.TabIndex = 11;
            // 
            // lblGiaNhap
            // 
            lblGiaNhap.AutoSize = true;
            lblGiaNhap.Font = new Font("Segoe UI", 10F);
            lblGiaNhap.Location = new Point(490, 28);
            lblGiaNhap.Name = "lblGiaNhap";
            lblGiaNhap.Size = new Size(83, 23);
            lblGiaNhap.TabIndex = 10;
            lblGiaNhap.Text = "Giá nhập:";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Font = new Font("Segoe UI", 10F);
            txtSoLuong.Location = new Point(390, 25);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(80, 30);
            txtSoLuong.TabIndex = 9;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Segoe UI", 10F);
            lblSoLuong.Location = new Point(310, 28);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(82, 23);
            lblSoLuong.TabIndex = 8;
            lblSoLuong.Text = "Số lượng:";
            // 
            // cboSanPham
            // 
            cboSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanPham.Font = new Font("Segoe UI", 10F);
            cboSanPham.FormattingEnabled = true;
            cboSanPham.Location = new Point(100, 25);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(190, 31);
            cboSanPham.TabIndex = 7;
            // 
            // lblSanPham
            // 
            lblSanPham.AutoSize = true;
            lblSanPham.Font = new Font("Segoe UI", 10F);
            lblSanPham.Location = new Point(15, 28);
            lblSanPham.Name = "lblSanPham";
            lblSanPham.Size = new Size(91, 23);
            lblSanPham.TabIndex = 6;
            lblSanPham.Text = "Sản phẩm:";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.White;
            pnlFooter.Controls.Add(lblTongTien);
            pnlFooter.Controls.Add(txtTongTien);
            pnlFooter.Controls.Add(btnHuyPhieu);
            pnlFooter.Controls.Add(btnLuuPhieu);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 620);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(950, 80);
            pnlFooter.TabIndex = 2;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.FromArgb(192, 57, 43);
            lblTongTien.Location = new Point(20, 25);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(108, 28);
            lblTongTien.TabIndex = 12;
            lblTongTien.Text = "Tổng tiền:";
            // 
            // txtTongTien
            // 
            txtTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtTongTien.ForeColor = Color.FromArgb(192, 57, 43);
            txtTongTien.Location = new Point(130, 22);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.ReadOnly = true;
            txtTongTien.Size = new Size(200, 34);
            txtTongTien.TabIndex = 13;
            txtTongTien.Text = "0";
            txtTongTien.TextAlign = HorizontalAlignment.Right;
            // 
            // btnHuyPhieu
            // 
            btnHuyPhieu.BackColor = Color.Gray;
            btnHuyPhieu.FlatAppearance.BorderSize = 0;
            btnHuyPhieu.FlatStyle = FlatStyle.Flat;
            btnHuyPhieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuyPhieu.ForeColor = Color.White;
            btnHuyPhieu.Location = new Point(788, 21);
            btnHuyPhieu.Name = "btnHuyPhieu";
            btnHuyPhieu.Size = new Size(110, 40);
            btnHuyPhieu.TabIndex = 11;
            btnHuyPhieu.Text = "Hủy phiếu";
            btnHuyPhieu.UseVisualStyleBackColor = false;
            btnHuyPhieu.Click += btnHuyPhieu_Click;
            // 
            // btnLuuPhieu
            // 
            btnLuuPhieu.BackColor = Color.FromArgb(46, 204, 113);
            btnLuuPhieu.FlatAppearance.BorderSize = 0;
            btnLuuPhieu.FlatStyle = FlatStyle.Flat;
            btnLuuPhieu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuuPhieu.ForeColor = Color.White;
            btnLuuPhieu.Location = new Point(658, 21);
            btnLuuPhieu.Name = "btnLuuPhieu";
            btnLuuPhieu.Size = new Size(120, 40);
            btnLuuPhieu.TabIndex = 10;
            btnLuuPhieu.Text = "Lưu phiếu";
            btnLuuPhieu.UseVisualStyleBackColor = false;
            btnLuuPhieu.Click += btnLuuPhieu_Click;
            // 
            // dgvChiTietNhap
            // 
            dgvChiTietNhap.AllowUserToAddRows = false;
            dgvChiTietNhap.AllowUserToDeleteRows = false;
            dgvChiTietNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietNhap.BackgroundColor = Color.White;
            dgvChiTietNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietNhap.Dock = DockStyle.Fill;
            dgvChiTietNhap.Location = new Point(0, 200);
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.ReadOnly = true;
            dgvChiTietNhap.RowHeadersWidth = 51;
            dgvChiTietNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietNhap.Size = new Size(950, 420);
            dgvChiTietNhap.TabIndex = 3;
            // 
            // ucNhapKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvChiTietNhap);
            Controls.Add(pnlFooter);
            Controls.Add(pnlDetailInput);
            Controls.Add(pnlHeader);
            Name = "ucNhapKho";
            Size = new Size(950, 700);
            Load += ucNhapKho_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlDetailInput.ResumeLayout(false);
            pnlDetailInput.PerformLayout();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtMaPN;
        private System.Windows.Forms.Label lblMaPN;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label lblNCC;
        private System.Windows.Forms.Panel pnlDetailInput;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label lblGiaNhap;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.Button btnXoaSP;
        private System.Windows.Forms.Button btnThemSP;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.DataGridView dgvChiTietNhap;
        private System.Windows.Forms.Button btnHuyPhieu;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}