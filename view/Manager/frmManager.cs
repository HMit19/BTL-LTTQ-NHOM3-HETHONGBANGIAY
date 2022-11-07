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
        public frmManager()
        {
            InitializeComponent();
        }

        private void frmManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát!", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
        private void btnSell_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(storeControl);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(homeControl);
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(listProduct);
        }

        private void bringToFontUsercontrol(UserControl namePanel)
        {
            namePanel.BringToFront();
        }
    }
}
