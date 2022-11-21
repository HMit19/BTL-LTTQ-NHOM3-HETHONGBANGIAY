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
        private string gender;
        private DateTime birth;
        private string address;
        private string phone;
        private long point;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Gender { get => gender; set => gender = value; }
        public long Point { get => point; set => point = value; }
        public string Address { get => address; set => address = value; }
        public DateTime Birth { get => birth; set => birth = value; }

        public Customer(string id, string name, string gender, DateTime birth, string address, string phone, long point)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.Birth = birth;
            this.address = address;
            this.phone = phone;
            this.point = point;
        }
    }
}
