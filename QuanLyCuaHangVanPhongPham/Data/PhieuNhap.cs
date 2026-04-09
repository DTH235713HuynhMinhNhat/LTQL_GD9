using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyVanPhongPham.Data
{
    public class PhieuNhap
    {
        public PhieuNhap()
        {
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        [Key]
        [MaxLength(20)] 
        public string MaPN { get; set; }

        [Required]
        public DateTime NgayNhap { get; set; }

        public decimal TongTien { get; set; }

        // Khóa ngoại liên kết với Nhà Cung Cấp
        [StringLength(10)]
        public string MaNCC { get; set; } // Đổi từ int NhaCungCapID sang string MaNCC

        [ForeignKey("MaNCC")]
        public virtual NhaCungCap NhaCungCap { get; set; }

        // Danh sách chi tiết phiếu nhập đi kèm
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}