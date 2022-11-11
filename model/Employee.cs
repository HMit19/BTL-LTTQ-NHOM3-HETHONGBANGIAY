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
        private string cIC;
        private string gender;
        private DateTime birth;
        private string address;
        private string phone;
        private string username;
        private bool status;

        public Employee()
        {
        }

        public Employee(string id, string name, string cIC, string gender, DateTime birth, string address, string phone, string username, bool status)
        {
            this.Id = id;
            this.Name = name;
            this.cIC = cIC;
            this.Gender = gender;
            this.Birth = birth;
            this.Address = address;
            this.Phone = phone;
            this.Username = username;
            this.Status = status;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string CIC { get => cIC; set => CIC = value; }
        public string Gender { get => gender; set => gender = value; }
        public DateTime Birth { get => birth; set => birth = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Username { get => username; set => username = value; }
        public bool Status { get => status; set => status = value; }
    }
}
