using System.Collections.Generic;

namespace QuanLyVanPhongPham.Data
{
    public class DonViTinh
    {
        public int ID { get; set; }
        public string TenDonVi { get; set; }

        // 1 đơn vị tính áp dụng cho nhiều sản phẩm
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}