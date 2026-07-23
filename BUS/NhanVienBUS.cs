using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using QuanLyTinDung.Common;
using QuanLyTinDung.DAL;
using QuanLyTinDung.DAL.Interfaces;
using QuanLyTinDung.DTO;
using QuanLyTinDung.Security;

namespace QuanLyTinDung.BUS
{
    public class NhanVienBUS
    {
        private readonly INhanVienDAL _nhanVienDAL;

        public NhanVienBUS()
        {
            _nhanVienDAL = new NhanVienDAL();
        }

        private string HashMatKhau(string matKhauGoc)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(matKhauGoc));
                var sb = new StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public KetQuaXuLy DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(matKhau))
                return KetQuaXuLy.That_Bai("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");

            string matKhauHash = HashMatKhau(matKhau);
            NhanVienDTO nv = _nhanVienDAL.XacThuc(tenDangNhap.Trim(), matKhauHash);

            if (nv == null)
                return KetQuaXuLy.That_Bai("Tên đăng nhập hoặc mật khẩu không đúng.");

            if (string.Equals(nv.TrangThai, TrangThaiNhanVien.INACTIVE.ToString(), StringComparison.OrdinalIgnoreCase))
                return KetQuaXuLy.That_Bai("Tài khoản đã bị khoá. Vui lòng liên hệ quản lý.");

            UserSession.Instance.DangNhap(nv);
            return KetQuaXuLy.Thanh_Cong("Đăng nhập thành công.", nv);
        }

        public List<NhanVienDTO> LayDanhSach() => _nhanVienDAL.GetAll();

        public NhanVienDTO LayTheoMa(int maNhanVien) => _nhanVienDAL.GetById(maNhanVien);

        public KetQuaXuLy Them(NhanVienDTO nv, string matKhau)
        {
            string loi = KiemTraHopLe(nv);
            if (loi != null) return KetQuaXuLy.That_Bai(loi);

            if (string.IsNullOrWhiteSpace(matKhau) || matKhau.Length < 6)
                return KetQuaXuLy.That_Bai("Mật khẩu phải có ít nhất 6 ký tự.");

            // RÀNG BUỘC: tên đăng nhập không được trùng
            if (_nhanVienDAL.KiemTraTonTaiTenDangNhap(nv.TenDangNhap))
                return KetQuaXuLy.That_Bai("Tên đăng nhập đã tồn tại, vui lòng chọn tên khác.");

            string hash = HashMatKhau(matKhau);
            int maMoi = _nhanVienDAL.Insert(nv, hash);
            return KetQuaXuLy.Thanh_Cong("Thêm nhân viên thành công.", maMoi);
        }

        public KetQuaXuLy Sua(NhanVienDTO nv)
        {
            string loi = KiemTraHopLe(nv);
            if (loi != null) return KetQuaXuLy.That_Bai(loi);

            bool ok = _nhanVienDAL.Update(nv);
            return ok ? KetQuaXuLy.Thanh_Cong("Cập nhật nhân viên thành công.")
                      : KetQuaXuLy.That_Bai("Không tìm thấy nhân viên cần cập nhật.");
        }

        public KetQuaXuLy Xoa(int maNhanVien)
        {
            try
            {
                bool ok = _nhanVienDAL.Delete(maNhanVien);
                return ok ? KetQuaXuLy.Thanh_Cong("Xoá nhân viên thành công.")
                          : KetQuaXuLy.That_Bai("Không tìm thấy nhân viên cần xoá.");
            }
            catch (Exception ex) when (ex.Message.Contains("REFERENCE constraint") || ex.Message.Contains("FOREIGN KEY"))
            {
                // RÀNG BUỘC: không xoá được nhân viên đã có dữ liệu nghiệp vụ liên kết (chặn bởi khoá ngoại ở CSDL)
                return KetQuaXuLy.That_Bai("Không thể xoá: nhân viên này đã có dữ liệu nghiệp vụ liên kết trong hệ thống.");
            }
        }

        public KetQuaXuLy DatLaiMatKhau(int maNhanVien, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauMoi) || matKhauMoi.Length < 6)
                return KetQuaXuLy.That_Bai("Mật khẩu mới phải có ít nhất 6 ký tự.");

            string hash = HashMatKhau(matKhauMoi);
            bool ok = _nhanVienDAL.CapNhatMatKhau(maNhanVien, hash);
            return ok ? KetQuaXuLy.Thanh_Cong("Đặt lại mật khẩu thành công.")
                      : KetQuaXuLy.That_Bai("Không tìm thấy nhân viên.");
        }

        private string KiemTraHopLe(NhanVienDTO nv)
        {
            if (string.IsNullOrWhiteSpace(nv.HoTen))
                return "Vui lòng nhập họ tên.";
            if (string.IsNullOrWhiteSpace(nv.VaiTro))
                return "Vui lòng chọn vai trò.";
            if (nv.MaChiNhanh <= 0)
                return "Vui lòng chọn chi nhánh.";
            if (string.IsNullOrWhiteSpace(nv.TenDangNhap))
                return "Vui lòng nhập tên đăng nhập.";
            if (!string.IsNullOrWhiteSpace(nv.SoDienThoai) && !Validator.IsValidSoDienThoai(nv.SoDienThoai))
                return Validator.LoiSoDienThoai;
            if (!string.IsNullOrWhiteSpace(nv.Email) && !Validator.IsValidEmail(nv.Email))
                return Validator.LoiEmail;

            // RÀNG BUỘC: chỉ vai trò có quyền duyệt (QUAN_LY_CHI_NHANH, BAN_TIN_DUNG_HOI_SO) mới được đặt hạn mức phê duyệt > 0
            bool laVaiTroCoQuyenDuyet = nv.VaiTro == VaiTroNhanVien.QUAN_LY_CHI_NHANH.ToString()
                                     || nv.VaiTro == VaiTroNhanVien.BAN_TIN_DUNG_HOI_SO.ToString();
            if (!laVaiTroCoQuyenDuyet && nv.HanMucPheDuyet > 0)
                return "Chỉ vai trò Quản lý chi nhánh hoặc Ban tín dụng hội sở mới được đặt hạn mức phê duyệt.";

            return null;
        }
    }
}