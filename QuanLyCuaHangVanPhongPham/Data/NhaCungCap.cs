using System.Collections.Generic;

namespace QuanLyVanPhongPham.Data
{
    public class NhaCungCap
    {
        public int ID { get; set; }
        public string TenNhaCungCap { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }

        // 1 nhà cung cấp cung cấp nhiều sản phẩm
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}