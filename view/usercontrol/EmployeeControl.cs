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
using Excel = Microsoft.Office.Interop.Excel;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol
{
    public partial class EmployeeControl : UserControl
    {
        Classes.CommonFunctions functions = new Classes.CommonFunctions();
        Classes.ConnectData data = new Classes.ConnectData();
        public EmployeeControl()
        {
            InitializeComponent();
              
        }

      

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (txtEmployeeCode.Text != "")
                {
                    DataTable dtNV = data.ReadData("Select EmployeeCode, Name, ID, Gender, DOB, Address, PhoneNumber, Status from tEmployee where EmployeeCode like  N'%" + txtEmployeeCode.Text + "%'");
                    dgvListEmployee.DataSource = dtNV;
                }
                else if (txtName.Text != "" && txtEmployeeCode.Text == "")
                {
                    DataTable dtNV = data.ReadData("Select EmployeeCode, Name, ID, Gender, DOB, Address, PhoneNumber, Status from tEmployee where Name like N'%" + txtName.Text + "%'");
                    dgvListEmployee.DataSource = dtNV;
                }
                

            }
            catch
            {
                MessageBox.Show("Khong co NV ban can tim!");
            }

        }


        private void EmployeeControl_Load(object sender, EventArgs e)
        {
            loadData();
            ResetValue();
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
         
        }
        void loadData()
        {
            DataTable dtNV = data.ReadData("Select EmployeeCode, Name, ID, Gender, DOB, Address, PhoneNumber, Status from tEmployee");
            dgvListEmployee.DataSource = dtNV;
            dgvListEmployee.Columns[0].HeaderText = "Mã NV";
            dgvListEmployee.Columns[1].HeaderText = "Tên NV";
            dgvListEmployee.Columns[2].HeaderText = "CCCD/CMND";
            dgvListEmployee.Columns[3].HeaderText = "Giới Tính";
            dgvListEmployee.Columns[4].HeaderText = "Ngày Sinh";
            dgvListEmployee.Columns[5].HeaderText = "Địa Chỉ";
            dgvListEmployee.Columns[6].HeaderText = "SĐT";
            dgvListEmployee.Columns[7].HeaderText = "Trạng Thái";
        }
        void ResetValue()
        {
            txtEmployeeCode.Text = "";
            txtName.Text = "";
            txtEmployeeCode.Enabled = true;
            txtName.Enabled = true;
        }

        private void dgvListEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmployeeCode.Text = dgvListEmployee.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvListEmployee.CurrentRow.Cells[1].Value.ToString();
            if (dgvListEmployee.CurrentRow.Cells[7].Value.ToString() == "True")
            {
                cboStatus.Text = "Đang Làm";
            }
            else
            { cboStatus.Text = "Đã Nghỉ"; }
           
            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            
            loadData();
            ResetValue();
            EmployeeControl_Load(sender, e);
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    data.UpdateData("delete tEmployee where EmployeeCode='" +txtEmployeeCode.Text+ "'");
                    data.UpdateData("delete tLogin where UserName='"+txtName.Text+"'");

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
            exSheet.get_Range("B4:I4").Merge(true);
            header.Font.Size = 14;
            header.Font.Bold = true;
            header.Font.Color = System.Drawing.Color.Red;
            header.Value = "DANH SÁCH NHÂN VIÊN";
            exSheet.get_Range("B4:I4").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            exSheet.get_Range("B6:I6").Font.Bold = true;
            exSheet.get_Range("B6:I6").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exSheet.get_Range("B6").ColumnWidth = 17;
            exSheet.get_Range("C6").ColumnWidth = 20;
            exSheet.get_Range("D6").ColumnWidth = 7;
            exSheet.get_Range("E6:H6").ColumnWidth = 15;
            exSheet.get_Range("I6").ColumnWidth = 10;
            exSheet.get_Range("B6").Value = "Mã Nhân Viên";
            exSheet.get_Range("C6").Value = "Tên Nhân Viên";
            exSheet.get_Range("D6").Value = "Giới Tính ";
            exSheet.get_Range("E6").Value = "Ngày Sinh";
            exSheet.get_Range("F6").Value = "Địa Chỉ";
            exSheet.get_Range("G6").Value = "CCCD/CMND";
            exSheet.get_Range("H6").Value = "Số Điện Thoại";
            exSheet.get_Range("I6").Value = "Tình Trạng";

            DataTable dataEx = data.ReadData("select EmployeeCode, Name, Gender, DOB, Address, ID, PhoneNumber, Status from tEmployee ");
            for(int i = 0; i < dataEx.Rows.Count; i++)
            {
                exSheet.get_Range("B" + (i + 7).ToString() + ":H" + (i + 7).ToString()).Font.Bold = false;
                exSheet.get_Range("B" + (i + 7).ToString()).Value = dataEx.Rows[i][0].ToString();
                exSheet.get_Range("C" + (i + 7).ToString()).Value = dataEx.Rows[i][1].ToString();
                exSheet.get_Range("D" + (i + 7).ToString()).Value = dataEx.Rows[i][2].ToString();
                exSheet.get_Range("E" + (i + 7).ToString()).Value = dataEx.Rows[i][3].ToString();
                exSheet.get_Range("F" + (i + 7).ToString()).Value = dataEx.Rows[i][4].ToString();
                exSheet.get_Range("G" + (i + 7).ToString()).Value = dataEx.Rows[i][5].ToString();
                exSheet.get_Range("H" + (i + 7).ToString()).Value = "'" +dataEx.Rows[i][6].ToString();
                if (dataEx.Rows[i][7].ToString() == "True")
                {
                    exSheet.get_Range("I" + (i + 7).ToString()).Value = "Đang Làm";
                }
                else
                {
                    exSheet.get_Range("I" + (i + 7).ToString()).Value = "Đã Nghỉ";
                }
            }
            exSheet.Name = "Danh Sách Nhân Viên";
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
    }
}
