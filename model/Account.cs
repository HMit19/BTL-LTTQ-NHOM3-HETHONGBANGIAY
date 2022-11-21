using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model
{
    class Account
    {
        private string username;
        private string password;
        private int role;
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Role { get => role; set => role = value; }
        public Account()
        {
        }

        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Account(string username, string password, int role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }
    }
}
