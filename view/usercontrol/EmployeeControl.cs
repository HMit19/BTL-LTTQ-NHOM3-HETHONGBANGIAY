using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
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
    public partial class EmployeeControl : UserControl
    {
        Classes.CommonFunctions functions = new Classes.CommonFunctions();
        Classes.ConnectData data = new Classes.ConnectData();
        public EmployeeControl()
        {
            InitializeComponent();
            DataTable dtNV = data.ReadData("Select * from tEmployee");
            functions.FillComboBox(cbEmployeeCode, dtNV, "EmployeeCode", "EmployeeCode");
        }

      

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dtNV = data.ReadData("Select tEmployee.EmployeeCode, Name, ID, Gender, DOB, Address, PhoneNumber, Status from tEmployee where EmployeeCode=N'" + cbEmployeeCode.SelectedValue +"'");
            dgvListEmployee.DataSource = dtNV;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpList_Click(object sender, EventArgs e)
        {

        }

        private void cbEmployeeCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtNV = data.ReadData("Select Name, Status from tEmployee where EmployeeCode='" + cbEmployeeCode.SelectedValue + "'");
                txtName.Text = dtNV.Rows[0]["Name"].ToString();
                if (dtNV.Rows[0]["Status"].ToString() == "True")
                {
                    cboStatus.Text = "Đang Làm";
                }
                else
                { cboStatus.Text = "Đã Nghỉ"; }
            }
            catch
            {

            }
        }

        private void EmployeeControl_Load(object sender, EventArgs e)
        {
            loadData();
            dgvListEmployee.Columns[0].HeaderText = "Mã NV";
            dgvListEmployee.Columns[1].HeaderText = "Tên NV";
            ResetValue();
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
         
        }
        void loadData()
        {
            DataTable dtNV = data.ReadData("Select EmployeeCode, Name, ID, Gender, DOB, Address, PhoneNumber, Status from tEmployee");
            dgvListEmployee.DataSource = dtNV;
        }
        void ResetValue()
        {
            cbEmployeeCode.Text = "";
            txtName.Text = "";
        }

        private void dgvListEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbEmployeeCode.Text = dgvListEmployee.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvListEmployee.CurrentRow.Cells[1].Value.ToString();
            btnAdd.Enabled = false;
            btnDelete.Enabled = true;   
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
            ResetValue();
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    data.UpdateData("delete tEmployee where EmployeeCode='" +cbEmployeeCode.Text+ "'") ;
                    loadData();
                    ResetValue();
                }
                catch
                {
                   
                }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeInfor.EmployeeAddNew eif = new EmployeeInfor.EmployeeAddNew();
            eif.ShowDialog();
        }
        private void btnInfor_Click(object sender, EventArgs e)
        {
            EmployeeInfor.EmployeeInfor eif = new EmployeeInfor.EmployeeInfor();
            eif.ShowDialog();
        }
    }
}
