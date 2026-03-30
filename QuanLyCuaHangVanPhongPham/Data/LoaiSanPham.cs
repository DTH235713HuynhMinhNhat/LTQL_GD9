using System.Collections.Generic;

namespace QuanLyVanPhongPham.Data
{
    public class LoaiSanPham
    {
        public int ID { get; set; }
        public string TenLoai { get; set; }

        // 1 loại sản phẩm có nhiều sản phẩm
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}