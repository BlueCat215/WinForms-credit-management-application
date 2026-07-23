namespace QuanLyTinDung.Forms.DanhMuc
{
    partial class FrmNhanVien
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Panel pnlChiTiet;

        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label lblChiNhanh;
        private System.Windows.Forms.ComboBox cboChiNhanh;
        private System.Windows.Forms.Label lblHanMuc;
        private System.Windows.Forms.TextBox txtHanMuc;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDatLaiMatKhau;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.pnlChiTiet = new System.Windows.Forms.Panel();

            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblVaiTro = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblChiNhanh = new System.Windows.Forms.Label();
            this.cboChiNhanh = new System.Windows.Forms.ComboBox();
            this.lblHanMuc = new System.Windows.Forms.Label();
            this.txtHanMuc = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnDatLaiMatKhau = new System.Windows.Forms.Button();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblMoTa);
            this.pnlHeader.Controls.Add(this.txtTimKiem);
            this.pnlHeader.Controls.Add(this.btnLamMoi);

            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(24, 10);
            this.lblTieuDe.Text = "Nhân viên";

            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(24, 38);
            this.lblMoTa.Text = "Danh sách nhân viên và tài khoản đăng nhập";

            this.txtTimKiem.Location = new System.Drawing.Point(560, 20);
            this.txtTimKiem.Size = new System.Drawing.Size(220, 27);
            this.txtTimKiem.PlaceholderText = "Tìm theo họ tên...";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            this.btnLamMoi.Location = new System.Drawing.Point(790, 18);
            this.btnLamMoi.Size = new System.Drawing.Size(90, 32);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // dgvDanhSach
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvDanhSach.Width = 680;
            this.dgvDanhSach.AutoGenerateColumns = false;
            this.dgvDanhSach.SelectionChanged += new System.EventHandler(this.dgvDanhSach_SelectionChanged);
            this.dgvDanhSach.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDanhSach_CellFormatting);

            // pnlChiTiet
            this.pnlChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChiTiet.BackColor = System.Drawing.Color.White;
            this.pnlChiTiet.AutoScroll = true;
            this.pnlChiTiet.Controls.Add(this.lblHoTen);
            this.pnlChiTiet.Controls.Add(this.txtHoTen);
            this.pnlChiTiet.Controls.Add(this.lblVaiTro);
            this.pnlChiTiet.Controls.Add(this.cboVaiTro);
            this.pnlChiTiet.Controls.Add(this.lblChiNhanh);
            this.pnlChiTiet.Controls.Add(this.cboChiNhanh);
            this.pnlChiTiet.Controls.Add(this.lblHanMuc);
            this.pnlChiTiet.Controls.Add(this.txtHanMuc);
            this.pnlChiTiet.Controls.Add(this.lblSoDienThoai);
            this.pnlChiTiet.Controls.Add(this.txtSoDienThoai);
            this.pnlChiTiet.Controls.Add(this.lblEmail);
            this.pnlChiTiet.Controls.Add(this.txtEmail);
            this.pnlChiTiet.Controls.Add(this.lblTrangThai);
            this.pnlChiTiet.Controls.Add(this.cboTrangThai);
            this.pnlChiTiet.Controls.Add(this.lblTenDangNhap);
            this.pnlChiTiet.Controls.Add(this.txtTenDangNhap);
            this.pnlChiTiet.Controls.Add(this.lblMatKhau);
            this.pnlChiTiet.Controls.Add(this.txtMatKhau);
            this.pnlChiTiet.Controls.Add(this.btnDatLaiMatKhau);
            this.pnlChiTiet.Controls.Add(this.btnThem);
            this.pnlChiTiet.Controls.Add(this.btnSua);
            this.pnlChiTiet.Controls.Add(this.btnXoa);
            this.pnlChiTiet.Controls.Add(this.btnLuu);
            this.pnlChiTiet.Controls.Add(this.btnHuy);

            int x = 24, w = 300;
            this.lblHoTen.AutoSize = true; this.lblHoTen.Location = new System.Drawing.Point(x, 24); this.lblHoTen.Text = "Họ tên";
            this.txtHoTen.Location = new System.Drawing.Point(x, 46); this.txtHoTen.Size = new System.Drawing.Size(w, 27);

            this.lblVaiTro.AutoSize = true; this.lblVaiTro.Location = new System.Drawing.Point(x, 86); this.lblVaiTro.Text = "Vai trò";
            this.cboVaiTro.Location = new System.Drawing.Point(x, 108); this.cboVaiTro.Size = new System.Drawing.Size(w, 27);
            this.cboVaiTro.SelectedIndexChanged += new System.EventHandler(this.cboVaiTro_SelectedIndexChanged);

            this.lblChiNhanh.AutoSize = true; this.lblChiNhanh.Location = new System.Drawing.Point(x, 148); this.lblChiNhanh.Text = "Chi nhánh";
            this.cboChiNhanh.Location = new System.Drawing.Point(x, 170); this.cboChiNhanh.Size = new System.Drawing.Size(w, 27);

            this.lblHanMuc.AutoSize = true; this.lblHanMuc.Location = new System.Drawing.Point(x, 210); this.lblHanMuc.Text = "Hạn mức phê duyệt (VNĐ)";
            this.txtHanMuc.Location = new System.Drawing.Point(x, 232); this.txtHanMuc.Size = new System.Drawing.Size(w, 27);

            this.lblSoDienThoai.AutoSize = true; this.lblSoDienThoai.Location = new System.Drawing.Point(x, 272); this.lblSoDienThoai.Text = "Số điện thoại";
            this.txtSoDienThoai.Location = new System.Drawing.Point(x, 294); this.txtSoDienThoai.Size = new System.Drawing.Size(w, 27);

            this.lblEmail.AutoSize = true; this.lblEmail.Location = new System.Drawing.Point(x, 334); this.lblEmail.Text = "Email";
            this.txtEmail.Location = new System.Drawing.Point(x, 356); this.txtEmail.Size = new System.Drawing.Size(w, 27);

            this.lblTrangThai.AutoSize = true; this.lblTrangThai.Location = new System.Drawing.Point(x, 396); this.lblTrangThai.Text = "Trạng thái";
            this.cboTrangThai.Location = new System.Drawing.Point(x, 418); this.cboTrangThai.Size = new System.Drawing.Size(w, 27);

            this.lblTenDangNhap.AutoSize = true; this.lblTenDangNhap.Location = new System.Drawing.Point(x, 458); this.lblTenDangNhap.Text = "Tên đăng nhập";
            this.txtTenDangNhap.Location = new System.Drawing.Point(x, 480); this.txtTenDangNhap.Size = new System.Drawing.Size(w, 27);

            this.lblMatKhau.AutoSize = true; this.lblMatKhau.Location = new System.Drawing.Point(x, 520); this.lblMatKhau.Text = "Mật khẩu (khi thêm mới)";
            this.txtMatKhau.Location = new System.Drawing.Point(x, 542); this.txtMatKhau.Size = new System.Drawing.Size(w, 27); this.txtMatKhau.PasswordChar = '●';

            this.btnDatLaiMatKhau.Location = new System.Drawing.Point(x, 582); this.btnDatLaiMatKhau.Size = new System.Drawing.Size(150, 32);
            this.btnDatLaiMatKhau.Text = "Đặt lại mật khẩu";
            this.btnDatLaiMatKhau.Click += new System.EventHandler(this.btnDatLaiMatKhau_Click);

            this.btnThem.Location = new System.Drawing.Point(x, 630); this.btnThem.Size = new System.Drawing.Size(90, 34);
            this.btnThem.Text = "Thêm"; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(x + 98, 630); this.btnSua.Size = new System.Drawing.Size(90, 34);
            this.btnSua.Text = "Sửa"; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(x + 196, 630); this.btnXoa.Size = new System.Drawing.Size(90, 34);
            this.btnXoa.Text = "Xoá"; this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLuu.Location = new System.Drawing.Point(x, 630); this.btnLuu.Size = new System.Drawing.Size(90, 34);
            this.btnLuu.Text = "Lưu"; this.btnLuu.Visible = false; this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            this.btnHuy.Location = new System.Drawing.Point(x + 98, 630); this.btnHuy.Size = new System.Drawing.Size(90, 34);
            this.btnHuy.Text = "Huỷ"; this.btnHuy.Visible = false; this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // FrmNhanVien
            this.ClientSize = new System.Drawing.Size(1250, 700);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.pnlChiTiet);
            this.Controls.Add(this.pnlHeader);
            this.Text = "Quản lý Nhân viên";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
        }
    }
}