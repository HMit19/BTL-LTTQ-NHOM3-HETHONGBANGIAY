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

        public Account()
        {
        }

        public Account(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        // set passoword
        public void setPassword(string password)
        {
            this.password = password;
        }

        public string getUsername()
        {
            return this.username;
        }
        public string getPassword()
        {
            return this.password;
        }
    }
}
