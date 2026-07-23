CREATE DATABASE [QuanLyTinDung_DB];
GO

USE [QuanLyTinDung_DB];
GO

-- 1. BẢNG CHI NHÁNH
CREATE TABLE [chi_nhanh] (
  [ma_chi_nhanh] integer PRIMARY KEY IDENTITY(1, 1),
  [ten_chi_nhanh] nvarchar(255),
  [dia_chi] nvarchar(255),
  [so_dien_thoai] nvarchar(255),
  [ngay_tao] datetime
);
GO

-- 2. BẢNG NHÂN VIÊN
CREATE TABLE [nhan_vien] (
  [ma_nhan_vien] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_chi_nhanh] integer,
  [ho_ten] nvarchar(255),
  [vai_tro] nvarchar(255),
  [han_muc_phe_duyet] decimal(18, 2),
  [so_dien_thoai] nvarchar(255),
  [email] nvarchar(255),
  [trang_thai] nvarchar(255),
  [ten_dang_nhap] nvarchar(255),
  [mat_khau_hash] nvarchar(255)
);
GO

-- 3. BẢNG KHÁCH HÀNG
CREATE TABLE [khach_hang] (
  [ma_khach_hang] integer PRIMARY KEY IDENTITY(1, 1),
  [ho_ten] nvarchar(255),
  [so_cmnd_cccd] nvarchar(255) UNIQUE,
  [ngay_sinh] date,
  [dia_chi] nvarchar(255),
  [so_dien_thoai] nvarchar(255),
  [email] nvarchar(255),
  [hs_chung_minh_thu_nhap] nvarchar(255),
  [ngay_tao] datetime
);
GO

-- 4. BẢNG HỒ SƠ VAY
CREATE TABLE [ho_so_vay] (
  [ma_ho_so] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_khach_hang] integer,
  [ma_nhan_vien] integer,
  [ma_chi_nhanh] integer,
  [so_tien_de_nghi] decimal(18, 2),
  [thoi_han_thang] integer,
  [muc_dich_vay] nvarchar(255),
  [lai_suat_de_xuat] decimal(5, 2),
  [trang_thai] nvarchar(255),
  [ly_do_tu_choi] nvarchar(255),
  [ngay_tao] datetime,
  [ngay_cap_nhat] datetime
);
GO

-- 5. BẢNG TÀI SẢN THẾ CHẤP
CREATE TABLE [tai_san_the_chap] (
  [ma_tai_san] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_ho_so] integer,
  [loai_tai_san] nvarchar(255),
  [mo_ta] nvarchar(255),
  [so_giay_to_phap_ly] nvarchar(255),
  [gia_tri_khai_bao] decimal(18, 2),
  [du_dieu_kien] bit
);
GO

-- 6. BẢNG ĐỊNH GIÁ
CREATE TABLE [dinh_gia] (
  [ma_dinh_gia] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_tai_san] integer,
  [ma_nguoi_dinh_gia] integer,
  [gia_tri_dinh_gia] decimal(18, 2),
  [ngay_dinh_gia] date,
  [ghi_chu] nvarchar(255),
  [ket_qua] nvarchar(255)
);
GO

-- 7. BẢNG PHÊ DUYỆT
CREATE TABLE [phe_duyet] (
  [ma_phe_duyet] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_ho_so] integer,
  [ma_nguoi_duyet] integer,
  [cap_phe_duyet] nvarchar(255),
  [quyet_dinh] nvarchar(255),
  [so_tien_duyet] decimal(18, 2),
  [lai_suat_duyet] decimal(5, 2),
  [ngay_quyet_dinh] datetime,
  [y_kien] nvarchar(255)
);
GO

-- 8. BẢNG ĐĂNG KÝ GIAO DỊCH BẢO ĐẢM
CREATE TABLE [dang_ky_gd_bao_dam] (
  [ma_dang_ky] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_tai_san] integer,
  [so_cong_chung] nvarchar(255),
  [ngay_cong_chung] date,
  [co_quan_dang_ky] nvarchar(255),
  [ngay_dang_ky] date,
  [trang_thai] nvarchar(255)
);
GO

-- 9. BẢNG PHIẾU GIẢI NGÂN
CREATE TABLE [phieu_giai_ngan] (
  [ma_giai_ngan] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_ho_so] integer,
  [ma_nhan_vien] integer,
  [so_tien_giai_ngan] decimal(18, 2),
  [ngay_giai_ngan] datetime,
  [lan_giai_ngan] integer
);
GO

-- 10. BẢNG HỢP ĐỒNG VAY
CREATE TABLE [hop_dong_vay] (
  [ma_hop_dong] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_ho_so] integer,
  [ma_nhan_vien] integer,
  [so_hop_dong] nvarchar(255) UNIQUE,
  [so_tien_goc] decimal(18, 2),
  [lai_suat] decimal(5, 2),
  [loai_lai_suat] nvarchar(255),
  [phuong_thuc_tra_no] nvarchar(255),
  [ngay_bat_dau] date,
  [ngay_ket_thuc] date,
  [so_ngay_an_han] integer,
  [phi_phat_tra_truoc_han] decimal(5, 2),
  [trang_thai] nvarchar(255),
  [ngay_tao] datetime
);
GO

-- 11. BẢNG LỊCH TRẢ NỢ
CREATE TABLE [lich_tra_no] (
  [ma_lich_tra_no] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_hop_dong] integer,
  [ky_tra_no] integer,
  [ngay_den_han] date,
  [tien_goc_phai_tra] decimal(18, 2),
  [tien_lai_phai_tra] decimal(18, 2),
  [tien_goc_da_tra] decimal(18, 2) DEFAULT (0),
  [tien_lai_da_tra] decimal(18, 2) DEFAULT (0),
  [lai_phat] decimal(18, 2) DEFAULT (0),
  [trang_thai] nvarchar(255),
  [so_ngay_qua_han] integer DEFAULT (0),
  [nhom_no] nvarchar(255)
);
GO

-- 12. BẢNG PHIẾU THU NỢ
CREATE TABLE [phieu_thu_no] (
  [ma_phieu_thu] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_lich_tra_no] integer,
  [ma_nhan_vien] integer,
  [ngay_thanh_toan] datetime,
  [tien_goc] decimal(18, 2),
  [tien_lai] decimal(18, 2),
  [tien_phat] decimal(18, 2) DEFAULT (0),
  [loai_thanh_toan] nvarchar(255),
  [tien_thua] decimal(18, 2) DEFAULT (0)
);
GO

-- 13. BẢNG NHẮC NỢ
CREATE TABLE [nhac_no] (
  [ma_nhac_no] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_lich_tra_no] integer,
  [ngay_nhac_no] datetime,
  [kenh_nhac_no] nvarchar(255),
  [noi_dung] nvarchar(255),
  [ma_nhan_vien] integer
);
GO

-- 14. BẢNG TÁI CƠ CẤU NỢ
CREATE TABLE [tai_co_cau_no] (
  [ma_tai_co_cau] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_hop_dong] integer,
  [ngay_yeu_cau] date,
  [thoi_han_moi_thang] integer,
  [lai_suat_moi] decimal(5, 2),
  [ly_do] nvarchar(255),
  [nguoi_phe_duyet] integer,
  [trang_thai] nvarchar(255)
);
GO

-- 15. BẢNG XỬ LÝ NỢ XẤU
CREATE TABLE [xu_ly_no_xau] (
  [ma_xu_ly] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_hop_dong] integer,
  [ma_nhan_vien] integer,
  [hinh_thuc_xu_ly] nvarchar(255),
  [ngay_xu_ly] date,
  [mo_ta] nvarchar(255),
  [ket_qua] nvarchar(255)
);
GO

-- 16. BẢNG TẤT TOÁN
CREATE TABLE [tat_toan] (
  [ma_tat_toan] integer PRIMARY KEY IDENTITY(1, 1),
  [ma_hop_dong] integer,
  [ma_nhan_vien] integer,
  [ngay_tat_toan] datetime,
  [tong_goc_da_tra] decimal(18, 2),
  [tong_lai_da_tra] decimal(18, 2),
  [phi_tra_truoc_han] decimal(18, 2) DEFAULT (0),
  [loai_tat_toan] nvarchar(255)
);
GO

-- =========================================================
-- KHÓA NGOẠI (FOREIGN KEYS)
-- =========================================================
ALTER TABLE [nhan_vien] ADD FOREIGN KEY ([ma_chi_nhanh]) REFERENCES [chi_nhanh] ([ma_chi_nhanh]);
ALTER TABLE [ho_so_vay] ADD FOREIGN KEY ([ma_khach_hang]) REFERENCES [khach_hang] ([ma_khach_hang]);
ALTER TABLE [ho_so_vay] ADD FOREIGN KEY ([ma_nhan_vien]) REFERENCES [nhan_vien] ([ma_nhan_vien]);
ALTER TABLE [ho_so_vay] ADD FOREIGN KEY ([ma_chi_nhanh]) REFERENCES [chi_nhanh] ([ma_chi_nhanh]);
ALTER TABLE [tai_san_the_chap] ADD FOREIGN KEY ([ma_ho_so]) REFERENCES [ho_so_vay] ([ma_ho_so]);
ALTER TABLE [dinh_gia] ADD FOREIGN KEY ([ma_tai_san]) REFERENCES [tai_san_the_chap] ([ma_tai_san]);
ALTER TABLE [dinh_gia] ADD FOREIGN KEY ([ma_nguoi_dinh_gia]) REFERENCES [nhan_vien] ([ma_nhan_vien]);
ALTER TABLE [phe_duyet] ADD FOREIGN KEY ([ma_ho_so]) REFERENCES [ho_so_vay] ([ma_ho_so]);
ALTER TABLE [phe_duyet] ADD FOREIGN KEY ([ma_nguoi_duyet]) REFERENCES [nhan_vien] ([ma_nhan_vien]);
ALTER TABLE [dang_ky_gd_bao_dam] ADD FOREIGN KEY ([ma_tai_san]) REFERENCES [tai_san_the_chap] ([ma_tai_san]);
ALTER TABLE [phieu_giai_ngan] ADD FOREIGN KEY ([ma_ho_so]) REFERENCES [ho_so_vay] ([ma_ho_so]);
ALTER TABLE [phieu_giai_ngan] ADD FOREIGN KEY ([ma_nhan_vien]) REFERENCES [nhan_vien] ([ma_nhan_vien]);
ALTER TABLE [hop_dong_vay] ADD FOREIGN KEY ([ma_ho_so]) REFERENCES [ho_so_vay] ([ma_ho_so]);
ALTER TABLE [hop_dong_vay] ADD FOREIGN KEY ([ma_nhan_vien]) REFERENCES [nhan_vien] ([ma_nhan_vien]);
ALTER TABLE [lich_tra_no] ADD FOREIGN KEY ([ma_hop_dong]) REFERENCES [hop_dong_vay] ([ma_hop_dong]);
ALTER TABLE [phieu_thu_no] ADD FOREIGN KEY ([ma_lich_tra_no]) REFERENCES [lich_tra_no] ([ma_lich_tra_no]);
ALTER TABLE [phieu_thu_no] ADD FOREIGN KEY ([ma_nhan_vien]) REFERENCES [nhan_vien] ([ma_nhan_vien]);
ALTER TABLE [nhac_no] ADD FOREIGN KEY ([ma_lich_tra_no]) REFERENCES [lich_tra_no] ([ma_lich_tra_no]);
ALTER TABLE [nhac_no] ADD FOREIGN KEY ([ma_nhan_vien]) REFERENCES [nhan_vien] ([ma_nhan_vien]);
ALTER TABLE [tai_co_cau_no] ADD FOREIGN KEY ([ma_hop_dong]) REFERENCES [hop_dong_vay] ([ma_hop_dong]);
ALTER TABLE [tai_co_cau_no] ADD FOREIGN KEY ([nguoi_phe_duyet]) REFERENCES [nhan_vien] ([ma_nhan_vien]);
ALTER TABLE [xu_ly_no_xau] ADD FOREIGN KEY ([ma_hop_dong]) REFERENCES [hop_dong_vay] ([ma_hop_dong]);
ALTER TABLE [xu_ly_no_xau] ADD FOREIGN KEY ([ma_nhan_vien]) REFERENCES [nhan_vien] ([ma_nhan_vien]);
ALTER TABLE [tat_toan] ADD FOREIGN KEY ([ma_hop_dong]) REFERENCES [hop_dong_vay] ([ma_hop_dong]);
ALTER TABLE [tat_toan] ADD FOREIGN KEY ([ma_nhan_vien]) REFERENCES [nhan_vien] ([ma_nhan_vien]);
GO

-- =========================================================
-- MÔ TẢ CỘT (EXTENDED PROPERTIES)
-- =========================================================
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'NHAN_VIEN_TIN_DUNG, CHUYEN_VIEN_DINH_GIA, QUAN_LY_CHI_NHANH, GIAO_DICH_VIEN, BAN_TIN_DUNG_HOI_SO, NHAN_VIEN_XU_LY_NO', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'nhan_vien', @level2type = N'Column', @level2name = 'vai_tro';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Hạn mức phê duyệt tối đa (nếu là cấp duyệt)', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'nhan_vien', @level2type = N'Column', @level2name = 'han_muc_phe_duyet';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'ACTIVE, INACTIVE', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'nhan_vien', @level2type = N'Column', @level2name = 'trang_thai';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Số CMND/CCCD', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'khach_hang', @level2type = N'Column', @level2name = 'so_cmnd_cccd';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Đường dẫn/mã hồ sơ chứng minh thu nhập', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'khach_hang', @level2type = N'Column', @level2name = 'hs_chung_minh_thu_nhap';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Nhân viên tín dụng lập hồ sơ', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'ho_so_vay', @level2type = N'Column', @level2name = 'ma_nhan_vien';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Thời hạn vay (tháng)', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'ho_so_vay', @level2type = N'Column', @level2name = 'thoi_han_thang';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Mục đích sử dụng vốn', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'ho_so_vay', @level2type = N'Column', @level2name = 'muc_dich_vay';EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'MOI_TAO, CHO_DINH_GIA, CHO_PHE_DUYET, CHO_BO_SUNG, TU_CHOI, DA_DUYET, DANG_VAY, DA_TAT_TOAN', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'ho_so_vay', @level2type = N'Column', @level2name = 'trang_thai';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'BAT_DONG_SAN, PHUONG_TIEN, SO_TIET_KIEM, KHAC', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'tai_san_the_chap', @level2type = N'Column', @level2name = 'loai_tai_san';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Số giấy tờ pháp lý tài sản', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'tai_san_the_chap', @level2type = N'Column', @level2name = 'so_giay_to_phap_ly';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Giá trị khách hàng tự khai', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'tai_san_the_chap', @level2type = N'Column', @level2name = 'gia_tri_khai_bao';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Chuyên viên định giá', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'dinh_gia', @level2type = N'Column', @level2name = 'ma_nguoi_dinh_gia';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'DAT, KHONG_DAT', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'dinh_gia', @level2type = N'Column', @level2name = 'ket_qua';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'CHI_NHANH, HOI_SO', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'phe_duyet', @level2type = N'Column', @level2name = 'cap_phe_duyet';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'DUYET, TU_CHOI, YEU_CAU_BO_SUNG', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'phe_duyet', @level2type = N'Column', @level2name = 'quyet_dinh';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Số tiền thực duyệt (có thể khác số đề nghị)', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'phe_duyet', @level2type = N'Column', @level2name = 'so_tien_duyet';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Số văn bản công chứng', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'dang_ky_gd_bao_dam', @level2type = N'Column', @level2name = 'so_cong_chung';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Cơ quan đăng ký giao dịch bảo đảm', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'dang_ky_gd_bao_dam', @level2type = N'Column', @level2name = 'co_quan_dang_ky';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'DA_DANG_KY, DA_GIAI_CHAP', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'dang_ky_gd_bao_dam', @level2type = N'Column', @level2name = 'trang_thai';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Giao dịch viên lập phiếu', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'phieu_giai_ngan', @level2type = N'Column', @level2name = 'ma_nhan_vien';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Lần giải ngân thứ mấy (nếu giải ngân nhiều đợt)', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'phieu_giai_ngan', @level2type = N'Column', @level2name = 'lan_giai_ngan';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Giao dịch viên lập hợp đồng/khế ước nhận nợ', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'hop_dong_vay', @level2type = N'Column', @level2name = 'ma_nhan_vien';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'CO_DINH, THA_NOI', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'hop_dong_vay', @level2type = N'Column', @level2name = 'loai_lai_suat';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'GOC_DEU, DU_NO_GIAM_DAN, GOC_CUOI_KY', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'hop_dong_vay', @level2type = N'Column', @level2name = 'phuong_thuc_tra_no';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Số ngày ân hạn trước khi tính quá hạn', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'hop_dong_vay', @level2type = N'Column', @level2name = 'so_ngay_an_han';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Phí phạt trả trước hạn (%)', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'hop_dong_vay', @level2type = N'Column', @level2name = 'phi_phat_tra_truoc_han';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'DANG_VAY, DA_TAT_TOAN', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'hop_dong_vay', @level2type = N'Column', @level2name = 'trang_thai';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Kỳ trả nợ thứ mấy', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'lich_tra_no', @level2type = N'Column', @level2name = 'ky_tra_no';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Lãi phạt quá hạn phát sinh', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'lich_tra_no', @level2type = N'Column', @level2name = 'lai_phat';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'CHUA_DEN_HAN, DA_THANH_TOAN, THANH_TOAN_MOT_PHAN, QUA_HAN', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'lich_tra_no', @level2type = N'Column', @level2name = 'trang_thai';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'NHOM_1..NHOM_5, phân loại theo số ngày quá hạn', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'lich_tra_no', @level2type = N'Column', @level2name = 'nhom_no';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Giao dịch viên lập phiếu thu nợ', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'phieu_thu_no', @level2type = N'Column', @level2name = 'ma_nhan_vien';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'DAY_DU, THIEU, THUA', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'phieu_thu_no', @level2type = N'Column', @level2name = 'loai_thanh_toan';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Số tiền thừa chuyển kỳ sau/hoàn trả', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'phieu_thu_no', @level2type = N'Column', @level2name = 'tien_thua';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'SMS, EMAIL, GOI_DIEN, VAN_BAN', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'nhac_no', @level2type = N'Column', @level2name = 'kenh_nhac_no';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Nhân viên xử lý nợ / cấp có thẩm quyền phê duyệt tái cơ cấu', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'tai_co_cau_no', @level2type = N'Column', @level2name = 'nguoi_phe_duyet';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'CHO_DUYET, DA_DUYET, TU_CHOI', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'tai_co_cau_no', @level2type = N'Column', @level2name = 'trang_thai';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'Nhân viên xử lý nợ phụ trách', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'xu_ly_no_xau', @level2type = N'Column', @level2name = 'ma_nhan_vien';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'PHAT_MAI_TAI_SAN, KHOI_KIEN, KHAC', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'xu_ly_no_xau', @level2type = N'Column', @level2name = 'hinh_thuc_xu_ly';
EXEC sp_addextendedproperty @name = N'MS_Description', @value = 'DUNG_HAN, TRUOC_HAN', @level0type = N'Schema', @level0name = 'dbo', @level1type = N'Table', @level1name = 'tat_toan', @level2type = N'Column', @level2name = 'loai_tat_toan';
GO