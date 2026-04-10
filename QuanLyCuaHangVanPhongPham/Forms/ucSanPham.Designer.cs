namespace QuanLyVanPhongPham.Forms
{
    partial class ucSanPham : UserControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblTimKiem = new Label();
            cboLoaiSP = new ComboBox();
            lblLoaiSP = new Label();
            btnXoa = new Button();
            btnSua = new Button();
            btnThemMoi = new Button();
            btnXuatExcel = new Button();
            txtTimKiem = new TextBox();
            lblTitle = new Label();
            dgvSanPham = new DataGridView();
            pnlFooter = new Panel();
            lblTongSanPham = new Label();
            lblTongGiaTri = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblTimKiem);
            pnlHeader.Controls.Add(cboLoaiSP);
            pnlHeader.Controls.Add(lblLoaiSP);
            pnlHeader.Controls.Add(btnXoa);
            pnlHeader.Controls.Add(btnSua);
            pnlHeader.Controls.Add(btnThemMoi);
            pnlHeader.Controls.Add(btnXuatExcel);
            pnlHeader.Controls.Add(txtTimKiem);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(910, 100);
            pnlHeader.TabIndex = 1;
            lblTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTimKiem.Location = new Point(388, 67);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(91, 23);
            lblTimKiem.TabIndex = 18;
            lblTimKiem.Text = "Tìm kiếm:";
            cboLoaiSP.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSP.FormattingEnabled = true;
            cboLoaiSP.Location = new Point(110, 60);
            cboLoaiSP.Name = "cboLoaiSP";
            cboLoaiSP.Size = new Size(220, 31);
            cboLoaiSP.TabIndex = 7;
            cboLoaiSP.SelectedIndexChanged += cboLoaiSP_SelectedIndexChanged;
            lblLoaiSP.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblLoaiSP.AutoSize = true;
            lblLoaiSP.Location = new Point(10, 64);
            lblLoaiSP.Name = "lblLoaiSP";
            lblLoaiSP.Size = new Size(93, 23);
            lblLoaiSP.TabIndex = 6;
            lblLoaiSP.Text = "Danh mục:";
            // 
            // btnXoa
            // 
            btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXoa.BackColor = Color.FromArgb(231, 76, 60);
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 57, 43);
            btnXoa.FlatAppearance.MouseOverBackColor = Color.FromArgb(236, 112, 99);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(793, 10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 40);
            btnXoa.TabIndex = 5;
            btnXoa.Text = "🗑 Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSua.BackColor = Color.FromArgb(241, 196, 15);
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatAppearance.MouseDownBackColor = Color.FromArgb(212, 172, 13);
            btnSua.FlatAppearance.MouseOverBackColor = Color.FromArgb(247, 220, 111);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(683, 10);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 40);
            btnSua.TabIndex = 4;
            btnSua.Text = "✎ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click_1;
            // 
            // btnThemMoi
            // 
            btnThemMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThemMoi.BackColor = Color.FromArgb(52, 152, 219);
            btnThemMoi.FlatAppearance.BorderSize = 0;
            btnThemMoi.FlatAppearance.MouseDownBackColor = Color.FromArgb(41, 128, 185);
            btnThemMoi.FlatAppearance.MouseOverBackColor = Color.FromArgb(93, 173, 226);
            btnThemMoi.FlatStyle = FlatStyle.Flat;
            btnThemMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThemMoi.ForeColor = Color.White;
            btnThemMoi.Location = new Point(573, 10);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(100, 40);
            btnThemMoi.TabIndex = 2;
            btnThemMoi.Text = "✚ Thêm mới";
            btnThemMoi.UseVisualStyleBackColor = false;
            btnThemMoi.Click += btnThemMoi_Click_1;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatExcel.BackColor = Color.FromArgb(39, 174, 96);
            btnXuatExcel.FlatAppearance.BorderSize = 0;
            btnXuatExcel.FlatAppearance.MouseDownBackColor = Color.FromArgb(30, 132, 73);
            btnXuatExcel.FlatAppearance.MouseOverBackColor = Color.FromArgb(82, 190, 128);
            btnXuatExcel.FlatStyle = FlatStyle.Flat;
            btnXuatExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(423, 10);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(140, 40);
            btnXuatExcel.TabIndex = 3;
            btnXuatExcel.Text = "📊 Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTimKiem.Location = new Point(485, 64);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(250, 30);
            txtTimKiem.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(10, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(162, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SẢN PHẨM";
            // 
            // dgvSanPham
            // 
            dgvSanPham.AllowUserToAddRows = false;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.BackgroundColor = Color.White;
            dgvSanPham.BorderStyle = BorderStyle.None;
            dgvSanPham.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSanPham.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSanPham.ColumnHeadersHeight = 45;
            dgvSanPham.Dock = DockStyle.Fill;
            dgvSanPham.EnableHeadersVisualStyles = false;
            dgvSanPham.Location = new Point(0, 100);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(226, 234, 253);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dgvSanPham.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvSanPham.RowTemplate.Height = 40;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(910, 440);
            dgvSanPham.TabIndex = 2;
            dgvSanPham.CellFormatting += dgvSanPham_CellFormatting;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.WhiteSmoke;
            pnlFooter.Controls.Add(lblTongSanPham);
            pnlFooter.Controls.Add(lblTongGiaTri);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 540);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(910, 40);
            pnlFooter.TabIndex = 3;
            // 
            // lblTongSanPham
            // 
            lblTongSanPham.AutoSize = true;
            lblTongSanPham.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongSanPham.ForeColor = Color.FromArgb(64, 64, 64);
            lblTongSanPham.Location = new Point(10, 10);
            lblTongSanPham.Name = "lblTongSanPham";
            lblTongSanPham.Size = new Size(319, 23);
            lblTongSanPham.TabIndex = 0;
            lblTongSanPham.Text = "Tổng số mặt hàng: 0 | Tổng tồn kho: 0";
            // 
            // lblTongGiaTri
            // 
            lblTongGiaTri.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTongGiaTri.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongGiaTri.ForeColor = Color.FromArgb(231, 76, 60);
            lblTongGiaTri.Location = new Point(500, 10);
            lblTongGiaTri.Name = "lblTongGiaTri";
            lblTongGiaTri.Size = new Size(400, 23);
            lblTongGiaTri.TabIndex = 1;
            lblTongGiaTri.Text = "Tổng giá trị hàng tồn: 0 VNĐ";
            lblTongGiaTri.TextAlign = ContentAlignment.TopRight;
            // 
            // ucSanPham
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvSanPham);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucSanPham";
            Size = new Size(910, 580);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            pnlFooter.ResumeLayout(false);
            pnlFooter.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblTongSanPham;
        private System.Windows.Forms.Label lblTongGiaTri;
        private System.Windows.Forms.Label lblLoaiSP;
        private System.Windows.Forms.ComboBox cboLoaiSP;
        private Label lblTimKiem;
    }
}