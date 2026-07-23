using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyTinDung.Config;
using QuanLyTinDung.DAL.Interfaces;
using QuanLyTinDung.DTO;

namespace QuanLyTinDung.DAL
{
    public class ChiNhanhDAL : IChiNhanhDAL
    {
        private ChiNhanhDTO Map(SqlDataReader reader)
        {
            return new ChiNhanhDTO
            {
                MaChiNhanh = reader.GetInt32(reader.GetOrdinal("ma_chi_nhanh")),
                TenChiNhanh = reader["ten_chi_nhanh"]?.ToString(),
                DiaChi = reader["dia_chi"]?.ToString(),
                SoDienThoai = reader["so_dien_thoai"]?.ToString(),
                NgayTao = reader.IsDBNull(reader.GetOrdinal("ngay_tao")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("ngay_tao"))
            };
        }

        public List<ChiNhanhDTO> GetAll()
        {
            var ds = new List<ChiNhanhDTO>();
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    "SELECT ma_chi_nhanh, ten_chi_nhanh, dia_chi, so_dien_thoai, ngay_tao FROM chi_nhanh ORDER BY ten_chi_nhanh", conn))
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
                throw new Exception("Lỗi khi lấy danh sách chi nhánh: " + ex.Message, ex);
            }
        }

        public ChiNhanhDTO GetById(int maChiNhanh)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    "SELECT ma_chi_nhanh, ten_chi_nhanh, dia_chi, so_dien_thoai, ngay_tao FROM chi_nhanh WHERE ma_chi_nhanh = @Ma", conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", maChiNhanh);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? Map(reader) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy chi nhánh mã {maChiNhanh}: " + ex.Message, ex);
            }
        }

        public int Insert(ChiNhanhDTO cn)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    @"INSERT INTO chi_nhanh (ten_chi_nhanh, dia_chi, so_dien_thoai, ngay_tao)
                      OUTPUT INSERTED.ma_chi_nhanh
                      VALUES (@Ten, @DiaChi, @SoDienThoai, @NgayTao)", conn))
                {
                    cmd.Parameters.AddWithValue("@Ten", cn.TenChiNhanh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", cn.DiaChi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai", cn.SoDienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayTao", cn.NgayTao);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi nhánh: " + ex.Message, ex);
            }
        }

        public bool Update(ChiNhanhDTO cn)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    @"UPDATE chi_nhanh SET ten_chi_nhanh = @Ten, dia_chi = @DiaChi, so_dien_thoai = @SoDienThoai
                      WHERE ma_chi_nhanh = @Ma", conn))
                {
                    cmd.Parameters.AddWithValue("@Ten", cn.TenChiNhanh ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", cn.DiaChi ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoDienThoai", cn.SoDienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Ma", cn.MaChiNhanh);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật chi nhánh mã {cn.MaChiNhanh}: " + ex.Message, ex);
            }
        }

        public bool Delete(int maChiNhanh)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand("DELETE FROM chi_nhanh WHERE ma_chi_nhanh = @Ma", conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", maChiNhanh);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xoá chi nhánh mã {maChiNhanh}: " + ex.Message, ex);
            }
        }

        public List<ChiNhanhDTO> TimKiem(string tuKhoa)
        {
            var ds = new List<ChiNhanhDTO>();
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    @"SELECT ma_chi_nhanh, ten_chi_nhanh, dia_chi, so_dien_thoai, ngay_tao
                      FROM chi_nhanh WHERE ten_chi_nhanh LIKE @TuKhoa ORDER BY ten_chi_nhanh", conn))
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
                throw new Exception("Lỗi khi tìm kiếm chi nhánh: " + ex.Message, ex);
            }
        }

        public bool CoNhanVienThamChieu(int maChiNhanh)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand("SELECT COUNT(1) FROM nhan_vien WHERE ma_chi_nhanh = @Ma", conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", maChiNhanh);
                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra nhân viên tham chiếu: " + ex.Message, ex);
            }
        }

        public bool CoHoSoVayThamChieu(int maChiNhanh)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand("SELECT COUNT(1) FROM ho_so_vay WHERE ma_chi_nhanh = @Ma", conn))
                {
                    cmd.Parameters.AddWithValue("@Ma", maChiNhanh);
                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra hồ sơ vay tham chiếu: " + ex.Message, ex);
            }
        }
    }
}