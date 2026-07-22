namespace QuanLyTinDung.Security
{
    /// <summary>
    /// Ánh xạ 1-1 với Common.VaiTroNhanVien, dùng riêng trong tầng Security/PhanQuyen
    /// để tách biệt phụ thuộc giữa Security và Common nếu sau này cần mở rộng.
    /// </summary>
    public enum VaiTro
    {
        NHAN_VIEN_TIN_DUNG,
        CHUYEN_VIEN_DINH_GIA,
        QUAN_LY_CHI_NHANH,
        GIAO_DICH_VIEN,
        BAN_TIN_DUNG_HOI_SO,
        NHAN_VIEN_XU_LY_NO
    }
}