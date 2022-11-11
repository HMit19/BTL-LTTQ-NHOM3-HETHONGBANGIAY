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
        private string image;
        private string idCategory;
        private List<DetailProduct> detailProduct;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Image { get => image; set => image = value; }
        public string IdCategory { get => idCategory; set => idCategory = value; }
        internal List<DetailProduct> DetailProduct { get => detailProduct; set => detailProduct = value; }

        public Product() { }
        public Product(string id, string name, string image, string idCategory)
        {
            this.id = id;
            this.name = name;
            this.image = image;
            this.idCategory = idCategory;
        }
    }
}