using System.Collections.Generic;

namespace QuanLyTinDung.Security
{
    /// <summary>
    /// Ma trận phân quyền: vai trò -> tập hợp module được phép thao tác.
    /// Dùng để ẩn/khoá menu ở FrmMain và chặn nghiệp vụ ở tầng BUS.
    /// </summary>
    public static class PhanQuyenHelper
    {
        private static readonly Dictionary<VaiTro, HashSet<string>> MaTranQuyen =
            new Dictionary<VaiTro, HashSet<string>>
            {
                [VaiTro.NHAN_VIEN_TIN_DUNG] = new HashSet<string>
                {
                    "HoSoVay", "DanhMuc", "BaoCao"
                },
                [VaiTro.CHUYEN_VIEN_DINH_GIA] = new HashSet<string>
                {
                    "TaiSan_DinhGia"
                },
                [VaiTro.QUAN_LY_CHI_NHANH] = new HashSet<string>
                {
                    "HoSoVay", "PheDuyet", "DanhMuc", "BaoCao"
                },
                [VaiTro.GIAO_DICH_VIEN] = new HashSet<string>
                {
                    "GiaiNgan_HopDong", "ThuNo_NhacNo", "TatToan"
                },
                [VaiTro.BAN_TIN_DUNG_HOI_SO] = new HashSet<string>
                {
                    "PheDuyet", "BaoCao", "PhanQuyen"
                },
                [VaiTro.NHAN_VIEN_XU_LY_NO] = new HashSet<string>
                {
                    "TaiCoCau_XuLyNoXau", "ThuNo_NhacNo", "BaoCao"
                }
            };

        /// <summary>
        /// Kiểm tra vai trò có được phép thao tác module hay không.
        /// </summary>
        public static bool DuocPhep(VaiTro vaiTro, string tenModule)
        {
            if (!MaTranQuyen.ContainsKey(vaiTro)) return false;
            return MaTranQuyen[vaiTro].Contains(tenModule);
        }
    }
}