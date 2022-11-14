﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.EmployeeInfor
{
    
    public partial class EmployeeAddNew : Form
    {
        Classes.CommonFunctions functions = new Classes.CommonFunctions();
        Classes.ConnectData data = new Classes.ConnectData();
        public EmployeeAddNew()
        {
            InitializeComponent();
            DataTable dtNV = data.ReadData("Select * from tEmployee");
            DataTable dtLG = data.ReadData("Select * from tLogin");
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

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
            if (txtEmployeeCode.Text.Trim() == "")
            {
                errChiTiet.SetError(txtEmployeeCode, "Bạn không được để trống Ma NV!");
                return;
            }
            else
            {
               string sqlselect = "Select * from tEmployee where EmployeeCode = '" + txtEmployeeCode.Text + "'";
               DataTable dtNV = data.ReadData(sqlselect);
                if (dtNV.Rows.Count > 0)
                {
                    errChiTiet.SetError(txtEmployeeCode, "Mã NV trùng trong cơ sở dữ liệu");
                    return;
                }
                errChiTiet.Clear();
            }
            dtdob = Convert.ToDateTime(dtpDOB.Value.ToLongDateString());
            string sql = "INSERT INTO tEmployee (EmployeeCode, Name, ID, Gender, DOB, Address, PhoneNumber, UserName) VALUES (";
            sql += "N'" + txtEmployeeCode.Text + "' ,N'" + txtName.Text + "',N'" + txtID.Text + "',N'" + cboGender.SelectedValue + "','" + String.Format("{0000:MM/dd/yyyy}", dtdob) + "',N'" + txtAddress.Text + "','" + int.Parse(txtPhoneNumber.Text) + "','"+txtAccount.Text+"')";

            data.UpdateData(sql);
            string sqlacc = "INSERT INTO tLogin (UserName, PassWord) VALUES ('"+txtAccount.Text + "','" + txtPassWord.Text + "')";
            data.UpdateData(sqlacc);
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
            cboStatus.Text = "";
            txtAddress.Text = "";
            txtAccount.Text = "";
            txtPassWord.Text = "";
            txtEmployeeCode.Focus();
            
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ResetValue();
        }
    }
}