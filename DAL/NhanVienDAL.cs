using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using QuanLyTinDung.Config;
using QuanLyTinDung.DAL.Interfaces;
using QuanLyTinDung.DTO;

namespace QuanLyTinDung.DAL
{
    public class NhanVienDAL : INhanVienDAL
    {
        private NhanVienDTO Map(SqlDataReader reader)
        {
            return new NhanVienDTO
            {
                MaNhanVien = reader.GetInt32(reader.GetOrdinal("ma_nhan_vien")),
                MaChiNhanh = reader.IsDBNull(reader.GetOrdinal("ma_chi_nhanh")) ? 0 : reader.GetInt32(reader.GetOrdinal("ma_chi_nhanh")),
                HoTen = reader["ho_ten"]?.ToString(),
                VaiTro = reader["vai_tro"]?.ToString(),
                HanMucPheDuyet = reader.IsDBNull(reader.GetOrdinal("han_muc_phe_duyet")) ? 0 : reader.GetDecimal(reader.GetOrdinal("han_muc_phe_duyet")),
                SoDienThoai = reader["so_dien_thoai"]?.ToString(),
                Email = reader["email"]?.ToString(),
                TrangThai = reader["trang_thai"]?.ToString(),
                TenDangNhap = reader["ten_dang_nhap"]?.ToString()
            };
        }

        public List<NhanVienDTO> GetAll()
        {
            var ds = new List<NhanVienDTO>();
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    @"SELECT ma_nhan_vien, ma_chi_nhanh, ho_ten, vai_tro, han_muc_phe_duyet,
                             so_dien_thoai, email, trang_thai, ten_dang_nhap
                      FROM nhan_vien ORDER BY ho_ten", conn))
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
                throw new Exception("Lỗi khi lấy danh sách nhân viên: " + ex.Message, ex);
            }
        }

        public NhanVienDTO GetById(int maNhanVien)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    @"SELECT ma_nhan_vien, ma_chi_nhanh, ho_ten, vai_tro, han_muc_phe_duyet,
                             so_dien_thoai, email, trang_thai, ten_dang_nhap
                      FROM nhan_vien WHERE ma_nhan_vien = @MaNhanVien", conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? Map(reader) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy nhân viên mã {maNhanVien}: " + ex.Message, ex);
            }
        }

        public int Insert(NhanVienDTO nv, string matKhauHash)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    @"INSERT INTO nhan_vien
                        (ma_chi_nhanh, ho_ten, vai_tro, han_muc_phe_duyet, so_dien_thoai,
                         email, trang_thai, ten_dang_nhap, mat_khau_hash)
                      OUTPUT INSERTED.ma_nhan_vien
                      VALUES
                        (@MaChiNhanh, @HoTen, @VaiTro, @HanMucPheDuyet, @SoDienThoai,
                         @Email, @TrangThai, @TenDangNhap, @MatKhauHash)", conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiNhanh", nv.MaChiNhanh);
                    cmd.Parameters.AddWithValue("@HoTen", nv.HoTen ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VaiTro", nv.VaiTro ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@HanMucPheDuyet", nv.HanMucPheDuyet);
                    cmd.Parameters.AddWithValue("@SoDienThoai", nv.SoDienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", nv.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TrangThai", nv.TrangThai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenDangNhap", nv.TenDangNhap ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MatKhauHash", matKhauHash ?? (object)DBNull.Value);

                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message, ex);
            }
        }

        public bool Update(NhanVienDTO nv)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    @"UPDATE nhan_vien SET
                        ma_chi_nhanh = @MaChiNhanh, ho_ten = @HoTen, vai_tro = @VaiTro,
                        han_muc_phe_duyet = @HanMucPheDuyet, so_dien_thoai = @SoDienThoai,
                        email = @Email, trang_thai = @TrangThai, ten_dang_nhap = @TenDangNhap
                      WHERE ma_nhan_vien = @MaNhanVien", conn))
                {
                    cmd.Parameters.AddWithValue("@MaChiNhanh", nv.MaChiNhanh);
                    cmd.Parameters.AddWithValue("@HoTen", nv.HoTen ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VaiTro", nv.VaiTro ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@HanMucPheDuyet", nv.HanMucPheDuyet);
                    cmd.Parameters.AddWithValue("@SoDienThoai", nv.SoDienThoai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", nv.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TrangThai", nv.TrangThai ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenDangNhap", nv.TenDangNhap ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật nhân viên mã {nv.MaNhanVien}: " + ex.Message, ex);
            }
        }

        public bool Delete(int maNhanVien)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand("DELETE FROM nhan_vien WHERE ma_nhan_vien = @MaNhanVien", conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xoá nhân viên mã {maNhanVien}: " + ex.Message, ex);
            }
        }

        public NhanVienDTO XacThuc(string tenDangNhap, string matKhauHash)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    @"SELECT ma_nhan_vien, ma_chi_nhanh, ho_ten, vai_tro, han_muc_phe_duyet,
                             so_dien_thoai, email, trang_thai, ten_dang_nhap
                      FROM nhan_vien
                      WHERE ten_dang_nhap = @TenDangNhap AND mat_khau_hash = @MatKhauHash", conn))
                {
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhauHash", matKhauHash);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        return reader.Read() ? Map(reader) : null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xác thực đăng nhập: " + ex.Message, ex);
            }
        }

        public bool KiemTraTonTaiTenDangNhap(string tenDangNhap)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    "SELECT COUNT(1) FROM nhan_vien WHERE ten_dang_nhap = @TenDangNhap", conn))
                {
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    conn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi kiểm tra tên đăng nhập: " + ex.Message, ex);
            }
        }

        public bool CapNhatMatKhau(int maNhanVien, string matKhauHashMoi)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.ConnectionString))
                using (var cmd = new SqlCommand(
                    "UPDATE nhan_vien SET mat_khau_hash = @MatKhauHash WHERE ma_nhan_vien = @MaNhanVien", conn))
                {
                    cmd.Parameters.AddWithValue("@MatKhauHash", matKhauHashMoi);
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật mật khẩu nhân viên mã {maNhanVien}: " + ex.Message, ex);
            }
        }
    }
}