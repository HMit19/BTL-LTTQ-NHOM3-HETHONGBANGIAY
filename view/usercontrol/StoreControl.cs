using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol
{
    public delegate void UserEvent();
    public partial class StoreControl : UserControl
    {
        public event UserEvent sortProduct;
        public event UserEvent searchProduct;
        public event UserEvent showListProduct;
        public event UserEvent selectCategoryProduct;
        public event UserEvent addProductToCart;
        public event UserEvent showCart;
        public StoreControl()
        {
            InitializeComponent();
        }
        public void loadCategory(List<string> categoryName)
        {
            cbCategory.DataSource = categoryName;
        }
        public string getSearch() { return txtSearch.Text; }

        private void cbSortProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            sortProduct?.Invoke();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != "") searchProduct?.Invoke();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") showListProduct?.Invoke();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectCategoryProduct?.Invoke();
        }

        private void btnIncrease_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(quantityExist.Text);
            int unit = Convert.ToInt32(selectUnit.Text);
            if (unit < quantity)
            {
                selectUnit.Text = (++unit).ToString();
                this.unit.Text = unit.ToString();
            }
            else MessageBox.Show("Sản phẩm không vượt quá số lượng còn lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            int unit = Convert.ToInt32(selectUnit.Text);
            if (unit > 1)
            {
                selectUnit.Text = (--unit).ToString();
                this.unit.Text = unit.ToString();
            }
        }
        public void resetUnit()
        {
            this.unit.Text = "1";
        }

        public string getQuantity()
        {
            return this.unit.Text;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            addProductToCart?.Invoke();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            showCart?.Invoke();
        }
        public void setImageCurrent(string image)
        {
            string path = Application.StartupPath + "\\images\\";
            string imageDefault = "default.jpg";
            try
            {
                this.imageCurrent.Image = Image.FromFile(path + image);
            }
            catch (Exception e)
            {
                this.imageCurrent.Image = Image.FromFile(path + imageDefault);
            }
        }

        private void unit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Vui lòng nhập số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void unit_TextChanged(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(quantityExist.Text);
            int unit = 1;
            if (this.unit.Text != "")
            {
                unit = Convert.ToInt32(this.unit.Text);
            }
            if (unit > quantity)
            {
                this.unit.Text = "1";
                this.selectUnit.Text = "1";
                MessageBox.Show("Sản phẩm không vượt quá số lượng còn lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.selectUnit.Text = this.unit.Text;
        }
    }
}
