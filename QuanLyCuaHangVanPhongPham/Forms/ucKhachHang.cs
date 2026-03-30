using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucKhachHang : UserControl
    {
        private bool isAdding = false;

        // Uncomment dòng dưới khi bạn đã chuẩn bị xong Entity Framework kết nối DB
        // private QLCHVPPDbContext db = new QLCHVPPDbContext(); 

        public ucKhachHang()
        {
            InitializeComponent();
        }

        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);
        }

        private void LoadData()
        {
            try
            {
                // Gọi dữ liệu từ database:
                // dgvKhachHang.DataSource = db.KhachHangs.ToList();

                // Code giả lập dữ liệu:
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã KH");
                dt.Columns.Add("Tên Khách Hàng");
                dt.Columns.Add("Điện Thoại");
                dt.Columns.Add("Địa Chỉ");
                dt.Rows.Add("KH01", "Nguyễn Văn Tuấn", "0987123456", "Long Xuyên, An Giang");
                dt.Rows.Add("KH02", "Trần Thị Bé", "0909888777", "Châu Đốc, An Giang");
                dt.Rows.Add("KH03", "Cửa hàng Hoa Hồng", "0868112233", "Cần Thơ");
                dgvKhachHang.DataSource = dt;
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // db.KhachHangs.Remove(db.KhachHangs.Find(txtMaKH.Text));
                // db.SaveChanges();
                MessageBox.Show("Xóa thành công!");
                LoadData();
                ClearInput();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Tên khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isAdding)
            {
                MessageBox.Show("Thêm mới khách hàng thành công!");
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