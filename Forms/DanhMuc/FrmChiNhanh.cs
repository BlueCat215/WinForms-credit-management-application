using System;
using System.Windows.Forms;
using QuanLyTinDung.BUS;
using QuanLyTinDung.Common;
using QuanLyTinDung.DTO;

namespace QuanLyTinDung.Forms.DanhMuc
{
    public partial class FrmChiNhanh : Form
    {
        private readonly ChiNhanhBUS _chiNhanhBUS;
        private BindingSource _bindingSource;
        private bool _dangThem = false;

        public FrmChiNhanh()
        {
            InitializeComponent();
            _chiNhanhBUS = new ChiNhanhBUS();
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
            foreach (Control c in pnlChiTiet.Controls)
            {
                if (c is TextBox txt) UiTheme.ApDungTextBox(txt);
                if (c is Label lbl && lbl != lblTenChiNhanh) { }
            }
        }

        private void ThietLapDataGridView()
        {
            UiTheme.ApDungDataGridView(dgvDanhSach);
            dgvDanhSach.DataSource = _bindingSource;

            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MaChiNhanh",
                HeaderText = "Mã CN",
                Width = 70
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenChiNhanh",
                HeaderText = "Tên chi nhánh",
                Width = 220
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DiaChi",
                HeaderText = "Địa chỉ",
                Width = 220
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SoDienThoai",
                HeaderText = "SĐT",
                Width = 110
            });
            dgvDanhSach.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgayTao",
                HeaderText = "Ngày tạo",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
        }

        private void TaiDuLieu(string tuKhoa = "")
        {
            _bindingSource.DataSource = _chiNhanhBUS.TimKiem(tuKhoa);
        }

        private ChiNhanhDTO ChiNhanhDangChon()
        {
            if (dgvDanhSach.CurrentRow == null) return null;
            return (dgvDanhSach.CurrentRow.DataBoundItem as ChiNhanhDTO);
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            var cn = ChiNhanhDangChon();
            if (cn == null || _dangThem) return;
            txtTenChiNhanh.Text = cn.TenChiNhanh;
            txtDiaChi.Text = cn.DiaChi;
            txtSoDienThoai.Text = cn.SoDienThoai;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TaiDuLieu(txtTimKiem.Text.Trim());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            TaiDuLieu();
            XoaTrangNhap();
        }

        private void XoaTrangNhap()
        {
            txtTenChiNhanh.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
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
            txtTenChiNhanh.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ChiNhanhDangChon() == null)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _dangThem = false;
            ChuyenCheDoNhap(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var cn = ChiNhanhDangChon();
            if (cn == null)
            {
                MessageBox.Show("Vui lòng chọn chi nhánh cần xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show($"Xác nhận xoá chi nhánh '{cn.TenChiNhanh}'?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            KetQuaXuLy ketQua = _chiNhanhBUS.Xoa(cn.MaChiNhanh);
            MessageBox.Show(ketQua.ThongBao, "Thông báo", MessageBoxButtons.OK,
                ketQua.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (ketQua.ThanhCong) TaiDuLieu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenChiNhanh.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chi nhánh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KetQuaXuLy ketQua;
            if (_dangThem)
            {
                var cn = new ChiNhanhDTO
                {
                    TenChiNhanh = txtTenChiNhanh.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim()
                };
                ketQua = _chiNhanhBUS.Them(cn);
            }
            else
            {
                var cnDangChon = ChiNhanhDangChon();
                if (cnDangChon == null) return;
                var cn = new ChiNhanhDTO
                {
                    MaChiNhanh = cnDangChon.MaChiNhanh,
                    TenChiNhanh = txtTenChiNhanh.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim()
                };
                ketQua = _chiNhanhBUS.Sua(cn);
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
    }
}