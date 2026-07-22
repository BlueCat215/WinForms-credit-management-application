namespace QuanLyTinDung.Common
{
    /// <summary>
    /// Kết quả trả về chuẩn từ các hàm ghi dữ liệu ở tầng BUS.
    /// </summary>
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }
        public object DuLieu { get; set; }

        public KetQuaXuLy() { }

        public KetQuaXuLy(bool thanhCong, string thongBao, object duLieu = null)
        {
            ThanhCong = thanhCong;
            ThongBao = thongBao;
            DuLieu = duLieu;
        }

        public static KetQuaXuLy Thanh_Cong(string thongBao = "Thực hiện thành công.", object duLieu = null)
            => new KetQuaXuLy(true, thongBao, duLieu);

        public static KetQuaXuLy That_Bai(string thongBao)
            => new KetQuaXuLy(false, thongBao);
    }
}