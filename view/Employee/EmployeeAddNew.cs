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
using System.Security.Cryptography;
namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.EmployeeInfor
{
    
    public partial class EmployeeAddNew : Form
    {
        Classes.CommonFunctions functions = new Classes.CommonFunctions();
        Classes.ConnectData data = new Classes.ConnectData();
        public static string GetHash(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] datapass = Encoding.UTF8.GetBytes(str);
            byte[] pass = md5.ComputeHash(datapass);
            string BytePass = null;
            for (int i = 0; i < pass.Length; i++)
            {
                BytePass +=pass[i].ToString("x2");
            }
            return BytePass;
        }
        public static string RandomCode(string rd)
        {
            int a = 13, b = 10;
            Random random = new Random();
            for(int i=1; i <= a; i++)
            {
                 rd+=Convert.ToString(random.Next(b));
            }
            
            
                return rd;
        }
        public EmployeeAddNew()
        {
            InitializeComponent();
            DataTable dtNV = data.ReadData("Select * from tEmployee");
            DataTable dtLG = data.ReadData("Select * from tLogin");
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {

            
            DateTime dtdob;

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
           
            dtdob = Convert.ToDateTime(dtpDOB.Value.ToLongDateString());
            try
            {
                string sqlusn = "select * from tLogin where UserName ='" + txtAccount.Text + "'";
                DataTable dtLG = data.ReadData(sqlusn);
                if (dtLG.Rows.Count > 0)
                {
                    errChiTiet.SetError(txtAccount, "UserName trùng trong cơ sở dữ liệu");
                    txtAccount.Focus();
                    return;
                }
                else errChiTiet.Clear();
                string passHash = GetHash(txtPassWord.Text.ToString());
                passHash = passHash.Substring(0, 15);
                string sqlacc = "INSERT INTO tLogin (UserName, PassWord) VALUES ('" + txtAccount.Text + "','" + passHash + "')";
                data.UpdateData(sqlacc);


            }
            catch
            {

            }

            string sql = "INSERT INTO tEmployee (EmployeeCode, Name, ID, Gender, DOB, Address, PhoneNumber, UserName, Status) VALUES (";
            sql += "N'" + txtEmployeeCode.Text + "' ,N'" + txtName.Text + "',N'" + txtID.Text + "',N'" + cboGender.Text.ToString() + "','" + String.Format("{0000:MM/dd/yyyy}", dtdob) + "',N'" + txtAddress.Text + "','" + int.Parse(txtPhoneNumber.Text) + "','" + txtAccount.Text + "','" + Boolean.Parse("true") + "')";

            data.UpdateData(sql);

            
            MessageBox.Show("Thêm mới thành công");
            ResetValue();

        }
        void ResetValue()

        {
            txtEmployeeCode.Text = "";
            txtName.Text = "";
            cboGender.Text = "";
            dtpDOB.Value = DateTime.Now;
            txtPhoneNumber.Text = "";
            txtID.Text = "";
            txtAddress.Text = "";
            txtAccount.Text = "";
            txtPassWord.Text = "";
            txtEmployeeCode.Focus();
            
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ResetValue();
        }

        private void EmployeeAddNew_Load(object sender, EventArgs e)
        {
            
            txtEmployeeCode.Text ="NV"+ RandomCode(txtEmployeeCode.Text.ToString());
            string sqlselect = "Select * from tEmployee where EmployeeCode = '" + txtEmployeeCode.Text + "'";
            DataTable dtNV = data.ReadData(sqlselect);
            if (dtNV.Rows.Count > 0)
            {
                RandomCode(txtEmployeeCode.Text.ToString());
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
