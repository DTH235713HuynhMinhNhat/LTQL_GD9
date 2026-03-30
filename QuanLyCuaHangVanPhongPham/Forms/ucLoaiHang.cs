using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucLoaiHang : UserControl
    {
        private bool isAdding = false;
        public ucLoaiHang()
        {
            InitializeComponent();
        }

        private void ucLoaiHang_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false); // Vừa vào thì khóa các nút Lưu/Hủy, khóa TextBox
        }

        private void LoadData()
        {
            try
            {
                // Dòng này load dữ liệu từ DB. Đổi "LoaiSanPhams" thành tên bảng của bạn nhé!
                // dgvLoaiHang.DataSource = db.LoaiSanPhams.ToList();

                // (Tạm thời mình giả lập dữ liệu để bạn test giao diện không bị lỗi)
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã loại");
                dt.Columns.Add("Tên loại");
                dt.Rows.Add("L01", "Bút viết");
                dt.Rows.Add("L02", "Sổ tay - Giấy");
                dgvLoaiHang.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // Hàm điều khiển trạng thái bật/tắt của các nút và textbox
        private void SetControlState(bool editing)
        {
            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing;
            btnXoa.Enabled = !editing;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;

            txtTenLoai.Enabled = editing;
            dgvLoaiHang.Enabled = !editing; // Đang nhập liệu thì không cho bấm lung tung vào Grid
        }

        private void ClearInput()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtTenLoai.Focus();
        }

        private void dgvLoaiHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiHang.Rows[e.RowIndex];
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
                MessageBox.Show("Vui lòng chọn loại hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAdding = false;
            SetControlState(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLoai.Text))
            {
                MessageBox.Show("Vui lòng chọn loại hàng cần xóa!", "Thông báo");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Gọi DB để xóa ở đây: 
                // var loai = db.LoaiSanPhams.Find(txtMaLoai.Text);
                // db.LoaiSanPhams.Remove(loai);
                // db.SaveChanges();

                MessageBox.Show("Xóa thành công!");
                LoadData();
                ClearInput();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Tên loại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isAdding)
            {
                // Code thêm vào DB ở đây
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                // Code cập nhật vào DB ở đây
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
    }
}

