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
    }
}
