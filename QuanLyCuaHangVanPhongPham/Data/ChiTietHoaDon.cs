using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVanPhongPham.Data
{
    public class ChiTietHoaDon
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string MaHD { get; set; }

        [ForeignKey("MaHD")]
        public virtual HoaDon HoaDon { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSP { get; set; } // Đã sửa thành MaSP

        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DonGia { get; set; }
    }
}