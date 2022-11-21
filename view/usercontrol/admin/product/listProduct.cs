using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
using TH4;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.admin.product
{
    public partial class ListProduct : UserControl
    {
        AccessData accessData = new AccessData();
        public ListProduct()
        {
            InitializeComponent();
        }
        public event EventHandler ButtonCreateProductClick = null;
        public event EventHandler ButtonEditClick = null;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ButtonEditClick != null) ButtonEditClick(sender, e);
        }
        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            if (ButtonCreateProductClick != null) ButtonCreateProductClick(sender, e);
        }
        public void FillCombobox(ComboBox cbo, DataTable dtData, string Display, string Value)
        {
            cbo.DataSource = dtData;
            cbo.DisplayMember = Display;
            cbo.ValueMember = Value;
        }
        public void showProduct()
        {
            dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where Status = 1 group by tProduct.ProductCode,NameProduct,CategoryCode,Image");
            string url = "E:\\C#\\BTL-LTTQ-NHOM3-HETHONGBANGIAY\\bin\\Debug\\images\\";
            for (int i = 0; i < dtgListProduct.Rows.Count; i++)
            {
                Image image = Image.FromFile(url + dtgListProduct.Rows[i].Cells["cPImage"].Value.ToString());
                dtgListProduct.Rows[i].Cells[0].Value = image;
            }
            dtgDetailProduct.DataSource = null;
            dtgListProduct.ClearSelection();
        }
        public void updateListProduct()
        {
            showProduct();
            lblQuantityProduct.Text = dtgListProduct.Rows.Count.ToString();
            cbCategory.Items.Clear();
            DataTable dtCategory = accessData.DataReader("Select CategoryCode from tCategory");
            cbCategory.Items.Add("Tất cả");
            for (int i = 0; i < dtCategory.Rows.Count; i++)
            {
                cbCategory.Items.Add(dtCategory.Rows[i]["CategoryCode"].ToString());
            }
            foreach (RadioButton rdo in groupBox1.Controls)
            {
                rdo.Checked = false;
            }
            dtgListProduct.ClearSelection();
            cbCategory.StartIndex = 0;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        public string stringSort(string cbtext)
        {
            string sort = "";
            if (cbtext == "Mã sản phẩm")
                sort = "order by ProductCode asc";
            else if (cbtext == "Tên sản phẩm")
                sort = "order by NameProduct asc";
            else if (cbtext == "Số lượng")
                sort = "order by Quantity desc";
            return sort;
        }
        public string stringCategory(string category)
        {
            string qCategory = "";
            if (cbCategory.Text == "Tất cả")
                qCategory = "";
            else
                qCategory = "CategoryCode = '" + cbCategory.Text + "' and ";
            return qCategory;
        }
        public void filterbyCategory(string price, string sort, string category)
        {
            if (price == null && sort == null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where " + category + " Status = 1 group by tProduct.ProductCode,NameProduct,CategoryCode,Image");
            else if (price == null && sort != null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where " + category + " Status = 1 group by tProduct.ProductCode,NameProduct,CategoryCode,Image " + sort + "");
            else if (price != null && sort == null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where " + category + " Status = 1 and " + price + " group by tProduct.ProductCode,NameProduct,CategoryCode,Image");
            else if (price != null && sort != null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where " + category + " Status = 1 and " + price + " group by tProduct.ProductCode,NameProduct,CategoryCode,Image " + sort + "");
            for (int i = 0; i < dtgListProduct.Rows.Count; i++)
            {
                Image image = Image.FromFile(Application.StartupPath + "\\images\\" + dtgListProduct.Rows[i].Cells["cPImage"].Value.ToString());
                dtgListProduct.Rows[i].Cells[0].Value = image;
            }
        }
        public void filterbyPrice(string category, string sort, string price)
        {
            if (category == "Tất cả" && sort == null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where Status = 1 and " + price + " group by tProduct.ProductCode,NameProduct,CategoryCode,Image");
            else if (category != "Tất cả" && sort == null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where Status = 1 and " + price + " and CategoryCode = '" + cbCategory.Text + "' group by tProduct.ProductCode,NameProduct,CategoryCode,Image");
            else if (category == "Tất cả" && sort != null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where Status = 1 and " + price + " group by tProduct.ProductCode,NameProduct,CategoryCode,Image " + sort + "");
            else if (category != "Tất cả" && sort != null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where Status = 1 and " + price + " and CategoryCode = '" + cbCategory.Text + "' group by tProduct.ProductCode,NameProduct,CategoryCode,Image " + sort + "");
            for (int i = 0; i < dtgListProduct.Rows.Count; i++)
            {
                Image image = Image.FromFile(Application.StartupPath + "\\images\\" + dtgListProduct.Rows[i].Cells["cPImage"].Value.ToString());
                dtgListProduct.Rows[i].Cells[0].Value = image;
            }
        }
        public void sortProduct(string category, string price, string sort)
        {
            if (category == "Tất cả" && price == null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where Status = 1 group by tProduct.ProductCode,NameProduct,CategoryCode,Image " + sort + "");
            else if (category == "Tất cả" && price != null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where Status = 1 and " + price + " group by tProduct.ProductCode,NameProduct,CategoryCode,Image " + sort + "");
            else if (category != "Tất cả" && price == null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where Status = 1 and CategoryCode = '" + category + "' group by tProduct.ProductCode,NameProduct,CategoryCode,Image " + sort + "");
            else if (category != "Tất cả" && price != null)
                dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where Status = 1 and " + price + " and CategoryCode = '" + category + "' group by tProduct.ProductCode,NameProduct,CategoryCode,Image " + sort + "");
            for (int i = 0; i < dtgListProduct.Rows.Count; i++)
            {
                Image image = Image.FromFile(Application.StartupPath + "\\images\\" + dtgListProduct.Rows[i].Cells["cPImage"].Value.ToString());
                dtgListProduct.Rows[i].Cells[0].Value = image;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtgListProduct.DataSource = accessData.DataReader("Select tProduct.ProductCode,NameProduct,isnull(sum(Quantity),0) as Quantity,CategoryCode,Image from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where NameProduct like '%" + txtSearch.Text + "%' and Status = 1 group by tProduct.ProductCode,NameProduct,CategoryCode,Image");
            for (int i = 0; i < dtgListProduct.Rows.Count; i++)
            {
                Image image = Image.FromFile(Application.StartupPath + "\\images\\" + dtgListProduct.Rows[i].Cells["cPImage"].Value.ToString());
                dtgListProduct.Rows[i].Cells[0].Value = image;
            }
            lblQuantityProduct.Text = dtgListProduct.Rows.Count.ToString();
            dtgDetailProduct.DataSource = null;
            dtgListProduct.ClearSelection();
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }
        public void listProduct_Load(object sender, EventArgs e)
        {
            DataTable dtQuantityProduct = accessData.DataReader("Select count(distinct tProduct.ProductCode) as QuantityProduct from tProduct join tDetailProduct on tProduct.ProductCode = tDetailProduct.ProductCode where Status = 1");
            lblQuantityProduct.Text = dtQuantityProduct.Rows[0]["QuantityProduct"].ToString();
            showProduct();
        }
        private void dtgListProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StaticData.ProductCode = dtgListProduct.CurrentRow.Cells[1].Value.ToString();
            StaticData.NameProduct = dtgListProduct.CurrentRow.Cells[2].Value.ToString();
            StaticData.Category = dtgListProduct.CurrentRow.Cells[4].Value.ToString();
            DataTable dtPathImage = accessData.DataReader("Select Image from tProduct where ProductCode = '" + dtgListProduct.CurrentRow.Cells[1].Value.ToString() + "'");
            StaticData.PathImage = Application.StartupPath + "\\images\\" + dtPathImage.Rows[0]["Image"].ToString();
            bool check = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            foreach (RadioButton rdo in groupBox1.Controls)
            {
                if (rdo.Checked == true)
                {
                    check = true;
                    break;
                }
            }
            if (check == true)
            {
                foreach (RadioButton rdo in groupBox1.Controls)
                {
                    if (rdo.Checked == true)
                    {
                        dtgDetailProduct.DataSource = accessData.DataReader("Select Size as 'Size',Color as 'Màu',ImportPrice as 'Giá nhập',Price as 'Giá bán',isnull(Quantity,0) as 'Số lượng' from tDetailProduct where ProductCode = '" + dtgListProduct.CurrentRow.Cells[1].Value.ToString() + "' and " + rdo.Tag.ToString() + "");
                        dtgDetailProduct.ClearSelection();
                    }
                }
            }
            else
            {
                dtgDetailProduct.DataSource = accessData.DataReader("Select Size as 'Size',Color as 'Màu',ImportPrice as 'Giá nhập',Price as 'Giá bán',isnull(Quantity,0) as 'Số lượng' from tDetailProduct where ProductCode = '" + dtgListProduct.CurrentRow.Cells[1].Value.ToString() + "'");
                dtgDetailProduct.ClearSelection();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm " + StaticData.NameProduct, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                accessData.DataChange("Update tProduct set Status = 0 where ProductCode = '" + StaticData.ProductCode + "'");
                showProduct();
                lblQuantityProduct.Text = dtgListProduct.Rows.Count.ToString();
            }
            else
                return;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                showProduct();
                lblQuantityProduct.Text = dtgListProduct.Rows.Count.ToString();
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }

        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool check = false;
            foreach (RadioButton rdo in groupBox1.Controls)
            {
                if (rdo.Checked == true)
                {
                    check = true;
                    break;
                }
            }
            if (check == true)
            {
                foreach (RadioButton rdo in groupBox1.Controls)
                {
                    if (rdo.Checked == true)
                        filterbyCategory(rdo.Tag.ToString(), stringSort(cbSort.Text), stringCategory(cbCategory.Text));
                }
            }
            else
                filterbyCategory(null, stringSort(cbSort.Text), stringCategory(cbCategory.Text));
            lblQuantityProduct.Text = dtgListProduct.Rows.Count.ToString();
            dtgListProduct.ClearSelection();
            dtgDetailProduct.DataSource = null;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
        private void rdo3_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RadioButton rdo in groupBox1.Controls)
            {
                if (rdo.Checked == true)
                    filterbyPrice(cbCategory.Text, stringSort(cbSort.Text), rdo.Tag.ToString());
            }
            lblQuantityProduct.Text = dtgListProduct.Rows.Count.ToString();
            dtgListProduct.ClearSelection();
            dtgDetailProduct.DataSource = null;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

        private void cbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool check = false;
            foreach (RadioButton rdo in groupBox1.Controls)
            {
                if (rdo.Checked == true)
                {
                    check = true;
                    break;
                }
            }
            if (check == true)
            {
                foreach (RadioButton rdo in groupBox1.Controls)
                {
                    if (rdo.Checked == true)
                        sortProduct(cbCategory.Text, rdo.Tag.ToString(), stringSort(cbSort.Text));
                }
            }
            else
                sortProduct(cbCategory.Text, null, stringSort(cbSort.Text));
            dtgListProduct.ClearSelection();
            dtgDetailProduct.DataSource = null;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }
    }
}
