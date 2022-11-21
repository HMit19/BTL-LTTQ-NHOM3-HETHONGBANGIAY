using System;
using System.Drawing;
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
            if (txtSearch.Text == "Tìm kiếm khách hàng theo...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                txtSearch.Text = "Tìm kiếm khách hàng theo...";
                txtSearch.ForeColor = SystemColors.GrayText;
            }
        }
        //UserControl Load...
        private void CustomerControl_Load(object sender, EventArgs e)
        {
            //textbox...
            txtSearch.Text = "Tìm kiếm khách hàng theo...";
            txtSearch.ForeColor = SystemColors.GrayText;
            //combobox..
            cbbType.SelectedIndex = 0;
            cbbFilter.SelectedIndex = 0;
            //data grid view...
            dgvList.DataSource = dataBase.readData("select CustomerCode, Name from tCustomer");
            dgvList.Columns[0].HeaderText = "Mã khách hàng";
            dgvList.Columns[1].HeaderText = "Tên khách hàng";
            //panel InforCustomer...
            panelInfor("KH01");
        }
        //Function to display information of customer
        void panelInfor(string customerCode)
        {
            if (btnCancel.Visible == true)
                return;
            DataTable data = dataBase.readData("select * from tCustomer where CustomerCode = N'"+ customerCode + "'");
            lblCode.Text = data.Rows[0][0].ToString();
            lblName.Text = data.Rows[0][1].ToString();
            lblPhone.Text = data.Rows[0][4].ToString();
            lblAddress.Text = data.Rows[0][3].ToString();
            lblGender.Text = data.Rows[0][2].ToString();
            if (data.Rows[0][5].ToString() == "")
                lblPoint.Text = "0";
            else
                lblPoint.Text = data.Rows[0][5].ToString();
            lblBirth.Text = Convert.ToDateTime(data.Rows[0][6].ToString()).ToString("dd/MM/yyyy");
            DataTable totalBill = dataBase.readData("select ctb.Quantity, sp.Price, isnull(0,hdb.Discount) from tBillOfSale hdb join tDetailBillOfSale ctb on hdb.CodeBill = ctb.CodeBill join tDetailProduct sp on ctb.DetailProductCode = sp.DetailProductCode where hdb.CustomerCode = N'" + customerCode + "'");
            double total = 0;
            for (int i = 0; i < totalBill.Rows.Count; i++)
            {
                total += Convert.ToDouble(totalBill.Rows[i][0].ToString()) * Convert.ToDouble(totalBill.Rows[i][1].ToString()) - Convert.ToDouble(totalBill.Rows[0][2].ToString());
            }
            lblTotal.Text = total.ToString("#,###");
            dgvBill.DataSource = dataBase.readData("Select CodeBill as 'Số Hóa Đơn', DateSale as 'Ngày bán', PaymentMethods as 'Thanh toán', Discount as 'Điểm' from tBillOfSale where CustomerCode = N'" + customerCode + "'");
        }

        //Function to get value of combobox
        string filterOfCbb()
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

        //Hide or display update textbox
        void onText(bool check = true)
        {
            lblName.Visible = !check;
            lblPhone.Visible = !check;
            lblAddress.Visible = !check;
            lblGender.Visible = !check;
            lblBirth.Visible = !check;
            txtName.Visible = check;
            txtPhone.Visible = check;
            txtAddress.Visible = check;
            cbbGender.Visible = check;
            dtpBirth.Visible = check;
        }

        //DataGridView of customer's list
        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentCell = dgvList.CurrentRow.Cells[0].Value.ToString();
            if (currentCell == "")
                panelInfor("KH01");
            else
                panelInfor(currentCell);
        }

        //Display ascend or descend...
        private void cbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = filterOfCbb();
            dgvList.DataSource = dataBase.readData("select CustomerCode, Name from tCustomer " + filter);
            panelInfor(dgvList.CurrentRow.Cells[0].Value.ToString());
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
                dgvList.DataSource = dataBase.readData("select CustomerCode, Name from tCustomer where CustomerCode like N'%" + search+"%' " + filterOfCbb());
            }
            else
            {
                dgvList.DataSource = dataBase.readData("select CustomerCode, Name from tCustomer where Name like N'%" + search + "%' " + filterOfCbb());
            }
            
        }

        //Update information of customer
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnCancel.Visible == false)
            {
                onText();
                txtName.Text = lblName.Text;
                txtPhone.Text = lblPhone.Text;
                txtAddress.Text = lblAddress.Text;
                cbbGender.Text = lblGender.Text;
                dtpBirth.Value = Convert.ToDateTime(lblBirth.Text);
                btnCancel.Visible = true;
                btnSearch.Enabled = false;
                btnExcel.Enabled = false;
            }
            else//Need update Gender and BirthDay
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
                string gender = ", Gender = N'" + cbbGender.Text + "' ";
                lblGender.Text = cbbGender.Text;
                string birthday = ", BirthDay = N'"+ dtpBirth.Value.ToString()+"' ";
                lblBirth.Text = dtpBirth.Value.ToString("dd/MM/yyyy");
                dataBase.updateData("update tCustomer set CustomerCode = N'"+ lblCode.Text + "' "+name + phone + address + gender + birthday +" where CustomerCode = N'"+ lblCode.Text +"'");
                dgvList.DataSource = dataBase.readData("select CustomerCode, Name from tCustomer");
                onText(false);
                panelInfor(code);
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
            onText(false);
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

            DataTable dataEx = dataBase.readData("select CustomerCode, Name, Address, PhoneNumber, Point\r\nfrom tCustomer");
            for(int i = 0; i < dataEx.Rows.Count; i++)
            {
                exSheet.get_Range("A" + (i + 7) + ":H" + (i + 7)).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
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
