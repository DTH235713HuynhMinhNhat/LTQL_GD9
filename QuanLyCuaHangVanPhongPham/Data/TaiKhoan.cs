using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyVanPhongPham.Data
{
    public class TaiKhoan
    {
        [Key]
        [StringLength(20)] // Sửa thành 20 để khớp tuyệt đối với bảng NhanVien
        // Chúng ta đổi từ NhanVienID (int) sang MaNV (string) 
        // để khớp với khóa chính của bảng NhanVien
        public string MaNV { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }

        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }

        [StringLength(20)]
        public string QuyenHan { get; set; } // Admin hoặc User

        // Khai báo mối quan hệ 1-1 với bảng NhanVien
        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set; }
    }
}