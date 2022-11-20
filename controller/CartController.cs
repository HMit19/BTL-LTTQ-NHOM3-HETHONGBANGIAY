using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.cart;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.customer;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.product;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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
        CustomerDAO customerDAO = null;

        public CartController(frmManager main, CartDAO cartDAO, CartControl cartControl)
        {
            this.main = main;
            this.cartDAO = cartDAO;
            this.cartControl = cartControl;
            productDAO = new ProductDAO();
            customerDAO = new CustomerDAO();
            loadCart();
            loadEvent();
        }
        public void loadEvent()
        {
            cartControl.removeAllinCart += removeAllProductOfCart;
            cartControl.findCustomer += findAndLoadCustomer;
            cartControl.inputPoint += inputPointForCustomer;
            cartControl.returnMoney += returnMoney;
            cartControl.payUp += checkPayUp;
        }

        public void checkPayUp()
        {
            if (cartControl.getMoney() == "")
            {
                cartControl.Controls["pnlInformationPay"].Controls["pnlPay"].Controls["txtCustomerPayUp"].Focus();
                MessageBox.Show("Nhập số tiền khách thanh toán", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (cartControl.Controls["methodPay"].Text == "")
            {
                MessageBox.Show("Chọn phương thức thanh toán!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (MessageBox.Show("Xác nhận thanh toán!", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                List<DetailBillSell> detailBillSells = new List<DetailBillSell>();
                foreach (ItemProductOfCart itemProductOfCart in cartControl.Controls["pnlContainer"].Controls)
                {
                    string idProductDetail = itemProductOfCart.getIdBillDetailSell();
                    int quantity = Convert.ToInt32(itemProductOfCart.getQuantity());
                    detailBillSells.Add(new DetailBillSell(idProductDetail, quantity));
                }
                DateTime date = DateTime.Now;
                string methodPay = cartControl.Controls["methodPay"].Text;
                string idEmployee = main.getEmployee().Id;
                string idCustomer = cartControl.Controls["pnlInformationPay"].Controls["pnlCustomer"].Controls["lblIdCustomer"].Text;
                int discount = cartControl.getPoint();
                string idBill = GetMD5(date.ToString() + idCustomer + idEmployee);
                idBill = idBill.Substring(0, 15);
                BillSell billSell = new BillSell(idBill, date, methodPay, idEmployee, idCustomer, discount);
                if (cartDAO.saveBill(billSell))
                    MessageBox.Show("Thanh toán thành công");
                cartDAO.setListDetailBill(detailBillSells);
                cartDAO.saveDetailBill(idBill);
            }
        }

        private void returnMoney(object o)
        {
            if (o.ToString() == "") return;
            long totalPay = Convert.ToInt64(cartControl.Controls["pnlInformationPay"].Controls["pnlPay"].Controls["lblMoneyOrder"].Text.Replace(",", ""));
            long moneyInput = Convert.ToInt32(o);
            if (moneyInput < totalPay || moneyInput < 0)
            {
                MessageBox.Show("Số tiền chưa đủ để thanh toán", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                cartControl.resetMoney();
                cartControl.Controls["pnlInformationPay"].Controls["pnlPay"].Controls["txtCustomerPayUp"].Focus();
                return;
            }
            cartControl.setMoneyReturn(moneyInput - totalPay);
        }

        private void inputPointForCustomer(object o)
        {
            if (o.ToString() == "") return;
            int pointInput = Convert.ToInt32(o);
            int pointCustomer = Convert.ToInt32(cartControl.Controls["pnlInformationPay"].Controls["pnlPay"].Controls["lblScoreOfCustomer"].Text);
            if ((pointInput > 0 && pointInput > pointCustomer) || pointInput < 0)
            {
                MessageBox.Show("Điểm nhập không hợp lệ!");
                cartControl.resetPoint();
                cartControl.Controls["pnlInformationPay"].Controls["pnlPay"].Controls["txtPoint"].Focus();
                return;
            }
            int discount = pointInput * 1000;
            if (discount != 0)
            {
                cartControl.Controls["pnlInformationPay"].Controls["pnlPay"].Controls["lblDetailDiscount"].Text = "- " + discount.ToString("#,###");
                string discountText = cartControl.Controls["pnlInformationPay"].Controls["pnlPay"].Controls["lblSumTotalInOrder"].Text.Replace("- ", "");
                long sumTotal = Convert.ToInt64(discountText.Replace(",", ""));
                sumTotal -= discount;
                cartControl.Controls["pnlInformationPay"].Controls["pnlPay"].Controls["lblMoneyOrder"].Text = sumTotal.ToString("#,###");
            }
        }
        private void findAndLoadCustomer(object o)
        {
            string phone = o.ToString();
            Customer customer = customerDAO.getCustomerByPhone(phone);
            if (customer == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng!");
            }
            else
            {
                cartControl.setInformation(customer.Id, customer.Name, customer.Phone, customer.Gender.Equals("Nam"),
                    customer.Birth, customer.Address, customer.Point.ToString());
            }
        }
        private void loadCart()
        {

            nameEmployee = main.getEmployee().Name;
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
        private void changeQuantity(object o)
        {
            ItemProductOfCart item = (ItemProductOfCart)o;
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
        private void loadPayment()
        {
            double price = 0;
            foreach (ItemProductOfCart item in cartControl.Controls["pnlContainer"].Controls)
            {
                price += Convert.ToDouble(item.getTotalPrice());
            }
            cartControl.Controls["pnlFooter"].Controls["lblSumTotal"].Text = price.ToString("#,###");
            cartControl.Controls["pnlInformationPay"].Controls["pnlPay"].Controls["lblSumTotalInOrder"].Text = price.ToString("#,###");
            cartControl.Controls["pnlInformationPay"].Controls["pnlPay"].Controls["lblMoneyOrder"].Text = price.ToString("#,###");
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
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");
            }
            return byte2String;
        }
    }
}