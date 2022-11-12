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
            searchProduct?.Invoke();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                showListProduct?.Invoke();
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectCategoryProduct?.Invoke();
        }
    }
}
