using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace QuanLyTinDung.DTO
{
    public class ChiNhanhDTO
    {
        public int MaChiNhanh { get; set; }
        public string TenChiNhanh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayTao { get; set; }

        public ChiNhanhDTO() { }

        public ChiNhanhDTO(int maChiNhanh, string tenChiNhanh, string diaChi, string soDienThoai, DateTime ngayTao)
        {
            MaChiNhanh = maChiNhanh;
            TenChiNhanh = tenChiNhanh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            NgayTao = ngayTao;
        }
    }
}
