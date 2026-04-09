using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Thêm để dùng [Table]

namespace QuanLyVanPhongPham.Data
{
    [Table("DonViTinh")]
    public class DonViTinh
    {
        public DonViTinh()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(10)] // BẮT BUỘC: Phải là 10 để khớp với bảng SanPham
        public string MaDVT { get; set; }

        [Required]
        [StringLength(50)] // NÊN SỬA: Tên đơn vị (Cái, Thùng, Ram...) để 50 cho thoải mái
        public string TenDonVi { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}