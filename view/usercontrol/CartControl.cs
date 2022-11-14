using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
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
    public partial class CartControl : UserControl
    {
        public event UserEvent removeAllinCart;
        public CartControl()
        {
            InitializeComponent();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            removeAllinCart?.Invoke();
        }
    }
}
