using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVanPhongPham.Data
{
    public class PhieuNhap
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime NgayNhap { get; set; }

        public decimal TongTien { get; set; }

        // Khóa ngoại liên kết tới Nhà cung cấp
        public int NhaCungCapID { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }

        // Danh sách chi tiết các mặt hàng trong phiếu này
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}