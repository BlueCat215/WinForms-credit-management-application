using System;
using System.Security.Cryptography;
using System.Text;
using QuanLyTinDung.Common;
using QuanLyTinDung.DAL;
using QuanLyTinDung.DAL.Interfaces;
using QuanLyTinDung.DTO;
using QuanLyTinDung.Security;

namespace QuanLyTinDung.BUS
{
    public class NhanVienBUS
    {
        private readonly INhanVienDAL _nhanVienDAL;

        public NhanVienBUS()
        {
            _nhanVienDAL = new NhanVienDAL();
        }

        /// <summary>Hash mật khẩu bằng SHA256, trả về chuỗi hex thường (lowercase).</summary>
        private string HashMatKhau(string matKhauGoc)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(matKhauGoc));
                var sb = new StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        /// <summary>
        /// RÀNG BUỘC: đăng nhập thành công chỉ khi tên đăng nhập + mật khẩu khớp
        /// VÀ trang_thai = ACTIVE. Nếu tài khoản tồn tại nhưng bị khoá (INACTIVE) thì
        /// phải báo rõ "Tài khoản đã bị khoá" thay vì báo sai tên đăng nhập/mật khẩu.
        /// </summary>
        public KetQuaXuLy DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                return KetQuaXuLy.That_Bai("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");

            string matKhauHash = HashMatKhau(matKhau);
            NhanVienDTO nv = _nhanVienDAL.XacThuc(tenDangNhap.Trim(), matKhauHash);

            if (nv == null)
                return KetQuaXuLy.That_Bai("Tên đăng nhập hoặc mật khẩu không đúng.");

            if (string.Equals(nv.TrangThai, TrangThaiNhanVien.INACTIVE.ToString(), StringComparison.OrdinalIgnoreCase))
                return KetQuaXuLy.That_Bai("Tài khoản đã bị khoá. Vui lòng liên hệ quản lý.");

            UserSession.Instance.DangNhap(nv);
            return KetQuaXuLy.Thanh_Cong("Đăng nhập thành công.", nv);
        }
    }
}