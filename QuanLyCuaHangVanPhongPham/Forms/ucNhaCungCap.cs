using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucNhaCungCap : UserControl
    {
        private bool isAdding = false;

        public ucNhaCungCap()
        {
            InitializeComponent();
        }

        private void ucNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);
        }

        private void LoadData()
        {
            try
            {
                // Gọi dữ liệu từ database:
                // dgvNhaCungCap.DataSource = db.NhaCungCaps.ToList();

                // Code giả lập dữ liệu:
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã NCC");
                dt.Columns.Add("Tên Nhà Cung Cấp");
                dt.Columns.Add("Điện Thoại");
                dt.Columns.Add("Địa Chỉ");
                dt.Rows.Add("NCC01", "Công ty CP Tập đoàn Thiên Long", "02837505555", "Quận Bình Tân, TP.HCM");
                dt.Rows.Add("NCC02", "Công ty VPP Hồng Hà", "02436522222", "Quận Hai Bà Trưng, Hà Nội");
                dt.Rows.Add("NCC03", "Nhà Phân Phối Deli VN", "19008866", "Quận 1, TP.HCM");
                dgvNhaCungCap.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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
            txtDienThoai.Enabled = editing;
            txtDiaChi.Enabled = editing;
            dgvNhaCungCap.Enabled = !editing;
        }

        private void ClearInput()
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTenNCC.Focus();
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhaCungCap.Rows[e.RowIndex];
                txtMaNCC.Text = row.Cells[0].Value?.ToString();
                txtTenNCC.Text = row.Cells[1].Value?.ToString();
                txtDienThoai.Text = row.Cells[2].Value?.ToString();
                txtDiaChi.Text = row.Cells[3].Value?.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            ClearInput();
            SetControlState(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAdding = false;
            SetControlState(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Xóa thành công!");
                LoadData();
                ClearInput();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNCC.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isAdding)
            {
                MessageBox.Show("Thêm mới nhà cung cấp thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin thành công!");
            }

            SetControlState(false);
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            ClearInput();
        }
    }
}