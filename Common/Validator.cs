using System;
using System.Text.RegularExpressions;

namespace QuanLyTinDung.Common
{
    /// <summary>
    /// Các hàm kiểm tra dữ liệu đầu vào dùng chung toàn hệ thống.
    /// </summary>
    public static class Validator
    {
        public const string LoiCCCD = "Số CMND/CCCD không hợp lệ (phải là 9 hoặc 12 chữ số).";
        public const string LoiSoDienThoai = "Số điện thoại không hợp lệ (phải là 10 chữ số, bắt đầu bằng 0).";
        public const string LoiEmail = "Địa chỉ email không hợp lệ.";
        public const string LoiSoTien = "Số tiền phải lớn hơn 0.";

        public static bool IsValidCCCD(string so)
        {
            if (string.IsNullOrWhiteSpace(so)) return false;
            return Regex.IsMatch(so.Trim(), @"^\d{9}$") || Regex.IsMatch(so.Trim(), @"^\d{12}$");
        }

        public static bool IsValidSoDienThoai(string so)
        {
            if (string.IsNullOrWhiteSpace(so)) return false;
            return Regex.IsMatch(so.Trim(), @"^0\d{9}$");
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return Regex.IsMatch(email.Trim(),
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsSoTienHopLe(decimal soTien)
        {
            return soTien > 0;
        }
    }
}