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
    public delegate void UserEventParam(object o);
    public partial class ItemProduct : UserControl
    {
        public event UserEventParam selectProduct;
        private List<string> colors;
        private List<string> sizes;


        public ItemProduct()
        {
            InitializeComponent();
        }
        public ItemProduct(string idProduct, string name, string image, string price, string quantity, string idCategory)
        {
            InitializeComponent();
            this.idProduct.Text = idProduct;
            this.name.Text = name;
            this.setImage(image);
            this.price.Text = price;
            this.quantity.Text = quantity;
            this.idCategory.Text = idCategory;
        }
        public ItemProduct(string idProduct, string name, string image, string price, string quantity, string idCategory, List<string> colors, List<string> sizes)
        {
            InitializeComponent();
            this.idProduct.Text = idProduct;
            this.name.Text = name;
            this.setImage(image);
            this.price.Text = price;
            this.quantity.Text = quantity;
            this.idCategory.Text = idCategory;
            this.colors = colors;
            this.sizes = sizes;
            this.imageCurrent.Text = image;
        }

        public List<string> ColorItem { get => colors; set => colors = value; }
        public List<string> SizeItem { get => sizes; set => sizes = value; }
        private void pnlContain_Click(object sender, EventArgs e)
        {
            selectProduct?.Invoke(this);
        }

        private void pnlContain_MouseMove(object sender, MouseEventArgs e)
        {

            pnlContain.BackColor = SystemColors.Control;
        }

        private void pnlContain_MouseLeave(object sender, EventArgs e)
        {
            pnlContain.BackColor = System.Drawing.Color.White;
        }
        public string getIdProduct() { return this.idProduct.Text; }
        public string getNameProduct() { return name.Text; }
        public string getPriceProduct() { return price.Text; }
        public string getQuantityProduct() { return quantity.Text; }
        public string getIdCategory() { return idCategory.Text; }
        
        public string getImageProduct()
        {
            return this.imageCurrent.Text;
        }
        
        public void setImage(string image)
        {
            string path = Application.StartupPath + "\\image\\";
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
    }
}
