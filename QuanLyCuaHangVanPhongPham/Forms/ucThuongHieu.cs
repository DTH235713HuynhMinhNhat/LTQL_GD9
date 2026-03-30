using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucThuongHieu : UserControl
    {
        // Khai báo sẵn biến isAdding
        private bool isAdding = false;

        // Uncomment dòng dưới nếu đã nối DB
        // private QLCHVPPDbContext db = new QLCHVPPDbContext(); 

        public ucThuongHieu()
        {
            InitializeComponent();
        }

        private void ucThuongHieu_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);
        }

        private void LoadData()
        {
            try
            {
                // Gọi DB ở đây: dgvThuongHieu.DataSource = db.ThuongHieus.ToList();

                // Code giả lập dữ liệu hiển thị (khi nối DB thì xóa phần này đi)
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã TH");
                dt.Columns.Add("Tên Thương Hiệu");
                dt.Rows.Add("TH01", "Thiên Long");
                dt.Rows.Add("TH02", "Hồng Hà");
                dt.Rows.Add("TH03", "Bến Nghé");
                dt.Rows.Add("TH04", "Campus");
                dgvThuongHieu.DataSource = dt;
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

            txtTenThuongHieu.Enabled = editing;
            dgvThuongHieu.Enabled = !editing;
        }

        private void ClearInput()
        {
            txtMaThuongHieu.Clear();
            txtTenThuongHieu.Clear();
            txtTenThuongHieu.Focus();
        }

        private void dgvThuongHieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThuongHieu.Rows[e.RowIndex];
                txtMaThuongHieu.Text = row.Cells[0].Value?.ToString();
                txtTenThuongHieu.Text = row.Cells[1].Value?.ToString();
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
            if (string.IsNullOrEmpty(txtMaThuongHieu.Text))
            {
                MessageBox.Show("Vui lòng chọn thương hiệu cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAdding = false;
            SetControlState(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaThuongHieu.Text))
            {
                MessageBox.Show("Vui lòng chọn thương hiệu cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Xóa thành công!");
                LoadData();
                ClearInput();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenThuongHieu.Text))
            {
                MessageBox.Show("Tên thương hiệu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isAdding)
            {
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật thành công!");
            }

            SetControlState(false);
            LoadData();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            ClearInput();
        }

        private void txtMaThuongHieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenThuongHieu_TextChanged(object sender, EventArgs e)
        {

        }
    }
}