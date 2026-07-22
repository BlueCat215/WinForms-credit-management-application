using System.Configuration;

namespace QuanLyTinDung.Config
{
    /// <summary>
    /// Đọc cấu hình kết nối CSDL từ App.config.
    /// Toàn bộ tầng DAL PHẢI lấy connection string qua AppConfig.ConnectionString,
    /// không được hard-code chuỗi kết nối trong code.
    /// </summary>
    public static class AppConfig
    {
        private const string TenConnectionString = "QuanLyTinDungDB";

        public static string ConnectionString
        {
            get
            {
                var setting = ConfigurationManager.ConnectionStrings[TenConnectionString];
                if (setting == null)
                {
                    throw new ConfigurationErrorsException(
                        $"Không tìm thấy connection string '{TenConnectionString}' trong App.config. " +
                        "Vui lòng kiểm tra lại thẻ <connectionStrings> trong file App.config.");
                }
                return setting.ConnectionString;
            }
        }
    }
}