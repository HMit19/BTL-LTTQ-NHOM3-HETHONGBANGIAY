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
    public partial class ItemSize : UserControl
    {
        public event UserEventParam chooseSize;
        public ItemSize()
        {
            InitializeComponent();
        }
        public ItemSize(string size)
        {
            InitializeComponent();
            this.size.Text = size;
        }
        public string getSize() { return this.size.Text; }

        private void size_Click(object sender, EventArgs e)
        {
            chooseSize?.Invoke(this);
        }
        public void setBorder(bool choose = false)
        {
            if (choose) this.size.BorderColor = Color.Red;
            else this.size.BorderColor = Color.Silver;
        }
        public void setEnable(bool choose = false)
        {
            this.size.Enabled = choose;
        }
    }
}
