using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.model
{
    class Customer
    {
        private string id;
        private string name;
        private string phone;
        private string gender;
        private long point;
        private string address;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Gender { get => gender; set => gender = value; }
        public long Point { get => point; set => point = value; }
        public string Address { get => address; set => address = value; }

        public Customer() { }

        public Customer(string id, string name, string gender, string address, string phone, long point)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Gender = gender;
            this.Point = point;
            this.Address = address;
        }

        public Customer(string id, string name, string phone, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Address = address;
        }
    }
}
