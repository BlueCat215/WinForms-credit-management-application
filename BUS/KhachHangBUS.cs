using System;
using System.Collections.Generic;
using QuanLyTinDung.Common;
using QuanLyTinDung.DAL;
using QuanLyTinDung.DAL.Interfaces;
using QuanLyTinDung.DTO;

namespace QuanLyTinDung.BUS
{
    public class KhachHangBUS
    {
        private readonly IKhachHangDAL _khachHangDAL;

        public KhachHangBUS()
        {
            _khachHangDAL = new KhachHangDAL();
        }

        public List<KhachHangDTO> LayDanhSach() => _khachHangDAL.GetAll();

        public List<KhachHangDTO> TimKiem(string tuKhoa) =>
            string.IsNullOrWhiteSpace(tuKhoa) ? _khachHangDAL.GetAll() : _khachHangDAL.TimKiem(tuKhoa.Trim());

        public KhachHangDTO LayTheoMa(int maKhachHang) => _khachHangDAL.GetById(maKhachHang);

        public KetQuaXuLy Them(KhachHangDTO kh)
        {
            string loi = KiemTraHopLe(kh);
            if (loi != null) return KetQuaXuLy.That_Bai(loi);

            // RÀNG BUỘC: không trùng CCCD với khách hàng đã có khi thêm mới
            if (_khachHangDAL.TimTheoSoCCCD(kh.SoCmndCccd) != null)
                return KetQuaXuLy.That_Bai("Số CMND/CCCD này đã tồn tại trong hệ thống.");

            kh.NgayTao = DateTime.Now;
            int maMoi = _khachHangDAL.Insert(kh);
            return KetQuaXuLy.Thanh_Cong("Thêm khách hàng thành công.", maMoi);
        }

        public KetQuaXuLy Sua(KhachHangDTO kh)
        {
            string loi = KiemTraHopLe(kh);
            if (loi != null) return KetQuaXuLy.That_Bai(loi);

            var trung = _khachHangDAL.TimTheoSoCCCD(kh.SoCmndCccd);
            if (trung != null && trung.MaKhachHang != kh.MaKhachHang)
                return KetQuaXuLy.That_Bai("Số CMND/CCCD này đã được dùng bởi khách hàng khác.");

            bool ok = _khachHangDAL.Update(kh);
            return ok ? KetQuaXuLy.Thanh_Cong("Cập nhật khách hàng thành công.")
                      : KetQuaXuLy.That_Bai("Không tìm thấy khách hàng cần cập nhật.");
        }

        public KetQuaXuLy Xoa(int maKhachHang)
        {
            try
            {
                bool ok = _khachHangDAL.Delete(maKhachHang);
                return ok ? KetQuaXuLy.Thanh_Cong("Xoá khách hàng thành công.")
                          : KetQuaXuLy.That_Bai("Không tìm thấy khách hàng cần xoá.");
            }
            catch (Exception ex) when (ex.Message.Contains("REFERENCE constraint") || ex.Message.Contains("FOREIGN KEY"))
            {
                // RÀNG BUỘC: không xoá được khách hàng đã có hồ sơ vay liên kết (chặn bởi khoá ngoại ở CSDL)
                return KetQuaXuLy.That_Bai("Không thể xoá: khách hàng này đã có hồ sơ vay liên kết trong hệ thống.");
            }
        }

        private string KiemTraHopLe(KhachHangDTO kh)
        {
            if (string.IsNullOrWhiteSpace(kh.HoTen))
                return "Vui lòng nhập họ tên.";

            // RÀNG BUỘC: CCCD phải là số, đủ 9 hoặc 12 ký tự
            if (!Validator.IsValidCCCD(kh.SoCmndCccd))
                return Validator.LoiCCCD;

            // RÀNG BUỘC: khách hàng phải đủ 18 tuổi tính từ ngày hiện tại
            int tuoi = DateTime.Now.Year - kh.NgaySinh.Year;
            if (kh.NgaySinh.Date > DateTime.Now.AddYears(-tuoi)) tuoi--;
            if (tuoi < 18)
                return "Khách hàng phải đủ 18 tuổi trở lên.";

            if (!string.IsNullOrWhiteSpace(kh.SoDienThoai) && !Validator.IsValidSoDienThoai(kh.SoDienThoai))
                return Validator.LoiSoDienThoai;

            if (!string.IsNullOrWhiteSpace(kh.Email) && !Validator.IsValidEmail(kh.Email))
                return Validator.LoiEmail;

            return null;
        }
    }
}