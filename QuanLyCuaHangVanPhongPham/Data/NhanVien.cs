using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuanLyCuaHangVanPhongPham.Models;

namespace QuanLyVanPhongPham.Data
{
    [Table("NhanVien")] // Đảm bảo mapping đúng tên bảng
    public class NhanVien
    {
        [Key]
        [StringLength(20)]
        public string MaNV { get; set; }

        [Required]
        [StringLength(100)] // ĐÃ SỬA: Tăng lên 100 để chứa được họ tên đầy đủ
        public string HoTen { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(15)]
        public string DiaChi { get; set; }


        [Required]
        [StringLength(10)] // GIỮ NGUYÊN 10: Để khớp với MaChucVu bên bảng ChucVu
        public string MaChucVu { get; set; }

        [ForeignKey("MaChucVu")]
        public virtual ChucVu ChucVu { get; set; }

        // Mối quan hệ 1-1 với TaiKhoan (nếu có)
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}