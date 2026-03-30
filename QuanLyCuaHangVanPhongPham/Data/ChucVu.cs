using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVanPhongPham.Data
{
    public class ChucVu
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string TenChucVu { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}