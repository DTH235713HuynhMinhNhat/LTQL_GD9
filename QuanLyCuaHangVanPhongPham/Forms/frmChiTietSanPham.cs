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
        private int? _idSanPham;

        public frmChiTietSanPham(int? id = null)
        {
            InitializeComponent();
            _idSanPham = id;

            // Đăng ký sự kiện
            this.Load += frmChiTietSanPham_Load;
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += (s, e) => this.Close();
            btnChonAnh.Click += BtnChonAnh_Click;

            txtGiaBan.KeyPress += OnlyNumber_KeyPress;
            txtSoLuong.KeyPress += OnlyNumber_KeyPress;
            txtGiaBan.TextChanged += MoneyFormat_TextChanged;
        }

        private void frmChiTietSanPham_Load(object sender, EventArgs e)
        {
            LoadComboBox(); // Phải chạy trước để có dữ liệu cho SelectedValue phía dưới

            if (_idSanPham != null)
            {
                lblTitle.Text = "CHỈNH SỬA SẢN PHẨM";
                LoadProductData();
            }
            else
            {
                lblTitle.Text = "THÊM MỚI SẢN PHẨM";
                txtGiaBan.Text = "0";
                txtSoLuong.Text = "0";
            }
        }

        private void LoadComboBox()
        {
            try
            {

                var dsLoai = db.LoaiSanPham.AsNoTracking().ToList();
                MessageBox.Show($"Đã truy vấn CSDL: Tìm thấy {dsLoai.Count} Loại Sản Phẩm!");
                // Load Loại Sản Phẩm
                
                cboLoaiSP.DataSource = dsLoai;
                cboLoaiSP.DisplayMember = "TenLoai";
                cboLoaiSP.ValueMember = "ID";
                cboLoaiSP.SelectedIndex = -1;

                // Load Đơn Vị Tính
                var dsDVT = db.DonViTinh.AsNoTracking().ToList();
                cboDVT.DataSource = dsDVT;
                cboDVT.DisplayMember = "TenDonVi";
                cboDVT.ValueMember = "ID";
                cboDVT.SelectedIndex = -1;

                // Load Thương Hiệu
                var dsTH = db.ThuongHieu.AsNoTracking().ToList();
                cboThuongHieu.DataSource = dsTH;
                cboThuongHieu.DisplayMember = "TenThuongHieu";
                cboThuongHieu.ValueMember = "ID";
                cboThuongHieu.SelectedIndex = -1;

                // Load Nhà Cung Cấp
                var dsNCC = db.NhaCungCap.AsNoTracking().ToList();
                cboNhaCungCap.DataSource = dsNCC;
                cboNhaCungCap.DisplayMember = "TenNCC";
                cboNhaCungCap.ValueMember = "ID";
                cboNhaCungCap.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductData()
        {
            var sp = db.SanPham.Find(_idSanPham);
            if (sp != null)
            {
                txtTenSP.Text = sp.TenSanPham;

                // Gán giá trị trước khi định dạng
                txtGiaBan.Text = sp.GiaBan.ToString();
                txtSoLuong.Text = sp.SoLuong.ToString();

                // Quan trọng: Gán đúng ID vào SelectedValue
                cboLoaiSP.SelectedValue = sp.LoaiSanPhamID;
                cboDVT.SelectedValue = sp.DonViTinhID;
                cboThuongHieu.SelectedValue = sp.ThuongHieuID;
                cboNhaCungCap.SelectedValue = sp.NhaCungCapID;

                if (!string.IsNullOrEmpty(sp.HinhAnh))
                {
                    try
                    {
                        ptbHinhAnh.ImageLocation = sp.HinhAnh;
                    }
                    catch { /* Bỏ qua nếu đường dẫn ảnh cũ bị lỗi/không tồn tại */ }
                }
            }
        }

        private void MoneyFormat_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (string.IsNullOrEmpty(txt.Text)) return;

            try
            {
                // Xóa tất cả ký tự không phải số
                string value = new string(txt.Text.Where(char.IsDigit).ToArray());
                if (double.TryParse(value, out double result))
                {
                    // Định dạng theo chuẩn Việt Nam (dấu chấm phân cách hàng nghìn)
                    txt.TextChanged -= MoneyFormat_TextChanged; // Tạm tắt event để tránh lặp vô tận
                    txt.Text = result.ToString("N0", CultureInfo.CreateSpecificCulture("vi-VN"));
                    txt.SelectionStart = txt.Text.Length;
                    txt.TextChanged += MoneyFormat_TextChanged; // Bật lại event
                }
            }
            catch { }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validation cơ bản (Đã bổ sung thêm kiểm tra tất cả các ô chọn)
                if (string.IsNullOrWhiteSpace(txtTenSP.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboLoaiSP.SelectedValue == null || cboDVT.SelectedValue == null ||
                    cboThuongHieu.SelectedValue == null || cboNhaCungCap.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn đầy đủ: Loại SP, Đơn vị tính, Thương hiệu và Nhà cung cấp!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Chuẩn bị đối tượng
                SanPham sp = (_idSanPham == null) ? new SanPham() : db.SanPham.Find(_idSanPham);

                sp.TenSanPham = txtTenSP.Text.Trim();

                // Xử lý giá bán an toàn (phòng trường hợp người dùng copy/paste lỗi)
                string giaNet = new string(txtGiaBan.Text.Where(char.IsDigit).ToArray());
                sp.GiaBan = string.IsNullOrEmpty(giaNet) ? 0 : int.Parse(giaNet);

                // Xử lý số lượng an toàn
                sp.SoLuong = string.IsNullOrWhiteSpace(txtSoLuong.Text) ? 0 : int.Parse(txtSoLuong.Text.Trim());

                // Lấy ID an toàn từ ComboBox
                sp.LoaiSanPhamID = Convert.ToInt32(cboLoaiSP.SelectedValue);
                sp.DonViTinhID = Convert.ToInt32(cboDVT.SelectedValue);
                sp.ThuongHieuID = Convert.ToInt32(cboThuongHieu.SelectedValue);
                sp.NhaCungCapID = Convert.ToInt32(cboNhaCungCap.SelectedValue);

                sp.HinhAnh = ptbHinhAnh.ImageLocation;

                // 3. Thực thi lưu trữ
                if (_idSanPham == null)
                {
                    db.SanPham.Add(sp);
                }

                db.SaveChanges();

                MessageBox.Show("Lưu sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close(); // Chủ động đóng Form Chi Tiết lại sau khi thêm xong
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép nhập số và phím Backspace (điều hướng xóa)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Thêm bộ lọc để người dùng chỉ có thể chọn file ảnh
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                ofd.Title = "Chọn hình ảnh sản phẩm";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ptbHinhAnh.ImageLocation = ofd.FileName;
                }
            }
        }
    }
}