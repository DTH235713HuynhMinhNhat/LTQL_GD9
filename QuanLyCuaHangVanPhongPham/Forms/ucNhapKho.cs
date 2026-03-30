using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyVanPhongPham.Data;

namespace QuanLyCuaHangVanPhongPham.Forms
{
    public partial class ucNhapKho : UserControl
    {
        private DataTable dtChiTiet;

        public ucNhapKho()
        {
            InitializeComponent();
        }

        private void ucNhapKho_Load(object sender, EventArgs e)
        {
            TaoPhieuMoi();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            try
            {
                using (var db = new QLCHVPPDbContext())
                {
                    // 1. Load Nhà cung cấp an toàn
                    var listNCC = db.NhaCungCap.ToList();
                    if (listNCC.Count > 0)
                    {
                        cboNhaCungCap.DataSource = listNCC;
                        cboNhaCungCap.DisplayMember = "TenNCC";
                        cboNhaCungCap.ValueMember = "ID";
                    }
                    else
                    {
                        cboNhaCungCap.DataSource = null;
                        cboNhaCungCap.Text = "Chưa có dữ liệu NCC!";
                    }

                    // 2. Load Sản phẩm an toàn
                    var listSP = db.SanPham.ToList();
                    if (listSP.Count > 0)
                    {
                        cboSanPham.DataSource = listSP;
                        cboSanPham.DisplayMember = "TenSanPham";
                        cboSanPham.ValueMember = "ID";
                    }
                    else
                    {
                        cboSanPham.DataSource = null;
                        cboSanPham.Text = "Chưa có SP nào!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaoPhieuMoi()
        {
            // Hiển thị mã tạm thời cho người dùng xem
            txtMaPN.Text = "PN_" + DateTime.Now.ToString("yyyyMMdd_HHmm");
            dtpNgayNhap.Value = DateTime.Now;

            dtChiTiet = new DataTable();
            dtChiTiet.Columns.Add("Mã SP");
            dtChiTiet.Columns.Add("Tên Sản Phẩm");
            dtChiTiet.Columns.Add("Số Lượng", typeof(int));
            dtChiTiet.Columns.Add("Giá Nhập", typeof(decimal));
            dtChiTiet.Columns.Add("Thành Tiền", typeof(decimal));

            dgvChiTietNhap.DataSource = dtChiTiet;
            TinhTongTien();
        }

        private void TinhTongTien()
        {
            if (dtChiTiet == null || dtChiTiet.Rows.Count == 0)
            {
                txtTongTien.Text = "0 VNĐ";
                return;
            }
            decimal tongTien = dtChiTiet.AsEnumerable().Sum(r => r.Field<decimal>("Thành Tiền"));
            txtTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn sản phẩm chưa
            if (cboSanPham.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoLuong.Text) || string.IsNullOrWhiteSpace(txtGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập Số lượng và Giá nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int soLuong = int.Parse(txtSoLuong.Text);
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text);
                string maSP = cboSanPham.SelectedValue.ToString();
                string tenSP = cboSanPham.Text;

                dtChiTiet.Rows.Add(maSP, tenSP, soLuong, giaNhap, soLuong * giaNhap);
                TinhTongTien();

                txtSoLuong.Clear();
                txtGiaNhap.Clear();
            }
            catch { MessageBox.Show("Số lượng hoặc giá nhập không hợp lệ (Phải là số)!"); }
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            if (dtChiTiet.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong lưới chi tiết!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem đã chọn nhà cung cấp chưa
            if (cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận lưu phiếu nhập và cập nhật kho?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var db = new QLCHVPPDbContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Tạo đối tượng PhieuNhap chính
                            var pn = new PhieuNhap
                            {
                                NgayNhap = dtpNgayNhap.Value,
                                NhaCungCapID = Convert.ToInt32(cboNhaCungCap.SelectedValue),
                                TongTien = dtChiTiet.AsEnumerable().Sum(r => r.Field<decimal>("Thành Tiền"))
                            };
                            db.PhieuNhap.Add(pn);
                            db.SaveChanges(); // SQL sẽ tự động sinh ID cho pn

                            // 2. Lưu Chi Tiết Phiếu Nhập & Cập nhật tồn kho
                            foreach (DataRow row in dtChiTiet.Rows)
                            {
                                int idSP = Convert.ToInt32(row["Mã SP"]);
                                int sl = Convert.ToInt32(row["Số Lượng"]);

                                var ctpn = new ChiTietPhieuNhap
                                {
                                    PhieuNhapID = pn.ID, // Lấy ID vừa được tự sinh
                                    SanPhamID = idSP,
                                    SoLuong = sl,
                                    GiaNhap = (decimal)row["Giá Nhập"]
                                };
                                db.ChiTietPhieuNhap.Add(ctpn);

                                // Cập nhật số lượng tồn kho trong bảng SanPham
                                var sp = db.SanPham.Find(idSP);
                                if (sp != null)
                                {
                                    sp.SoLuong += sl;
                                }
                            }
                            db.SaveChanges();
                            transaction.Commit();

                            MessageBox.Show("Lưu thành công vào SQL Server!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            TaoPhieuMoi();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.CurrentRow != null)
            {
                dtChiTiet.Rows.RemoveAt(dgvChiTietNhap.CurrentRow.Index);
                TinhTongTien();
            }
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy phiếu hiện tại? Các thay đổi sẽ không được lưu.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                TaoPhieuMoi();
        }
    }
}