using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyVanPhongPham.Data
{
    public class ChiTietPhieuNhap
    {
        [Key]
        public int ID { get; set; } // Giữ ID tự tăng (Surrogate Key) là một lựa chọn an toàn và dễ code

        [Required]
        [MaxLength(20)] // Hoặc [StringLength(20)] tùy bạn đang dùng cái nào
        public string MaPN { get; set; }

        [ForeignKey("MaPN")]
        public virtual PhieuNhap PhieuNhap { get; set; }

        [Required]
        [StringLength(10)] 
        public string MaSP { get; set; }

        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "decimal(18,2)")] // Bắt buộc thêm để SQL Server hiểu đúng định dạng tiền tệ
        public decimal GiaNhap { get; set; }
    }
}