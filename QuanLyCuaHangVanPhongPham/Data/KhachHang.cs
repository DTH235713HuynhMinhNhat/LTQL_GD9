using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVanPhongPham.Data
{
    public class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(20)] // BẮT BUỘC: Phải là 20 để khớp với bảng HoaDon
        public string MaKH { get; set; }
        public string TenKhachHang { get; set; }

        [StringLength(15)]
        public string SoDienThoai { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        public int DiemTichLuy { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}