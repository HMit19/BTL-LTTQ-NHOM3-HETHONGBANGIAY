using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.product;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.category;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.detailProduct;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.product;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.controller
{
    internal class StoreController
    {
        StoreControl storeControl = null;
        ProductDAO productDAO = null;
        public StoreController(StoreControl storeControl)
        {
            this.storeControl = storeControl;
            productDAO = new ProductDAO();
            loadForm();
            showListProduct();
            addEventHandle();
        }
        private void addEventHandle()
        {
            storeControl.sortProduct += sortProduct;
            storeControl.searchProduct += searchProduct;
            storeControl.showListProduct += showListProduct;
            storeControl.selectCategoryProduct += showProductOfCategory;
        }

        private void showProductOfCategory()
        {
            string name = storeControl.Controls["pnlOptionSidebar"].Controls["cbCategory"].Text;
            if (name.Equals("Tất cả"))
            {
                productDAO.setListProducts(productDAO.getListProductsDefault());
                sortProduct();
            }
            else
            {
                productDAO.productOfCategory(name);
                sortProduct();
            }
        }

        private void showListProduct()
        {
            productDAO.setListProducts(productDAO.getListProductsDefault());
            sortProduct();
        }
        private void sortProduct()
        {
            string option = storeControl.Controls["pnlOptionHeader"].Controls["cbSortProduct"].Text;
            switch (option)
            {
                case "Giá tăng dần":
                    productDAO.sortProductByPrice(true);
                    loadListProduct();
                    break;
                case "Giá giảm dần":
                    productDAO.sortProductByPrice();
                    loadListProduct();
                    break;
                case "Số lượng":
                    productDAO.sortProductByQuantity();
                    loadListProduct();
                    break;
                case "Sản phẩm bán chạy":
                    loadListProduct();
                    break;
            }
        }

        private void searchProduct()
        {
            string search = storeControl.getSearch();
            if (productDAO.searchByName(search))
            {
                MessageBox.Show("Không tìm thấy sản phẩm!");
            }
            else
            {
                loadListProduct();
                sortProduct();
            }
        }
        private void loadForm()
        {
            long quantityProduct = productDAO.getListProducts().Count;
            List<string> categoryName = productDAO.getNameCategory();
            storeControl.Controls["pnlOptionHeader"].Controls["lblQuantityProduct"].Text = quantityProduct.ToString();
            storeControl.loadCategory(categoryName);
        }
        private void loadListProduct(List<Product> products = null)
        {
            if (products == null) products = productDAO.getListProducts();
            storeControl.Controls["pnlContainProduct"].Controls.Clear();
            foreach (Product product in products)
            {
                string name = product.Name;
                string price;
                if (productDAO.getMinPrice(product.DetailProduct) != productDAO.getMaxPrice(product.DetailProduct))
                {
                    price = productDAO.getMinPrice(product.DetailProduct).ToString("#,###") + " - " + productDAO.getMaxPrice(product.DetailProduct).ToString("#,###");

                }
                else
                {
                    price = productDAO.getMinPrice(product.DetailProduct).ToString("#,###");
                }
                string quantity = productDAO.getQuantityProduct(product.DetailProduct).ToString();
                storeControl.Controls["pnlContainProduct"].Controls.Add(new ItemProduct("", name, price, quantity));
            }
        }
    }
}
