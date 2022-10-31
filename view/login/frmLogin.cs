using BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit?", "Exit login", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                MessageBox.Show("Login");
                // check login

            }
            else
            {
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validate()
        {
            if (txtUsername.Text == "")
            {
                erLogin.SetError(this.txtUsername, "Please enter your username!");
            }
            if (txtPassword.Text == "")
            {
                erLogin.SetError(this.txtPassword, "Please enter your Password!");
            }
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                return true;
            }
            return false;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                erLogin.SetError(this.txtUsername, "");
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            erLogin.SetError(this.txtPassword, "");
        }
    }
}
