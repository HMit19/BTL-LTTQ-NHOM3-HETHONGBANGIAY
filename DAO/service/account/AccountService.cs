using BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service
{
    class AccountService : IAccountService
    {
        private IDatabaseHandle databaseHandle;

        public AccountService()
        {
            databaseHandle = new DatabaseHandle();
        }

        public Account find(string username)
        {
            Account account = null;
            try
            {
                DataTable dataTable = null;
                string sql = "select * from tLogin where username = '" + username + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string usernameColumn = row[0].ToString();
                    string passwordColumn = row[1].ToString();
                    int role = Convert.ToInt32(row[2]);
                    int status = Convert.ToInt32(row[3]);
                    account = new Account(usernameColumn, passwordColumn, role, status);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get account by Username");
                databaseHandle.CloseConnect();
            }
            return account;
        }

        public List<Account> findAll()
        {
            List<Account> listAccount = null;
            try
            {
                listAccount = new List<Account>();
                DataTable dataTable = null;
                string sql = "select * from tLogin";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string usernameColumn = row[0].ToString();
                    string passwordColumn = row[1].ToString();
                    int role = Convert.ToInt32(row[2]);
                    int status = Convert.ToInt32(row[3]);
                    listAccount.Add(new Account(usernameColumn, passwordColumn, role, status));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get list account");
                databaseHandle.CloseConnect();
            }
            return listAccount;
        }

        public bool remove(string username)
        {
            bool excute = false;
            try
            {
                string sql = "delete table form tLogin where username = '" + username + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error remove account by Username");
                databaseHandle.CloseConnect();
            }
            return excute;
        }

        public bool save(Account account)
        {
            bool excute = false;
            try
            {
                string sql = "insert into tLogin values ('" + account.Username + "', '" + account.Password + "'," + account.Role + "," + account.Status + ")";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error insert account by Username");
                databaseHandle.CloseConnect();
            }
            return excute;
        }

        public bool update(string username, Account account)
        {
            bool excute = false;
            try
            {
                string sql = "update tLogin set username = '" + account.Username + "', password = '" + account.Password + "', role = " + account.Role + ", status = " + account.Status;
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error update account by Username");
                databaseHandle.CloseConnect();
            }
            return excute;
        }
    }
}
