using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.model
{
    class DetailBillSell
    {
        private string idBill;
        private string idProductDetail;
        private int quantity;
        private long totalPrice;

        public string IdBill { get => idBill; set => idBill = value; }
        public string IdProductDetail { get => idProductDetail; set => idProductDetail = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public long TotalPrice { get => totalPrice; set => totalPrice = value; }
        public DetailBillSell() { }

        public DetailBillSell(string idBill, string idProductDetail, int quantity)
        {
            this.idBill = idBill;
            this.idProductDetail = idProductDetail;
            this.quantity = quantity;
        }

        public DetailBillSell(string idProductDetail, int quantity)
        {
            this.idProductDetail = idProductDetail;
            this.quantity = quantity;
        }
    }
}
