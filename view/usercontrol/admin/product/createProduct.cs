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
using System.Windows.Markup;
using System.Windows.Media.Media3D;
using TH4;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.admin.product
{
    public partial class CreateProduct : UserControl
    {
        public CreateProduct()
        {
            InitializeComponent();
        }
        AccessData accessData = new AccessData();
        string pathImage;
        public string colorProduct(string color)
        {
            string cProduct = null;
            if (color == "Đen")
                cProduct = "D";
            else if (color == "Trắng")
                cProduct = "T";
            else if (color == "Xanh lục")
                cProduct = "XL";
            else if (color == "Xanh dương")
                cProduct = "XD";
            else if (color == "Chàm")
                cProduct = "C";
            else if (color == "Xám")
                cProduct = "X";
            return cProduct;
        }
        public void reset()
        {
            txtIdProduct.Text = txtNameProduct.Text = txtPrice.Text = txtImportPrice.Text = txtBrand.Text = txtCategoryCode.Text = txtOrigin.Text = "";
            cbColor.StartIndex = -1;
            resetCategory();
            cbSize.StartIndex = -1;
            ptbProduct.Image = null;
            txtNameProduct.Enabled = true;
            imgProduct.Enabled = true;
            cbCategory.Enabled = true;
            grbNewCategory.Visible = false;
        }
        public void resetCategory()
        {
            cbCategory.Items.Clear();
            DataTable dtCategory = accessData.DataReader("Select CategoryCode from tCategory");
            for (int i = 0; i < dtCategory.Rows.Count; i++)
            {
                cbCategory.Items.Add(dtCategory.Rows[i]["CategoryCode"].ToString());
            }
            cbCategory.Items.Add("Thêm mới");
        }
        private void btnConfirmNewProduct_Click(object sender, EventArgs e)
        {
            if (txtIdProduct.Text == "")
            {
                MessageBox.Show("Mã sản phẩm không được để trống");
                txtIdProduct.Focus();
                return;
            }
            if (txtNameProduct.Text == "")
            {
                MessageBox.Show("Tên sản phẩm không được để trống");
                txtNameProduct.Focus();
                return;
            }
            if (txtImportPrice.Text == "")
            {
                MessageBox.Show("Giá nhập không được để trống");
                txtImportPrice.Focus();
                return;
            }
            if (txtPrice.Text == "")
            {
                MessageBox.Show("Giá bán không được để trống");
                txtPrice.Focus();
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
            }
            string DetailProductCode = txtIdProduct.Text + colorProduct(cbColor.Text) + cbSize.Text;
            DataTable dtCheckExistProduct = accessData.DataReader("Select * from tProduct where ProductCode = '" + txtIdProduct.Text + "'");
            DataTable dtCheckDetailProduct = accessData.DataReader("Select * from tDetailProduct where DetailProductCode = '" + DetailProductCode + "'");
            if (dtCheckExistProduct.Rows.Count > 0)
            {
                if (dtCheckExistProduct.Rows[0]["Status"].ToString() == "False")
                {
                    if (MessageBox.Show("Bạn có muốn khôi phục trạng thái bán của sản phẩm", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        accessData.DataChange("Update tProduct set Status = 1 where ProductCode = '" + txtIdProduct.Text + "'");
                        MessageBox.Show("Khôi phục thành công");
                    }
                    if (dtCheckDetailProduct.Rows.Count != 0)
                        return;
                    else if (dtCheckDetailProduct.Rows.Count == 0)
                    {
                        accessData.DataChange("Insert into tDetailProduct values ('" + DetailProductCode + "','" + txtIdProduct.Text + "','" + cbSize.Text + "',N'" + cbColor.Text + "','" + txtImportPrice.Text + "','" + txtPrice.Text + "','0')");
                        MessageBox.Show("Thêm sản phẩm " + txtNameProduct.Text + " có màu " + cbColor.Text + " và size " + cbSize.Text + " thành công");
                    }
                }
                else if (dtCheckExistProduct.Rows[0]["Status"].ToString() == "True")
                {
                    if (dtCheckDetailProduct.Rows.Count != 0)
                    {
                        MessageBox.Show("Sản phẩm đã tồn tại màu " + cbColor.Text + " và size " + cbSize.Text);
                        return;
                    }
                    else
                    {
                        accessData.DataChange("Insert into tDetailProduct values ('" + DetailProductCode + "','" + txtIdProduct.Text + "','" + cbSize.Text + "',N'" + cbColor.Text + "','" + txtImportPrice.Text + "','" + txtPrice.Text + "','0')");
                        MessageBox.Show("Thêm sản phẩm " + txtNameProduct.Text + " có màu " + cbColor.Text + " và size " + cbSize.Text + " thành công");
                    }
                }
            }
            else
            {
                if (cbCategory.Text == "Thêm mới")
                {
                    if (txtCategoryCode.Text == "")
                    {
                        MessageBox.Show("Mã danh mục không được để trống");
                        txtCategoryCode.Focus();
                        return;
                    }
                    if (txtBrand.Text == "")
                    {
                        MessageBox.Show("Tên hãng không được để trống");
                        txtBrand.Focus();
                        return;
                    }
                    if (txtOrigin.Text == "")
                    {
                        MessageBox.Show("Xuất xứ không được để trống");
                        txtOrigin.Focus();
                        return;
                    }
                    DataTable dtCategory = accessData.DataReader("Select * from tCategory where CategoryCode = '" + txtCategoryCode.Text + "'");
                    if (dtCategory.Rows.Count == 0)
                    {
                        accessData.DataChange("Insert into tCategory values('" + txtCategoryCode.Text + "','" + txtBrand.Text + "',N'" + txtOrigin.Text + "')");
                        accessData.DataChange("Insert into tProduct values ('" + txtIdProduct.Text + "','" + txtNameProduct.Text + "','" + pathImage + "','" + txtCategoryCode.Text + "','1')");
                        accessData.DataChange("Insert into tDetailProduct values ('" + DetailProductCode + "','" + txtIdProduct.Text + "','" + cbSize.Text + "',N'" + cbColor.Text + "','" + txtImportPrice.Text + "','" + txtPrice.Text + "','0')");
                        MessageBox.Show("Thêm sản phẩm " + txtNameProduct.Text + " có màu " + cbColor.Text + " và size " + cbSize.Text + " thành công");
                    }
                    else
                    {
                        MessageBox.Show("Danh mục sản phẩm đã tồn tại");
                        return;
                    }
                }
                else
                {
                    accessData.DataChange("Insert into tProduct values ('" + txtIdProduct.Text + "','" + txtNameProduct.Text + "','" + pathImage + "','" + cbCategory.Text + "','1')");
                    accessData.DataChange("Insert into tDetailProduct values ('" + DetailProductCode + "','" + txtIdProduct.Text + "','" + cbSize.Text + "',N'" + cbColor.Text + "','" + txtImportPrice.Text + "','" + txtPrice.Text + "','0')");
                    MessageBox.Show("Thêm sản phẩm " + txtNameProduct.Text + " có màu " + cbColor.Text + " và size " + cbSize.Text + " thành công");
                }
            }
            reset();
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
            if (!char.IsDigit(e.KeyChar) && Convert.ToInt16(e.KeyChar) != 8)
            {
                MessageBox.Show("Bạn phải nhập số nguyên");
                e.Handled = true;
            }
        }

        private void txtIdProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtIdProduct.Text != "")
            {
                DataTable dtProduct = accessData.DataReader("Select ProductCode,NameProduct,Image,CategoryCode from tProduct where ProductCode = '" + txtIdProduct.Text + "'");
                if (dtProduct.Rows.Count != 0)
                {
                    txtNameProduct.Text = dtProduct.Rows[0]["NameProduct"].ToString();
                    cbCategory.Text = dtProduct.Rows[0]["CategoryCode"].ToString();
                    ptbProduct.Image = Image.FromFile(Application.StartupPath + "\\image\\" + dtProduct.Rows[0]["Image"].ToString());
                    txtNameProduct.Enabled = false;
                    imgProduct.Enabled = false;
                    cbCategory.Enabled = false;
                }
                else
                {
                    txtNameProduct.Text = "";
                    cbCategory.StartIndex = -1;
                    ptbProduct.Image = null;
                    txtNameProduct.Enabled = true;
                    imgProduct.Enabled = true;
                    cbCategory.Enabled = true;
                }
            }
            else
            {
                reset();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtPrice = accessData.DataReader("Select ImportPrice,Price from tDetailProduct where DetailProductCode = '" + txtIdProduct.Text + colorProduct(cbColor.Text) + cbSize.Text + "' ");
            if (dtPrice.Rows.Count != 0)
            {
                txtImportPrice.Text = dtPrice.Rows[0]["ImportPrice"].ToString();
                txtPrice.Text = dtPrice.Rows[0]["Price"].ToString();
            }
            else
                txtPrice.Text = txtImportPrice.Text = "";
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.Text == "Thêm mới")
                grbNewCategory.Visible = true;
            else
                grbNewCategory.Visible = false;
        }
    }
}
