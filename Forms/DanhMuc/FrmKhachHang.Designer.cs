namespace QuanLyTinDung.Forms.DanhMuc
{
    partial class FrmKhachHang
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
        private System.Windows.Forms.Label lblCccd;
        private System.Windows.Forms.TextBox txtCccd;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblHoSoThuNhap;
        private System.Windows.Forms.TextBox txtHoSoThuNhap;
        private System.Windows.Forms.Button btnDinhKem;

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
            this.lblCccd = new System.Windows.Forms.Label();
            this.txtCccd = new System.Windows.Forms.TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblHoSoThuNhap = new System.Windows.Forms.Label();
            this.txtHoSoThuNhap = new System.Windows.Forms.TextBox();
            this.btnDinhKem = new System.Windows.Forms.Button();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();

            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblMoTa);
            this.pnlHeader.Controls.Add(this.txtTimKiem);
            this.pnlHeader.Controls.Add(this.btnLamMoi);

            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(24, 10);
            this.lblTieuDe.Text = "Khách hàng";

            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(24, 38);
            this.lblMoTa.Text = "Hồ sơ khách hàng, CCCD và chứng minh thu nhập";

            this.txtTimKiem.Location = new System.Drawing.Point(560, 20);
            this.txtTimKiem.Size = new System.Drawing.Size(220, 27);
            this.txtTimKiem.PlaceholderText = "Tìm theo tên/CCCD...";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            this.btnLamMoi.Location = new System.Drawing.Point(790, 18);
            this.btnLamMoi.Size = new System.Drawing.Size(90, 32);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvDanhSach.Width = 700;
            this.dgvDanhSach.AutoGenerateColumns = false;
            this.dgvDanhSach.SelectionChanged += new System.EventHandler(this.dgvDanhSach_SelectionChanged);

            this.pnlChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChiTiet.BackColor = System.Drawing.Color.White;
            this.pnlChiTiet.AutoScroll = true;
            this.pnlChiTiet.Controls.Add(this.lblHoTen);
            this.pnlChiTiet.Controls.Add(this.txtHoTen);
            this.pnlChiTiet.Controls.Add(this.lblCccd);
            this.pnlChiTiet.Controls.Add(this.txtCccd);
            this.pnlChiTiet.Controls.Add(this.lblNgaySinh);
            this.pnlChiTiet.Controls.Add(this.dtpNgaySinh);
            this.pnlChiTiet.Controls.Add(this.lblDiaChi);
            this.pnlChiTiet.Controls.Add(this.txtDiaChi);
            this.pnlChiTiet.Controls.Add(this.lblSoDienThoai);
            this.pnlChiTiet.Controls.Add(this.txtSoDienThoai);
            this.pnlChiTiet.Controls.Add(this.lblEmail);
            this.pnlChiTiet.Controls.Add(this.txtEmail);
            this.pnlChiTiet.Controls.Add(this.lblHoSoThuNhap);
            this.pnlChiTiet.Controls.Add(this.txtHoSoThuNhap);
            this.pnlChiTiet.Controls.Add(this.btnDinhKem);
            this.pnlChiTiet.Controls.Add(this.btnThem);
            this.pnlChiTiet.Controls.Add(this.btnSua);
            this.pnlChiTiet.Controls.Add(this.btnXoa);
            this.pnlChiTiet.Controls.Add(this.btnLuu);
            this.pnlChiTiet.Controls.Add(this.btnHuy);

            int x = 24, w = 320;
            this.lblHoTen.AutoSize = true; this.lblHoTen.Location = new System.Drawing.Point(x, 24); this.lblHoTen.Text = "Họ tên";
            this.txtHoTen.Location = new System.Drawing.Point(x, 46); this.txtHoTen.Size = new System.Drawing.Size(w, 27);

            this.lblCccd.AutoSize = true; this.lblCccd.Location = new System.Drawing.Point(x, 86); this.lblCccd.Text = "Số CMND/CCCD";
            this.txtCccd.Location = new System.Drawing.Point(x, 108); this.txtCccd.Size = new System.Drawing.Size(w, 27);

            this.lblNgaySinh.AutoSize = true; this.lblNgaySinh.Location = new System.Drawing.Point(x, 148); this.lblNgaySinh.Text = "Ngày sinh";
            this.dtpNgaySinh.Location = new System.Drawing.Point(x, 170); this.dtpNgaySinh.Size = new System.Drawing.Size(w, 27);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblDiaChi.AutoSize = true; this.lblDiaChi.Location = new System.Drawing.Point(x, 210); this.lblDiaChi.Text = "Địa chỉ";
            this.txtDiaChi.Location = new System.Drawing.Point(x, 232); this.txtDiaChi.Size = new System.Drawing.Size(w, 27);

            this.lblSoDienThoai.AutoSize = true; this.lblSoDienThoai.Location = new System.Drawing.Point(x, 272); this.lblSoDienThoai.Text = "Số điện thoại";
            this.txtSoDienThoai.Location = new System.Drawing.Point(x, 294); this.txtSoDienThoai.Size = new System.Drawing.Size(w, 27);

            this.lblEmail.AutoSize = true; this.lblEmail.Location = new System.Drawing.Point(x, 334); this.lblEmail.Text = "Email";
            this.txtEmail.Location = new System.Drawing.Point(x, 356); this.txtEmail.Size = new System.Drawing.Size(w, 27);

            this.lblHoSoThuNhap.AutoSize = true; this.lblHoSoThuNhap.Location = new System.Drawing.Point(x, 396); this.lblHoSoThuNhap.Text = "Hồ sơ chứng minh thu nhập";
            this.txtHoSoThuNhap.Location = new System.Drawing.Point(x, 418); this.txtHoSoThuNhap.Size = new System.Drawing.Size(w, 27); this.txtHoSoThuNhap.ReadOnly = true;
            this.btnDinhKem.Location = new System.Drawing.Point(x, 452); this.btnDinhKem.Size = new System.Drawing.Size(180, 32);
            this.btnDinhKem.Text = "Đính kèm hồ sơ...";
            this.btnDinhKem.Click += new System.EventHandler(this.btnDinhKem_Click);

            this.btnThem.Location = new System.Drawing.Point(x, 510); this.btnThem.Size = new System.Drawing.Size(90, 34);
            this.btnThem.Text = "Thêm"; this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(x + 98, 510); this.btnSua.Size = new System.Drawing.Size(90, 34);
            this.btnSua.Text = "Sửa"; this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(x + 196, 510); this.btnXoa.Size = new System.Drawing.Size(90, 34);
            this.btnXoa.Text = "Xoá"; this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLuu.Location = new System.Drawing.Point(x, 510); this.btnLuu.Size = new System.Drawing.Size(90, 34);
            this.btnLuu.Text = "Lưu"; this.btnLuu.Visible = false; this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            this.btnHuy.Location = new System.Drawing.Point(x + 98, 510); this.btnHuy.Size = new System.Drawing.Size(90, 34);
            this.btnHuy.Text = "Huỷ"; this.btnHuy.Visible = false; this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            this.ClientSize = new System.Drawing.Size(1300, 650);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.pnlChiTiet);
            this.Controls.Add(this.pnlHeader);
            this.Text = "Quản lý Khách hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
        }
    }
}