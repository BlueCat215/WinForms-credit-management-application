using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTinDung.Common
{
    /// <summary>
    /// Định nghĩa màu sắc/font dùng chung cho toàn bộ Form, phỏng theo bảng màu
    /// của bộ template thiết kế (tham khảo màu sắc, không copy layout HTML gốc).
    /// </summary>
    public static class UiTheme
    {
        public static readonly Color MauNen = ColorTranslator.FromHtml("#F4F5F7");
        public static readonly Color MauNenPhu = ColorTranslator.FromHtml("#F9FAFB");
        public static readonly Color MauChinh = ColorTranslator.FromHtml("#1E2939");
        public static readonly Color MauVien = ColorTranslator.FromHtml("#E5E7EB");
        public static readonly Color MauVienNhat = ColorTranslator.FromHtml("#F3F4F6");
        public static readonly Color MauChuTieuDe = ColorTranslator.FromHtml("#101828");
        public static readonly Color MauChuChinh = ColorTranslator.FromHtml("#1E2939");
        public static readonly Color MauChuPhu = ColorTranslator.FromHtml("#4A5565");
        public static readonly Color MauChuMo = ColorTranslator.FromHtml("#99A1AF");

        public static readonly Font FontTieuDe = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font FontTieuDeForm = new Font("Segoe UI", 13F, FontStyle.Bold);
        public static readonly Font FontMoTa = new Font("Segoe UI", 9F);
        public static readonly Font FontChu = new Font("Segoe UI", 9.5F);
        public static readonly Font FontChuDam = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        public static readonly Font FontMa = new Font("Consolas", 9.5F);
        public static readonly Font FontHeaderGrid = new Font("Segoe UI", 8.5F, FontStyle.Bold);

        public enum MauBadge { Xam, Cam, Xanh, Do, XanhDuong }

        public static void ApDungForm(Form frm)
        {
            frm.BackColor = MauNen;
            frm.Font = FontChu;
            frm.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void ApDungNutChinh(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = MauChinh;
            btn.ForeColor = Color.White;
            btn.Font = FontChuDam;
            btn.Cursor = Cursors.Hand;
            btn.Height = 34;
        }

        public static void ApDungNutPhu(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = MauVien;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = MauNenPhu;
            btn.ForeColor = MauChuChinh;
            btn.Font = FontChu;
            btn.Cursor = Cursors.Hand;
            btn.Height = 34;
        }

        public static void ApDungNutNguyHiem(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#FCA5A5");
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = ColorTranslator.FromHtml("#FEF2F2");
            btn.ForeColor = ColorTranslator.FromHtml("#B91C1C");
            btn.Font = FontChu;
            btn.Cursor = Cursors.Hand;
            btn.Height = 34;
        }

        public static void ApDungTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = FontChu;
        }

        public static void ApDungComboBox(ComboBox cbo)
        {
            cbo.FlatStyle = FlatStyle.Flat;
            cbo.Font = FontChu;
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static void ApDungDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = MauVienNhat;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowTemplate.Height = 38;
            dgv.Font = FontChu;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = MauNenPhu;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = MauChuMo;
            dgv.ColumnHeadersDefaultCellStyle.Font = FontHeaderGrid;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 36;
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = MauChuChinh;
            dgv.DefaultCellStyle.SelectionBackColor = MauVienNhat;
            dgv.DefaultCellStyle.SelectionForeColor = MauChuChinh;
            dgv.DefaultCellStyle.Padding = new Padding(4, 0, 0, 0);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = MauNenPhu;
        }

        /// <summary>Style dạng badge (pill) cho label trạng thái, phỏng theo mẫu template.</summary>
        public static void ApDungBadge(Label lbl, MauBadge mau)
        {
            lbl.AutoSize = true;
            lbl.Padding = new Padding(10, 4, 10, 4);
            lbl.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            switch (mau)
            {
                case MauBadge.Xanh:
                    lbl.BackColor = ColorTranslator.FromHtml("#F0FDF4");
                    lbl.ForeColor = ColorTranslator.FromHtml("#166534");
                    break;
                case MauBadge.Cam:
                    lbl.BackColor = ColorTranslator.FromHtml("#FFF7ED");
                    lbl.ForeColor = MauChinh;
                    break;
                case MauBadge.Do:
                    lbl.BackColor = ColorTranslator.FromHtml("#FEF2F2");
                    lbl.ForeColor = ColorTranslator.FromHtml("#B91C1C");
                    break;
                case MauBadge.XanhDuong:
                    lbl.BackColor = ColorTranslator.FromHtml("#EFF6FF");
                    lbl.ForeColor = ColorTranslator.FromHtml("#1D4ED8");
                    break;
                default:
                    lbl.BackColor = MauVienNhat;
                    lbl.ForeColor = MauChuPhu;
                    break;
            }
        }
    }
}
