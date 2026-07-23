namespace QuanLyTinDung.Forms.DanhMuc
{
    partial class FrmChiNhanh
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
        private System.Windows.Forms.Label lblTenChiNhanh;
        private System.Windows.Forms.TextBox txtTenChiNhanh;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
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
            this.lblTenChiNhanh = new System.Windows.Forms.Label();
            this.txtTenChiNhanh = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
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
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.pnlHeader.Controls.Add(this.lblTieuDe);
            this.pnlHeader.Controls.Add(this.lblMoTa);
            this.pnlHeader.Controls.Add(this.txtTimKiem);
            this.pnlHeader.Controls.Add(this.btnLamMoi);

            // lblTieuDe
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Location = new System.Drawing.Point(24, 10);
            this.lblTieuDe.Text = "Chi nhánh";

            // lblMoTa
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(24, 38);
            this.lblMoTa.Text = "Danh sách chi nhánh trong hệ thống";

            // txtTimKiem
            this.txtTimKiem.Location = new System.Drawing.Point(560, 20);
            this.txtTimKiem.Size = new System.Drawing.Size(220, 27);
            this.txtTimKiem.PlaceholderText = "Tìm theo tên chi nhánh...";
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);

            // btnLamMoi
            this.btnLamMoi.Location = new System.Drawing.Point(790, 18);
            this.btnLamMoi.Size = new System.Drawing.Size(90, 32);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // dgvDanhSach
            this.dgvDanhSach.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvDanhSach.Width = 650;
            this.dgvDanhSach.AutoGenerateColumns = false;
            this.dgvDanhSach.SelectionChanged += new System.EventHandler(this.dgvDanhSach_SelectionChanged);

            // pnlChiTiet
            this.pnlChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChiTiet.BackColor = System.Drawing.Color.White;
            this.pnlChiTiet.Padding = new System.Windows.Forms.Padding(24);
            this.pnlChiTiet.Controls.Add(this.lblTenChiNhanh);
            this.pnlChiTiet.Controls.Add(this.txtTenChiNhanh);
            this.pnlChiTiet.Controls.Add(this.lblDiaChi);
            this.pnlChiTiet.Controls.Add(this.txtDiaChi);
            this.pnlChiTiet.Controls.Add(this.lblSoDienThoai);
            this.pnlChiTiet.Controls.Add(this.txtSoDienThoai);
            this.pnlChiTiet.Controls.Add(this.btnThem);
            this.pnlChiTiet.Controls.Add(this.btnSua);
            this.pnlChiTiet.Controls.Add(this.btnXoa);
            this.pnlChiTiet.Controls.Add(this.btnLuu);
            this.pnlChiTiet.Controls.Add(this.btnHuy);

            // lblTenChiNhanh
            this.lblTenChiNhanh.AutoSize = true;
            this.lblTenChiNhanh.Location = new System.Drawing.Point(24, 30);
            this.lblTenChiNhanh.Text = "Tên chi nhánh";

            // txtTenChiNhanh
            this.txtTenChiNhanh.Location = new System.Drawing.Point(24, 52);
            this.txtTenChiNhanh.Size = new System.Drawing.Size(300, 27);

            // lblDiaChi
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(24, 95);
            this.lblDiaChi.Text = "Địa chỉ";

            // txtDiaChi
            this.txtDiaChi.Location = new System.Drawing.Point(24, 117);
            this.txtDiaChi.Size = new System.Drawing.Size(300, 27);

            // lblSoDienThoai
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location = new System.Drawing.Point(24, 160);
            this.lblSoDienThoai.Text = "Số điện thoại";

            // txtSoDienThoai
            this.txtSoDienThoai.Location = new System.Drawing.Point(24, 182);
            this.txtSoDienThoai.Size = new System.Drawing.Size(300, 27);

            // btnThem
            this.btnThem.Location = new System.Drawing.Point(24, 240);
            this.btnThem.Size = new System.Drawing.Size(90, 34);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // btnSua
            this.btnSua.Location = new System.Drawing.Point(122, 240);
            this.btnSua.Size = new System.Drawing.Size(90, 34);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            // btnXoa
            this.btnXoa.Location = new System.Drawing.Point(220, 240);
            this.btnXoa.Size = new System.Drawing.Size(90, 34);
            this.btnXoa.Text = "Xoá";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // btnLuu
            this.btnLuu.Location = new System.Drawing.Point(24, 284);
            this.btnLuu.Size = new System.Drawing.Size(90, 34);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            // btnHuy
            this.btnHuy.Location = new System.Drawing.Point(122, 284);
            this.btnHuy.Size = new System.Drawing.Size(90, 34);
            this.btnHuy.Text = "Huỷ";
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);

            // FrmChiNhanh
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.pnlChiTiet);
            this.Controls.Add(this.pnlHeader);
            this.Text = "Quản lý Chi nhánh";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
        }
    }
}