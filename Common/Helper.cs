using System;
using System.Globalization;

namespace QuanLyTinDung.Common
{
    /// <summary>
    /// Các hàm tiện ích dùng chung: format tiền, format ngày, sinh mã tự động.
    /// </summary>
    public static class Helper
    {
        private static readonly Random _random = new Random();

        public static string FormatTien(decimal soTien)
        {
            return soTien.ToString("#,##0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
        }

        public static string FormatNgay(DateTime ngay)
        {
            return ngay.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Sinh số hợp đồng dạng HD-yyyyMMdd-XXXX (XXXX là số ngẫu nhiên 4 chữ số).
        /// LƯU Ý: đây là sinh mã tạm thời phía client; nếu cần đảm bảo không trùng tuyệt đối
        /// khi nhiều người dùng thao tác đồng thời, cần kiểm tra lại UNIQUE ở DAL trước khi Insert.
        /// </summary>
        public static string SinhSoHopDong()
        {
            string ngay = DateTime.Now.ToString("yyyyMMdd");
            int soNgauNhien = _random.Next(0, 10000);
            return $"HD-{ngay}-{soNgauNhien:D4}";
        }

        /// <summary>
        /// Sinh số phiếu dùng chung cho phiếu thu nợ / phiếu giải ngân, dạng {prefix}-yyyyMMddHHmmss.
        /// </summary>
        public static string SinhSoPhieu(string prefix)
        {
            return $"{prefix}-{DateTime.Now:yyyyMMddHHmmss}";
        }
    }
}