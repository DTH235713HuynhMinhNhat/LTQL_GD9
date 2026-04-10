using QuanLyVanPhongPham.Data;
using QuanLyVanPhongPham.Utilities;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucNhaCungCap : UserControl
    {
        private bool isAdding = false;
        private QLCHVPPDbContext db;

        public ucNhaCungCap()
        {
            InitializeComponent();
        }

        private void ucNhaCungCap_Load(object sender, EventArgs e)
        {
            // Placeholder cho ô tìm kiếm
            txtTimKiem.Text = "Nhập tên, SĐT, mã NCC...";
            txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            txtTimKiem.Enter += txtTimKiem_Enter;
            txtTimKiem.Leave += txtTimKiem_Leave;

            LoadData();
            SetControlState(false);
            txtMaNCC.ReadOnly = true;
            txtMaNCC.BackColor = Color.LightGray;
        }

        private void LoadData()
        {
            try
            {
                db = new QLCHVPPDbContext();

                string keyword = txtTimKiem.Text.Trim();
                if (keyword == "Nhập tên, SĐT, mã NCC...") keyword = "";

                var query = db.NhaCungCap.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    query = query.Where(n => n.TenNhaCungCap.Contains(keyword) || 
                                              n.SoDienThoai.Contains(keyword) || 
                                              n.MaNCC.Contains(keyword));
                }

                var data = query.Select(n => new {
                                 Mã_NCC = n.MaNCC,
                                 Tên_Nhà_Cung_Cấp = n.TenNhaCungCap,
                                 Địa_Chỉ = n.DiaChi,
                                 SĐT = n.SoDienThoai
                             }).ToList();
                dgvNhaCungCap.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void SetControlState(bool editing)
        {
            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;

            txtTenNCC.Enabled = editing;
            txtDiaChi.Enabled = editing;
            txtDienThoai.Enabled = editing; // Đã đổi từ txtSDT thành txtDienThoai theo Designer
            dgvNhaCungCap.Enabled = !editing;
        }

        private void ClearInput()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDiaChi.Clear();
            txtDienThoai.Clear();
            txtTenNCC.Focus();
        }

        private string GenerateMaNCC()
        {
            try
            {
                var last = db.NhaCungCap.OrderByDescending(n => n.MaNCC).FirstOrDefault();
                if (last != null)
                {
                    int num = int.Parse(last.MaNCC.Substring(3));
                    return "NCC" + (num + 1).ToString("D2");
                }
            }
            catch { }
            return "NCC01";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            SetControlState(true);
            ClearInput();
            txtMaNCC.Text = GenerateMaNCC();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text)) return;
            isAdding = false;
            SetControlState(true);
            txtTenNCC.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp!");
                return;
            }

            try
            {
                if (isAdding)
                {
                    var ncc = new NhaCungCap
                    {
                        MaNCC = txtMaNCC.Text,
                        TenNhaCungCap = txtTenNCC.Text,
                        DiaChi = txtDiaChi.Text,
                        SoDienThoai = txtDienThoai.Text
                    };
                    db.NhaCungCap.Add(ncc);
                }
                else
                {
                    string ma = txtMaNCC.Text;
                    var nccSua = db.NhaCungCap.FirstOrDefault(n => n.MaNCC == ma);
                    if (nccSua != null)
                    {
                        nccSua.TenNhaCungCap = txtTenNCC.Text;
                        nccSua.DiaChi = txtDiaChi.Text;
                        nccSua.SoDienThoai = txtDienThoai.Text;
                    }
                }
                db.SaveChanges();
                LoadData();
                SetControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text)) return;
            if (MessageBox.Show("Xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var ncc = db.NhaCungCap.FirstOrDefault(n => n.MaNCC == txtMaNCC.Text);
                    if (ncc != null)
                    {
                        db.NhaCungCap.Remove(ncc);
                        db.SaveChanges();
                        LoadData();
                        ClearInput();
                    }
                }
                catch { MessageBox.Show("Không thể xóa nhà cung cấp này vì có liên kết dữ liệu!"); }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            LoadData();
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !btnLuu.Enabled)
            {
                var row = dgvNhaCungCap.Rows[e.RowIndex];
                txtMaNCC.Text = row.Cells[0].Value?.ToString();
                txtTenNCC.Text = row.Cells[1].Value?.ToString();
                txtDiaChi.Text = row.Cells[2].Value?.ToString();
                txtDienThoai.Text = row.Cells[3].Value?.ToString();
            }
        }

        // --- HÀM TÌM KIẾM & PLACEHOLDER ---
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Nhập tên, SĐT, mã NCC...")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Nhập tên, SĐT, mã NCC...";
                txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportToExcel(dgvNhaCungCap, "DanhSachNhaCungCap");
        }
    }
}