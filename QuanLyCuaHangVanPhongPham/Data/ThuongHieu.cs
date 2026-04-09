using System.ComponentModel.DataAnnotations;

namespace QuanLyVanPhongPham.Data
{
    public class ThuongHieu
    {
        [Key] // Đánh dấu đây là khóa chính
        [StringLength(10)]
        public string MaTH { get; set; }

        [Required]
        [StringLength(100)]
        public string TenThuongHieu { get; set; }

        // Nhớ có dòng này để tránh lỗi khi bảng chưa có sản phẩm
        public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }
}