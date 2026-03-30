using System.ComponentModel.DataAnnotations;

namespace QuanLyVanPhongPham.Data
{
    public class ChiTietPhieuNhap
    {
        [Key]
        public int ID { get; set; }

        public int PhieuNhapID { get; set; }
        public virtual PhieuNhap PhieuNhap { get; set; }

        public int SanPhamID { get; set; }
        public virtual SanPham SanPham { get; set; }

        public int SoLuong { get; set; }

        public decimal GiaNhap { get; set; }
    }
}