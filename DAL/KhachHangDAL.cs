using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyTinDung.Config;
using QuanLyTinDung.DAL.Interfaces;
using QuanLyTinDung.DTO;

namespace QuanLyTinDung.DAL
{
    public class KhachHangDAL : IKhachHangDAL
    {
        private KhachHangDTO Map(SqlDataReader reader)
        {
            return new KhachHangDTO
            {
                MaKhachHang = reader.GetInt32(reader.GetOrdinal("ma_khach_hang")),
                HoTen = reader["ho_ten"]?.ToString(),
                SoCmndCccd = reader["so_cmnd_cccd"]?.ToString(),
                NgaySinh = reader.IsDBNull(reader.GetOrdinal("ngay_sinh")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("ngay_sinh")),
                DiaChi = reader["dia_chi"]?.ToString(),
                SoDienThoai = reader["so_dien_thoai"]?.ToString(),
                Email = reader["email"]?.ToString(),
                HsChungMinhThuNhap = reader["hs_chung_minh_thu_nhap"]?.ToString(),
                NgayTao = reader.IsDBNull(reader.GetOrdinal("ngay_tao")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("ngay_tao"))
            };
        }

        private const string CotChon =
            "ma_khach_hang, ho_ten, so_cmnd_cccd, ngay_sinh, dia_chi, so_dien_thoai, email, hs_chung_minh_thu_nhap, ngay_tao";

        public List<KhachHangDTO> GetAll()
        {
            var ds = new List<KhachHangDTO>();
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand($"SELECT {CotChon} FROM khach_hang ORDER BY ho_ten", conn))
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) ds.Add(Map(reader));
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách khách hàng: " + ex.Message, ex);
            }
        }

        public KhachHangDTO GetById(int maKhachHang)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand($"SELECT {CotChon} FROM khach_hang WHERE ma_khach_hang = @Ma", conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", maKhachHang);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? Map(reader) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy khách hàng mã {maKhachHang}: " + ex.Message, ex);
            }
        }

        public int Insert(KhachHangDTO kh)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    @"INSERT INTO khach_hang
                        (ho_ten, so_cmnd_cccd, ngay_sinh, dia_chi, so_dien_thoai, email, hs_chung_minh_thu_nhap, ngay_tao)
                      OUTPUT INSERTED.ma_khach_hang
                      VALUES
                        (@HoTen, @SoCccd, @NgaySinh, @DiaChi, @SoDienThoai, @Email, @HoSoThuNhap, @NgayTao)", conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", kh.HoTen ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoCccd", kh.SoCmndCccd ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgaySinh", kh.NgaySinh);
                    cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", kh.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@HoSoThuNhap", kh.HsChungMinhThuNhap ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayTao", kh.NgayTao);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm khách hàng: " + ex.Message, ex);
            }
        }

        public bool Update(KhachHangDTO kh)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    @"UPDATE khach_hang SET
                        ho_ten = @HoTen, so_cmnd_cccd = @SoCccd, ngay_sinh = @NgaySinh, dia_chi = @DiaChi,
                        so_dien_thoai = @SoDienThoai, email = @Email, hs_chung_minh_thu_nhap = @HoSoThuNhap
                      WHERE ma_khach_hang = @Ma", conn))
                {
                    cmd.Parameters.AddWithValue("@HoTen", kh.HoTen ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoCccd", kh.SoCmndCccd ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgaySinh", kh.NgaySinh);
                    cmd.Parameters.AddWithValue("@DiaChi", kh.DiaChi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai", kh.SoDienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", kh.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@HoSoThuNhap", kh.HsChungMinhThuNhap ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ma", kh.MaKhachHang);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật khách hàng mã {kh.MaKhachHang}: " + ex.Message, ex);
            }
        }

        public bool Delete(int maKhachHang)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand("DELETE FROM khach_hang WHERE ma_khach_hang = @Ma", conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", maKhachHang);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xoá khách hàng mã {maKhachHang}: " + ex.Message, ex);
            }
        }

        public KhachHangDTO TimTheoSoCCCD(string soCccd)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand($"SELECT {CotChon} FROM khach_hang WHERE so_cmnd_cccd = @SoCccd", conn))
                {
                    cmd.Parameters.AddWithValue("@SoCccd", soCccd);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? Map(reader) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm khách hàng theo CCCD: " + ex.Message, ex);
            }
        }

        public List<KhachHangDTO> TimKiem(string tuKhoa)
        {
            var ds = new List<KhachHangDTO>();
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    $@"SELECT {CotChon} FROM khach_hang
                       WHERE ho_ten LIKE @TuKhoa OR so_cmnd_cccd LIKE @TuKhoa
                       ORDER BY ho_ten", conn))
                {
                    cmd.Parameters.AddWithValue("@TuKhoa", $"%{tuKhoa}%");
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read()) ds.Add(Map(reader));
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm khách hàng: " + ex.Message, ex);
            }
        }
    }
}