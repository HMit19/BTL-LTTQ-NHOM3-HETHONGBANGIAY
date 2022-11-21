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
                string sql = "select * from tLogin where Username = '" + username + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string password = row[1].ToString();
                    int role = Convert.ToInt32(row[2]);
                    account = new Account(username, password, role);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get Account by Username");
                databaseHandle.closeConnect();
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
                    string username = row[0].ToString();
                    string password = row[1].ToString();
                    int role = Convert.ToInt32(row[2]);
                    listAccount.Add(new Account(username, password, role));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get list Account");
                databaseHandle.closeConnect();
            }
            return listAccount;
        }

        public bool remove(string username)
        {
            bool excute = false;
            try
            {
                string sql = "delete from tLogin where username = '" + username + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error remove Account by Username");
                databaseHandle.closeConnect();
            }
            return excute;
        }

        public bool save(Account account)
        {
            bool excute = false;
            try
            {
                string sql = "insert into tLogin values ('" + account.Username + "', '" + account.Password + "'," + account.Role + ")";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error insert Account");
                databaseHandle.closeConnect();
            }
            return excute;
        }

        public bool update(string username, Account account)
        {
            bool excute = false;
            try
            {
                string sql = "update tLogin set password = '" + account.Password + "', role = " + account.Role + ", status = " + " where username = '" + account.Username + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error update Account by Username");
                databaseHandle.closeConnect();
            }
            return excute;
        }
    }
}
