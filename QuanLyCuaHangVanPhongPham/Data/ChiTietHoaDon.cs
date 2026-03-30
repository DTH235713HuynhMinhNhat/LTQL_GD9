using System.ComponentModel.DataAnnotations;

namespace QuanLyVanPhongPham.Data
{
    public class ChiTietHoaDon
    {
        [Key]
        public int ID { get; set; }
        public int HoaDonID { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public int SanPhamID { get; set; }
        public virtual SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; } // Giá lúc bán
    }
}