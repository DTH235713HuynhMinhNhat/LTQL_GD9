using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyVanPhongPham.Data;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucThuongHieu : UserControl
    {
        private bool isAdding = false;
        private QLCHVPPDbContext db; // Chỉ khai báo, chưa khởi tạo vội

        public ucThuongHieu()
        {
            InitializeComponent();
        }

        private void ucThuongHieu_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);

            txtMaThuongHieu.ReadOnly = true;
            txtMaThuongHieu.BackColor = Color.LightGray;
        }

        private void LoadData()
        {
            try
            {
                // Khởi tạo mới DBContext mỗi lần load để luôn lấy dữ liệu mới nhất (chống cache)
                db = new QLCHVPPDbContext();

                var danhSachTH = db.ThuongHieu
                                   .Select(th => new
                                   {
                                       Mã_TH = th.MaTH,
                                       Tên_Thương_Hiệu = th.TenThuongHieu
                                   })
                                   .ToList();

                dgvThuongHieu.DataSource = danhSachTH;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private string GenerateMaTH()
        {
            try
            {
                var lastTH = db.ThuongHieu
                               .OrderByDescending(t => t.MaTH)
                               .FirstOrDefault();

                if (lastTH != null && !string.IsNullOrEmpty(lastTH.MaTH))
                {
                    string curID = lastTH.MaTH;
                    // Lấy các ký tự số phía sau chữ "TH" (bỏ qua 2 ký tự đầu)
                    if (int.TryParse(curID.Substring(2), out int num))
                    {
                        return "TH" + (num + 1).ToString("D2"); // D2: Format dạng 01, 02...
                    }
                }
            }
            catch { }

            return "TH01"; // Trả về mặc định nếu bảng trống hoặc lỗi
        }

        private void dgvThuongHieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Tránh lỗi click vào tiêu đề cột (RowIndex = -1)
            if (e.RowIndex >= 0 && !btnLuu.Enabled)
            {
                DataGridViewRow row = dgvThuongHieu.Rows[e.RowIndex];
                txtMaThuongHieu.Text = row.Cells[0].Value?.ToString();
                txtTenThuongHieu.Text = row.Cells[1].Value?.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAdding = true;
            SetControlState(true);
            ClearInput();
            txtMaThuongHieu.Text = GenerateMaTH();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaThuongHieu.Text))
            {
                MessageBox.Show("Vui lòng chọn một thương hiệu dưới bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isAdding = false;
            SetControlState(true);
            txtTenThuongHieu.Focus(); // Cho con trỏ chuột nhảy thẳng vào ô Tên để sửa
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ma = txtMaThuongHieu.Text;
            string ten = txtTenThuongHieu.Text.Trim();

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Tên thương hiệu không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenThuongHieu.Focus();
                return;
            }

            try
            {
                if (isAdding)
                {
                    // Thêm mới
                    ThuongHieu thMoi = new ThuongHieu()
                    {
                        MaTH = ma,
                        TenThuongHieu = ten
                    };
                    db.ThuongHieu.Add(thMoi);
                }
                else
                {
                    // Cập nhật (Tìm theo MaTH)
                    var thSua = db.ThuongHieu.FirstOrDefault(t => t.MaTH == ma);
                    if (thSua != null)
                    {
                        thSua.TenThuongHieu = ten;
                    }
                }

                db.SaveChanges();
                SetControlState(false);
                ClearInput();
                LoadData(); // Load lại bảng để cập nhật dữ liệu mới
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaThuongHieu.Text;
            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Vui lòng chọn một thương hiệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa thương hiệu '{txtTenThuongHieu.Text}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var thXoa = db.ThuongHieu.FirstOrDefault(t => t.MaTH == ma);
                    if (thXoa != null)
                    {
                        db.ThuongHieu.Remove(thXoa);
                        db.SaveChanges();
                        ClearInput();
                        LoadData(); // Load lại bảng sau khi xóa
                    }
                }
                catch
                {
                    MessageBox.Show("Không thể xóa do thương hiệu này đang chứa sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            ClearInput();
            LoadData(); // Phục hồi lại dữ liệu cũ trên các ô Textbox nếu người dùng đang sửa dở
        }
    }
}