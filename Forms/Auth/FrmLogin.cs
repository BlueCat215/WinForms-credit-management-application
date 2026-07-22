using System;
using System.Windows.Forms;
using QuanLyTinDung.BUS;
using QuanLyTinDung.Common;

namespace QuanLyTinDung.Forms.Auth
{
    public partial class FrmLogin : Form
    {
        private readonly NhanVienBUS _nhanVienBUS;

        public FrmLogin()
        {
            InitializeComponent();
            _nhanVienBUS = new NhanVienBUS();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblLoi.Text = "";

            // Validate rỗng ở Form trước khi gọi BUS
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                lblLoi.Text = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.";
                return;
            }

            KetQuaXuLy ketQua = _nhanVienBUS.DangNhap(txtTenDangNhap.Text.Trim(), txtMatKhau.Text);

            if (!ketQua.ThanhCong)
            {
                lblLoi.Text = ketQua.ThongBao;
                return;
            }

            // TODO: thay bằng FrmMain thật khi đã dựng xong.
            // Tạm thời mở form placeholder rỗng để xác nhận luồng đăng nhập hoạt động đúng.
            var frmPlaceholder = new Form
            {
                Text = "Trang chủ (placeholder - sẽ thay bằng FrmMain ở PHẦN 9)",
                Width = 800,
                Height = 500,
                StartPosition = FormStartPosition.CenterScreen
            };
            var lbl = new Label
            {
                Text = $"Xin chào {Security.UserSession.Instance.HoTen} " +
                       $"({Security.UserSession.Instance.VaiTro})",
                AutoSize = true,
                Location = new System.Drawing.Point(20, 20)
            };
            frmPlaceholder.Controls.Add(lbl);
            frmPlaceholder.Show();

            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}