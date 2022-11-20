using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TH4;
using TheArtOfDevHtmlRenderer.Adapters;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.admin.product
{
    public partial class EditProduct : UserControl
    {
        AccessData accessData = new AccessData();
        public EditProduct()
        {
            InitializeComponent();
        }
        string detailProductCode = "";
        string pathImage = null;
        public void FillCombobox(ComboBox cbo, DataTable dtData, string Display, string Value)
        {
            cbo.DataSource = dtData;
            cbo.DisplayMember = Display;
            cbo.ValueMember = Value;
        }
        public void LoadEditProduct ()
        {
            txtIdProduct.Text = StaticData.ProductCode;
            txtNameProduct.Text = StaticData.NameProduct;
            ptbProduct.Image = Image.FromFile(StaticData.PathImage);
            DataTable dtSize = new DataTable();
            DataTable dtColor = new DataTable();
            DataTable dtCategory = new DataTable();
            dtSize = accessData.DataReader("Select distinct Size from tDetailProduct where ProductCode = '" + StaticData.ProductCode + "'");
            dtColor = accessData.DataReader("Select distinct Color from tDetailProduct where ProductCode = '" + StaticData.ProductCode + "'");
            dtCategory = accessData.DataReader("Select CategoryCode from tCategory");
            FillCombobox(cbSize, dtSize, "Size", "Size");
            FillCombobox(cbColor, dtColor, "Color", "Color");
            FillCombobox(cbCategory, dtCategory, "CategoryCode", "CategoryCode");
            cbCategory.Text = StaticData.Category;
        }
        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSize.Text != "")
            {
                try
                {
                    DataTable dtDetailProduct = new DataTable();
                    dtDetailProduct = accessData.DataReader("Select DetailProductCode,ImportPrice,Price from tDetailProduct where ProductCode = '" + StaticData.ProductCode + "'and Size = '" + cbSize.Text + "' and Color = N'" + cbColor.Text + "'");
                    txtImportPrice.Text = dtDetailProduct.Rows[0]["ImportPrice"].ToString();
                    txtPrice.Text = dtDetailProduct.Rows[0]["Price"].ToString();
                    detailProductCode = dtDetailProduct.Rows[0]["DetailProductCode"].ToString();
                }
                catch { }
            }
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbColor.Text != "")
            {
                try
                {
                    DataTable dtDetailProduct = new DataTable();
                    dtDetailProduct = accessData.DataReader("Select DetailProductCode,ImportPrice,Price from tDetailProduct where ProductCode = '" + StaticData.ProductCode + "'and Size = '" + cbSize.Text + "' and Color = N'" + cbColor.Text + "'");
                    txtImportPrice.Text = dtDetailProduct.Rows[0]["ImportPrice"].ToString();
                    txtPrice.Text = dtDetailProduct.Rows[0]["Price"].ToString();
                    detailProductCode = dtDetailProduct.Rows[0]["DetailProductCode"].ToString();
                }
                catch { }
            }
        }
        private void btnConfirmNewProduct_Click(object sender, EventArgs e)
        {
            if (txtNameProduct.Text == "")
            {
                MessageBox.Show("Tên sản phẩm không được để trống");
                return;
            }
            if (txtImportPrice.Text == "")
            {
                MessageBox.Show("Giá nhập không được để trống");
                return;
            }
            if (txtPrice.Text == "")
            {
                MessageBox.Show("Giá bán không được để trống");
                return;
            }
            if (cbCategory.Text == "")
            {
                MessageBox.Show("Danh mục không được để trống");
                return;
            }
            if (cbColor.Text == "")
            {
                MessageBox.Show("Màu không được để trống");
                return;
            }
            if (cbSize.Text == "")
            {
                MessageBox.Show("Size không được để trống");
                return;
            }
            if (pathImage == null)
            {
                accessData.DataChange("Update tDetailProduct set ImportPrice = '" + double.Parse(txtImportPrice.Text) + "', Price = '" + double.Parse(txtPrice.Text) + "' where DetailProductCode = '" + detailProductCode + "'");
                accessData.DataChange("Update tProduct set NameProduct = '" + txtNameProduct.Text + "',CategoryCode = N'" + cbCategory.Text + "' where ProductCode = '" + txtIdProduct.Text + "'");
            }
            else
            {
                accessData.DataChange("Update tDetailProduct set ImportPrice = '" + double.Parse(txtImportPrice.Text) + "', Price = '" + double.Parse(txtPrice.Text) + "' where DetailProductCode = '" + detailProductCode + "'");
                accessData.DataChange("Update tProduct set NameProduct = '" + txtNameProduct.Text + "',CategoryCode = '" + cbCategory.Text + "',Image = '" + pathImage + "' where ProductCode = '" + txtIdProduct.Text + "'");
            }         
            MessageBox.Show("Sửa thông tin sản phẩm thành công");
        }
        private void imgProduct_Click(object sender, EventArgs e)
        {
            string[] Img;
            openFileDialog1.InitialDirectory = Application.StartupPath.ToString();
            openFileDialog1.Filter = "JPEG files |*.jpg|PNG images|*png|All Files|*.*";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ptbProduct.Image = Image.FromFile(openFileDialog1.FileName);
                Img = openFileDialog1.ToString().Split('\\');
                pathImage = Img[Img.Length - 1];
            }
        }

        private void txtImportPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && Convert.ToInt16(e.KeyChar)!=8)
            {
                MessageBox.Show("Bạn phải nhập số nguyên");
                e.Handled = true;
            }
        }
    }
}
