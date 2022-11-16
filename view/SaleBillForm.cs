using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using System;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view
{
    public partial class SaleBillForm : Form
    {
        DAO.connect.ConnectData dataBase = new DAO.connect.ConnectData();
        string status = "";
        string codeBill = "";
        //create function
        public SaleBillForm(string codeBill, string status = "")
        {
            InitializeComponent();
            this.status = status;
            this.codeBill = codeBill;
        }
        //Hide product textbox
        void HideProductText(bool check = true)
        {
            cbbProductCode.Visible = !check;
            cbbProductName.Visible = !check;
            cbbColor.Visible = !check;
            cbbSize.Visible = !check;
            txtQuantity.Visible = !check;
            txtPoint.Visible = !check;
            lblProductCode.Visible = check;
            lblProductName.Visible = check;
            lblColor.Visible = check;
            lblSize.Visible = check;
            lblQuantity.Visible = check;
            lblTotal.Visible = check;
            lblPoint.Visible = check;
        }
        //Display Customer infor of bill
        void DisplayBill()
        {
            lblBillCode.Text = codeBill;
            DataTable inforBill = dataBase.ReadData("select DateSale, Name, PhoneNumber, Address, PaymentMethods, isnull(0,Discount),  EmployeeCode from tBillOfSale ctb join tCustomer kh on ctb.CustomerCode = kh.CustomerCode where CodeBill = N'" + codeBill+"'");
            lblDate.Text = (Convert.ToDateTime(inforBill.Rows[0][0].ToString())).ToString("dd/MM/yyyy"); ;
            lblName.Text = inforBill.Rows[0][1].ToString();
            lblPhone.Text = inforBill.Rows[0][2].ToString();
            lblAddress.Text = inforBill.Rows[0][3].ToString();
            lblPayment.Text = inforBill.Rows[0][4].ToString();
            lblPoint.Text = inforBill.Rows[0][5].ToString();
            lblEmployeeCode.Text = inforBill.Rows[0][6].ToString();
        }
        //Display product infor
        void DisplayProduct(string deProductCode)
        {
            DataTable product = dataBase.ReadData("select sp.ProductCode, NameProduct, Color, Size, ctb.Quantity,Price   from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode join tDetailBillOfSale ctb on ctb.DetailProductCode = ctsp.DetailProductCode where ctsp.DetailProductCode = N'"+deProductCode+"'");
            lblProductCode.Text = product.Rows[0][0].ToString();
            lblProductName.Text = product.Rows[0][1].ToString();
            lblColor.Text = product.Rows[0][2].ToString();
            lblSize.Text = product.Rows[0][3].ToString();
            lblQuantity.Text = product.Rows[0][4].ToString();
            lblPrice.Text = (Convert.ToDouble(product.Rows[0][5].ToString()) * int.Parse(lblQuantity.Text)).ToString("#,###");
        }
        //Display product infor when delete all
        void DisplayProduct()
        {
            lblProductCode.Text = "";
            lblProductName.Text = "";
            lblColor.Text = "";
            lblSize.Text = "";
            lblQuantity.Text = "";
            lblPrice.Text = "";
            lblTotal.Text = "";
        }
        //Display list product
        void DisplayList()
        {
            DataTable list = dataBase.ReadData("select ctsp.DetailProductCode, ctsp.ProductCode, NameProduct, Price  from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode join tDetailBillOfSale ctn on ctn.DetailProductCode = ctsp.DetailProductCode where CodeBill = N'" + codeBill + "'");
            dgvList.DataSource = list;
            if (list.Rows.Count == 0)
            {
                DisplayProduct();
                return;
            }

            DisplayProduct(dgvList.Rows[0].Cells[0].Value.ToString());
            DisplayTotal();
        }
        //Display TotalPrice
        void DisplayTotal()
        {
            double totalPrice = 0;
            DataTable total = dataBase.ReadData("select ctb.Quantity,Price  from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode join tDetailBillOfSale ctb on ctb.DetailProductCode = ctsp.DetailProductCode where ctb.CodeBill = N'" + codeBill + "'");
            for (int i = 0; i < total.Rows.Count; i++)
            {
                totalPrice += int.Parse(total.Rows[i][0].ToString()) * Convert.ToDouble(total.Rows[i][1].ToString());
            }
            totalPrice -= int.Parse(lblPoint.Text);
            lblTotal.Text = totalPrice.ToString("#,###");

        }
        //FormLoad

        void statusForm(string status = "INFOR")
        {
            if (status == "INFOR")
            {
                HideProductText();
                DisplayBill();
                DisplayList();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
                btnPrint.Enabled = true;
                dgvList.Columns[0].HeaderText = "Mã chi tiết";
                dgvList.Columns[1].HeaderText = "Mã sản phẩm";
                dgvList.Columns[2].HeaderText = "Tên sản phẩm";
                dgvList.Columns[3].HeaderText = "Đơn giá";
            }
        }
        void DeleteProduct(string deProductCode)
        {
            string quantity = "";
            DataTable Bill = dataBase.ReadData("select Quantity from tDetailBillOfSale where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
            quantity = Bill.Rows[0][0].ToString();
            dataBase.UpdateData("update tDetailProduct set Quantity = Quantity + " + quantity + " where DetailProductCode = N'" + deProductCode + "'");
            dataBase.UpdateData("delete from tDetailBillOfSale where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
        }
        //cell click dataGridView
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnSave.Enabled == false && dgvList.Rows.Count > 0)
                DisplayProduct(dgvList.CurrentRow.Cells[0].Value.ToString());
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnSave.Visible == false && dgvList.Rows.Count > 0)
            {
                if (MessageBox.Show("Bạn có muốn trả lại sản phẩm này không?", "Messager",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteProduct(dgvList.CurrentRow.Cells[0].Value.ToString());
                    DisplayList();
                }
            }
        }
        void Price()
        {
            DataTable price = dataBase.ReadData("select Price from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode where sp.ProductCode = N'" + cbbProductCode.Text + "' and Color = N'" + cbbColor.Text + "' and Size =N'" + cbbSize.Text + "'");
            lblPrice.Text = (Convert.ToDouble(price.Rows[0][0].ToString()) * int.Parse(txtQuantity.Text)).ToString("#,###");
        }
        private void cbbProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable color = dataBase.ReadData("select distinct Color from tDetailProduct where ProductCode = N'" + cbbProductCode.Text + "'");
            dataBase.FillComboBox(cbbColor, color, "Color", "Color");

        }

        private void cbbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable size = dataBase.ReadData("select Size from tDetailProduct where ProductCode = N'" + cbbProductCode.Text + "' and Color = N'" + cbbColor.Text + "'");
            dataBase.FillComboBox(cbbSize, size, "Size", "Size");

        }
        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
                MessageBox.Show("Bạn phải nhập số lượng");
            else
                Price();
        }

        private void txtPoint_Leave(object sender, EventArgs e)
        {
            DataTable customerPoint = dataBase.ReadData("select isnull(0,point) from tCustomer kh join tBillOfSale hdb on kh.CustomerCode = hdb.CustomerCode where CodeBill = N'" + codeBill + "'");
            int point = int.Parse(customerPoint.Rows[0][0].ToString());
            if (txtPoint.Text == "")
                MessageBox.Show("Bạn phải nhập số lượng");
            if (int.Parse(txtPoint.Text) > 0)
                txtPoint.Text = point.ToString();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Bạn chỉ nhập số nguyên");
                e.Handled = true;
            }
        }
        private void SaleBillForm_Load(object sender, EventArgs e)
        {
            statusForm(status);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (status == "INFOR")
            {
                if (btnSave.Enabled == false)
                {
                    if (MessageBox.Show("Bạn có muốn trả lại sản phẩm này không?", "Messager",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DeleteProduct(dgvList.CurrentRow.Cells[0].Value.ToString());
                        DisplayList();
                    }
                }
                else
                {
                    btnDelete.Text = "Trả hàng";
                    btnUpdate.Enabled = true;
                    btnPrint.Enabled = true;
                    btnSave.Enabled = false;
                    HideProductText();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnPrint.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = true;
            btnDelete.Text = "Hủy bỏ";
            DataTable Product = dataBase.ReadData("select ProductCode, NameProduct from tProduct");
            dataBase.FillComboBox(cbbProductCode, Product, "ProductCode", "ProductCode");
            dataBase.FillComboBox(cbbProductName, Product, "NameProduct", "NameProduct");
            cbbProductCode.Text = lblProductCode.Text;
            cbbProductName.Text = lblProductName.Text;
            txtQuantity.Text = lblQuantity.Text;
            txtPoint.Text = lblPoint.Text;  
            HideProductText(false);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPrCode = dataBase.ReadData("select DetailProductCode from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode where sp.ProductCode = N'" + lblProductCode.Text + "' and Color = N'" + lblColor.Text + "' and Size =N'" + lblSize.Text + "'").Rows[0][0].ToString();
            DataTable code = dataBase.ReadData("select DetailProductCode from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode where sp.ProductCode = N'" + cbbProductCode.Text + "' and Color = N'" + cbbColor.Text + "' and Size =N'" + cbbSize.Text + "'");
            string deProductCode = code.Rows[0][0].ToString();
            if (int.Parse(txtQuantity.Text) == 0)
            {
                if (MessageBox.Show("Bạn có muốn trả lại sản phẩm này không?", "Messager",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteProduct(deProductCode);
                    DisplayList();
                }
            }
            DataTable dataBill = dataBase.ReadData("select DetailProductCode from tDetailBillOfSale where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
            if (dataBill.Rows.Count > 0)//Kiem tra san pham da co trong list chua
            {
                if (oldPrCode != deProductCode)//Neui san pham moi khac san pham cu
                {
                    if (MessageBox.Show("Sản phẩm bạn chọn đã tồn tại, bạn có muốn cập nhật số lượng cho sản phẩm đó?", "Messager",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dataBase.UpdateData("update tDetailProduct set Quantity = Quantity + " + lblQuantity.Text + " where DetailProductCode = N'" + oldPrCode + "'");
                        dataBase.UpdateData("update tDetailProduct set Quantity = Quantity  - " + txtQuantity.Text + " where DetailProductCode = N'" + deProductCode + "'");
                        dataBase.UpdateData("update tDetailBillOfSale set Quantity = Quantity + " + txtQuantity.Text + " where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
                        dataBase.UpdateData("delete from tDetailBillOfSale where DetailProductCode = N'" + oldPrCode + "' and CodeBill = N'" + codeBill + "'");
                    }
                    else
                        return;
                }
                else
                {
                    dataBase.UpdateData("update tDetailProduct set Quantity = Quantity  - " + txtQuantity.Text + " + " + lblQuantity.Text + " where DetailProductCode = N'" + deProductCode + "'");
                    dataBase.UpdateData("update tDetailBillOfSale set DetailProductCode = N'" + deProductCode + "', Quantity = N'" + txtQuantity.Text + "' where DetailProductCode = N'" + oldPrCode + "' and CodeBill = N'" + codeBill + "'");

                }
            }
            else
            {
                dataBase.UpdateData("update tDetailProduct set Quantity = Quantity  - " + txtQuantity.Text + " where DetailProductCode = N'" + deProductCode + "'");
                dataBase.UpdateData("update tDetailProduct set Quantity = Quantity + " + lblQuantity.Text + " where DetailProductCode = N'" + oldPrCode + "'");
                dataBase.UpdateData("update tDetailBillOfSale set DetailProductCode = N'" + deProductCode + "', Quantity = N'" + txtQuantity.Text + "' where DetailProductCode = N'" + oldPrCode + "' and CodeBill = N'" + codeBill + "'");

            }
            DataTable customerCode = dataBase.ReadData("select CustomerCode from tBillOfSale where CodeBill = N'"+codeBill+"'");
            dataBase.UpdateData("update tCustomer set Point = Point  + " + lblPoint.Text + " - "+txtPoint.Text+"where CustomerCode = N'" + customerCode.Rows[0][0].ToString()+"'");
            dataBase.UpdateData("update tBillOfSale set Discount = N'"+txtPoint.Text+"'  where  CodeBill = N'" + codeBill + "'");
            btnDelete.Text = "Trả hàng";
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            btnPrint.Enabled = true;
            HideProductText();
            DisplayList();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

            Excel.Range shopName = (Excel.Range)exSheet.Cells[1, 1];
            shopName.Font.Size = 20;
            shopName.Font.Bold = true;
            shopName.Value = "CỬA HÀNG GIÀY SMART MEN";

            Excel.Range shopAddress = (Excel.Range)exSheet.Cells[2, 1];
            shopAddress.Font.Size = 14;
            shopAddress.Font.Bold = true;
            shopAddress.Value = "31 P. Quan Hoa, Quan Hoa, Cầu Giấy, Hà Nội, Việt Nam";

            Excel.Range header = (Excel.Range)exSheet.Cells[4, 2];
            exSheet.get_Range("D4:F4").Merge(true);
            header.Font.Size = 14;
            header.Font.Bold = true;
            header.Value = "CHI TIẾT HÓA ĐƠN BÁN";

            exSheet.get_Range("A6").Value = "Số hóa đơn";
            exSheet.get_Range("B6").Value = codeBill;
            exSheet.get_Range("A7").Value = "Người tạo";
            exSheet.get_Range("B7").Value = lblEmployeeCode.Text;
            exSheet.get_Range("A8").Value = "Ngày tạo";
            exSheet.get_Range("B8").Value = lblDate.Text;
            exSheet.get_Range("G6").Value = "Khách hàng";
            exSheet.get_Range("H6").Value = lblName.Text;
            exSheet.get_Range("G7").Value = "Điện thoại";
            exSheet.get_Range("H7").Value = lblPhone.Text;
            exSheet.get_Range("G8").Value = "Địa chỉ";
            exSheet.get_Range("H8").Value = lblAddress.Text;

            exSheet.get_Range("A10:H10").Font.Bold = true;
            exSheet.get_Range("A10:H10").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exSheet.get_Range("A10:H10").ColumnWidth = 15;
            exSheet.get_Range("C10").ColumnWidth = 25;
            exSheet.get_Range("A10").Value = "Mã chi tiết";
            exSheet.get_Range("B10").Value = "Mã sản phẩm";
            exSheet.get_Range("C10").Value = "Tên sản phẩm";
            exSheet.get_Range("D10").Value = "Màu sắc";
            exSheet.get_Range("E10").Value = "Cỡ";
            exSheet.get_Range("F10").Value = "SL Bán";
            exSheet.get_Range("G10").Value = "Đơn giá";
            exSheet.get_Range("H10").Value = "Thành tiền";

            DataTable dataEx = dataBase.ReadData("select ctsp.DetailProductCode, ctsp.ProductCode, NameProduct, Color, Size, ctn.Quantity, Price, ctn.Quantity * Price  from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode join tDetailBillOfSale ctn on ctn.DetailProductCode = ctsp.DetailProductCode where CodeBill = N'" + codeBill + "'");
            int i = 0;
            double total = 0;
            for (i = 0; i < dataEx.Rows.Count; i++)
            {
                exSheet.get_Range("A" + (i + 12).ToString() + ":H" + (i + 11).ToString()).Font.Bold = false;
                exSheet.get_Range("A" + (i + 12).ToString()).Value = dataEx.Rows[i][0].ToString();
                exSheet.get_Range("B" + (i + 12).ToString()).Value = dataEx.Rows[i][1].ToString();
                exSheet.get_Range("C" + (i + 12).ToString()).Value = dataEx.Rows[i][2].ToString();
                exSheet.get_Range("D" + (i + 12).ToString()).Value = dataEx.Rows[i][3].ToString();
                exSheet.get_Range("E" + (i + 12).ToString()).Value = dataEx.Rows[i][4].ToString();
                exSheet.get_Range("F" + (i + 12).ToString()).Value = dataEx.Rows[i][5].ToString();
                exSheet.get_Range("G" + (i + 12).ToString()).Value = dataEx.Rows[i][6].ToString();
                exSheet.get_Range("H" + (i + 12).ToString()).Value = dataEx.Rows[i][7].ToString();
                total += Convert.ToDouble(dataEx.Rows[i][7].ToString());
            }
            exSheet.get_Range("G" + (i + 14)).Value = "Hình thức thanh toán";
            exSheet.get_Range("H" + (i + 14)).Value = lblPayment.Text;
            exSheet.get_Range("G" + (i + 15)).Value = "Điểm";
            exSheet.get_Range("H" + (i + 15)).Value = lblPoint.Text;
            exSheet.get_Range("G" + (i + 16)).Value = "Tổng tiền";
            exSheet.get_Range("H" + (i + 16)).Value = total;
            exSheet.Name = "Chi tiết hóa đơn " + codeBill;
            exBook.Activate();

            dlgSave.Filter = "Excel Document(*.xlsx)|*.xlsx |All files(*.*)|*.*";
            dlgSave.FilterIndex = 1;
            dlgSave.AddExtension = true;
            dlgSave.DefaultExt = ".xlsx";
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(dlgSave.FileName.ToString());
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }

            exApp.Quit();
        }
        //btnExit
        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
