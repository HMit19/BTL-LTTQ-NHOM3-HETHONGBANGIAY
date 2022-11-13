using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol
{
    public partial class CustomerControl : UserControl
    {
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

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentCell = dgvList.CurrentRow.Cells[0].Value.ToString();
            if (currentCell == "")
                PanelInfor("KH01");
            else
            PanelInfor(currentCell);
        }

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
        private void cbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = FilterOfCbb();
            dgvList.DataSource = dataBase.ReadData("select CustomerCode, Name from tCustomer " + filter);
            PanelInfor(dgvList.CurrentRow.Cells[0].Value.ToString());
        }

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
        void OnText(bool check = true)
        {
                lblName.Visible = !check;
                lblPhone.Visible = !check;
                lblAddress.Visible = !check;
                txtName.Visible = check;
                txtPhone.Visible = check;
                txtAddress.Visible = check;
        }

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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Bạn chỉ nhập số nguyên");
                e.Handled = true;
            }
        }
    }
}
