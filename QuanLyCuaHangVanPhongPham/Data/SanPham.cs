using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyVanPhongPham.Data
{
    public class SanPham
    {
        public SanPham()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        [Key]
        [StringLength(10)] // Khớp chuẩn với các bảng Chi Tiết
        public string MaSP { get; set; }

        [Required]
        [StringLength(200)]
        public string TenSanPham { get; set; }

        public int SoLuong { get; set; }

        // Đã sửa sang kiểu Decimal để đồng bộ với ChiTietPhieuNhap và ChiTietHoaDon
        [Column(TypeName = "decimal(18,2)")]
        public decimal GiaNhap { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GiaBan { get; set; }

        public string HinhAnh { get; set; }
        public string MoTa { get; set; }

        // --- CÁC KHÓA NGOẠI: PHẢI CHUYỂN HẾT SANG STRING ---

        [StringLength(10)]
        public string MaLoai { get; set; }

        [StringLength(10)]
        public string MaNCC { get; set; }

        [StringLength(10)]
        public string MaDVT { get; set; }

        [StringLength(10)]
        public string MaTH { get; set; }

        // --- ĐỊNH NGHĨA MỐI QUAN HỆ (NAVIGATION PROPERTIES) ---

        [ForeignKey("MaLoai")]
        public virtual LoaiSanPham LoaiSanPham { get; set; }

        [ForeignKey("MaNCC")]
        public virtual NhaCungCap NhaCungCap { get; set; }

        [ForeignKey("MaDVT")]
        public virtual DonViTinh DonViTinh { get; set; }

        [ForeignKey("MaTH")]
        public virtual ThuongHieu ThuongHieu { get; set; }

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
    }
}