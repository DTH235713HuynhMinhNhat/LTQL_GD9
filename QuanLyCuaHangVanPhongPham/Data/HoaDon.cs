using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyVanPhongPham.Data
{
    public class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            NgayLap = DateTime.Now;
        }

        [Key]
        [StringLength(50)]
        public string MaHD { get; set; }

        public DateTime NgayLap { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TongTien { get; set; }

        [Required]
        [StringLength(20)]
        public string MaKH { get; set; } // Sửa thành MaKH

        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }

        [Required]
        [StringLength(20)]
        public string MaNV { get; set; } // Sửa thành MaNV

        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}