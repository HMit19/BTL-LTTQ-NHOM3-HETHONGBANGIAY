using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.model
{
    class Product
    {
        private string id;
        private string name;
        private int image;
        private int idCategory;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Image { get => image; set => image = value; }
        public int IdCategory { get => idCategory; set => idCategory = value; }

        public Product() { }
        public Product(string id, string name, int image, int idCategory)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.idCategory = idCategory;
        }
    }
}