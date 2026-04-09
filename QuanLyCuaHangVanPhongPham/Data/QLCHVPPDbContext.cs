using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangVanPhongPham.Models;
using QuanLyVanPhongPham.Data;
using System.Configuration;

namespace QuanLyVanPhongPham.Data
{
    public class QLCHVPPDbContext : DbContext
    {
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public DbSet<DonViTinh> DonViTinh { get; set; }
        public DbSet<NhaCungCap> NhaCungCap { get; set; }
        public DbSet<ThuongHieu> ThuongHieu { get; set; }

        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDon { get; set; }

        public DbSet<PhieuNhap> PhieuNhap { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhap { get; set; }

        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<ChucVu> ChucVu { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; } // Đảm bảo bạn đã có class TaiKhoan nhé

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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
                .WithMany(s => s.ChiTietPhieuNhaps)
                .HasForeignKey(c => c.MaSP) // ĐÃ SỬA: Trỏ vào MaSP
                .OnDelete(DeleteBehavior.Restrict);

            // Chặn xóa dây chuyền từ Phiếu Nhập -> Chi Tiết Phiếu Nhập
            modelBuilder.Entity<ChiTietPhieuNhap>()
                .HasOne(c => c.PhieuNhap)
                .WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(c => c.MaPN) // ĐÃ SỬA: Trỏ vào MaPN
                .OnDelete(DeleteBehavior.Restrict);

            // Chặn xóa dây chuyền từ Sản Phẩm -> Chi Tiết Hóa Đơn
            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(c => c.SanPham)
                .WithMany(s => s.ChiTietHoaDons)
                .HasForeignKey(c => c.MaSP) // ĐÃ SỬA: Trỏ vào MaSP
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}