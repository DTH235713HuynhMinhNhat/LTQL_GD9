using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVanPhongPham.Data
{
    public class HoaDon
    {
        [Key]
        public int ID { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public int KhachHangID { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public int NhanVienID { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}