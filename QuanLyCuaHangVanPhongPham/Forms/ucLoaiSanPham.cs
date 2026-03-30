using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucLoaiSanPham : UserControl
    {
        private bool isAdding = false;

        public ucLoaiSanPham()
        {
            InitializeComponent();
        }

        private void ucLoaiSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);
        }

        private void LoadData()
        {
            try
            {
                // Giả lập dữ liệu Loại hàng
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã Loại");
                dt.Columns.Add("Tên Loại Sản Phẩm");
                dt.Rows.Add("L01", "Bút các loại");
                dt.Rows.Add("L02", "Vở - Tập học sinh");
                dt.Rows.Add("L03", "Giấy in - Giấy photo");
                dt.Rows.Add("L04", "Dụng cụ văn phòng");
                dgvLoaiSP.DataSource = dt;
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

            txtTenLoai.Enabled = editing;
            dgvLoaiSP.Enabled = !editing;
        }

        private void ClearInput()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtTenLoai.Focus();
        }

        private void dgvLoaiSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiSP.Rows[e.RowIndex];
                txtMaLoai.Text = row.Cells[0].Value?.ToString();
                txtTenLoai.Text = row.Cells[1].Value?.ToString();
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
            if (string.IsNullOrEmpty(txtMaLoai.Text))
            {
                MessageBox.Show("Vui lòng chọn loại cần sửa!", "Thông báo");
                return;
            }
            isAdding = false;
            SetControlState(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLoai.Text))
            {
                MessageBox.Show("Vui lòng chọn loại cần xóa!", "Thông báo");
                return;
            }
            if (MessageBox.Show("Xác nhận xóa loại sản phẩm này?", "Hỏi", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("Đã xóa thành công!");
                LoadData();
                ClearInput();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Tên loại không được để trống!");
                return;
            }

            string msg = isAdding ? "Thêm mới thành công!" : "Cập nhật thành công!";
            MessageBox.Show(msg);

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