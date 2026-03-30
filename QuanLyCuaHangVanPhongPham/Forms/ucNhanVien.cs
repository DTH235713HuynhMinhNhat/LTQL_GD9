using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucNhanVien : UserControl
    {
        private bool isAdding = false;

        public ucNhanVien()
        {
            InitializeComponent();
        }

        private void ucNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);
        }

        private void LoadData()
        {
            try
            {
                // Gọi dữ liệu từ database:
                // dgvNhanVien.DataSource = db.NhanViens.ToList();

                // Code giả lập dữ liệu:
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã NV");
                dt.Columns.Add("Tên Nhân Viên");
                dt.Columns.Add("Điện Thoại");
                dt.Columns.Add("Địa Chỉ");
                dt.Rows.Add("NV01", "Lê Thị Thu Thảo", "0912345678", "Long Xuyên, An Giang");
                dt.Rows.Add("NV02", "Nguyễn Hải Đăng", "0988777666", "Châu Đốc, An Giang");
                dt.Rows.Add("NV03", "Phạm Văn Cường", "0909111222", "Thoại Sơn, An Giang");
                dgvNhanVien.DataSource = dt;
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

            txtTenNV.Enabled = editing;
            txtDienThoai.Enabled = editing;
            txtDiaChi.Enabled = editing;
            dgvNhanVien.Enabled = !editing;
        }

        private void ClearInput()
        {
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTenNV.Focus();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value?.ToString();
                txtTenNV.Text = row.Cells[1].Value?.ToString();
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
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAdding = false;
            SetControlState(true);
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
                MessageBox.Show("Xóa thành công!");
                LoadData();
                ClearInput();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Tên nhân viên không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isAdding)
            {
                MessageBox.Show("Thêm mới nhân viên thành công!");
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