using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.model
{
    class Employee
    {
        private string id;
        private string name;
        private int gender;
        private string address;
        private string phone;
        private string username;
        private int status;
        private string CCCD;
        private DateTime birth;

        public Employee()
        {
        }

        public Employee(string id, string name, string username)
        {
            this.id = id;
            this.name = name;
            this.username = username;
        }

        public Employee(string id, string name, int gender, string address, string phone, string username, int status, string CCCD, DateTime birth)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.address = address;
            this.phone = phone;
            this.username = username;
            this.status = status;
            this.CCCD = CCCD;
            this.birth = birth;
        }
    }
}
