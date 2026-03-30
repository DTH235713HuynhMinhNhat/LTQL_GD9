using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace QuanLyVanPhongPham.Data
{
    public class QLCHVPPDbContext : DbContext
    {
        // 1. Nhóm Sản phẩm & Thuộc tính (5 bảng)
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<DonViTinh> DonViTinh { get; set; }
        public DbSet<NhaCungCap> NhaCungCap { get; set; }
        public DbSet<ThuongHieu> ThuongHieu { get; set; }

        // 2. Nhóm Khách hàng & Bán hàng (3 bảng)
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }

        // 3. Nhóm Nhập kho (2 bảng)
        public DbSet<PhieuNhap> PhieuNhap { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }

        // 4. Nhóm Nhân sự & Hệ thống (3 bảng)
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<ChucVu> ChucVu { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Gọi chuỗi kết nối từ file App.config
                string conn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                optionsBuilder.UseSqlServer(conn);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Chặn xóa dây chuyền từ Sản Phẩm -> Chi Tiết Phiếu Nhập
            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasOne(c => c.SanPham)
                .WithMany()
                .HasForeignKey(c => c.SanPhamID)
                .OnDelete(DeleteBehavior.Restrict);

            // Chặn xóa dây chuyền từ Phiếu Nhập -> Chi Tiết Phiếu Nhập
            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasOne(c => c.PhieuNhap)
                .WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(c => c.PhieuNhapID)
                .OnDelete(DeleteBehavior.Restrict);

            // Chặn luôn cho Chi Tiết Hóa Đơn để phòng ngừa lỗi tương tự
            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(c => c.SanPham)
                .WithMany()
                .HasForeignKey(c => c.SanPhamID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}