using System;

namespace QuanLyTinDung.DTO
{
    /// <summary>
    /// POCO ánh xạ bảng nhan_vien. KHÔNG chứa mat_khau_hash để tránh lộ hash ra
    /// các tầng không cần thiết (Form/BUS thông thường) — thao tác mật khẩu chỉ
    /// thực hiện qua các hàm riêng ở DAL (XacThuc, CapNhatMatKhau).
    /// </summary>
    public class NhanVienDTO
    {
        public int MaNhanVien { get; set; }
        public int MaChiNhanh { get; set; }
        public string HoTen { get; set; }
        public string VaiTro { get; set; }
        public decimal HanMucPheDuyet { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TrangThai { get; set; }
        public string TenDangNhap { get; set; }

        public NhanVienDTO() { }

        public NhanVienDTO(int maNhanVien, int maChiNhanh, string hoTen, string vaiTro,
            decimal hanMucPheDuyet, string soDienThoai, string email, string trangThai,
            string tenDangNhap)
        {
            MaNhanVien = maNhanVien;
            MaChiNhanh = maChiNhanh;
            HoTen = hoTen;
            VaiTro = vaiTro;
            HanMucPheDuyet = hanMucPheDuyet;
            SoDienThoai = soDienThoai;
            Email = email;
            TrangThai = trangThai;
            TenDangNhap = tenDangNhap;
        }
    }
}