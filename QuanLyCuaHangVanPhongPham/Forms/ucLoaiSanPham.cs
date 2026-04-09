using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyVanPhongPham.Data; // Đảm bảo đúng thư mục chứa DbContext của bạn

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucLoaiSanPham : UserControl
    {
        private bool isAdding = false;

        // Khởi tạo kết nối CSDL
        private QLCHVPPDbContext db = new QLCHVPPDbContext();

        public ucLoaiSanPham()
        {
            InitializeComponent();
        }

        private void ucLoaiSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            SetControlState(false);

            // Khóa ô nhập mã để tránh sửa thủ công
            txtMaLoai.Enabled = false;
        }

        private void LoadData()
        {
            try
            {
                // Lấy dữ liệu thực tế từ CSDL thay vì dùng DataTable giả lập
                dgvLoaiSP.DataSource = db.LoaiSanPham.Select(l => new
                {
                    MaLoai = l.MaLoai,
                    TenLoaiSanPham = l.TenLoai
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- HÀM TỰ ĐỘNG SINH MÃ LOẠI SẢN PHẨM ---
        private string GenerateMaLoai()
        {
            try
            {
                // Tìm mã lớn nhất hiện có trong DB
                var lastLoai = db.LoaiSanPham.OrderByDescending(l => l.MaLoai).FirstOrDefault();

                if (lastLoai == null || string.IsNullOrEmpty(lastLoai.MaLoai))
                {
                    return "L01";
                }

                string lastMa = lastLoai.MaLoai;
                // Cắt chữ "L" ở đầu (độ dài 1 ký tự), lấy phần số phía sau
                if (lastMa.StartsWith("L"))
                {
                    string numberPart = lastMa.Substring(1);
                    if (int.TryParse(numberPart, out int number))
                    {
                        number++;
                        return "L" + number.ToString("D2"); // D2 để format thành 01, 02...
                    }
                }
            }
            catch (Exception)
            {
                return "L01";
            }

            return "L01";
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

            // Tự động sinh mã khi nhấn Thêm
            txtMaLoai.Text = GenerateMaLoai();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLoai.Text))
            {
                MessageBox.Show("Vui lòng chọn loại cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (MessageBox.Show("Xác nhận xóa loại sản phẩm này?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    db.ChangeTracker.Clear();

                    // Tìm loại sản phẩm theo mã
                    var loaiSP = db.LoaiSanPham.Find(txtMaLoai.Text);
                    if (loaiSP != null)
                    {
                        db.LoaiSanPham.Remove(loaiSP);
                        db.SaveChanges(); // Lưu thay đổi xuống CSDL

                        MessageBox.Show("Đã xóa thành công!");
                        LoadData();
                        ClearInput();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy loại sản phẩm trong CSDL!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Tên loại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                db.ChangeTracker.Clear();

                if (isAdding)
                {
                    // Thêm mới
                    var loaiMoi = new LoaiSanPham() // Đổi thành tên Class Entity của bạn nếu khác
                    {
                        MaLoai = txtMaLoai.Text,
                        TenLoai = txtTenLoai.Text
                    };
                    db.LoaiSanPham.Add(loaiMoi);
                    db.SaveChanges();

                    MessageBox.Show("Thêm mới thành công!");
                }
                else
                {
                    // Sửa
                    var loaiSua = db.LoaiSanPham.Find(txtMaLoai.Text);
                    if (loaiSua != null)
                    {
                        loaiSua.TenLoai = txtTenLoai.Text;

                        db.LoaiSanPham.Update(loaiSua);
                        db.SaveChanges();

                        MessageBox.Show("Cập nhật thành công!");
                    }
                }

                SetControlState(false);
                LoadData();
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                if (ex.InnerException != null) errorMsg += "\n" + ex.InnerException.Message;
                MessageBox.Show("Lỗi khi lưu: " + errorMsg, "Lỗi DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetControlState(false);
            ClearInput();
        }
    }
}