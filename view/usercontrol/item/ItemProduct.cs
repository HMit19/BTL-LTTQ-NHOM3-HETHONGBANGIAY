using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item
{
    public partial class ItemProduct : UserControl
    {
        public ItemProduct()
        {
            InitializeComponent();
        }
        public ItemProduct(string image, string name, string price, string quantity)
        {
            InitializeComponent();
            this.name.Text = name;
            this.price.Text = price;
            this.quantity.Text = quantity;
        }
    }
}
