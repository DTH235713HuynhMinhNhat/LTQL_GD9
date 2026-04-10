namespace QuanLyCuaHangVanPhongPham.Forms
{
    partial class ucLichSuNhapKho
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
            pnlTop = new Panel();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            btnTimKiem = new Button();
            btnXuatExcel = new Button();
            dtpDenNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblTuNgay = new Label();
            lblTitle = new Label();
            splitContainer1 = new SplitContainer();
            grpDanhSach = new GroupBox();
            dgvPhieuNhap = new DataGridView();
            grpChiTiet = new GroupBox();
            dgvChiTiet = new DataGridView();
            pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuNhap).BeginInit();
            grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.White;
            pnlTop.Controls.Add(txtTimKiem);
            pnlTop.Controls.Add(lblTimKiem);
            pnlTop.Controls.Add(btnTimKiem);
            pnlTop.Controls.Add(btnXuatExcel);
            pnlTop.Controls.Add(dtpDenNgay);
            pnlTop.Controls.Add(lblDenNgay);
            pnlTop.Controls.Add(dtpTuNgay);
            pnlTop.Controls.Add(lblTuNgay);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(950, 100);
            pnlTop.TabIndex = 0;
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(340, 58);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(370, 30);
            txtTimKiem.TabIndex = 6;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            lblTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTimKiem.Location = new Point(260, 61);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(58, 23);
            lblTimKiem.TabIndex = 7;
            lblTimKiem.Text = "Nhập:";
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.FromArgb(52, 152, 219);
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 128, 185);
            btnTimKiem.FlatAppearance.MouseOverBackColor = Color.FromArgb(93, 173, 226);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(740, 57);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(120, 32);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatExcel.BackColor = Color.FromArgb(39, 174, 96);
            btnXuatExcel.FlatAppearance.BorderSize = 0;
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(871, 56);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(75, 32);
            btnXuatExcel.TabIndex = 8;
            btnXuatExcel.Text = "📊 Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            dtpDenNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpDenNgay.Font = new Font("Segoe UI", 10F);
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(580, 26);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(130, 30);
            dtpDenNgay.TabIndex = 4;
            lblDenNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDenNgay.AutoSize = true;
            lblDenNgay.Font = new Font("Segoe UI", 10F);
            lblDenNgay.Location = new Point(490, 30);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(87, 23);
            lblDenNgay.TabIndex = 3;
            lblDenNgay.Text = "Đến ngày:";
            dtpTuNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpTuNgay.Font = new Font("Segoe UI", 10F);
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(340, 27);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(130, 30);
            dtpTuNgay.TabIndex = 2;
            lblTuNgay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTuNgay.AutoSize = true;
            lblTuNgay.Font = new Font("Segoe UI", 10F);
            lblTuNgay.Location = new Point(260, 30);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(75, 23);
            lblTuNgay.TabIndex = 1;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(241, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "LỊCH SỬ NHẬP KHO";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 100);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(grpDanhSach);
            splitContainer1.Panel1.Padding = new Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(grpChiTiet);
            splitContainer1.Panel2.Padding = new Padding(10);
            splitContainer1.Size = new Size(950, 600);
            splitContainer1.SplitterDistance = 290;
            splitContainer1.TabIndex = 1;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Controls.Add(dgvPhieuNhap);
            grpDanhSach.Dock = DockStyle.Fill;
            grpDanhSach.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpDanhSach.Location = new Point(10, 10);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(930, 270);
            grpDanhSach.TabIndex = 0;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách Phiếu Nhập";
            // 
            // dgvPhieuNhap
            // 
            dgvPhieuNhap.AllowUserToAddRows = false;
            dgvPhieuNhap.AllowUserToDeleteRows = false;
            dgvPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuNhap.BackgroundColor = Color.White;
            dgvPhieuNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieuNhap.Dock = DockStyle.Fill;
            dgvPhieuNhap.Font = new Font("Segoe UI", 10F);
            dgvPhieuNhap.Location = new Point(3, 26);
            dgvPhieuNhap.Name = "dgvPhieuNhap";
            dgvPhieuNhap.ReadOnly = true;
            dgvPhieuNhap.RowHeadersWidth = 51;
            dgvPhieuNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhieuNhap.Size = new Size(924, 241);
            dgvPhieuNhap.TabIndex = 0;
            dgvPhieuNhap.SelectionChanged += dgvPhieuNhap_SelectionChanged;
            // 
            // grpChiTiet
            // 
            grpChiTiet.Controls.Add(dgvChiTiet);
            grpChiTiet.Dock = DockStyle.Fill;
            grpChiTiet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpChiTiet.Location = new Point(10, 10);
            grpChiTiet.Name = "grpChiTiet";
            grpChiTiet.Size = new Size(930, 286);
            grpChiTiet.TabIndex = 0;
            grpChiTiet.TabStop = false;
            grpChiTiet.Text = "Chi tiết Phiếu Nhập được chọn";
            // 
            // dgvChiTiet
            // 
            dgvChiTiet.AllowUserToAddRows = false;
            dgvChiTiet.AllowUserToDeleteRows = false;
            dgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTiet.BackgroundColor = Color.White;
            dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTiet.Dock = DockStyle.Fill;
            dgvChiTiet.Font = new Font("Segoe UI", 10F);
            dgvChiTiet.Location = new Point(3, 26);
            dgvChiTiet.Name = "dgvChiTiet";
            dgvChiTiet.ReadOnly = true;
            dgvChiTiet.RowHeadersWidth = 51;
            dgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTiet.Size = new Size(924, 257);
            dgvChiTiet.TabIndex = 1;
            // 
            // ucLichSuNhapKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            Controls.Add(splitContainer1);
            Controls.Add(pnlTop);
            Name = "ucLichSuNhapKho";
            Size = new Size(950, 700);
            Load += ucLichSuNhapKho_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPhieuNhap).EndInit();
            grpChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTiet).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.DataGridView dgvPhieuNhap;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Button btnXuatExcel;
    }
}