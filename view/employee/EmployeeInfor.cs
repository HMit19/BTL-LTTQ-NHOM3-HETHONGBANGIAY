using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
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

            // functions.FillComboBox(cboGender, dtNV, "Gender", "Gender");
            //functions.FillComboBox(cboStatus, dtNV, "Status", "Status");
            functions.FillComboBox(cboEmployeeCode, dtNV, "EmployeeCode", "EmployeeCode");
        }
        public static string GetHash(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] datapass = Encoding.UTF8.GetBytes(str);
            byte[] pass = md5.ComputeHash(datapass);
            string BytePass = null;
            for (int i = 0; i < pass.Length; i++)
            {
                BytePass += pass[i].ToString("x2");
            }
            return BytePass;
        }
        private void EmployeeInfor_Load(object sender, EventArgs e)
        {
            loadData();
        }
        void loadData()
        {
            DataTable dtHDN = data.ReadData("Select CodeBill, DateImport, ProviderCode from tImportBill where EmployeeCode='" + cboEmployeeCode.SelectedValue + "'");
            dgvListImport.DataSource = dtHDN;
            DataTable dtHDB = data.ReadData("Select CodeBill, DateSale, PaymentMethods, CustomerCode, Discount from tBillOfSale where EmployeeCode='" + cboEmployeeCode.SelectedValue + "'");
            dgvListSale.DataSource = dtHDB;
            DataTable dtNV = data.ReadData("Select Name, ID, Gender, DOB, Address, PhoneNumber, Status,UserName from tEmployee where EmployeeCode='" + cboEmployeeCode.SelectedValue + "'");
            dgvListImport.Columns[0].HeaderText = "Mã HĐN";
            dgvListImport.Columns[1].HeaderText = "Ngày Nhập";
            dgvListImport.Columns[2].HeaderText = "Mã NCC";
            dgvListSale.Columns[0].HeaderText = "Mã HĐB";
            dgvListSale.Columns[1].HeaderText = "Ngày Bán";
            dgvListSale.Columns[2].HeaderText = "PTTT";
            dgvListSale.Columns[3].HeaderText = "Mã KH";
            dgvListSale.Columns[4].HeaderText = "Giảm Giá";
        }
        private void cboEmployeeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtNV = data.ReadData("Select Name, ID, Gender, DOB, Address, PhoneNumber, Status, UserName from tEmployee where EmployeeCode='" + cboEmployeeCode.SelectedValue + "'");
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

                
                if (dtNV.Rows[0]["UserName"].ToString() != "")
                {
                    txtUserName.Text = dtNV.Rows[0]["UserName"].ToString();
                    lblUserName.Visible = true;
                    txtUserName.Visible = true;
                    
                    txtUserName.Enabled = false;
                    
                }
                else
                {
                    lblUserName.Visible = false;
                    txtUserName.Visible = false;
                }
                

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

        

        private void btnReload_Click(object sender, EventArgs e)
        {
            
            loadData();
            cboEmployeeCode_SelectedIndexChanged(sender, new EventArgs());
            cboEmployeeCode.Enabled = true;
            txtName.Enabled = true;
            txtID.Enabled = true;
            txtAddress.Enabled = true;
            txtPhoneNumber.Enabled = true;
            cboGender.Enabled = true;
            cboStatus.Enabled = true;
            dtpDOB.Enabled = true;
            lblPassWord.Visible = false;
            txtPassWord.Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblPassWord.Visible == false)
            {
                DateTime dtdob = Convert.ToDateTime(dtpDOB.Value.ToLongDateString());
                if (txtName.Text.Trim() == "")
                {
                    errChiTiet.SetError(txtName, "Bạn không được để trống!");
                    txtName.Focus();
                    return;
                }
                else errChiTiet.Clear();
                if (dtpDOB.Value >= DateTime.Now)
                {
                    errChiTiet.SetError(dtpDOB, "Loi Ngay!");

                    return;
                }
                else errChiTiet.Clear();
                if (txtPhoneNumber.Text.Trim() == "")
                {
                    errChiTiet.SetError(txtPhoneNumber, "Bạn không được để trống!");
                    txtPhoneNumber.Focus();
                    return;
                }
                else errChiTiet.Clear();
                if (txtID.Text.Trim() == "")
                {
                    errChiTiet.SetError(txtID, "Bạn không được để trống!");
                    txtID.Focus();
                    return;
                }
                else errChiTiet.Clear();
                if (txtAddress.Text.Trim() == "")
                {
                    errChiTiet.SetError(txtAddress, "Bạn không được để trống!");
                    txtAddress.Focus();
                    return;
                }
                else errChiTiet.Clear();
                if (MessageBox.Show("Bạn có thực sự muốn cập nhập không?", "Có hay không",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (cboStatus.Text.ToString() == "Đang Làm")
                    {
                        lblAccount.Text = "True";
                    }
                    else
                    {
                        lblAccount.Text = "False";
                    }

                    data.UpdateData("update tEmployee set Name=N'" + txtName.Text + "',ID='" + txtID.Text +
                "',Gender=N'" + cboGender.Text + "',DOB='" + String.Format("{0000:MM/dd/yyyy}", dtdob) + "',Address=N'" +
                txtAddress.Text + "',PhoneNumber='" + txtPhoneNumber.Text + "',Status='" + Boolean.Parse(lblAccount.Text) + "' where EmployeeCode=N'" + cboEmployeeCode.Text + "'");
                    MessageBox.Show("Da luu thanh cong");
                }
            }
            else
            {

                try
                {
                    if (txtUserName.Text == "" && txtPassWord.Text != "")
                    {
                        MessageBox.Show("Bạn không được để trống Account!");
                        txtUserName.Focus();
                        return;
                    }
                    else if (txtUserName.Text != "" && txtPassWord.Text == "")
                    {
                        MessageBox.Show("Bạn không được để trống PassWord!");
                        txtPassWord.Focus();
                        return;
                    }
                    else if(txtUserName.Enabled == true)
                    {
                        string passHash = GetHash(txtPassWord.Text.ToString());
                        passHash = passHash.Substring(0, 15);
                        string sqlacc = "INSERT INTO tLogin (UserName, PassWord) VALUES ('" + txtUserName.Text + "','" + passHash + "')";
                        data.UpdateData(sqlacc);
                        data.UpdateData("update tEmployee set UserName='" + txtUserName.Text + "'where EmployeeCode='" + cboEmployeeCode.SelectedValue + "'");

                    }
                    else
                    {
                        string passHash = GetHash(txtPassWord.Text.ToString());
                        passHash = passHash.Substring(0, 15);
                        data.UpdateData("update tLogin set PassWord='" + passHash + "' where UserName='"+txtUserName.Text+"'");
                        
                    }
                    MessageBox.Show("Da luu thanh cong");
                }
                catch
                {

                }
            }
                
                loadData();
            cboEmployeeCode_SelectedIndexChanged(sender, new EventArgs());
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            cboEmployeeCode.Enabled = false;
            txtName.Enabled = false;
            txtID.Enabled = false;
            txtAddress.Enabled = false;
            txtPhoneNumber.Enabled = false;
            cboGender.Enabled = false;
            cboStatus.Enabled = false;
            dtpDOB.Enabled = false;
            txtPassWord.Text = "";
            if(txtUserName.Visible == true)
            {
                
                lblPassWord.Visible = true;
                txtPassWord.Visible = true;

            }
            else 
            {
                txtUserName.Text = "";
                txtUserName.Enabled = true;
                lblUserName.Visible = true;
                txtUserName.Visible = true;
                lblPassWord.Visible = true;
                txtPassWord.Visible = true;
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt16(e.KeyChar) < Convert.ToInt16('0') || Convert.ToInt16(e.KeyChar) > Convert.ToInt16('9'))
                if (Convert.ToInt16(e.KeyChar) != 8)
                {
                    MessageBox.Show("Vui lòng nhập số");
                    e.Handled = true;
                }
        }
    }
    }

