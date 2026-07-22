using System.Collections.Generic;
using QuanLyTinDung.DTO;

namespace QuanLyTinDung.DAL.Interfaces
{
    public interface INhanVienDAL
    {
        List<NhanVienDTO> GetAll();
        NhanVienDTO GetById(int maNhanVien);
        int Insert(NhanVienDTO nv, string matKhauHash);
        bool Update(NhanVienDTO nv);
        bool Delete(int maNhanVien);

        /// <summary>Xác thực đăng nhập, trả về NhanVienDTO nếu tên đăng nhập + mật khẩu (đã hash) khớp, ngược lại null.</summary>
        NhanVienDTO XacThuc(string tenDangNhap, string matKhauHash);

        bool KiemTraTonTaiTenDangNhap(string tenDangNhap);

        bool CapNhatMatKhau(int maNhanVien, string matKhauHashMoi);
    }
}