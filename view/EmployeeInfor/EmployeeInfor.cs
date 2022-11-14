using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using TheArtOfDevHtmlRenderer.Adapters;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.EmployeeInfor
{
    public partial class EmployeeInfor : Form
    {
        Classes.CommonFunctions functions = new Classes.CommonFunctions();
        Classes.ConnectData data = new Classes.ConnectData();
        public EmployeeInfor()
        {
            InitializeComponent();
            DataTable dtNV = data.ReadData("Select * from tEmployee");
            DataTable dtHDN = data.ReadData("Select * from tImportBill");
            DataTable dtHDB = data.ReadData("Select * from tBillOfSale");
            DataTable dtLG = data.ReadData("Select * from tLogin");
            // functions.FillComboBox(cboGender, dtNV, "Gender", "Gender");
            //functions.FillComboBox(cboStatus, dtNV, "Status", "Status");
            functions.FillComboBox(cboEmployeeCode, dtNV, "EmployeeCode", "EmployeeCode");
        }
        public void funData(TextBox txtForm1)
        {

        }
        private void EmployeeInfor_Load(object sender, EventArgs e)
        {

        }
        void loadData()
        {
            DataTable dtHDN = data.ReadData("Select CodeBill, DateImport, ProviderCode from tImportBill where EmployeeCode='" + cboEmployeeCode.SelectedValue + "'");
            dgvListImport.DataSource = dtHDN;
            DataTable dtHDB = data.ReadData("Select CodeBill, DateSale, PaymentMethods, CustomerCode, Discount from tBillOfSale where EmployeeCode='" + cboEmployeeCode.SelectedValue + "'");
            dgvListSale.DataSource = dtHDB;
            DataTable dtNV = data.ReadData("Select Name, ID, Gender, DOB, Address, PhoneNumber, Status,UserName from tEmployee where EmployeeCode='" + cboEmployeeCode.SelectedValue + "'");
          
        }
        private void cboEmployeeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtNV = data.ReadData("Select Name, ID, Gender, DOB, Address, PhoneNumber, Status,UserName from tEmployee where EmployeeCode='" + cboEmployeeCode.SelectedValue + "'");
                txtName.Text = dtNV.Rows[0]["Name"].ToString();
                txtID.Text = dtNV.Rows[0]["ID"].ToString();
                cboGender.Text = dtNV.Rows[0]["Gender"].ToString();
                txtAddress.Text = dtNV.Rows[0]["Address"].ToString();
                txtPhoneNumber.Text = dtNV.Rows[0]["PhoneNumber"].ToString();
                if (dtNV.Rows[0]["Status"].ToString() == "True")
                {
                    cboStatus.Text = "Đang Làm";
                }
                else
                { cboStatus.Text = "Đã Nghỉ"; }
                dtpDOB.Text = dtNV.Rows[0]["DOB"].ToString();

                DataTable dtLG = data.ReadData("Select PassWord from tLogin join tEmployee on tLogin.UserName=tEmployee.UserName where tLogin.UserName=tEmployee.UserName");
                txtAccount.Text = dtNV.Rows[0]["UserName"].ToString();
                txtPassWord.Text = dtLG.Rows[0]["PassWord"].ToString();

                loadData();

            }
            catch
            {

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvListImport.Rows.RemoveAt(dgvListImport.CurrentCell.RowIndex);
                dgvListSale.Rows.RemoveAt(dgvListSale.CurrentCell.RowIndex);
                loadData();
            }
            
            loadData();
            MessageBox.Show("da xoa thanh cong");
            

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
            cboEmployeeCode_SelectedIndexChanged(sender, new EventArgs());

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime dtdob = Convert.ToDateTime(dtpDOB.Value.ToLongDateString());
            if (MessageBox.Show("Bạn có thực sự muốn cập nhập không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.UpdateData("update tLogin set UserName=N'" + txtAccount.Text + "',PassWord='" + txtPassWord + "' where UserName='"+txtAccount.Text+"' ");
                data.UpdateData("update tEmployee set Name=N'" + txtName.Text + "',ID='" + txtID.Text +
            "',Gender=N'" + cboGender.Text + "',DOB='" + String.Format("{0000:MM/dd/yyyy}", dtdob) + "',Address=N'" +
            txtAddress.Text + "',PhoneNumber='" + txtPhoneNumber.Text + "' where EmployeeCode=N'" + cboEmployeeCode.Text + "'");
               
                loadData();
                MessageBox.Show("Da luu thanh cong");


            }
        }
    }
}
