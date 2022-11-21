﻿using System;
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
        private string payMethod;
        private string idEmployee;
        private string idCustomer;
        private int discount;
        public string Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string PayMethod { get => payMethod; set => payMethod = value; }
        public string IdEmployee { get => idEmployee; set => idEmployee = value; }
        public string IdCustomer { get => idCustomer; set => idCustomer = value; }
        public int Discount { get => discount; set => discount = value; }

        public BillSell(string id, DateTime date, string payMethod, string idEmployee, string idCustomer, int discount)
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