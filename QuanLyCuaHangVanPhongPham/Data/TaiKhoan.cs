using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyVanPhongPham.Data
{
    public class TaiKhoan
    {
        [Key, ForeignKey("NhanVien")]
        public int NhanVienID { get; set; }
        [Required]
        public string TenDangNhap { get; set; }
        [Required]
        public string MatKhau { get; set; }
        public string QuyenHan { get; set; } // Admin hoặc User
        public virtual NhanVien NhanVien { get; set; }
    }
}