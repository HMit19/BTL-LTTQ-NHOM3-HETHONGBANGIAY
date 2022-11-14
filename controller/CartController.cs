using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.cart;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.product;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.controller
{
    class CartController
    {
        frmManager main = null;
        CartControl cartControl = null;
        CartDAO cartDAO = null;
        string nameEmployee = null;
        string date = null;
        ProductDAO productDAO = null;

        public CartController(frmManager main, CartDAO cartDAO, CartControl cartControl)
        {
            this.main = main;
            this.cartDAO = cartDAO;
            this.cartControl = cartControl;
            productDAO = new ProductDAO();
            loadCart();
            loadEvent();
        }
        public void loadEvent()
        {
            cartControl.removeAllinCart += removeAllProductOfCart;
        }
        private void loadCart()
        {
            nameEmployee = main.getNameEmployee();
            date = DateTime.Now.ToString("dd/mm/yyyy");
            cartControl.Controls["pnlContainer"].Controls.Clear();
            List<DetailBillSell> detailBillSells = cartDAO.getListDetailBillSells();
            int index = 1;
            foreach (DetailBillSell detailBillSell in detailBillSells)
            {
                DetailProduct detailProduct = productDAO.getDetailProductById(detailBillSell.IdProductDetail);
                Product product = productDAO.getProductById(detailProduct.IdProduct);
                string name = product.Name;
                string image = product.Image;
                string color = detailProduct.Color;
                string size = detailProduct.Size.ToString();
                string price = detailProduct.PriceOut.ToString("#,###");
                string quantity = detailBillSell.Quantity.ToString();
                ItemProductOfCart item = new ItemProductOfCart(index++, detailBillSell.IdProductDetail, image, name, color, size, quantity, price);
                item.deleteItemInCart += removeProductOfCart;
                item.changeQuantity += changeQuantity;
                cartControl.Controls["pnlContainer"].Controls.Add(item);
            }
            loadPayment();
        }
        public void changeQuantity(object o)
        {
            ItemProductOfCart item = (ItemProductOfCart)o;
            // update lai gia tien khi tang so luong
            string idItem = item.getIdItem();
            int quantity = Convert.ToInt32(item.getQuantity());
            foreach (ItemProductOfCart itemProduct in cartControl.Controls["pnlContainer"].Controls)
            {
                if (itemProduct.getIdItem().Equals(idItem))
                {
                    itemProduct.updatePrice();
                    loadPayment();
                    break;
                }
            }
        }
        public void loadPayment()
        {
            double price = 0;
            foreach (ItemProductOfCart item in cartControl.Controls["pnlContainer"].Controls)
            {
                price += Convert.ToDouble(item.getTotalPrice());
            }
            cartControl.Controls["pnlFooter"].Controls["lblSumTotal"].Text = price.ToString("#,###");
            cartControl.Controls["pnlRegister"].Controls["lblSumTotalInOrder"].Text = price.ToString("#,###");
            cartControl.Controls["pnlRegister"].Controls["lblMoneyOrder"].Text = price.ToString("#,###");
        }

        private void removeProductOfCart(object o)
        {
            ItemProductOfCart item = (ItemProductOfCart)o;
            cartDAO.removeItemOfCart(item.getIdBillDetailSell());
            loadCart();
        }
        private void removeAllProductOfCart()
        {
            cartDAO.removeAllInCart();
            loadCart();
        }
    }
}