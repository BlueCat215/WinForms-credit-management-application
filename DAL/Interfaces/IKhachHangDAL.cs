using System.Collections.Generic;
using QuanLyTinDung.DTO;

namespace QuanLyTinDung.DAL.Interfaces
{
    public interface IKhachHangDAL
    {
        List<KhachHangDTO> GetAll();
        KhachHangDTO GetById(int maKhachHang);
        int Insert(KhachHangDTO kh);
        bool Update(KhachHangDTO kh);
        bool Delete(int maKhachHang);
        KhachHangDTO TimTheoSoCCCD(string soCccd);
        List<KhachHangDTO> TimKiem(string tuKhoa);
    }
}