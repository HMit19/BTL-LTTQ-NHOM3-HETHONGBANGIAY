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

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            //btnLogout.BackColor = Color.FromArgb(231, 233, 237);
        }

        private void btnLogout_MouseMove(object sender, MouseEventArgs e)
        {
            //btnLogout.BackColor = Color.FromArgb(165, 216, 255);
        }

        private void btnCart_MouseMove(object sender, MouseEventArgs e)
        {
            btnCart.BackColor = Color.FromArgb(165, 216, 255);
        }

        private void btnCart_MouseLeave(object sender, EventArgs e)
        {
            btnCart.BackColor = Color.FromArgb(231, 233, 237);
        }

        private void btnSetting_MouseLeave(object sender, EventArgs e)
        {
            btnSetting.BackColor = Color.FromArgb(231, 233, 237);
            
        }

        private void btnSetting_MouseMove(object sender, MouseEventArgs e)
        {
            btnSetting.BackColor = Color.FromArgb(165, 216, 255);
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
        }

    }
}
