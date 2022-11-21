using BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
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
    public delegate void Login();
    public partial class frmLogin : Form
    {
        public event Login login;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login?.Invoke();
        }
        internal Object getInfomation()
        {
            Account account = new Account(txtAccount.Text, txtPassword.Text);
            return account;
        }

        internal void clearInformation()
        {
            txtAccount.Focus();
            txtAccount.Text = "";
            txtPassword.Text = "";
        }

        private void btnInformationGroup_Click(object sender, EventArgs e)
        {
            IntroduceForm introduce = new IntroduceForm();
            introduce.ShowDialog();
        }
    }
}
