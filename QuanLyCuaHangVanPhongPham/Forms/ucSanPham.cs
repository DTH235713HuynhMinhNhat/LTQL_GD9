using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore; // Thêm thư viện này để dùng AsNoTracking()
using QuanLyVanPhongPham.Data;
using ClosedXML.Excel;

namespace QuanLyVanPhongPham.Forms
{
    public partial class ucSanPham : UserControl
    {
        private QLCHVPPDbContext db = new QLCHVPPDbContext();

        public ucSanPham()
        {
            InitializeComponent();

            // Đăng ký sự kiện Load và Tìm kiếm
            this.Load += UcSanPham_Load;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
        }

        private void UcSanPham_Load(object sender, EventArgs e)
        {
            // Thêm placeholder text cho ô tìm kiếm
            txtTimKiem.Text = "Nhập tên, loại SP...";
            txtTimKiem.ForeColor = Color.Gray;
            txtTimKiem.Enter += TxtTimKiem_Enter;
            txtTimKiem.Leave += TxtTimKiem_Leave;
            
            LoadCategories();
            LoadData();
        }

        private void LoadCategories()
        {
            try
            {
                var listLoai = db.LoaiSanPham.AsNoTracking().ToList();
                // Chèn thêm tùy chọn "Tất cả" vào đầu danh sách
                listLoai.Insert(0, new LoaiSanPham { MaLoai = "ALL", TenLoai = "--- Tất cả danh mục ---" });

                cboLoaiSP.DataSource = listLoai;
                cboLoaiSP.DisplayMember = "TenLoai";
                cboLoaiSP.ValueMember = "MaLoai";
                cboLoaiSP.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- 1. HÀM ĐỔ DỮ LIỆU LÊN DATAGRIDVIEW ---
        // --- 1. HÀM ĐỔ DỮ LIỆU LÊN DATAGRIDVIEW ---
        private void LoadData()
        {
            try
            {
                // TỐI ƯU: Giải phóng DB Context cũ trước khi tạo mới để tránh tràn RAM
                if (db != null)
                {
                    db.Dispose();
                }

                db = new QLCHVPPDbContext();
                var query = db.SanPham.AsNoTracking();

                // --- LỰC CHỌN BỘ LỌC ---
                string keyword = txtTimKiem.Text.Trim();
                if (keyword == "Nhập tên, loại SP...") keyword = "";

                // Lọc theo từ khóa (Tên hoặc Mã)
                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(sp => sp.TenSanPham.Contains(keyword) || sp.MaSP.Contains(keyword));
                }

                // Lọc theo danh mục
                if (cboLoaiSP.SelectedValue != null && cboLoaiSP.SelectedValue.ToString() != "ALL")
                {
                    string maLoai = cboLoaiSP.SelectedValue.ToString();
                    query = query.Where(sp => sp.MaLoai == maLoai);
                }

                // BƯỚC A: Lấy dữ liệu thô từ Database
                var rawData = query.Select(sp => new
                {
                    MaSP = sp.MaSP,
                    HinhAnhPath = sp.HinhAnh,
                    TenSanPham = sp.TenSanPham,
                    LoaiSP = sp.LoaiSanPham.TenLoai,
                    ThuongHieu = sp.ThuongHieu.TenThuongHieu,
                    SoLuong = sp.SoLuong,
                    GiaBan = sp.GiaBan
                }).ToList();

                // BƯỚC B: Chuyển đổi đường dẫn thành đối tượng Image
                var data = rawData.Select(sp => new
                {
                    MaSP = sp.MaSP,
                    HinhAnh = GetImageSafe(sp.HinhAnhPath), // Gọi hàm load ảnh thực tế
                    TenSanPham = sp.TenSanPham,
                    LoaiSP = sp.LoaiSP,
                    ThuongHieu = sp.ThuongHieu,
                    SoLuong = sp.SoLuong,
                    GiaBan = sp.GiaBan
                }).ToList();

                // Tăng chiều cao dòng để chứa vừa bức ảnh (Mặc định thường chỉ ~22px)
                dgvSanPham.RowTemplate.Height = 60;

                dgvSanPham.DataSource = data;

                // Đổi tên và định dạng cột
                if (dgvSanPham.Columns.Count > 0)
                {
                    dgvSanPham.Columns["MaSP"].HeaderText = "Mã SP";
                    dgvSanPham.Columns["MaSP"].Width = 70;

                    // Cấu hình riêng cho cột Hình Ảnh
                    if (dgvSanPham.Columns["HinhAnh"] is DataGridViewImageColumn imgCol)
                    {
                        imgCol.HeaderText = "Hình Ảnh";
                        imgCol.Width = 80;
                        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; // Căn giữa và thu phóng giữ đúng tỷ lệ ảnh
                    }

                    dgvSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";

                    dgvSanPham.Columns["LoaiSP"].HeaderText = "Loại SP";
                    dgvSanPham.Columns["LoaiSP"].Width = 120;

                    dgvSanPham.Columns["ThuongHieu"].HeaderText = "Thương Hiệu";
                    dgvSanPham.Columns["ThuongHieu"].Width = 120;

                    dgvSanPham.Columns["SoLuong"].HeaderText = "Tồn Kho";
                    dgvSanPham.Columns["SoLuong"].Width = 90;
                    dgvSanPham.Columns["SoLuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
                    dgvSanPham.Columns["GiaBan"].Width = 110;
                    dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
                    dgvSanPham.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                // --- BƯỚC C: THỐNG KÊ NHANH XUỐNG CUỐI TRANG ---
                // Sử dụng Convert để ép kiểu an toàn, tránh lỗi khi nhân số lượng với giá bán
                var tongSoLoai = data.Count;
                var tongTonKho = data.Sum(sp => Convert.ToInt32(sp.SoLuong));
                var tongGiaTri = data.Sum(sp => Convert.ToDecimal(sp.SoLuong) * Convert.ToDecimal(sp.GiaBan));

                // Hiển thị ra Label (Nhớ tạo Label trên giao diện Design trước nhé)
                if (lblTongSanPham != null && lblTongGiaTri != null)
                {
                    lblTongSanPham.Text = $"Tổng số mặt hàng: {tongSoLoai:N0} | Tổng tồn kho: {tongTonKho:N0}";
                    lblTongGiaTri.Text = $"Tổng giá trị hàng tồn: {tongGiaTri:N0} VNĐ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm hỗ trợ đọc file ảnh an toàn từ đường dẫn
        // Hàm hỗ trợ đọc file ảnh an toàn từ đường dẫn (Đã fix lỗi GDI+)
        private Image GetImageSafe(string path)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path) && System.IO.File.Exists(path))
                {
                    using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        using (var tempImg = Image.FromStream(stream))
                        {
                            // Trả về một bản sao độc lập (Bitmap) để giải phóng hoàn toàn stream và file gốc
                            return new Bitmap(tempImg);
                        }
                    }
                }
            }
            catch
            {
                // Bỏ qua lỗi (ví dụ file bị hỏng, sai định dạng)
            }
            return null;
        }

        // --- 2. HÀM TÌM KIẾM & LỌC ---
        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chỉ LoadData khi combobox đã được bind xong (tránh lỗi khi vừa khởi tạo)
            if (cboLoaiSP.Focused || cboLoaiSP.DroppedDown)
            {
                LoadData();
            }
        }

        // --- Xử lý giao diện cho thanh tìm kiếm (Placeholder) ---
        private void TxtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập tên, loại SP...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void TxtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Nhập tên, loại SP...";
                txtTimKiem.ForeColor = Color.Gray;
                LoadData(); // Load lại toàn bộ khi bỏ trống
            }
        }

        // --- 3. CÁC NÚT CHỨC NĂNG ---
        private void btnThemMoi_Click_1(object sender, EventArgs e)
        {
            // Mở form chi tiết ở chế độ Thêm mới
            frmChiTietSanPham frm = new frmChiTietSanPham();

            // 🌟 Gọi ShowDialog để bắt chương trình đợi Form đóng rồi mới chạy tiếp
            frm.ShowDialog();

            // 🌟 Sau khi form Thêm đóng, tự động Load lại dữ liệu để hiển thị SP mới
            LoadData();
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                // Lấy MaSP dạng string của dòng đang chọn
                string maSP = dgvSanPham.SelectedRows[0].Cells["MaSP"].Value.ToString();

                // Mở form chi tiết truyền vào maSP để sửa
                frmChiTietSanPham frm = new frmChiTietSanPham(maSP);

                // 🌟 Tương tự như thêm, đợi form đóng rồi Load lại dữ liệu
                frm.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.SelectedRows.Count > 0)
            {
                // Lấy MaSP dạng string
                string maSP = dgvSanPham.SelectedRows[0].Cells["MaSP"].Value.ToString();
                string tenSP = dgvSanPham.SelectedRows[0].Cells["TenSanPham"].Value.ToString();

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{tenSP}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        var sp = db.SanPham.Find(maSP); // Tìm bằng string
                        if (sp != null)
                        {
                            db.SanPham.Remove(sp);
                            db.SaveChanges();
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadData(); // Cập nhật lại lưới sau khi xóa
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa (Có thể sản phẩm này đã phát sinh hóa đơn):\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            // Tính năng xuất Excel sẽ code ở đây
            // Kiểm tra xem có dữ liệu trên DataGridView không
            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở hộp thoại cho phép người dùng chọn nơi lưu file
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
                sfd.Title = "Lưu danh sách sản phẩm";
                sfd.FileName = "DanhSachSanPham.xlsx"; // Tên file mặc định

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Khởi tạo file Excel mới
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            // Tạo một sheet mới tên là "Danh sách SP"
                            var worksheet = workbook.Worksheets.Add("Danh sách SP");

                            // 1. In Tiêu đề cột (Header) từ DataGridView
                            for (int i = 0; i < dgvSanPham.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgvSanPham.Columns[i].HeaderText;
                            }

                            // 2. Đổ dữ liệu các dòng
                            for (int i = 0; i < dgvSanPham.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvSanPham.Columns.Count; j++)
                                {
                                    // 🌟 Xử lý ngoại lệ: Nếu là cột Hình Ảnh thì chỉ in ra chữ "[Có ảnh]" thay vì lỗi
                                    if (dgvSanPham.Columns[j] is DataGridViewImageColumn)
                                    {
                                        worksheet.Cell(i + 2, j + 1).Value = "[Có ảnh]";
                                    }
                                    else
                                    {
                                        // Lấy giá trị của ô, nếu null thì gán bằng chuỗi rỗng
                                        worksheet.Cell(i + 2, j + 1).Value = dgvSanPham.Rows[i].Cells[j].Value?.ToString() ?? "";
                                    }
                                }
                            }

                            // 3. Định dạng làm đẹp Excel
                            var headerRow = worksheet.Row(1);
                            headerRow.Style.Font.Bold = true; // In đậm tiêu đề
                            headerRow.Style.Fill.BackgroundColor = XLColor.LightGray; // Tô nền xám cho tiêu đề
                            worksheet.Columns().AdjustToContents(); // Tự động căn chỉnh độ rộng cột cho vừa với chữ

                            // 4. Lưu file vào đường dẫn đã chọn
                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Bắt lỗi trong trường hợp file đang bị mở bởi phần mềm khác không ghi đè được
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSanPham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu đang ở cột "SoLuong" (Tồn Kho)
            if (dgvSanPham.Columns[e.ColumnIndex].Name == "SoLuong" && e.Value != null)
            {
                int tonKho = Convert.ToInt32(e.Value);
                if (tonKho < 10) // Nếu tồn kho dưới 10
                {
                    // Đổi màu nền ô đó thành màu vàng nhạt và chữ đỏ để cảnh báo
                    e.CellStyle.BackColor = Color.PeachPuff;
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new Font(dgvSanPham.Font, FontStyle.Bold);
                }
            }
        }
    }
}