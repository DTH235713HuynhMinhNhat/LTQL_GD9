using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuanLyVanPhongPham.Data;

namespace QuanLyCuaHangVanPhongPham.Models // Đổi lại thành namespace của bạn nếu cần
{
    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        [StringLength(10)] // ĐIỂM QUAN TRỌNG: Độ dài 10 để khớp với bảng NhanVien
        public string MaChucVu { get; set; }

        [Required]
        [StringLength(50)] // Tên chức vụ thì để tầm 50 ký tự là thoải mái
        public string TenChucVu { get; set; }

        // Navigation property: Thể hiện mối quan hệ 1 Chức Vụ có nhiều Nhân Viên
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}