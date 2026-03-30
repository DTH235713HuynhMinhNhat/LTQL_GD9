using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVanPhongPham.Data
{
    public class NhanVien
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public int ChucVuID { get; set; }
        public virtual ChucVu ChucVu { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}