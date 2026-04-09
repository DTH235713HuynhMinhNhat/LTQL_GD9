using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using QuanLyVanPhongPham.Data;

namespace QuanLyVanPhongPham.Forms
{
    public partial class frmChiTietSanPham : Form
    {
        private QLCHVPPDbContext db = new QLCHVPPDbContext();
        private string _maSP; // Chứa mã SP được truyền từ Form cha (nếu là Sửa)

        public frmChiTietSanPham(string maSP = null)
        {
            InitializeComponent();
            _maSP = maSP;

            // Đăng ký sự kiện
            this.Load += frmChiTietSanPham_Load;
            btnLuu.Click += btnLuu_Click;
            btnHuy.Click += (s, e) => this.Close();
            btnChonAnh.Click += BtnChonAnh_Click;

            txtGiaBan.KeyPress += OnlyNumber_KeyPress;
            txtSoLuong.KeyPress += OnlyNumber_KeyPress;
            txtGiaBan.TextChanged += MoneyFormat_TextChanged;
        }

        private void frmChiTietSanPham_Load(object sender, EventArgs e)
        {
            LoadComboBox();

            if (!string.IsNullOrEmpty(_maSP))
            {
                // Trạng thái: SỬA SẢN PHẨM
                lblTitle.Text = "CHỈNH SỬA SẢN PHẨM";
                txtMaSP.Enabled = false; // Khóa mã SP không cho sửa
                LoadProductData();
            }
            else
            {
                // Trạng thái: THÊM MỚI
                lblTitle.Text = "THÊM MỚI SẢN PHẨM";

                // Sinh mã tự động và khóa Textbox lại để bảo vệ cấu trúc mã
                txtMaSP.Text = SinhMaSanPhamTuDong();
                txtMaSP.Enabled = false;

                txtGiaBan.Text = "0";
                txtSoLuong.Text = "0";
            }
        }

        private void LoadComboBox()
        {
            try
            {
                // Load danh sách dữ liệu cho ComboBox
                cboLoaiSP.DataSource = db.LoaiSanPham.AsNoTracking().ToList();
                cboLoaiSP.DisplayMember = "TenLoai";
                cboLoaiSP.ValueMember = "MaLoai";
                cboLoaiSP.SelectedIndex = -1;

                cboDVT.DataSource = db.DonViTinh.AsNoTracking().ToList();
                cboDVT.DisplayMember = "TenDonVi";
                cboDVT.ValueMember = "MaDVT";
                cboDVT.SelectedIndex = -1;

                cboThuongHieu.DataSource = db.ThuongHieu.AsNoTracking().ToList();
                cboThuongHieu.DisplayMember = "TenThuongHieu";
                cboThuongHieu.ValueMember = "MaTH";
                cboThuongHieu.SelectedIndex = -1;

                cboNhaCungCap.DataSource = db.NhaCungCap.AsNoTracking().ToList();
                cboNhaCungCap.DisplayMember = "TenNhaCungCap";
                cboNhaCungCap.ValueMember = "MaNCC";
                cboNhaCungCap.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductData()
        {
            var sp = db.SanPham.Find(_maSP);
            if (sp != null)
            {
                txtMaSP.Text = sp.MaSP;
                txtTenSP.Text = sp.TenSanPham;

                // Format tiền tệ
                txtGiaBan.Text = sp.GiaBan.ToString("N0", CultureInfo.CreateSpecificCulture("vi-VN"));
                txtSoLuong.Text = sp.SoLuong.ToString();

                // Gán ComboBox
                cboLoaiSP.SelectedValue = sp.MaLoai ?? (object)DBNull.Value;
                cboDVT.SelectedValue = sp.MaDVT ?? (object)DBNull.Value;
                cboThuongHieu.SelectedValue = sp.MaTH ?? (object)DBNull.Value;
                cboNhaCungCap.SelectedValue = sp.MaNCC ?? (object)DBNull.Value;

                // Gán hình ảnh
                if (!string.IsNullOrEmpty(sp.HinhAnh))
                {
                    try { ptbHinhAnh.ImageLocation = sp.HinhAnh; }
                    catch { /* Bỏ qua nếu đường dẫn ảnh bị lỗi */ }
                }
            }
        }

        private void MoneyFormat_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (string.IsNullOrEmpty(txt.Text)) return;

            try
            {
                // Giữ lại các chữ số, bỏ đi các dấu phẩy/chấm
                string value = new string(txt.Text.Where(char.IsDigit).ToArray());
                if (decimal.TryParse(value, out decimal result))
                {
                    txt.TextChanged -= MoneyFormat_TextChanged;
                    txt.Text = result.ToString("N0", CultureInfo.CreateSpecificCulture("vi-VN"));
                    txt.SelectionStart = txt.Text.Length;
                    txt.TextChanged += MoneyFormat_TextChanged;
                }
            }
            catch { }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra các dữ liệu bắt buộc nhập
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Mã sản phẩm không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSP.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return;
            }

            try
            {
                // Khóa an toàn: Xóa cache tracking để tránh lỗi khi lưu lại sau một lần lỗi trước đó
                db.ChangeTracker.Clear();

                // 2. Chuyển đổi dữ liệu số lượng, giá bán
                string strGiaBan = new string(txtGiaBan.Text.Where(char.IsDigit).ToArray());
                decimal giaBan = string.IsNullOrEmpty(strGiaBan) ? 0 : decimal.Parse(strGiaBan);
                int soLuong = string.IsNullOrEmpty(txtSoLuong.Text) ? 0 : int.Parse(txtSoLuong.Text);

                bool isAdding = string.IsNullOrEmpty(_maSP);

                if (isAdding)
                {
                    // --- THÊM MỚI SẢN PHẨM ---
                    if (db.SanPham.Any(s => s.MaSP == txtMaSP.Text.Trim()))
                    {
                        MessageBox.Show("Mã sản phẩm này đã tồn tại, vui lòng nhập mã khác!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var spMoi = new SanPham()
                    {
                        MaSP = txtMaSP.Text.Trim(),
                        TenSanPham = txtTenSP.Text.Trim(),
                        GiaBan = giaBan,
                        SoLuong = soLuong,
                        MaLoai = cboLoaiSP.SelectedValue?.ToString(),
                        MaDVT = cboDVT.SelectedValue?.ToString(),
                        MaTH = cboThuongHieu.SelectedValue?.ToString(),
                        MaNCC = cboNhaCungCap.SelectedValue?.ToString(),
                        HinhAnh = ptbHinhAnh.ImageLocation,

                        // FIX LỖI SỐ 1: Gán rỗng để Database không báo lỗi NULL
                        MoTa = ""
                    };

                    db.SanPham.Add(spMoi);
                    db.SaveChanges();
                    MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // --- CẬP NHẬT SẢN PHẨM ---
                    var spUpdate = db.SanPham.Find(_maSP);
                    if (spUpdate != null)
                    {
                        spUpdate.TenSanPham = txtTenSP.Text.Trim();
                        spUpdate.GiaBan = giaBan;
                        spUpdate.SoLuong = soLuong;
                        spUpdate.MaLoai = cboLoaiSP.SelectedValue?.ToString();
                        spUpdate.MaDVT = cboDVT.SelectedValue?.ToString();
                        spUpdate.MaTH = cboThuongHieu.SelectedValue?.ToString();
                        spUpdate.MaNCC = cboNhaCungCap.SelectedValue?.ToString();
                        spUpdate.HinhAnh = ptbHinhAnh.ImageLocation;

                        // FIX LỖI SỐ 1: Gán rỗng để Database không báo lỗi NULL khi sửa
                        spUpdate.MoTa = "";

                        db.SaveChanges();
                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Lưu thành công thì đóng Form
                this.Close();
            }
            catch (Exception ex)
            {
                string errMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + errMsg, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn không cho nhập chữ vào ô số
            }
        }

        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "Chọn hình ảnh sản phẩm";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ptbHinhAnh.ImageLocation = ofd.FileName;
                }
            }
        }

        private string SinhMaSanPhamTuDong()
        {
            try
            {
                var lastSP = db.SanPham
                               .Where(s => s.MaSP.StartsWith("SP"))
                               .OrderByDescending(s => s.MaSP)
                               .FirstOrDefault();

                if (lastSP == null)
                {
                    return "SP001";
                }

                string lastMa = lastSP.MaSP;
                string numberPart = lastMa.Substring(2);

                if (int.TryParse(numberPart, out int number))
                {
                    number++;
                    return "SP" + number.ToString("D3");
                }

                return "SP001";
            }
            catch
            {
                return "SP" + DateTime.Now.ToString("yyMMddHHmm");
            }
        }
    }
}