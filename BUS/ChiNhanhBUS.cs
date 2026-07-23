using System;
using System.Collections.Generic;
using QuanLyTinDung.Common;
using QuanLyTinDung.DAL;
using QuanLyTinDung.DAL.Interfaces;
using QuanLyTinDung.DTO;

namespace QuanLyTinDung.BUS
{
    public class ChiNhanhBUS
    {
        private readonly IChiNhanhDAL _chiNhanhDAL;

        public ChiNhanhBUS()
        {
            _chiNhanhDAL = new ChiNhanhDAL();
        }

        public List<ChiNhanhDTO> LayDanhSach() => _chiNhanhDAL.GetAll();

        public List<ChiNhanhDTO> TimKiem(string tuKhoa) =>
            string.IsNullOrWhiteSpace(tuKhoa) ? _chiNhanhDAL.GetAll() : _chiNhanhDAL.TimKiem(tuKhoa.Trim());

        public ChiNhanhDTO LayTheoMa(int maChiNhanh) => _chiNhanhDAL.GetById(maChiNhanh);

        public KetQuaXuLy Them(ChiNhanhDTO cn)
        {
            if (string.IsNullOrWhiteSpace(cn.TenChiNhanh))
                return KetQuaXuLy.That_Bai("Vui lòng nhập tên chi nhánh.");

            if (!string.IsNullOrWhiteSpace(cn.SoDienThoai) && !Validator.IsValidSoDienThoai(cn.SoDienThoai))
                return KetQuaXuLy.That_Bai(Validator.LoiSoDienThoai);

            cn.NgayTao = DateTime.Now;
            int maMoi = _chiNhanhDAL.Insert(cn);
            return KetQuaXuLy.Thanh_Cong("Thêm chi nhánh thành công.", maMoi);
        }

        public KetQuaXuLy Sua(ChiNhanhDTO cn)
        {
            if (string.IsNullOrWhiteSpace(cn.TenChiNhanh))
                return KetQuaXuLy.That_Bai("Vui lòng nhập tên chi nhánh.");

            if (!string.IsNullOrWhiteSpace(cn.SoDienThoai) && !Validator.IsValidSoDienThoai(cn.SoDienThoai))
                return KetQuaXuLy.That_Bai(Validator.LoiSoDienThoai);

            bool ok = _chiNhanhDAL.Update(cn);
            return ok ? KetQuaXuLy.Thanh_Cong("Cập nhật chi nhánh thành công.")
                      : KetQuaXuLy.That_Bai("Không tìm thấy chi nhánh cần cập nhật.");
        }

        public KetQuaXuLy Xoa(int maChiNhanh)
        {
            // RÀNG BUỘC: không cho xoá chi nhánh nếu còn nhân viên hoặc hồ sơ vay tham chiếu
            if (_chiNhanhDAL.CoNhanVienThamChieu(maChiNhanh))
                return KetQuaXuLy.That_Bai("Không thể xoá: chi nhánh này còn nhân viên đang trực thuộc.");

            if (_chiNhanhDAL.CoHoSoVayThamChieu(maChiNhanh))
                return KetQuaXuLy.That_Bai("Không thể xoá: chi nhánh này còn hồ sơ vay tham chiếu.");

            bool ok = _chiNhanhDAL.Delete(maChiNhanh);
            return ok ? KetQuaXuLy.Thanh_Cong("Xoá chi nhánh thành công.")
                      : KetQuaXuLy.That_Bai("Không tìm thấy chi nhánh cần xoá.");
        }
    }
}