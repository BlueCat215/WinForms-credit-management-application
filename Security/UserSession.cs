using System;
using QuanLyTinDung.DTO;

namespace QuanLyTinDung.Security
{
    /// <summary>
    /// Singleton lưu thông tin nhân viên đang đăng nhập trong phiên làm việc hiện tại.
    /// </summary>
    public sealed class UserSession
    {
        private static readonly Lazy<UserSession> _instance =
            new Lazy<UserSession>(() => new UserSession());

        public static UserSession Instance => _instance.Value;

        private UserSession() { }

        public int MaNhanVien { get; private set; }
        public string HoTen { get; private set; }
        public VaiTro VaiTro { get; private set; }
        public int MaChiNhanh { get; private set; }
        public decimal HanMucPheDuyet { get; private set; }
        public bool DaDangNhap { get; private set; }

        public void DangNhap(NhanVienDTO nv)
        {
            if (nv == null)
                throw new ArgumentNullException(nameof(nv));

            MaNhanVien = nv.MaNhanVien;
            HoTen = nv.HoTen;
            VaiTro = (VaiTro)Enum.Parse(typeof(VaiTro), nv.VaiTro);
            MaChiNhanh = nv.MaChiNhanh;
            HanMucPheDuyet = nv.HanMucPheDuyet;
            DaDangNhap = true;
        }

        public void DangXuat()
        {
            MaNhanVien = 0;
            HoTen = null;
            MaChiNhanh = 0;
            HanMucPheDuyet = 0;
            DaDangNhap = false;
        }
    }
}