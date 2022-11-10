using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.model
{
    class BillSell
    {
        private string id;
        private DateTime date;
        private int payMethod;
        private string idEmployee;
        private string idCustomer;
        private int discount;
        private long totalPrice;

        public string Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int PayMethod { get => payMethod; set => payMethod = value; }
        public string IdEmployee { get => idEmployee; set => idEmployee = value; }
        public string IdCustomer { get => idCustomer; set => idCustomer = value; }
        public int Discount { get => discount; set => discount = value; }
        public long TotalPrice { get => totalPrice; set => totalPrice = value; }

        public BillSell(string id, DateTime date, int payMethod, string idEmployee, string idCustomer, int discount)
        {
            this.id = id;
            this.date = date;
            this.payMethod = payMethod;
            this.idEmployee = idEmployee;
            this.idCustomer = idCustomer;
            this.discount = discount;
        }
    }
}
