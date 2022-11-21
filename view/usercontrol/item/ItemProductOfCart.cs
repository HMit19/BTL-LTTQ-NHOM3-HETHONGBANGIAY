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
    public partial class ItemProductOfCart : UserControl
    {
        public event UserEventParam deleteItemInCart;
        public event UserEventParam changeQuantity;
        public ItemProductOfCart()
        {
            InitializeComponent();
        }
        public ItemProductOfCart(int index, string idItemDetail, string image, string name, string color, string size, string quantity, string price)
        {
            InitializeComponent();
            this.index.Text = index.ToString();
            this.idItemDetail.Text = idItemDetail;
            setImage(image);
            this.image.Text = image;
            this.name.Text = name;
            this.color.Text = color;
            this.size.Text = size;
            this.quantity.Text = quantity;
            this.price.Text = price;
            this.total.Text = (Convert.ToDouble(price) * Convert.ToDouble(quantity)).ToString("#,###");
        }
        public void setImage(string image)
        {
            string path = Application.StartupPath + "\\images\\";
            string imageDefault = "default.jpg";
            try
            {
                this.image.Image = Image.FromFile(path + image);
            }
            catch (Exception e)
            {
                this.image.Image = Image.FromFile(path + imageDefault);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chắc chắc xóa sản phẩm khỏi giỏ hàng?", "Xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                deleteItemInCart?.Invoke(this);
        }
        public string getTotalPrice() { return this.total.Text; }
        public string getIdBillDetailSell()
        {
            return this.idItemDetail.Text;
        }
        public string getIdItem()
        {
            return idItemDetail.Text;
        }
        public string getQuantity()
        {
            return quantity.Text;
        }
        public void updatePrice()
        {
            this.total.Text = (Convert.ToDouble(this.price.Text) * Convert.ToDouble(this.quantity.Text)).ToString("#,###");
        }

        private void decrease_Click(object sender, EventArgs e)
        {
            if (this.quantity.Text == "1")
                deleteItemInCart?.Invoke(this);
            else
            {
                int unit = Convert.ToInt32(this.quantity.Text);
                this.quantity.Text = (--unit).ToString();
                changeQuantity?.Invoke(this);
            }
        }

        private void increase_Click(object sender, EventArgs e)
        {
            int unit = Convert.ToInt32(this.quantity.Text);
            this.quantity.Text = (++unit).ToString();
            changeQuantity?.Invoke(this);
        }
    }
}
