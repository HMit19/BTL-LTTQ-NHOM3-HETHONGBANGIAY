using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.employee;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.controller
{
    class LoginController
    {
        private frmLogin loginView;
        private IAccountService accountService = null;
        private IEmployeeService employeeService = null;
        private List<Account> accounts = null;
        public LoginController(frmLogin loginView)
        {
            this.loginView = loginView;
            accountService = new AccountService();
            employeeService = new EmployeeService();
            loginView.login += loginUser;
            Application.Run(loginView);
        }

        private void loginUser()
        {
            accounts = accountService.findAll();
            Account account = (Account)(loginView.getInfomation());
            if (!validate(account)) return;
            foreach (Account item in accounts)
            {
                string pass = GetMD5(account.Password).Substring(0, 15);
                if (account.Username.Equals(item.Username) && pass.Equals(item.Password))
                {
                    Employee employee = employeeService.findByUsername(item.Username);
                    frmManager main = new frmManager(employee, item.Role, loginView);
                    loginView.Visible = false;
                    main.ShowDialog();
                    loginView.clearInformation();
                    return;
                }
            }
            MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            loginView.clearInformation();
        }
        public bool validate(Account account)
        {
            if (account.Username == "" || account.Password == "")
            {
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loginView.clearInformation();
                    loginView.Controls["txtAccount"].Focus();
                    return false;
                }
            }
            if (account.Password.Length < 6 || account.Password.Length > 15)
            {
                MessageBox.Show("Tên đăng nhập phải từ 6 đến 15 ký tự!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                loginView.clearInformation();
                loginView.Controls["txtAccount"].Focus();
                return false;
            }
            return true;
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
    }
}
