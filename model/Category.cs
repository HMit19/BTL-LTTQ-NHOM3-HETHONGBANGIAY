using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.model
{
    class Category
    {
        private string id;
        private string name;
        private string origin;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Origin { get => origin; set => origin = value; }

        public Category() { }

        public Category(string id, string name, string origin)
        {
            this.id = id;
            this.name = name;
            this.origin = origin;
        }
    }
}
