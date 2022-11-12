using BTL_LTTQ_NHOM3_HETHONGBANGIAY.controller;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin loginView = new frmLogin();
            new LoginController(loginView);
            //Application.Run(new Form1());
        }
    }
}
