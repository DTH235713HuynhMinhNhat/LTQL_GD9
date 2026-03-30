using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyVanPhongPham.Data
{
    public class ThuongHieu
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tên thương hiệu không được để trống")]
        [StringLength(100)]
        public string TenThuongHieu { get; set; }

        public string MoTa { get; set; }

        // Một thương hiệu có thể có nhiều sản phẩm (Mối quan hệ 1-N)
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}