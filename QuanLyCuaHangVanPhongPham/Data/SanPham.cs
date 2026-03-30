using System.Collections.Generic; // Đừng quên namespace này

namespace QuanLyVanPhongPham.Data
{
    public class SanPham
    {
        // Constructor để tránh lỗi Null
        public SanPham()
        {
            TenSanPham = string.Empty;
            HinhAnh = string.Empty;
            MoTa = string.Empty;

            // Khởi tạo các danh sách liên quan (nếu có bảng ChiTiet)
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        public int ID { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public int GiaNhap { get; set; }
        public int GiaBan { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }

        // Các khóa ngoại
        public int LoaiSanPhamID { get; set; }
        public int NhaCungCapID { get; set; }
        public int DonViTinhID { get; set; }
        public int ThuongHieuID { get; set; }

        // Quan hệ 1-n (Một sản phẩm thuộc về một...)
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual DonViTinh DonViTinh { get; set; }
        public virtual ThuongHieu ThuongHieu { get; set; }

        // Quan hệ ngược lại (Một sản phẩm có thể nằm trong nhiều...)
        // Bổ sung các dòng này ... bạn có bảng chi tiết hóa đơn/phiếu nhập
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}