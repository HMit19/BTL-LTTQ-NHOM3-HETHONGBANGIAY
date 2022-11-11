using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.model
{
    class DetailProduct
    {
        private string idProductDetail;
        private string idProduct;
        private int size;
        private string color;
        private double priceOut;
        private double priceIn;
        private int quantity;
        private bool status;

        public string IdProductDetail { get => idProductDetail; set => idProductDetail = value; }
        public string IdProduct { get => idProduct; set => idProduct = value; }
        public int Size { get => size; set => size = value; }
        public string Color { get => color; set => color = value; }
        public double PriceOut { get => priceOut; set => priceOut = value; }
        public double PriceIn { get => priceIn; set => priceIn = value; }
        public bool Status { get => status; set => status = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        public DetailProduct() { }
        public DetailProduct(string idProductDetail, string idProduct, int size, string color, double priceIn, double priceOut, int quantity, bool status)
        {
            this.IdProductDetail = idProductDetail;
            this.IdProduct = idProduct;
            this.Size = size;
            this.Color = color;
            this.PriceOut = priceOut;
            this.PriceIn = priceIn;
            this.Quantity = quantity;
            this.Status = status;
        }
    }
}
