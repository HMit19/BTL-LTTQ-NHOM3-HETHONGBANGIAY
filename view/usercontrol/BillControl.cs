using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol
{
    public partial class BillControl : UserControl
    {
        public BillControl()
        {
            InitializeComponent();
            txtSearch.Text = "Tìm kiếm hóa đơn theo...";
            txtSearch.ForeColor = SystemColors.GrayText;
            cbbType.SelectedIndex = 0;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "Tìm kiếm hóa đơn theo...";
                txtSearch.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm hóa đơn theo...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.WindowText;
            }
        }

    }
}
