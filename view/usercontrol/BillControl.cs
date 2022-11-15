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
using Microsoft.Office.Interop.Excel;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol
{
    
    public partial class BillControl : UserControl
    {
        DAO.connect.ConnectData dataBase = new DAO.connect.ConnectData();
        public BillControl()
        {
            InitializeComponent();
        }
        //User control load...
        private void BillControl_Load(object sender, EventArgs e)
        {
            //watermark of textbox
            txtSearch.Text = "Tìm kiếm hóa đơn theo...";
            txtSearch.ForeColor = SystemColors.GrayText;
            //default value combobox
            cbbType.SelectedIndex = 0;
            cbbFilter.SelectedIndex = 0;
            cbbDate.SelectedIndex = 0;
            //dataSource of dgv
            DataSale(DateSort());
        }
        //Date sort
        string DateSort()
        {
            string sort = " order by ";
            if (cbbType.SelectedIndex == 0)
            {
                if (cbbDate.SelectedIndex == 0)
                    sort += "DateSale desc";
                else
                    sort += "DateSale asc";
            }
            else
            {
                if (cbbDate.SelectedIndex == 0)
                    sort += "DateImport desc";
                else
                    sort += "DateImport asc";
            }
            return sort;
        }
        //display sale bill
        void DataSale(string after = "")
        {
            dgvList.DataSource = dataBase.ReadData("select CodeBill, DateSale, PaymentMethods, isnull(0,Discount) from tBillOfSale" + after);
            dgvList.Columns[0].HeaderText = "Số hóa đơn";
            dgvList.Columns[1].HeaderText = "Ngày tạo";
            dgvList.Columns[2].HeaderText = "Phương thức thanh toán";
            dgvList.Columns[3].HeaderText = "Giảm giá";
        }
        //display importbill
        void DataImport(string after = "")
        {
            dgvList.DataSource = dataBase.ReadData("select CodeBill, DateImport, Name from tImportBill hdn join tProvider ncc on hdn.ProviderCode = ncc.ProviderCode" + after);
            dgvList.Columns[0].HeaderText = "Số hóa đơn";
            dgvList.Columns[1].HeaderText = "Ngày tạo";
            dgvList.Columns[2].HeaderText = "Nhà cung cấp";
        }
        //sql of filter
        string Filter()
        {
            string filter = "";
            if (cbbFilter.SelectedIndex == 0)
                filter = " where CodeBill ";
            else
                filter = " where EmployeeCode ";
            return filter;
        }
        // Search textbox watermark
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "Tìm kiếm hóa đơn theo...";
                txtSearch.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm hóa đơn theo...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.ControlText;
            }
        }
        //Type sale or import ...
        private void cbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbType.SelectedIndex == 0)
            {
                btnCreate.Visible = false;
                DataSale(DateSort());
            }
            if (cbbType.SelectedIndex == 1)
            {
                btnCreate.Visible = true;
                DataImport(DateSort());
            }
            txtSearch.Text = "Tìm kiếm hóa đơn theo...";
            txtSearch.ForeColor = SystemColors.GrayText;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            if (txtSearch.Text == "Tìm kiếm hóa đơn theo...")
            {
                search = "";
            }
            if (cbbType.SelectedIndex == 0)
                DataSale(Filter() + "like N'%" + search + "%' " + DateSort());
            else
                DataImport(Filter() + "like N'%" + search + "%' " + DateSort());
        }
        //Display by date
        private void cbbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbType.SelectedIndex == 0)
            {
                DataSale(DateSort());
                btnEdit.Enabled = false;
            }  
            else
            {
                DataImport(DateSort());
                btnEdit.Enabled = true;
            }      
        }
        //Export file excel
        private void btnExcel_Click(object sender, EventArgs e)
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
            exSheet.get_Range("B4:G4").Merge(true);
            header.Font.Size = 14;
            header.Font.Bold = true;
            if (cbbType.SelectedIndex == 0)
            {
                header.Value = "DANH SÁCH HÓA ĐƠN BÁN";

                exSheet.get_Range("A6:D6").Font.Bold = true;
                exSheet.get_Range("A6:D6").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A6:D6").ColumnWidth = 25;
                exSheet.get_Range("A6").Value = "Số hóa đơn";
                exSheet.get_Range("B6").Value = "Ngày tạo";
                exSheet.get_Range("C6").Value = "Phương thức thanh toán";
                exSheet.get_Range("D6").Value = "Giảm giá";
                exSheet.get_Range("E6").Value = "Người tạo";

                DataTable dataEx = dataBase.ReadData("select CodeBill, DateSale, PaymentMethods, Discount, EmployeeCode from tBillOfSale " + DateSort());
                for (int i = 0; i < dataEx.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 7).ToString() + ":G" + (i + 7).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 7).ToString()).Value = dataEx.Rows[i][0].ToString();
                    exSheet.get_Range("B" + (i + 7).ToString()).Value = dataEx.Rows[i][1].ToString();
                    exSheet.get_Range("C" + (i + 7).ToString()).Value = dataEx.Rows[i][2].ToString();
                    exSheet.get_Range("D" + (i + 7).ToString()).Value = dataEx.Rows[i][3].ToString();
                    exSheet.get_Range("E" + (i + 7).ToString()).Value = dataEx.Rows[i][4].ToString();
                }
                exSheet.Name = "Danh sách hóa đơn bán";
            }
            else
            {
                header.Value = "DANH SÁCH HÓA ĐƠN NHẬP";

                exSheet.get_Range("A6:D6").Font.Bold = true;
                exSheet.get_Range("A6:D6").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A6:D6").ColumnWidth = 25;
                exSheet.get_Range("A6").Value = "Số hóa đơn";
                exSheet.get_Range("B6").Value = "Ngày tạo";
                exSheet.get_Range("C6").Value = "Người tạo";
                exSheet.get_Range("D6").Value = "Nhà cung cấp";

                DataTable dataEx = dataBase.ReadData("select * from tImportBill " + DateSort());
                for (int i = 0; i < dataEx.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 7).ToString() + ":G" + (i + 7).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 7).ToString()).Value = dataEx.Rows[i][0].ToString();
                    exSheet.get_Range("B" + (i + 7).ToString()).Value = dataEx.Rows[i][1].ToString();
                    exSheet.get_Range("C" + (i + 7).ToString()).Value = dataEx.Rows[i][2].ToString();
                    exSheet.get_Range("D" + (i + 7).ToString()).Value = dataEx.Rows[i][3].ToString();
                }
                exSheet.Name = "Danh sách hóa đơn nhập";
            }
            if (cbbType.SelectedIndex == 0)
            {
                header.Value = "DANH SÁCH HÓA ĐƠN BÁN";

                exSheet.get_Range("A6:D6").Font.Bold = true;
                exSheet.get_Range("A6:D6").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A6:D6").ColumnWidth = 25;
                exSheet.get_Range("A6").Value = "Số hóa đơn";
                exSheet.get_Range("B6").Value = "Ngày tạo";
                exSheet.get_Range("C6").Value = "Phương thức thanh toán";
                exSheet.get_Range("D6").Value = "Giảm giá";
                exSheet.get_Range("E6").Value = "Người tạo";

                DataTable dataEx = dataBase.ReadData("select CodeBill, DateSale, PaymentMethods, Discount, EmployeeCode from tBillOfSale " + DateSort());
                for (int i = 0; i < dataEx.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 7).ToString() + ":G" + (i + 7).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 7).ToString()).Value = dataEx.Rows[i][0].ToString();
                    exSheet.get_Range("B" + (i + 7).ToString()).Value = dataEx.Rows[i][1].ToString();
                    exSheet.get_Range("C" + (i + 7).ToString()).Value = dataEx.Rows[i][2].ToString();
                    exSheet.get_Range("D" + (i + 7).ToString()).Value = dataEx.Rows[i][3].ToString();
                    exSheet.get_Range("E" + (i + 7).ToString()).Value = dataEx.Rows[i][4].ToString();
                }
                exSheet.Name = "Danh sách hóa đơn bán";
            }
            else
            {
                header.Value = "DANH SÁCH HÓA ĐƠN BÁN";

                exSheet.get_Range("A6:D6").Font.Bold = true;
                exSheet.get_Range("A6:D6").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A6:D6").ColumnWidth = 25;
                exSheet.get_Range("A6").Value = "Số hóa đơn";
                exSheet.get_Range("B6").Value = "Ngày tạo";
                exSheet.get_Range("C6").Value = "Phương thức thanh toán";
                exSheet.get_Range("D6").Value = "Giảm giá";

                DataTable dataEx = dataBase.ReadData("select CodeBill, DateSale, PaymentMethods, isnull(0,Discount) from tBillOfSale" + DateSort());
                for (int i = 0; i < dataEx.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 7).ToString() + ":G" + (i + 7).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 7).ToString()).Value = dataEx.Rows[i][0].ToString();
                    exSheet.get_Range("B" + (i + 7).ToString()).Value = dataEx.Rows[i][1].ToString();
                    exSheet.get_Range("C" + (i + 7).ToString()).Value = dataEx.Rows[i][2].ToString();
                    exSheet.get_Range("D" + (i + 7).ToString()).Value = dataEx.Rows[i][3].ToString();
                }
                exSheet.Name = "Danh sách hóa đơn bán";
            }
            exBook.Activate();

            dlgSave.Filter = "Excel Document(*.xlsx)|*.xlsx |All files(*.*)|*.*";
            dlgSave.FilterIndex = 1;
            dlgSave.AddExtension = true;
            dlgSave.DefaultExt = ".xlsx";
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(dlgSave.FileName.ToString());
                dlgSave.Reset();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            exApp.Quit();
        }
        //button infor
        private void btnInfor_Click(object sender, EventArgs e)
        {   
            if (cbbType.SelectedIndex == 1)
            {
                ImportBillForm infor = new ImportBillForm(dgvList.CurrentRow.Cells[0].Value.ToString(), "INFOR");
                infor.Show();
            }
            if (cbbType.SelectedIndex == 0)
            {
                SaleBillForm infor = new SaleBillForm(dgvList.CurrentRow.Cells[0].Value.ToString(), "INFOR");
                infor.Show();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string newCode = dataBase.AutoCode("tImportBill", "CodeBill", "HDN" + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString());
            ImportBillForm infor = new ImportBillForm(newCode, "CREATE");
            infor.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (cbbType.SelectedIndex == 1)
            {
                ImportBillForm infor = new ImportBillForm(dgvList.CurrentRow.Cells[0].Value.ToString(), "EDIT");
                infor.Show();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbbType.SelectedIndex == 1)
            {
                if (MessageBox.Show("Bạn có muốn xóa hóa đơn này không?", "Messager",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string codeBill = dgvList.CurrentRow.Cells[0].Value.ToString();
                    DataTable detailBill = dataBase.ReadData("select DetailProductCode from tDetailImportBill where CodeBill = N'"+codeBill+"'");
                    int n = detailBill.Rows.Count;
                    for (int i = 0; i < n; i++)
                    {
                        string deProductCode = detailBill.Rows[i][0].ToString();
                        DeleteProductImport(deProductCode, codeBill);
                    }
                    dataBase.UpdateData("delete from tImportBill where CodeBill = N'"+codeBill+"'");
                    DataImport(DateSort());
                }
            }
            if (cbbType.SelectedIndex == 0)
            {
                if (MessageBox.Show("Bạn có muốn xóa hóa đơn này không?", "Messager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string codeBill = dgvList.CurrentRow.Cells[0].Value.ToString();
                    DataTable detailBill = dataBase.ReadData("select DetailProductCode from tDetailBillOfSale where CodeBill = N'" + codeBill + "'");
                    int n = detailBill.Rows.Count;
                    for (int i = 0; i < n; i++)
                    {
                        string deProductCode = detailBill.Rows[i][0].ToString();
                        DeleteProductSale(deProductCode, codeBill);
                    }
                    dataBase.UpdateData("delete from tBillOfSale where CodeBill = N'" + codeBill + "'");
                    DataSale(DateSort());
                }
            }
        }
        void DeleteProductImport(string deProductCode, string codeBill)
        {
            string quantity = "";
            DataTable billData = dataBase.ReadData("select Quantity from tDetailImportBill where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
            quantity = billData.Rows[0][0].ToString();
            dataBase.UpdateData("update tDetailProduct set Quantity = Quantity - " + quantity + " where DetailProductCode = N'" + deProductCode + "'");
            dataBase.UpdateData("delete from tDetailImportBill where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
        }
        void DeleteProductSale(string deProductCode, string codeBill)
        {
            string quantity = "";
            DataTable billData = dataBase.ReadData("select Quantity from tDetailBillOfSale where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
            quantity = billData.Rows[0][0].ToString();
            dataBase.UpdateData("update tDetailProduct set Quantity = Quantity + " + quantity + " where DetailProductCode = N'" + deProductCode + "'");
            dataBase.UpdateData("delete from tDetailBillOfSale where DetailProductCode = N'" + deProductCode + "' and CodeBill = N'" + codeBill + "'");
        }
    }
}
