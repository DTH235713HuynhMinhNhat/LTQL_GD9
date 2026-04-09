namespace QuanLyCuaHangVanPhongPham.Forms
{
    partial class ucBanHang
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlLeft = new Panel();
            dgvSanPham = new DataGridView();
            pnlLeftBottom = new Panel();
            btnThemVaoGio = new Button();
            pnlLeftTop = new Panel();
            cboLoaiSP = new ComboBox();
            lblLoaiSP = new Label();
            txtTimKiem = new TextBox();
            lblTitleLeft = new Label();
            pnlRight = new Panel();
            dgvGioHang = new DataGridView();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colSoLuong = new DataGridViewTextBoxColumn();
            colDonGia = new DataGridViewTextBoxColumn();
            colThanhTien = new DataGridViewTextBoxColumn();
            pnlRightBottom = new Panel();
            btnXoaKhaiGio = new Button();
            btnThanhToan = new Button();
            lblTongTienValue = new Label();
            lblTongTienText = new Label();
            pnlRightTop = new Panel();
            cboKhachHang = new ComboBox();
            label1 = new Label();
            lblTitleRight = new Label();
            nudQuantityAdd = new NumericUpDown();
            lblSoLuong = new Label();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            pnlLeftBottom.SuspendLayout();
            pnlLeftTop.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            pnlRightBottom.SuspendLayout();
            pnlRightTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantityAdd).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(dgvSanPham);
            pnlLeft.Controls.Add(pnlLeftBottom);
            pnlLeft.Controls.Add(pnlLeftTop);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(450, 580);
            pnlLeft.TabIndex = 0;
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.BackgroundColor = Color.White;
            dgvSanPham.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSanPham.ColumnHeadersHeight = 40;
            dgvSanPham.Dock = DockStyle.Fill;
            dgvSanPham.EnableHeadersVisualStyles = false;
            dgvSanPham.Location = new Point(0, 100);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(226, 234, 253);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvSanPham.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvSanPham.RowTemplate.Height = 35;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(448, 378);
            dgvSanPham.TabIndex = 1;
            // 
            // pnlLeftBottom
            // 
            pnlLeftBottom.BackColor = Color.WhiteSmoke;
            pnlLeftBottom.BorderStyle = BorderStyle.FixedSingle;
            pnlLeftBottom.Controls.Add(btnThemVaoGio);
            pnlLeftBottom.Dock = DockStyle.Bottom;
            pnlLeftBottom.Location = new Point(0, 478);
            pnlLeftBottom.Name = "pnlLeftBottom";
            pnlLeftBottom.Size = new Size(448, 100);
            pnlLeftBottom.TabIndex = 2;
            // 
            // btnThemVaoGio
            // 
            btnThemVaoGio.BackColor = Color.FromArgb(52, 152, 219);
            btnThemVaoGio.FlatStyle = FlatStyle.Flat;
            btnThemVaoGio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemVaoGio.ForeColor = Color.White;
            btnThemVaoGio.Location = new Point(230, 45);
            btnThemVaoGio.Name = "btnThemVaoGio";
            btnThemVaoGio.Size = new Size(180, 40);
            btnThemVaoGio.TabIndex = 0;
            btnThemVaoGio.Text = "THÊM VÀO GIỎ";
            btnThemVaoGio.UseVisualStyleBackColor = false;
            btnThemVaoGio.Click += btnThemVaoGio_Click_1;
            // 
            // pnlLeftTop
            // 
            pnlLeftTop.BackColor = Color.White;
            pnlLeftTop.Controls.Add(cboLoaiSP);
            pnlLeftTop.Controls.Add(lblLoaiSP);
            pnlLeftTop.Controls.Add(txtTimKiem);
            pnlLeftTop.Controls.Add(lblTitleLeft);
            pnlLeftTop.Dock = DockStyle.Top;
            pnlLeftTop.Location = new Point(0, 0);
            pnlLeftTop.Name = "pnlLeftTop";
            pnlLeftTop.Size = new Size(448, 100);
            pnlLeftTop.TabIndex = 0;
            // 
            // cboLoaiSP
            // 
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Location = new Point(210, 56);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(220, 31);
            cboLoaiSP.TabIndex = 3;
            // 
            // lblLoaiSP
            // 
            lblLoaiSP.AutoSize = true;
            lblLoaiSP.Location = new Point(110, 60);
            lblLoaiSP.Name = "lblLoaiSP";
            lblLoaiSP.Size = new Size(93, 23);
            lblLoaiSP.TabIndex = 4;
            lblLoaiSP.Text = "Danh mục:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(170, 16);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm theo tên sản phẩm...";
            txtTimKiem.Size = new Size(260, 30);
            txtTimKiem.TabIndex = 1;
            // 
            // lblTitleLeft
            // 
            lblTitleLeft.AutoSize = true;
            lblTitleLeft.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitleLeft.Location = new Point(10, 16);
            lblTitleLeft.Name = "lblTitleLeft";
            lblTitleLeft.Size = new Size(119, 28);
            lblTitleLeft.TabIndex = 2;
            lblTitleLeft.Text = "SẢN PHẨM";
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(dgvGioHang);
            pnlRight.Controls.Add(pnlRightBottom);
            pnlRight.Controls.Add(pnlRightTop);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(450, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(460, 580);
            pnlRight.TabIndex = 1;
            // 
            // dgvGioHang
            // 
            dgvGioHang.AllowUserToAddRows = false;
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGioHang.BackgroundColor = Color.White;
            dgvGioHang.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(155, 89, 182);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(155, 89, 182);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dgvGioHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvGioHang.ColumnHeadersHeight = 40;
            dgvGioHang.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colTenSP, colSoLuong, colDonGia, colThanhTien });
            dgvGioHang.Dock = DockStyle.Fill;
            dgvGioHang.EnableHeadersVisualStyles = false;
            dgvGioHang.Location = new Point(0, 60);
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.RowHeadersVisible = false;
            dgvGioHang.RowHeadersWidth = 51;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(226, 234, 253);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dgvGioHang.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvGioHang.RowTemplate.Height = 35;
            dgvGioHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGioHang.Size = new Size(460, 370);
            dgvGioHang.TabIndex = 1;
            // 
            // colMaSP
            // 
            colMaSP.HeaderText = "Mã SP";
            colMaSP.MinimumWidth = 6;
            colMaSP.Name = "colMaSP";
            colMaSP.ReadOnly = true;
            colMaSP.Visible = false;
            // 
            // colTenSP
            // 
            colTenSP.HeaderText = "Tên SP";
            colTenSP.MinimumWidth = 6;
            colTenSP.Name = "colTenSP";
            colTenSP.ReadOnly = true;
            // 
            // colSoLuong
            // 
            colSoLuong.HeaderText = "SL";
            colSoLuong.MinimumWidth = 6;
            colSoLuong.Name = "colSoLuong";
            colSoLuong.ReadOnly = true;
            // 
            // colDonGia
            // 
            colDonGia.HeaderText = "Đơn giá";
            colDonGia.MinimumWidth = 6;
            colDonGia.Name = "colDonGia";
            colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            colThanhTien.HeaderText = "Thành tiền";
            colThanhTien.MinimumWidth = 6;
            colThanhTien.Name = "colThanhTien";
            colThanhTien.ReadOnly = true;
            // 
            // pnlRightBottom
            // 
            pnlRightBottom.BackColor = Color.WhiteSmoke;
            pnlRightBottom.BorderStyle = BorderStyle.FixedSingle;
            pnlRightBottom.Controls.Add(btnXoaKhaiGio);
            pnlRightBottom.Controls.Add(btnThanhToan);
            pnlRightBottom.Controls.Add(lblTongTienValue);
            pnlRightBottom.Controls.Add(lblTongTienText);
            pnlRightBottom.Dock = DockStyle.Bottom;
            pnlRightBottom.Location = new Point(0, 430);
            pnlRightBottom.Name = "pnlRightBottom";
            pnlRightBottom.Size = new Size(460, 150);
            pnlRightBottom.TabIndex = 2;
            // 
            // btnXoaKhaiGio
            // 
            btnXoaKhaiGio.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnXoaKhaiGio.BackColor = Color.FromArgb(231, 76, 60);
            btnXoaKhaiGio.FlatStyle = FlatStyle.Flat;
            btnXoaKhaiGio.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoaKhaiGio.ForeColor = Color.White;
            btnXoaKhaiGio.Location = new Point(20, 90);
            btnXoaKhaiGio.Name = "btnXoaKhaiGio";
            btnXoaKhaiGio.Size = new Size(120, 40);
            btnXoaKhaiGio.TabIndex = 0;
            btnXoaKhaiGio.Text = "Bỏ SP";
            btnXoaKhaiGio.UseVisualStyleBackColor = false;
            btnXoaKhaiGio.Click += btnXoaKhaiGio_Click_1;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThanhToan.BackColor = Color.FromArgb(46, 204, 113);
            btnThanhToan.FlatStyle = FlatStyle.Flat;
            btnThanhToan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnThanhToan.ForeColor = Color.White;
            btnThanhToan.Location = new Point(260, 80);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(180, 50);
            btnThanhToan.TabIndex = 1;
            btnThanhToan.Text = "THANH TOÁN";
            btnThanhToan.UseVisualStyleBackColor = false;
            btnThanhToan.Click += btnThanhToan_Click_1;
            // 
            // lblTongTienValue
            // 
            lblTongTienValue.AutoSize = true;
            lblTongTienValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTongTienValue.ForeColor = Color.FromArgb(231, 76, 60);
            lblTongTienValue.Location = new Point(160, 10);
            lblTongTienValue.Name = "lblTongTienValue";
            lblTongTienValue.Size = new Size(109, 41);
            lblTongTienValue.TabIndex = 2;
            lblTongTienValue.Text = "0 VNĐ";
            // 
            // lblTongTienText
            // 
            lblTongTienText.AutoSize = true;
            lblTongTienText.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTienText.Location = new Point(20, 20);
            lblTongTienText.Name = "lblTongTienText";
            lblTongTienText.Size = new Size(125, 28);
            lblTongTienText.TabIndex = 3;
            lblTongTienText.Text = "TỔNG TIỀN:";
            // 
            // pnlRightTop
            // 
            pnlRightTop.BackColor = Color.White;
            pnlRightTop.BorderStyle = BorderStyle.FixedSingle;
            pnlRightTop.Controls.Add(cboKhachHang);
            pnlRightTop.Controls.Add(label1);
            pnlRightTop.Controls.Add(lblTitleRight);
            pnlRightTop.Dock = DockStyle.Top;
            pnlRightTop.Location = new Point(0, 0);
            pnlRightTop.Name = "pnlRightTop";
            pnlRightTop.Size = new Size(460, 60);
            pnlRightTop.TabIndex = 0;
            // 
            // cboKhachHang
            // 
            cboKhachHang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboKhachHang.FormattingEnabled = true;
            cboKhachHang.Location = new Point(227, 14);
            cboKhachHang.Name = "cboKhachHang";
            cboKhachHang.Size = new Size(183, 31);
            cboKhachHang.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(160, 19);
            label1.Name = "label1";
            label1.Size = new Size(61, 23);
            label1.TabIndex = 3;
            label1.Text = "Khách:";
            // 
            // lblTitleRight
            // 
            lblTitleRight.AutoSize = true;
            lblTitleRight.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitleRight.Location = new Point(10, 16);
            lblTitleRight.Name = "lblTitleRight";
            lblTitleRight.Size = new Size(112, 28);
            lblTitleRight.TabIndex = 4;
            lblTitleRight.Text = "GIỎ HÀNG";
            // 
            // nudQuantityAdd
            // 
            nudQuantityAdd.Location = new Point(40, 50);
            nudQuantityAdd.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantityAdd.Name = "nudQuantityAdd";
            nudQuantityAdd.Size = new Size(120, 27);
            nudQuantityAdd.TabIndex = 1;
            nudQuantityAdd.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(40, 20);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(82, 23);
            lblSoLuong.TabIndex = 2;
            lblSoLuong.Text = "Số lượng:";
            // 
            // ucBanHang
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Font = new Font("Segoe UI", 10.2F);
            Name = "ucBanHang";
            Size = new Size(910, 580);
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            pnlLeftBottom.ResumeLayout(false);
            pnlLeftTop.ResumeLayout(false);
            pnlLeftTop.PerformLayout();
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            pnlRightBottom.ResumeLayout(false);
            pnlRightBottom.PerformLayout();
            pnlRightTop.ResumeLayout(false);
            pnlRightTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantityAdd).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private Panel pnlLeftTop;
        private Label lblTitleLeft;
        private TextBox txtTimKiem;
        private DataGridView dgvSanPham;

        private Panel pnlLeftBottom;
        private Button btnThemVaoGio;

        private Panel pnlRight;
        private Panel pnlRightTop;
        private Label lblTitleRight;

        private ComboBox cboKhachHang;
        private Label label1;

        private DataGridView dgvGioHang;

        private Panel pnlRightBottom;
        private Label lblTongTienText;
        private Label lblTongTienValue;
        private Button btnThanhToan;
        private Button btnXoaKhaiGio;

        // Trả lại 5 cột sạch sẽ
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colThanhTien;
        private ComboBox cboLoaiSP;
        private Label lblLoaiSP;
        private NumericUpDown nudQuantityAdd;
        private Label lblSoLuong;
    }
}