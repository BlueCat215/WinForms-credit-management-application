using System;

namespace QuanLyTinDung.Common
{
    /// <summary>
    /// Exception riêng cho lỗi nghiệp vụ (vi phạm RÀNG BUỘC ở tầng BUS).
    /// Form bắt exception này để hiển thị trực tiếp ThongBao lên MessageBox,
    /// không hiển thị stack trace kỹ thuật cho người dùng cuối.
    /// </summary>
    public class BusinessException : Exception
    {
        public string ThongBao { get; }

        public BusinessException(string thongBao) : base(thongBao)
        {
            ThongBao = thongBao;
        }

        public BusinessException(string thongBao, Exception innerException)
            : base(thongBao, innerException)
        {
            ThongBao = thongBao;
        }
    }
}