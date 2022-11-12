using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.controller
{
    class LoginController
    {
        private frmLogin loginView;
        private IAccountService accountService = null;
        private List<Account> accounts = null;
        public LoginController(frmLogin loginView)
        {
            this.loginView = loginView;
            accountService = new AccountService();
            loginView.login += loginUser;
            Application.Run(loginView);
        }

        private void loginUser()
        {
            accounts = accountService.findAll();
            Account account = (Account)(loginView.getInfomation());

            if (account.Username == "" || account.Password == "")
            {
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginView.Controls["txtAccount"].Focus();
                    loginView.clearInformation();
                    return;
                }
            }

            if (account.Username != "" || account.Password != "")
            {
                foreach (Account item in accounts)
                {
                    if (account.Username.Equals(item.Username) && account.Password.Equals(item.Password))
                    {
                        frmManager main = new frmManager();
                        loginView.Visible = false;
                        MessageBox.Show("Đăng nhập thành công!", "Đăng nhập thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        main.ShowDialog();
                        return;
                    }
                }
            }
            MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            loginView.clearInformation();
        }
    }
}
