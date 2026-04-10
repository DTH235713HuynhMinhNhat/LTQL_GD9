using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyVanPhongPham.Data; // Đảm bảo đúng namespace chứa DbContext của bạn
using QuanLyVanPhongPham.Utilities;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucKhachHang : UserControl
    {
        private bool isAdding = false;

        // Khởi tạo kết nối CSDL
        private QLCHVPPDbContext db = new QLCHVPPDbContext();

        public ucKhachHang()
        {
            InitializeComponent();
        }

        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            // Placeholder cho ô tìm kiếm
            txtTimKiem.Text = "Nhập tên, SĐT, mã KH...";
            txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            txtTimKiem.Enter += txtTimKiem_Enter;
            txtTimKiem.Leave += txtTimKiem_Leave;

            LoadData();
            SetControlState(false);
            txtMaKH.Enabled = false; // Không cho phép sửa mã thủ công
        }

        private void LoadData()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                if (keyword == "Nhập tên, SĐT, mã KH...") keyword = "";

                var query = db.KhachHang.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(kh => kh.TenKhachHang.Contains(keyword) || 
                                              kh.SoDienThoai.Contains(keyword) || 
                                              kh.MaKH.Contains(keyword));
                }

                // Load dữ liệu thực từ database
                dgvKhachHang.DataSource = query.Select(kh => new
                {
                    MaKH = kh.MaKH,
                    TenKH = kh.TenKhachHang,
                    DienThoai = kh.SoDienThoai,
                    DiaChi = kh.DiaChi
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- HÀM TỰ ĐỘNG SINH MÃ KHÁCH HÀNG (MỚI THÊM) ---
        private string GenerateMaKH()
        {
            try
            {
                var lastKH = db.KhachHang.OrderByDescending(k => k.MaKH).FirstOrDefault();

                if (lastKH == null || string.IsNullOrEmpty(lastKH.MaKH))
                {
                    return "KH01";
                }

                string lastMa = lastKH.MaKH;
                if (lastMa.StartsWith("KH"))
                {
                    string numberPart = lastMa.Substring(2);
                    if (int.TryParse(numberPart, out int number))
                    {
                        number++;
                        return "KH" + number.ToString("D2");
                    }
                }
            }
            catch { return "KH01"; }
            return "KH01";
        }

        private void SetControlState(bool editing)
        {
            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;

            txtTenKH.Enabled = editing;
            txtDienThoai.Enabled = editing;
            txtDiaChi.Enabled = editing;
            dgvKhachHang.Enabled = !editing;
        }

        private void ClearInput()
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTenKH.Focus();
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells[0].Value?.ToString();
                txtTenKH.Text = row.Cells[1].Value?.ToString();
                txtDienThoai.Text = row.Cells[2].Value?.ToString();
                txtDiaChi.Text = row.Cells[3].Value?.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInput();
            SetControlState(true);
            txtMaKH.Text = GenerateMaKH(); // Gọi hàm sinh mã khi nhấn Thêm
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAdding = false;
            SetControlState(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                db.ChangeTracker.Clear();

                if (isAdding)
                {
                    // Thêm mới
                    var khMoi = new KhachHang() // Đảm bảo tên class đúng với Model của bạn
                    {
                        MaKH = txtMaKH.Text,
                        TenKhachHang = txtTenKH.Text,
                        SoDienThoai = txtDienThoai.Text,
                        DiaChi = txtDiaChi.Text
                    };
                    db.KhachHang.Add(khMoi);
                    db.SaveChanges();
                    MessageBox.Show("Thêm mới khách hàng thành công!");
                }
                else
                {
                    // Sửa
                    var khSua = db.KhachHang.Find(txtMaKH.Text);
                    if (khSua != null)
                    {
                        khSua.TenKhachHang = txtTenKH.Text;
                        khSua.SoDienThoai = txtDienThoai.Text;
                        khSua.DiaChi = txtDiaChi.Text;
                        db.SaveChanges();
                        MessageBox.Show("Cập nhật thành công!");
                    }
                }

                SetControlState(false);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    db.ChangeTracker.Clear();
                    var kh = db.KhachHang.Find(txtMaKH.Text);
                    if (kh != null)
                    {
                        db.KhachHang.Remove(kh);
                        db.SaveChanges();
                        MessageBox.Show("Xóa thành công!");
                        LoadData();
                        ClearInput();
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
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportToExcel(dgvKhachHang, "DanhSachKhachHang");
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập tên, SĐT, mã KH...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Nhập tên, SĐT, mã KH...";
                txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }
    }
}