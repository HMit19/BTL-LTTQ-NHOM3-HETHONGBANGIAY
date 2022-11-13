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

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol
{
    public partial class CustomerControl : UserControl
    {
        //Connect database
        DAO.connect.ConnectData dataBase = new DAO.connect.ConnectData();
        //Hàm tạo...
        public CustomerControl()
        {
            InitializeComponent();

        }
        //Watermark for text box
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm hóa đơn theo...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "Tìm kiếm hóa đơn theo...";
                txtSearch.ForeColor = SystemColors.GrayText;
            }
        }
        //UserControl Load...
        private void CustomerControl_Load(object sender, EventArgs e)
        {
            //textbox...
            txtSearch.Text = "Tìm kiếm hóa đơn theo...";
            txtSearch.ForeColor = SystemColors.GrayText;
            //combobox..
            cbbType.SelectedIndex = 0;
            cbbFilter.SelectedIndex = 0;
            //data grid view...
            dgvList.DataSource = dataBase.ReadData("select CustomerCode, Name from tCustomer");
            dgvList.Columns[0].HeaderText = "Mã khách hàng";
            dgvList.Columns[1].HeaderText = "Tên khách hàng";
            //panel InforCustomer...
            PanelInfor("KH01");
        }
        //Function to display information of customer
        void PanelInfor(string customerCode)
        {
            if (btnCancel.Visible == true)
                return;
            DataTable data = dataBase.ReadData("select * from tCustomer where CustomerCode = N'"+ customerCode + "'");
            lblCode.Text = data.Rows[0][0].ToString();
            lblName.Text = data.Rows[0][1].ToString();
            lblPhone.Text = data.Rows[0][4].ToString();
            lblAddress.Text = data.Rows[0][3].ToString();
            if (data.Rows[0][5].ToString() == "")
                lblPoint.Text = "0";
            else
                lblPoint.Text = data.Rows[0][5].ToString();
            DataTable totalBill = dataBase.ReadData("select ctb.Quantity, sp.Price, isnull(0,hdb.Discount) from tBillOfSale hdb join tDetailBillOfSale ctb on hdb.CodeBill = ctb.CodeBill join tDetailProduct sp on ctb.DetailProductCode = sp.DetailProductCode where hdb.CustomerCode = N'" + customerCode + "'");
            double total = 0;
            for (int i = 0; i < totalBill.Rows.Count; i++)
            {
                total += Convert.ToDouble(totalBill.Rows[i][0].ToString()) * Convert.ToDouble(totalBill.Rows[i][1].ToString()) - Convert.ToDouble(totalBill.Rows[0][2].ToString());
            }
            lblTotal.Text = total.ToString();
            dgvBill.DataSource = dataBase.ReadData("Select CodeBill as 'Số Hóa Đơn', DateSale as 'Ngày bán', PaymentMethods as 'Thanh toán', Discount as 'Điểm' from tBillOfSale where CustomerCode = N'" + customerCode + "'");
        }
        //DataGridView of customer's list
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentCell = dgvList.CurrentRow.Cells[0].Value.ToString();
            if (currentCell == "")
                PanelInfor("KH01");
            else
            PanelInfor(currentCell);
        }
        //Function to get value of combobox
        string FilterOfCbb()
        {
            string filter ="";
            if (cbbType.SelectedIndex == 0)
            {
                if (cbbFilter.SelectedIndex == 0)
                    filter = "order by CustomerCode asc";
                else
                    filter = "order by CustomerCode desc";
            }
            else
            {
                if (cbbFilter.SelectedIndex == 0)
                    filter = "order by Name asc";
                else
                    filter = "order by Name desc";
            }
            return filter;
        }
        //Display ascend or descend...
        private void cbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = FilterOfCbb();
            dgvList.DataSource = dataBase.ReadData("select CustomerCode, Name from tCustomer " + filter);
            PanelInfor(dgvList.CurrentRow.Cells[0].Value.ToString());
        }
        //Get value in textbox and combobox to find and display into datagridview...
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            if (txtSearch.Text == "Tìm kiếm hóa đơn theo...")
            {
                search = "";
            }
            if (cbbType.SelectedIndex == 0)
            {
                dgvList.DataSource = dataBase.ReadData("select CustomerCode, Name from tCustomer where CustomerCode like N'%" + search+"%' " + FilterOfCbb());
            }
            else
            {
                dgvList.DataSource = dataBase.ReadData("select CustomerCode, Name from tCustomer where Name like N'%" + search + "%' " + FilterOfCbb());
            }
            
        }
        //Hide or display update textbox
        void OnText(bool check = true)
        {
                lblName.Visible = !check;
                lblPhone.Visible = !check;
                lblAddress.Visible = !check;
                txtName.Visible = check;
                txtPhone.Visible = check;
                txtAddress.Visible = check;
        }

        //Update information of customer
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnCancel.Visible == false)
            {
                OnText();
                txtName.Text = lblName.Text;
                txtPhone.Text = lblPhone.Text;
                txtAddress.Text = lblAddress.Text;
                btnCancel.Visible = true;
                btnSearch.Enabled = false;
                btnExcel.Enabled = false;
            }
            else
            {
                string name = "", phone = "", address = "", code = lblCode.Text;
                if (txtName.Text.Trim() != "")
                {
                    name = ", Name = N'" + txtName.Text + "' ";
                    lblName.Text = txtName.Text;
                }
                if (txtPhone.Text.Trim() != "")
                {
                    phone = ", PhoneNumber = N'" + txtPhone.Text + "' ";
                    lblPhone.Text = txtPhone.Text;
                }
                if (txtAddress.Text.Trim() != "")
                {
                    address = ", Address = N'" + txtAddress.Text + "' ";
                    lblAddress.Text = txtAddress.Text;
                }
                dataBase.UpdateData("update tCustomer set CustomerCode = N'"+ lblCode.Text + "' "+name + phone + address+ " where CustomerCode = N'"+ lblCode.Text +"'");
                dgvList.DataSource = dataBase.ReadData("select CustomerCode, Name from tCustomer");
                OnText(false);
                PanelInfor(code);
                btnCancel.Visible = false;
                btnSearch.Enabled = true;
                btnExcel.Enabled = true;
            }
        }
        // Cancel update...
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            OnText(false);
            btnCancel.Visible = false;
            btnSearch.Enabled = true;
            btnExcel.Enabled = true;
        }
        // Only number for phone textbox...
        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Bạn chỉ nhập số nguyên");
                e.Handled = true;
            }
        }
        // Export excel  file list of customer
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
            header.Value = "DANH SÁCH KHÁCH HÀNG";

            exSheet.get_Range("A6:E6").Font.Bold = true;
            exSheet.get_Range("A6:E6").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exSheet.get_Range("A6:E6").ColumnWidth = 20;
            exSheet.get_Range("A6").Value = "Mã khách hàng";
            exSheet.get_Range("B6").Value = "Tên khách hàng";
            exSheet.get_Range("C6").Value = "Địa chỉ";
            exSheet.get_Range("D6").Value = "Điện thoại";
            exSheet.get_Range("E6").Value = "Điểm";

            DataTable dataEx = dataBase.ReadData("select CustomerCode, Name, Address, PhoneNumber, Point\r\nfrom tCustomer");
            for(int i = 0; i < dataEx.Rows.Count; i++)
            {
                exSheet.get_Range("A" + (i + 7).ToString() + ":G" + (i + 7).ToString()).Font.Bold = false;
                exSheet.get_Range("A" + (i + 7).ToString()).Value = dataEx.Rows[i][0].ToString();
                exSheet.get_Range("B" + (i + 7).ToString()).Value = dataEx.Rows[i][1].ToString();
                exSheet.get_Range("C" + (i + 7).ToString()).Value = dataEx.Rows[i][2].ToString();
                exSheet.get_Range("D" + (i + 7).ToString()).Value = "'" + dataEx.Rows[i][3].ToString();
                exSheet.get_Range("E" + (i + 7).ToString()).Value = dataEx.Rows[i][4].ToString();
            }
            exSheet.Name = "Danh sách khách hàng";
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
    }
}
