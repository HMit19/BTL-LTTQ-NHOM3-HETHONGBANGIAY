using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
//Code dan viet cang dai dong va k duoc clean lam
namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view
{
    public partial class ImportBillForm : Form
    {
        DAO.connect.ConnectData dataBase = new DAO.connect.ConnectData();
        string status = "";
        string codeBill = "";
        //create function...
        public ImportBillForm(string codeBill, string status = "")
        {
            InitializeComponent();
            this.status = status;
            this.codeBill = codeBill;
        }
        //Hide EmployeeText
        void HideEmployeeText(bool check = true)
        {
            cbbEmployeeCode.Visible = !check;
            cbbProviderCode.Visible = !check;
            cbbProviderName.Visible = !check;
            dtpTime.Visible = !check;
            lblEmployeeCode.Visible = check;
            lblProviderCode.Visible = check;
            lblProviderName.Visible = check;
            lblDate.Visible = check;
        }
        //Hide Product Text
        void HideProductText(bool check = true)
        {
            cbbProductCode.Visible = !check;
            cbbProductName.Visible = !check;
            cbbColor.Visible = !check;
            cbbSize.Visible = !check;
            txtQuantity.Visible = !check;
            lblProductCode.Visible = check;
            lblProductName.Visible = check;
            lblColor.Visible = check;
            lblSize.Visible = check;
            lblQuantity.Visible = check;
            lblTotal.Visible = check;
        }
        //Display panel infor bill
        void DisplayBill()
        {
            lblBillCode.Text = codeBill;
            DataTable inforBill = dataBase.ReadData("select EmployeeCode, DateImport, hdn.ProviderCode, Name from tImportBill hdn join tProvider ncc on hdn.ProviderCode = ncc.ProviderCode where CodeBill = N'" + codeBill + "'");
            lblEmployeeCode.Text = inforBill.Rows[0][0].ToString();
            lblDate.Text = (Convert.ToDateTime(inforBill.Rows[0][1].ToString())).ToString("dd/MM/yyyy");
            lblProviderCode.Text = inforBill.Rows[0][2].ToString();
            lblProviderName.Text = inforBill.Rows[0][3].ToString();
        }
        //Display panel product
        void DisplayProduct(string deProductCode)
        {
            DataTable product = dataBase.ReadData("select sp.ProductCode, NameProduct, Color, Size, ctn.Quantity,ImportPrice  from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode join tDetailImportBill ctn on ctn.DetailProductCode = ctsp.DetailProductCode where ctsp.DetailProductCode = N'" + deProductCode +"'");
            lblProductCode.Text = product.Rows[0][0].ToString();
            lblProductName.Text = product.Rows[0][1].ToString();
            lblColor.Text = product.Rows[0][2].ToString();
            lblSize.Text = product.Rows[0][3].ToString();
            lblQuantity.Text = product.Rows[0][4].ToString();
            lblPrice.Text = (Convert.ToDouble(product.Rows[0][5].ToString()) * int.Parse(lblQuantity.Text)).ToString("#,###") ;

        }
        //Display panel product when delete all
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
            DataTable list = dataBase.ReadData("select ctsp.DetailProductCode, ctsp.ProductCode, NameProduct, ImportPrice  from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode join tDetailImportBill ctn on ctn.DetailProductCode = ctsp.DetailProductCode where CodeBill = N'" + codeBill + "'");
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
            DataTable total = dataBase.ReadData("select ctn.Quantity,ImportPrice  from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode join tDetailImportBill ctn on ctn.DetailProductCode = ctsp.DetailProductCode where ctn.CodeBill = N'" + codeBill + "'");
            for (int i = 0; i < total.Rows.Count; i++)
            {
                totalPrice += int.Parse(total.Rows[i][0].ToString()) * Convert.ToDouble(total.Rows[i][1].ToString()) ;
            }
            lblTotal.Text = totalPrice.ToString("#,###"); 
        }
        //Form load....
        private void ImportBillForm_Load(object sender, EventArgs e)
        {
            statusForm(status);
        }
        void statusForm(string status = "INFOR")
        {
            if (status == "INFOR")
            {
                HideEmployeeText();
                HideProductText();
                DisplayBill();
                DisplayList();
                btnSave.Visible = false;
                btnCreate.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Text = "  Xóa";
                btnPrint.Enabled = true;
                dgvList.Columns[0].HeaderText = "Mã chi tiết";
                dgvList.Columns[1].HeaderText = "Mã sản phẩm";
                dgvList.Columns[2].HeaderText = "Tên sản phẩm";
                dgvList.Columns[3].HeaderText = "Đơn giá";
                
            }
            if (status == "EDIT")
            {
                HideEmployeeText(false);
                HideProductText();
                DisplayBill();
                DisplayList();
                EditData();
                btnSave.Visible = true;
                btnCreate.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
                btnDelete.Text = "Hủy bỏ";
                btnPrint.Enabled = false;
                dgvList.Columns[0].HeaderText = "Mã chi tiết";
                dgvList.Columns[1].HeaderText = "Mã sản phẩm";
                dgvList.Columns[2].HeaderText = "Tên sản phẩm";
                dgvList.Columns[3].HeaderText = "Đơn giá";
            }
            if (status == "CREATE")
            {
                HideEmployeeText(false);
                HideProductText();
                FillBillCbb();
                DisplayProduct();
                lblBillCode.Text = codeBill;
                btnSave.Visible = true;
                btnCreate.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
                btnDelete.Text = "Hủy bỏ";
                btnPrint.Enabled = false;
            }
        }
        //Display EDIT Employee
        void EditData()
        {
            FillBillCbb();
            cbbEmployeeCode.Text = lblEmployeeCode.Text;
            cbbProviderCode.Text = lblProviderCode.Text;
            cbbProviderName.Text = lblProviderName.Text;
            dtpTime.Value = Convert.ToDateTime(lblDate.Text);

        }
        void FillBillCbb()
        {
            DataTable employee = dataBase.ReadData("select EmployeeCode from tEmployee");
            dataBase.FillComboBox(cbbEmployeeCode, employee, "EmployeeCode", "EmployeeCode");
            DataTable provider = dataBase.ReadData("select ProviderCode, Name from tProvider");
            dataBase.FillComboBox(cbbProviderCode, provider, "ProviderCode", "ProviderCode");
            dataBase.FillComboBox(cbbProviderName, provider, "Name", "Name");
        }
        //function delete product
        void DeleteProduct(string deProductCode)
        {
            string quantity = "";
            DataTable Bill = dataBase.ReadData("select Quantity from tDetailImportBill where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
            quantity = Bill.Rows[0][0].ToString();
            dataBase.UpdateData("update tDetailProduct set Quantity = Quantity - " + quantity + " where DetailProductCode = N'" + deProductCode + "'");
            dataBase.UpdateData("delete from tDetailImportBill where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
        }
        //Hien thi gia san pham...
        void ImpPrice()
        {
            DataTable price = dataBase.ReadData("select ImportPrice from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode where sp.ProductCode = N'" + cbbProductCode.Text + "' and Color = N'" + cbbColor.Text + "' and Size =N'" + cbbSize.Text + "'");
            lblPrice.Text = (Convert.ToDouble(price.Rows[0][0].ToString()) * int.Parse(txtQuantity.Text)).ToString("#,###");
        }
        //cell click dataGridView event...
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnSave.Visible == false && dgvList.Rows.Count > 0)
                DisplayProduct(dgvList.CurrentRow.Cells[0].Value.ToString());
        }
        //cell double click...
        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (btnSave.Visible == false)
            {
                if (MessageBox.Show("Bạn có muốn trả lại sản phẩm này không?", "Messager",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteProduct(dgvList.CurrentRow.Cells[0].Value.ToString());
                    DisplayList();
                }
            }    
        }
        //Chon san pham
        private void cbbProductCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable color = dataBase.ReadData("select distinct Color from tDetailProduct where ProductCode = N'" + cbbProductCode.Text+"'");
            dataBase.FillComboBox(cbbColor, color, "Color", "Color");
        }

        private void cbbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable size = dataBase.ReadData("select Size from tDetailProduct where ProductCode = N'" + cbbProductCode.Text + "' and Color = N'" + cbbColor.Text + "'");
            dataBase.FillComboBox(cbbSize, size, "Size", "Size");
        }

        private void cbbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        //Kiem soat dau vao so luong
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Bạn chỉ nhập số nguyên");
                e.Handled = true;
            }
        }
        //Kiem soat rong va cap nhat gia
        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
                MessageBox.Show("Bạn phải nhập số lượng");
            else
                ImpPrice();
        }
        //Delete...
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (status == "INFOR")
            {
                if (btnSave.Visible == false)
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
                    btnDelete.Text = "  Xóa";
                    btnEdit.Enabled = true;
                    btnPrint.Enabled = true;
                    btnCreate.Visible = true;
                    btnCreate.Enabled = true;
                    btnSave.Visible = false;
                    HideProductText();
                }
            }
            if (status == "EDIT")
            {
                this.Close();
            }

        }
        //BtnCreate...
        private void btnCreate_Click(object sender, EventArgs e)
        {
            btnCreate.Visible = false;
            btnSave.Visible = true;
            btnEdit.Enabled = false;
            btnPrint.Enabled = false;
            btnDelete.Text = "Hủy bỏ";
            HideProductText(false);
            DataTable Product = dataBase.ReadData("select ProductCode, NameProduct from tProduct");
            dataBase.FillComboBox(cbbProductCode, Product, "ProductCode", "ProductCode");
            dataBase.FillComboBox(cbbProductName, Product, "NameProduct", "NameProduct");
            txtQuantity.Text = "";
        }
        //Chuc nang luu cho nut edit va create
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (status == "INFOR")
            {
                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập số lượng");
                    return;
                }
                if (btnCreate.Enabled == true)//Add new items
                {
                    DataTable code = dataBase.ReadData("select DetailProductCode from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode where sp.ProductCode = N'" + cbbProductCode.Text + "' and Color = N'" + cbbColor.Text + "' and Size =N'" + cbbSize.Text + "'");
                    string deProductCode = code.Rows[0][0].ToString();
                    DataTable dataBill = dataBase.ReadData("select DetailProductCode from tDetailImportBill where DetailProductCode = N'"+deProductCode+"' and CodeBill = N'"+codeBill+"'");
                    if (dataBill.Rows.Count > 0)
                    {
                            MessageBox.Show("Sản phẩm đã tồn tại");
                            return;
                    }
                    else
                    {
                        dataBase.UpdateData("update tDetailProduct set Quantity = Quantity + " + txtQuantity.Text + " where DetailProductCode = N'" + code.Rows[0][0].ToString() + "'");
                        dataBase.UpdateData("insert into tDetailImportBill values (N'" + code.Rows[0][0].ToString() + "', N'" + codeBill + "', N'" + txtQuantity.Text + "');");
                        btnDelete.Text = "  Xóa";
                        btnEdit.Enabled = true;
                        btnPrint.Enabled = true;
                        btnCreate.Visible = true;
                        btnSave.Visible = false;
                        HideProductText();
                        DisplayList();
                    }
                }
                else//edit item
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
                    DataTable dataBill = dataBase.ReadData("select DetailProductCode from tDetailImportBill where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
                    if (dataBill.Rows.Count > 0)//Kiem tra san pham da co trong list chua
                    {
                        if (oldPrCode != deProductCode)//Neui san pham moi khac san pham cu
                        {
                            if (MessageBox.Show("Sản phẩm bạn chọn đã tồn tại, bạn có muốn cập nhật số lượng cho sản phẩm đó?", "Messager",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                dataBase.UpdateData("update tDetailProduct set Quantity = Quantity - " + lblQuantity.Text + " where DetailProductCode = N'" + oldPrCode + "'");
                                dataBase.UpdateData("update tDetailProduct set Quantity = Quantity  + " + txtQuantity.Text + " where DetailProductCode = N'" + deProductCode + "'");
                                dataBase.UpdateData("update tDetailImportBill set Quantity = Quantity + " + txtQuantity.Text + " where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
                                dataBase.UpdateData("delete from tDetailImportBill where DetailProductCode = N'" + oldPrCode + "' and CodeBill = N'" + codeBill + "'");
                            }
                            else
                                return;
                        }
                        else
                        {
                            dataBase.UpdateData("update tDetailProduct set Quantity = Quantity  + " + txtQuantity.Text + " - " + lblQuantity.Text + " where DetailProductCode = N'" + deProductCode + "'");
                            dataBase.UpdateData("update tDetailImportBill set DetailProductCode = N'" + deProductCode + "', Quantity = N'" + txtQuantity.Text + "' where DetailProductCode = N'" + oldPrCode + "' and CodeBill = N'" + codeBill + "'");

                        }
                    }
                    else
                    {
                        dataBase.UpdateData("update tDetailProduct set Quantity = Quantity  + " + txtQuantity.Text + " where DetailProductCode = N'" + deProductCode + "'");
                        dataBase.UpdateData("update tDetailProduct set Quantity = Quantity - " + lblQuantity.Text + " where DetailProductCode = N'" + oldPrCode + "'");
                        dataBase.UpdateData("update tDetailImportBill set DetailProductCode = N'" + deProductCode + "', Quantity = N'" + txtQuantity.Text + "' where DetailProductCode = N'" + oldPrCode + "' and CodeBill = N'" + codeBill + "'");

                    }
                    btnDelete.Text = "  Xóa";
                    btnCreate.Enabled = true;
                    btnEdit.Enabled = true;
                    btnPrint.Enabled = true;
                    btnCreate.Visible = true;
                    btnSave.Visible = false;
                    HideProductText();
                    DisplayList();
                }
            }
            if (status == "EDIT")
            {
                dataBase.UpdateData("update tImportBill set EmployeeCode = N'" + cbbEmployeeCode.Text + "', ProviderCode = N'" + cbbProviderCode.Text + "', DateImport = N'"+dtpTime.Value.ToString()+"' where CodeBill = N'" + codeBill + "'");
                status = "INFOR";
                statusForm();
            }
            if (status == "CREATE")
            {
                dataBase.UpdateData("insert into tImportBill values (N'" + codeBill + "', N'" + dtpTime.Value.ToString() + "',N'" + cbbEmployeeCode.Text + "', N'" + cbbProviderCode.Text + "');");
                status = "INFOR";
                statusForm();
            }

        }
        //nut chinh sua
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnCreate.Enabled = false;
            btnPrint.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Text = "Hủy bỏ";
            DataTable Product = dataBase.ReadData("select ProductCode, NameProduct from tProduct");
            dataBase.FillComboBox(cbbProductCode, Product, "ProductCode", "ProductCode");
            dataBase.FillComboBox(cbbProductName, Product, "NameProduct", "NameProduct");
            cbbProductCode.Text = lblProductCode.Text;
            cbbProductName.Text = lblProductName.Text;
            txtQuantity.Text = lblQuantity.Text;
            HideProductText(false);
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
            header.Value = "CHI TIẾT HÓA ĐƠN NHẬP";

            exSheet.get_Range("A6").Value = "Số hóa đơn";
            exSheet.get_Range("B6").Value = codeBill;
            exSheet.get_Range("A7").Value = "Người tạo";
            exSheet.get_Range("B7").Value = lblEmployeeCode.Text;
            exSheet.get_Range("G6").Value = "Mã nhà cung cấp";
            exSheet.get_Range("H6").Value = lblProviderCode.Text;
            exSheet.get_Range("G7").Value = "Nhà cung cấp";
            exSheet.get_Range("H7").Value = lblProviderName.Text;

            exSheet.get_Range("A9:H9").Font.Bold = true;
            exSheet.get_Range("A9:H9").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exSheet.get_Range("A9:H9").ColumnWidth = 15;
            exSheet.get_Range("C9").ColumnWidth = 25;
            exSheet.get_Range("A9").Value = "Mã chi tiết";
            exSheet.get_Range("B9").Value = "Mã sản phẩm";
            exSheet.get_Range("C9").Value = "Tên sản phẩm";
            exSheet.get_Range("D9").Value = "Màu sắc";
            exSheet.get_Range("E9").Value = "Cỡ";
            exSheet.get_Range("F9").Value = "SL Nhập";
            exSheet.get_Range("G9").Value = "Đơn giá";
            exSheet.get_Range("H9").Value = "Thành tiền";

            DataTable dataEx = dataBase.ReadData("select ctsp.DetailProductCode, ctsp.ProductCode, NameProduct, Color, Size, ctn.Quantity, ImportPrice, ctn.Quantity * ImportPrice  from tDetailProduct ctsp join tProduct sp on ctsp.ProductCode = sp.ProductCode join tDetailImportBill ctn on ctn.DetailProductCode = ctsp.DetailProductCode where CodeBill = N'" + codeBill + "'");
            int i = 0;
            double total = 0;
            for (i = 0; i < dataEx.Rows.Count; i++)
            {
                exSheet.get_Range("A" + (i + 11).ToString() + ":H" + (i + 11).ToString()).Font.Bold = false;
                exSheet.get_Range("A" + (i + 11).ToString()).Value = dataEx.Rows[i][0].ToString();
                exSheet.get_Range("B" + (i + 11).ToString()).Value = dataEx.Rows[i][1].ToString();
                exSheet.get_Range("C" + (i + 11).ToString()).Value = dataEx.Rows[i][2].ToString();
                exSheet.get_Range("D" + (i + 11).ToString()).Value = dataEx.Rows[i][3].ToString();
                exSheet.get_Range("E" + (i + 11).ToString()).Value = dataEx.Rows[i][4].ToString();
                exSheet.get_Range("F" + (i + 11).ToString()).Value = dataEx.Rows[i][5].ToString();
                exSheet.get_Range("G" + (i + 11).ToString()).Value = dataEx.Rows[i][6].ToString();
                exSheet.get_Range("H" + (i + 11).ToString()).Value = dataEx.Rows[i][7].ToString();
                total += Convert.ToDouble(dataEx.Rows[i][7].ToString());
            }
            exSheet.get_Range("G" + (i+13)).Value = "Tổng tiền";
            exSheet.get_Range("H" + (i+13)).Value = total;
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
        //Thoat
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
