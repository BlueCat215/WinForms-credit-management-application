using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyTinDung.BUS;
using QuanLyTinDung.Common;
using QuanLyTinDung.DTO;
using QuanLyTinDung.Security;

namespace QuanLyTinDung.Forms.DanhMuc
{
    public partial class FrmNhanVien : Form
    {
        private readonly NhanVienBUS _nhanVienBUS;
        private readonly ChiNhanhBUS _chiNhanhBUS;
        private BindingSource _bindingSource;
        private bool _dangThem = false;

        // RÀNG BUỘC: chỉ QUAN_LY_CHI_NHANH mới được Thêm/Sửa/Xoá, các vai trò khác chỉ xem
        private bool DuocPhepChinhSua => UserSession.Instance.VaiTro == QuanLyTinDung.Security.VaiTro.QUAN_LY_CHI_NHANH;

        public FrmNhanVien()
        {
            InitializeComponent();
            _nhanVienBUS = new NhanVienBUS();
            _chiNhanhBUS = new ChiNhanhBUS();
            _bindingSource = new BindingSource();
            ThietLapGiaoDien();
            ThietLapComboBox();
            ThietLapDataGridView();
            TaiDuLieu();
            ApDungPhanQuyen();
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
            UiTheme.ApDungNutPhu(btnDatLaiMatKhau);
            foreach (Control c in pnlChiTiet.Controls)
            {
                if (c is TextBox txt) UiTheme.ApDungTextBox(txt);
                if (c is ComboBox cbo) UiTheme.ApDungComboBox(cbo);
            }
        }

        private void ThietLapComboBox()
        {
            cboVaiTro.DataSource = Enum.GetValues(typeof(VaiTroNhanVien));
            cboTrangThai.DataSource = Enum.GetValues(typeof(TrangThaiNhanVien));
            NapDanhSachChiNhanh();
        }

        private void NapDanhSachChiNhanh()
        {
            var dsChiNhanh = _chiNhanhBUS.LayDanhSach();
            cboChiNhanh.DataSource = dsChiNhanh;
            cboChiNhanh.DisplayMember = "TenChiNhanh";
            cboChiNhanh.ValueMember = "MaChiNhanh";
        }

        private void ThietLapDataGridView()
        {
            UiTheme.ApDungDataGridView(dgvDanhSach);
            dgvDanhSach.DataSource = _bindingSource;

            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaNhanVien", HeaderText = "Mã NV", Width = 60 });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HoTen", HeaderText = "Họ tên", Width = 160 });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "VaiTro", HeaderText = "Vai trò", Width = 160, Name = "colVaiTro" });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaChiNhanh", HeaderText = "Chi nhánh", Width = 150, Name = "colChiNhanh" });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TrangThai", HeaderText = "Trạng thái", Width = 90 });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenDangNhap", HeaderText = "Tên đăng nhập", Width = 110 });
        }

        // Hiển thị tên chi nhánh thay vì mã chi nhánh trong lưới danh sách
        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSach.Columns[e.ColumnIndex].Name == "colChiNhanh" && e.Value != null)
            {
                var cn = _chiNhanhBUS.LayTheoMa((int)e.Value);
                e.Value = cn?.TenChiNhanh ?? e.Value.ToString();
                e.FormattingApplied = true;
            }
        }

        private void TaiDuLieu(string tuKhoa = "")
        {
            var ds = _nhanVienBUS.LayDanhSach();
            if (!string.IsNullOrWhiteSpace(tuKhoa))
                ds = ds.Where(n => n.HoTen != null && n.HoTen.ToLower().Contains(tuKhoa.ToLower())).ToList();
            _bindingSource.DataSource = ds;
        }

        private NhanVienDTO NhanVienDangChon()
        {
            if (dgvDanhSach.CurrentRow == null) return null;
            return dgvDanhSach.CurrentRow.DataBoundItem as NhanVienDTO;
        }

        private void ApDungPhanQuyen()
        {
            btnThem.Enabled = DuocPhepChinhSua;
            btnSua.Enabled = DuocPhepChinhSua;
            btnXoa.Enabled = DuocPhepChinhSua;
            btnDatLaiMatKhau.Enabled = DuocPhepChinhSua;
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            var nv = NhanVienDangChon();
            if (nv == null || _dangThem) return;

            txtHoTen.Text = nv.HoTen;
            cboVaiTro.SelectedItem = Enum.Parse(typeof(VaiTroNhanVien), nv.VaiTro);
            cboChiNhanh.SelectedValue = nv.MaChiNhanh;
            txtHanMuc.Text = nv.HanMucPheDuyet.ToString();
            txtSoDienThoai.Text = nv.SoDienThoai;
            txtEmail.Text = nv.Email;
            cboTrangThai.SelectedItem = Enum.Parse(typeof(TrangThaiNhanVien), nv.TrangThai);
            txtTenDangNhap.Text = nv.TenDangNhap;
            txtMatKhau.Text = "";
            txtMatKhau.Enabled = false;
        }

        private void cboVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // RÀNG BUỘC: chỉ vai trò có quyền duyệt mới được nhập hạn mức phê duyệt
            var vaiTroChon = (VaiTroNhanVien)cboVaiTro.SelectedItem;
            bool coQuyenDuyet = vaiTroChon == VaiTroNhanVien.QUAN_LY_CHI_NHANH || vaiTroChon == VaiTroNhanVien.BAN_TIN_DUNG_HOI_SO;
            txtHanMuc.Enabled = coQuyenDuyet;
            if (!coQuyenDuyet) txtHanMuc.Text = "0";
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
            if (cboVaiTro.Items.Count > 0) cboVaiTro.SelectedIndex = 0;
            if (cboChiNhanh.Items.Count > 0) cboChiNhanh.SelectedIndex = 0;
            txtHanMuc.Text = "0";
            txtSoDienThoai.Text = "";
            txtEmail.Text = "";
            if (cboTrangThai.Items.Count > 0) cboTrangThai.SelectedIndex = 0;
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
        }

        private void ChuyenCheDoNhap(bool nhap)
        {
            btnThem.Visible = !nhap && DuocPhepChinhSua;
            btnSua.Visible = !nhap && DuocPhepChinhSua;
            btnXoa.Visible = !nhap && DuocPhepChinhSua;
            btnLuu.Visible = nhap;
            btnHuy.Visible = nhap;
            dgvDanhSach.Enabled = !nhap;
            txtMatKhau.Enabled = nhap && _dangThem;
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
            if (NhanVienDangChon() == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _dangThem = false;
            ChuyenCheDoNhap(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var nv = NhanVienDangChon();
            if (nv == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Xác nhận xoá nhân viên '{nv.HoTen}'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            KetQuaXuLy ketQua = _nhanVienBUS.Xoa(nv.MaNhanVien);
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

            decimal.TryParse(txtHanMuc.Text, out decimal hanMuc);

            KetQuaXuLy ketQua;
            if (_dangThem)
            {
                var nv = new NhanVienDTO
                {
                    HoTen = txtHoTen.Text.Trim(),
                    VaiTro = cboVaiTro.SelectedItem.ToString(),
                    MaChiNhanh = (int)cboChiNhanh.SelectedValue,
                    HanMucPheDuyet = hanMuc,
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    TrangThai = cboTrangThai.SelectedItem.ToString(),
                    TenDangNhap = txtTenDangNhap.Text.Trim()
                };
                ketQua = _nhanVienBUS.Them(nv, txtMatKhau.Text);
            }
            else
            {
                var nvDangChon = NhanVienDangChon();
                if (nvDangChon == null) return;
                var nv = new NhanVienDTO
                {
                    MaNhanVien = nvDangChon.MaNhanVien,
                    HoTen = txtHoTen.Text.Trim(),
                    VaiTro = cboVaiTro.SelectedItem.ToString(),
                    MaChiNhanh = (int)cboChiNhanh.SelectedValue,
                    HanMucPheDuyet = hanMuc,
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    TrangThai = cboTrangThai.SelectedItem.ToString(),
                    TenDangNhap = txtTenDangNhap.Text.Trim()
                };
                ketQua = _nhanVienBUS.Sua(nv);
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

        private void btnDatLaiMatKhau_Click(object sender, EventArgs e)
        {
            var nv = NhanVienDangChon();
            if (nv == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần đặt lại mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var frmNhap = new Form
            {
                Text = "Đặt lại mật khẩu",
                Width = 340,
                Height = 160,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            })
            {
                var lbl = new Label { Text = $"Mật khẩu mới cho '{nv.HoTen}':", AutoSize = true, Location = new System.Drawing.Point(15, 15) };
                var txt = new TextBox { Location = new System.Drawing.Point(15, 40), Width = 290, PasswordChar = '●' };
                var btnOk = new Button { Text = "Xác nhận", Location = new System.Drawing.Point(15, 75), DialogResult = DialogResult.OK };
                UiTheme.ApDungNutChinh(btnOk);
                frmNhap.Controls.Add(lbl);
                frmNhap.Controls.Add(txt);
                frmNhap.Controls.Add(btnOk);
                frmNhap.AcceptButton = btnOk;

                if (frmNhap.ShowDialog(this) == DialogResult.OK)
                {
                    KetQuaXuLy ketQua = _nhanVienBUS.DatLaiMatKhau(nv.MaNhanVien, txt.Text);
                    MessageBox.Show(ketQua.ThongBao, "Thông báo", MessageBoxButtons.OK,
                        ketQua.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                }
            }
        }
    }
}