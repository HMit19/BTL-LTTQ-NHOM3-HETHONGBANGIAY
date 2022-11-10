using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.model
{
    class SellBillDetail
    {
        private string id;
        private string idBill;
        private string idProductDetail;
        private int quantity;
        private long totalPrice;

        public string Id { get => id; set => id = value; }
        public string IdBill { get => idBill; set => idBill = value; }
        public string IdProductDetail { get => idProductDetail; set => idProductDetail = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public long TotalPrice { get => totalPrice; set => totalPrice = value; }
        public SellBillDetail() { }

        public SellBillDetail(string id, string idBill, string idProductDetail, int quantity)
        {
            this.id = id;
            this.idBill = idBill;
            this.idProductDetail = idProductDetail;
            this.quantity = quantity;
        }

        public SellBillDetail(string id, string idProductDetail, int quantity)
        {
            this.id = id;
            this.idProductDetail = idProductDetail;
            this.quantity = quantity;
        }
    }
}
