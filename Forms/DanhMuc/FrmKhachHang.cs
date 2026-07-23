using System;
using System.Windows.Forms;
using QuanLyTinDung.BUS;
using QuanLyTinDung.Common;
using QuanLyTinDung.DTO;

namespace QuanLyTinDung.Forms.DanhMuc
{
    public partial class FrmKhachHang : Form
    {
        private readonly KhachHangBUS _khachHangBUS;
        private BindingSource _bindingSource;
        private bool _dangThem = false;

        public FrmKhachHang()
        {
            InitializeComponent();
            _khachHangBUS = new KhachHangBUS();
            _bindingSource = new BindingSource();
            ThietLapGiaoDien();
            ThietLapDataGridView();
            TaiDuLieu();
        }

        private void ThietLapGiaoDien()
        {
            UiTheme.ApDungForm(this);
            lblTieuDe.Font = UiTheme.FontTieuDeForm;
            lblTieuDe.ForeColor = UiTheme.MauChuTieuDe;
            lblMoTa.Font = UiTheme.FontMoTa;
            lblMoTa.ForeColor = UiTheme.MauChuMo;
            UiTheme.ApDungTextBox(txtTimKiem);
            UiTheme.ApDungNutPhu(btnLamMoi);
            UiTheme.ApDungNutChinh(btnThem);
            UiTheme.ApDungNutPhu(btnSua);
            UiTheme.ApDungNutNguyHiem(btnXoa);
            UiTheme.ApDungNutChinh(btnLuu);
            UiTheme.ApDungNutPhu(btnHuy);
            UiTheme.ApDungNutPhu(btnDinhKem);
            foreach (Control c in pnlChiTiet.Controls)
            {
                if (c is TextBox txt) UiTheme.ApDungTextBox(txt);
            }
        }

        private void ThietLapDataGridView()
        {
            UiTheme.ApDungDataGridView(dgvDanhSach);
            dgvDanhSach.DataSource = _bindingSource;

            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaKhachHang", HeaderText = "Mã KH", Width = 60 });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HoTen", HeaderText = "Họ tên", Width = 150 });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoCmndCccd", HeaderText = "CCCD", Width = 110 });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgaySinh",
                HeaderText = "Ngày sinh",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "SoDienThoai", HeaderText = "SĐT", Width = 100 });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Width = 160 });
        }

        private void TaiDuLieu(string tuKhoa = "")
        {
            _bindingSource.DataSource = _khachHangBUS.TimKiem(tuKhoa);
        }

        private KhachHangDTO KhachHangDangChon()
        {
            if (dgvDanhSach.CurrentRow == null) return null;
            return dgvDanhSach.CurrentRow.DataBoundItem as KhachHangDTO;
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            var kh = KhachHangDangChon();
            if (kh == null || _dangThem) return;

            txtHoTen.Text = kh.HoTen;
            txtCccd.Text = kh.SoCmndCccd;
            dtpNgaySinh.Value = kh.NgaySinh == DateTime.MinValue ? DateTime.Now.AddYears(-18) : kh.NgaySinh;
            txtDiaChi.Text = kh.DiaChi;
            txtSoDienThoai.Text = kh.SoDienThoai;
            txtEmail.Text = kh.Email;
            txtHoSoThuNhap.Text = kh.HsChungMinhThuNhap;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e) => TaiDuLieu(txtTimKiem.Text.Trim());

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            TaiDuLieu();
            XoaTrangNhap();
        }

        private void XoaTrangNhap()
        {
            txtHoTen.Text = "";
            txtCccd.Text = "";
            dtpNgaySinh.Value = DateTime.Now.AddYears(-18);
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
            txtHoSoThuNhap.Text = "";
        }

        private void ChuyenCheDoNhap(bool nhap)
        {
            btnThem.Visible = !nhap;
            btnSua.Visible = !nhap;
            btnXoa.Visible = !nhap;
            btnLuu.Visible = nhap;
            btnHuy.Visible = nhap;
            dgvDanhSach.Enabled = !nhap;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _dangThem = true;
            XoaTrangNhap();
            ChuyenCheDoNhap(true);
            txtHoTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KhachHangDangChon() == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _dangThem = false;
            ChuyenCheDoNhap(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var kh = KhachHangDangChon();
            if (kh == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Xác nhận xoá khách hàng '{kh.HoTen}'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            KetQuaXuLy ketQua = _khachHangBUS.Xoa(kh.MaKhachHang);
            MessageBox.Show(ketQua.ThongBao, "Thông báo", MessageBoxButtons.OK,
                ketQua.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (ketQua.ThanhCong) TaiDuLieu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KetQuaXuLy ketQua;
            if (_dangThem)
            {
                var kh = new KhachHangDTO
                {
                    HoTen = txtHoTen.Text.Trim(),
                    SoCmndCccd = txtCccd.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value.Date,
                    DiaChi = txtDiaChi.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    HsChungMinhThuNhap = txtHoSoThuNhap.Text
                };
                ketQua = _khachHangBUS.Them(kh);
            }
            else
            {
                var khDangChon = KhachHangDangChon();
                if (khDangChon == null) return;
                var kh = new KhachHangDTO
                {
                    MaKhachHang = khDangChon.MaKhachHang,
                    HoTen = txtHoTen.Text.Trim(),
                    SoCmndCccd = txtCccd.Text.Trim(),
                    NgaySinh = dtpNgaySinh.Value.Date,
                    DiaChi = txtDiaChi.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    HsChungMinhThuNhap = txtHoSoThuNhap.Text
                };
                ketQua = _khachHangBUS.Sua(kh);
            }

            MessageBox.Show(ketQua.ThongBao, "Thông báo", MessageBoxButtons.OK,
                ketQua.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (ketQua.ThanhCong)
            {
                ChuyenCheDoNhap(false);
                TaiDuLieu();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ChuyenCheDoNhap(false);
            dgvDanhSach_SelectionChanged(sender, e);
        }

        private void btnDinhKem_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog { Filter = "Tài liệu (*.pdf;*.jpg;*.png;*.docx)|*.pdf;*.jpg;*.png;*.docx|Tất cả file (*.*)|*.*" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtHoSoThuNhap.Text = dlg.FileName;
                }
            }
        }
    }
}