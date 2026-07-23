using System;

namespace QuanLyTinDung.DTO
{
    public class KhachHangDTO
    {
        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string SoCmndCccd { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string HsChungMinhThuNhap { get; set; }
        public DateTime NgayTao { get; set; }

        public KhachHangDTO() { }

        public KhachHangDTO(int maKhachHang, string hoTen, string soCmndCccd, DateTime ngaySinh,
            string diaChi, string soDienThoai, string email, string hsChungMinhThuNhap, DateTime ngayTao)
        {
            MaKhachHang = maKhachHang;
            HoTen = hoTen;
            SoCmndCccd = soCmndCccd;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
            HsChungMinhThuNhap = hsChungMinhThuNhap;
            NgayTao = ngayTao;
        }
    }
}