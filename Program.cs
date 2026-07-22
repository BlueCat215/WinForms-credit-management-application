using System;
using System.Windows.Forms;
using QuanLyTinDung.Forms.Auth;

namespace QuanLyTinDung
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmLogin());
        }
    }
}