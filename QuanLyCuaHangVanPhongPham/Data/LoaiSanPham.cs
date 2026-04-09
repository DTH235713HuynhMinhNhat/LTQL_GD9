using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Thêm thư viện này

namespace QuanLyVanPhongPham.Data
{
    [Table("LoaiSanPham")]
    public class LoaiSanPham
    {
        public LoaiSanPham()
        {
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(10)] // BẮT BUỘC: Phải là 10 để khớp với bảng SanPham
        public string MaLoai { get; set; }

        [Required]
        [StringLength(100)] // NÊN SỬA: Tên loại nên để 100 ký tự (10 là quá ngắn)
        public string TenLoai { get; set; }

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}