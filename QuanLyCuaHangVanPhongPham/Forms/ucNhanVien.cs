using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyVanPhongPham.Data; // Đảm bảo gọi thư mục chứa QLCHVPPDbContext và class NhanVien
using QuanLyVanPhongPham.Utilities;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucNhanVien : UserControl
    {
        private bool isAdding = false;

        // Khởi tạo kết nối CSDL (DbContext)
        private QLCHVPPDbContext db = new QLCHVPPDbContext();

        public ucNhanVien()
        {
            InitializeComponent();
        }

        private void ucNhanVien_Load(object sender, EventArgs e)
        {
            // Placeholder cho ô tìm kiếm
            txtTimKiem.Text = "Nhập tên, SĐT, mã NV...";
            txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            txtTimKiem.Enter += txtTimKiem_Enter;
            txtTimKiem.Leave += txtTimKiem_Leave;

            LoadChucVu(); // --- MỚI THÊM: Load danh sách chức vụ vào ComboBox trước ---
            LoadData();
            SetControlState(false);

            // Khóa luôn ô TextBox Mã NV để người dùng không tự gõ bậy bạ vào đây
            txtMaNV.Enabled = false;
        }

        // --- MỚI THÊM: Hàm load dữ liệu cho ComboBox Chức vụ ---
        private void LoadChucVu()
        {
            try
            {
                // Giả sử class trong DB của bạn tên là ChucVu và có 2 trường MaChucVu, TenChucVu
                // Nếu tên khác, bạn hãy đổi lại cho khớp nhé!
                cboChucVu.DataSource = db.ChucVu.ToList();
                cboChucVu.DisplayMember = "TenChucVu"; // Cột hiển thị chữ lên giao diện
                cboChucVu.ValueMember = "MaChucVu";    // Giá trị thật (ID) lấy để lưu DB
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách chức vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                if (keyword == "Nhập tên, SĐT, mã NV...") keyword = "";

                var query = db.NhanVien.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(nv => nv.HoTen.Contains(keyword) || 
                                              nv.SDT.Contains(keyword) || 
                                              nv.MaNV.Contains(keyword));
                }

                // Truy vấn dữ liệu từ bảng NhanViens trong SQL Server và đưa lên GridView
                dgvNhanVien.DataSource = query.Select(nv => new
                {
                    MaNV = nv.MaNV,
                    TenNV = nv.HoTen,
                    DienThoai = nv.SDT,
                    DiaChi = nv.DiaChi,
                    MaChucVu = nv.MaChucVu // --- MỚI THÊM: Lấy thêm MaChucVu để ẩn dưới GridView ---
                }).ToList();

                // Ẩn cột MaChucVu trên GridView cho đẹp (người dùng không cần xem mã này trên bảng)
                if (dgvNhanVien.Columns["MaChucVu"] != null)
                {
                    dgvNhanVien.Columns["MaChucVu"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu từ CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetControlState(bool editing)
        {
            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;

            txtTenNV.Enabled = editing;
            txtDienThoai.Enabled = editing;
            txtDiaChi.Enabled = editing;
            cboChucVu.Enabled = editing; // --- MỚI THÊM: Bật/Tắt ComboBox chức vụ ---
            dgvNhanVien.Enabled = !editing;
        }

        private void ClearInput()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            if (cboChucVu.Items.Count > 0)
            {
                cboChucVu.SelectedIndex = 0; // --- MỚI THÊM: Reset lại ComboBox ---
            }
            txtTenNV.Focus();
        }

        private string GenerateMaNV()
        {
            try
            {
                // Lấy mã nhân viên lớn nhất trực tiếp từ CSDL
                var lastNV = db.NhanVien.OrderByDescending(n => n.MaNV).FirstOrDefault();

                if (lastNV == null || string.IsNullOrEmpty(lastNV.MaNV))
                {
                    return "NV01";
                }

                string lastMaNV = lastNV.MaNV;
                if (lastMaNV.StartsWith("NV"))
                {
                    string numberPart = lastMaNV.Substring(2);
                    if (int.TryParse(numberPart, out int number))
                    {
                        number++;
                        return "NV" + number.ToString("D2");
                    }
                }
            }
            catch (Exception)
            {
                return "NV01";
            }

            return "NV01";
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value?.ToString();
                txtDienThoai.Text = row.Cells["DienThoai"].Value?.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value?.ToString();

                // --- MỚI THÊM: Binding dữ liệu cho ComboBox Chức Vụ ---
                if (row.Cells["MaChucVu"].Value != null)
                {
                    cboChucVu.SelectedValue = row.Cells["MaChucVu"].Value.ToString();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInput();
            SetControlState(true);
            txtMaNV.Text = GenerateMaNV();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAdding = false;
            SetControlState(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- MỚI THÊM: Bắt buộc phải chọn chức vụ ---
            if (cboChucVu.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ cho nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // MẤU CHỐT LÀ DÒNG NÀY: Xóa toàn bộ cache cũ để tránh xung đột Tracking
                db.ChangeTracker.Clear();

                if (isAdding)
                {
                    // Tạo Object Nhân Viên mới
                    NhanVien nvMoi = new NhanVien()
                    {
                        MaNV = txtMaNV.Text,
                        HoTen = txtTenNV.Text,
                        SDT = txtDienThoai.Text,
                        DiaChi = txtDiaChi.Text,
                        MaChucVu = cboChucVu.SelectedValue.ToString() // --- MỚI THÊM: Lấy mã chức vụ để lưu DB ---
                    };

                    db.NhanVien.Add(nvMoi); // Lệnh Thêm
                    db.SaveChanges();        // Thực thi xuống DB

                    MessageBox.Show($"Thêm mới nhân viên {txtMaNV.Text} thành công!");
                }
                else
                {
                    // Lấy nhân viên hiện tại lên từ DB để sửa
                    var nvSua = db.NhanVien.Find(txtMaNV.Text);
                    if (nvSua != null)
                    {
                        // Cập nhật lại các thông tin mới
                        nvSua.HoTen = txtTenNV.Text;
                        nvSua.SDT = txtDienThoai.Text;
                        nvSua.DiaChi = txtDiaChi.Text;
                        nvSua.MaChucVu = cboChucVu.SelectedValue.ToString(); // --- MỚI THÊM: Cập nhật mã chức vụ ---

                        db.NhanVien.Update(nvSua); // Cập nhật trạng thái
                        db.SaveChanges(); // Thực thi lệnh Cập nhật (Update) xuống DB
                        MessageBox.Show("Cập nhật thông tin thành công!");
                    }
                }

                SetControlState(false);
                LoadData(); // Gọi lại hàm LoadData để cập nhật bảng dgvNhanVien mới nhất
            }
            catch (Exception ex)
            {
                // Lấy thông báo lỗi chính
                string errorMessage = ex.Message;

                // Đào sâu vào Inner Exception để lấy nguyên nhân gốc rễ (nếu có)
                if (ex.InnerException != null)
                {
                    errorMessage += "\n\nNguyên nhân chi tiết (Inner Exception):\n" + ex.InnerException.Message;
                }

                MessageBox.Show("Lỗi khi lưu:\n" + errorMessage, "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Thêm dòng này để dọn dẹp cache trước khi tìm và xóa
                    db.ChangeTracker.Clear();

                    // Dùng hàm Find để tìm nhân viên theo Khóa chính (MaNV)
                    var nv = db.NhanVien.Find(txtMaNV.Text);

                    if (nv != null)
                    {
                        db.NhanVien.Remove(nv); // Lệnh xóa
                        db.SaveChanges();        // Thực thi xuống DB

                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                        ClearInput();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên trong CSDL!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            ClearInput();
        }

        // --- HÀM TÌM KIẾM & PLACEHOLDER ---
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập tên, SĐT, mã NV...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Nhập tên, SĐT, mã NV...";
                txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportToExcel(dgvNhanVien, "DanhSachNhanVien");
        }
    }
}