using BTL_LTTQ_NHOM3_HETHONGBANGIAY.controller;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager
{
    public partial class frmManager : Form
    {
        private StoreController storeController = null;
        public frmManager()
        {
            InitializeComponent();
        }
        private void btnSell_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(storeControl);
            if (storeController == null)
            {
                storeController = new StoreController(storeControl);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(homeControl);
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(listProduct);
        }

        public static void bringToFontUsercontrol(UserControl namePanel)
        {
            namePanel.BringToFront();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
