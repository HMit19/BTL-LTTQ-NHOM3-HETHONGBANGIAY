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
    public partial class ItemColor : UserControl
    {
        public event UserEventParam chooseColor;
        public ItemColor()
        {
            InitializeComponent();
        }
        public ItemColor(string color)
        {
            InitializeComponent();
            this.color.Text = color;
        }

        private void color_Click(object sender, EventArgs e)
        {
            chooseColor?.Invoke(this);
        }
        public string getColor()
        {
            return color.Text;
        }
        public void setBorder(bool choose = false)
        {
            if (choose) this.color.BorderColor = Color.Red;
            else this.color.BorderColor = Color.Silver;
        }
        public void setEnable(bool choose = false)
        {
            this.color.Enabled = choose;
        }
    }
}
