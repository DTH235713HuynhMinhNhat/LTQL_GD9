using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVanPhongPham.Data
{
    public class KhachHang
    {
        [Key]
        public int ID { get; set; }
        [Required, StringLength(100)]
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public int DiemTichLuy { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}