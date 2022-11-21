using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.bill;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.item;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.cart
{
    class CartDAO
    {
        public static List<DetailBillSell> detailBillSells = null;
        private IBillSellService billSellService = null;
        private IBillDetailService billDetailService = null;
        public CartDAO()
        {
            detailBillSells = new List<DetailBillSell>();
            billSellService = new BillSellService();
            billDetailService = new BillDetailService();
        }
        public void addProductToCart(string idDetailProduct, int quantity)
        {
            bool isExist = false;
            foreach (DetailBillSell detailBillSell in detailBillSells)
            {
                if (detailBillSell.IdProductDetail.Equals(idDetailProduct))
                {
                    detailBillSell.Quantity += quantity;
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                detailBillSells.Add(new DetailBillSell(idDetailProduct, quantity));
            }
        }
        public List<DetailBillSell> getListDetailBillSells()
        {
            return detailBillSells;
        }
        public void removeItemOfCart(string idDetailBillSell)
        {
            foreach (DetailBillSell detailBillSell in detailBillSells)
            {
                if (detailBillSell.IdProductDetail.Equals(idDetailBillSell))
                {
                    detailBillSells.Remove(detailBillSell);
                    break;
                }
            }
        }
        public void setListDetailBill(List<DetailBillSell> listDetailBillSell)
        {
            detailBillSells = listDetailBillSell;
        }
        public void saveDetailBill(string idBill)
        {
            foreach(DetailBillSell detailBillSell in detailBillSells)
            {
                detailBillSell.IdBill = idBill;
                billDetailService.save(detailBillSell);   
            }
            //detailBillSells.Clear();
        }
        public void removeAllInCart()
        {
            detailBillSells.Clear();
        }
        public bool saveBill(BillSell billSell)
        {
            return billSellService.save(billSell);
        }
    }
}