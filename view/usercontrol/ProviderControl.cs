using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol
{
    public partial class ProviderControl : UserControl
    {
        Classes.CommonFunctions functions = new Classes.CommonFunctions();
        Classes.ConnectData data = new Classes.ConnectData();
        public ProviderControl()
        {
            InitializeComponent();
            DataTable dtNCC = data.ReadData("Select * from tProvider");

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProviderCode.Text != "")
                {
                    DataTable dtNCC = data.ReadData("Select * from tProvider where ProviderCode='" + txtProviderCode.Text + "'");
                    txtName.Text = dtNCC.Rows[0]["Name"].ToString();
                    txtAddress.Text = dtNCC.Rows[0]["Address"].ToString();
                    dgvListProvider.DataSource = dtNCC;
                }
                else if (txtName.Text != "" && txtProviderCode.Text == "")
                {
                    DataTable dtNCC = data.ReadData("Select * from tProvider where Name='" + txtName.Text + "'");
                    txtProviderCode.Text = dtNCC.Rows[0]["ProviderCode"].ToString();
                    txtAddress.Text = dtNCC.Rows[0]["Address"].ToString();
                    dgvListProvider.DataSource = dtNCC;
                }

            }
            catch
            {
                MessageBox.Show("Khong co NCC ban can tim");
            }




        }
        void loadData()
        {
            DataTable dtNCC = data.ReadData("Select * from tProvider");
            dgvListProvider.DataSource = dtNCC;
        }
        void ResetValue()
        {
            txtProviderCode.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
        }
        private void ProviderControl_Load(object sender, EventArgs e)
        {
            loadData();
            ResetValue();
            btnRepair.Enabled = false;

        }

        private void dgvListProvider_Click(object sender, EventArgs e)
        {

        }

        private void txtProviderCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
            ResetValue();
            btnRepair.Enabled = false;
        }

        private void dgvListProvider_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProviderCode.Text = dgvListProvider.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvListProvider.CurrentRow.Cells[1].Value.ToString();
            txtAddress.Text = dgvListProvider.CurrentRow.Cells[2].Value.ToString();
            btnRepair.Enabled = true;

        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn cập nhập không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.UpdateData("update tProvider set Name=N'" + txtName.Text + "', Address=N'" + txtAddress.Text + "' where ProviderCode='" + txtProviderCode.Text + "' ");
                loadData();
                MessageBox.Show("cập nhập thanh cong");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    data.UpdateData("delete tProvider where ProviderCode='" + txtProviderCode.Text + "'");
                    loadData();
                    ResetValue();
                }
                catch
                {
                    MessageBox.Show("Khong the xoa dc");
                }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (txtProviderCode.Text.Trim() == "")
            {
                errChiTiet.SetError(txtProviderCode, "Bạn không được để trống!");
                txtProviderCode.Focus();
                return;
            }
            else errChiTiet.Clear();
            if (txtName.Text.Trim() == "")
            {
                errChiTiet.SetError(txtName, "Bạn không được để trống!");
                txtName.Focus();
                return;
            }
            else errChiTiet.Clear();
            if (txtAddress.Text.Trim() == "")
            {
                errChiTiet.SetError(txtAddress, "Bạn không được để trống!");
                txtAddress.Focus();
                return;
            }
            else
            {
                string sqlselect = "Select * from tProvider where ProviderCode = '" + txtProviderCode.Text + "'";
                DataTable dtNCC = data.ReadData(sqlselect);
                if (dtNCC.Rows.Count > 0)
                {
                    errChiTiet.SetError(txtProviderCode, "Mã NV trùng trong cơ sở dữ liệu");
                    return;
                }
                errChiTiet.Clear();
            }
            string sql = "INSERT INTO tProvider (ProviderCode, Name, Address) VALUES ('" + txtProviderCode.Text + "','" + txtName.Text + "','"+txtAddress.Text+"')";
            data.UpdateData(sql);
            MessageBox.Show("Thêm mới thành công");
            loadData();
            ResetValue();
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
            exSheet.get_Range("B4:D4").Merge(true);
            header.Font.Size = 14;
            header.Font.Bold = true;
            header.Font.Color = System.Drawing.Color.Red;
            header.Value = "DANH SÁCH NHÀ CUNG CẤP";
            exSheet.get_Range("B4:D4").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


            exSheet.get_Range("B6:D6").Font.Bold = true;
            exSheet.get_Range("B6:D6").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exSheet.get_Range("B6").ColumnWidth = 17;
            exSheet.get_Range("C6").ColumnWidth = 30;
            exSheet.get_Range("D6").ColumnWidth = 15;
            
            exSheet.get_Range("B6").Value = "Mã Nhà Cung Cấp";
            exSheet.get_Range("C6").Value = "Tên Nhà Cung Cấp";
            exSheet.get_Range("D6").Value = "Địa Chỉ ";
            

            DataTable dataEx = data.ReadData("select * from  tProvider ");
            for (int i = 0; i < dataEx.Rows.Count; i++)
            {
                exSheet.get_Range("B" + (i + 7).ToString() + ":D" + (i + 7).ToString()).Font.Bold = false;
                exSheet.get_Range("B" + (i + 7).ToString()).Value = dataEx.Rows[i][0].ToString();
                exSheet.get_Range("C" + (i + 7).ToString()).Value = dataEx.Rows[i][1].ToString();
                exSheet.get_Range("D" + (i + 7).ToString()).Value = dataEx.Rows[i][2].ToString();
                
            }
            exSheet.Name = "Danh Sách Nhà Cung Cấp";
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
