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
        private int status;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Role { get => role; set => role = value; }
        public int Status { get => status; set => status = value; }

        public Account()
        {
        }

        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public Account(string username, string password, int role, int status) : this(username, password)
        {
            this.Role = role;
            this.Status = status;
        }
    }
}
