using System.Collections.Generic;
using QuanLyTinDung.DTO;

namespace QuanLyTinDung.DAL.Interfaces
{
    public interface IChiNhanhDAL
    {
        List<ChiNhanhDTO> GetAll();
        ChiNhanhDTO GetById(int maChiNhanh);
        int Insert(ChiNhanhDTO cn);
        bool Update(ChiNhanhDTO cn);
        bool Delete(int maChiNhanh);
        List<ChiNhanhDTO> TimKiem(string tuKhoa);
        bool CoNhanVienThamChieu(int maChiNhanh);
        bool CoHoSoVayThamChieu(int maChiNhanh);
    }
}