using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.cart;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.product;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.controller
{
    internal class StoreController
    {
        frmManager main = null;
        StoreControl storeControl = null;
        ProductDAO productDAO = null;
        CartDAO cartDAO = null;
        ItemProduct itemProduct = null;
        CartControl cartControl = null;
        public StoreController(frmManager main, StoreControl storeControl, CartControl cartControl)
        {
            this.main = main;
            this.storeControl = storeControl;
            this.cartControl = cartControl;
            productDAO = new ProductDAO();
            cartDAO = new CartDAO();
            itemProduct = new ItemProduct();
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
            storeControl.addProductToCart += addDetailProductSellToCart;
            storeControl.showCart += showCart;
        }
        public void EventSelectItemProduct()
        {
            foreach (ItemProduct item in storeControl.Controls["pnlContainProduct"].Controls)
            {
                item.selectProduct += selectItemProduct;
            }
        }

        private void showCart()
        {
            if (cartDAO.getListDetailBillSells().Count == 0)
            {
                MessageBox.Show("Giỏ hàng trống");
                return;
            }
            else
            {
                new CartController(main, cartDAO, cartControl);
                main.showCart();
            }
        }

        private void addDetailProductSellToCart()
        {
            string idProduct = itemProduct.getIdProduct();
            string color = storeControl.Controls["selectColor"].Text;
            string size = storeControl.Controls["selectSize"].Text;
            int quantity = int.Parse(storeControl.getQuantity());
            try
            {
                if (size == "" || color == "" || size == "") throw new Exception();
                string idDetailProduct = productDAO.getIdDetailProduct(idProduct, color, size);
                if (idDetailProduct == null) throw new Exception();
                cartDAO.addProductToCart(idDetailProduct, quantity);
                MessageBox.Show("Thêm vào giỏ hàng thành công");
                resetOption();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm sản phẩm thất bại!");
            }
        }

        public void resetOption()
        {
            setOption("", "", 1);
            storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionColor"].Controls.Clear();
            storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionSize"].Controls.Clear();
            storeControl.Controls["pnlOptionDetail"].Visible = false;
            storeControl.Controls["pnlCurrent"].Visible = false;
        }

        private void selectItemProduct(object item)
        {
            setOption("", "", 1);
            itemProduct = (ItemProduct)item;
            setProductCurrent();
            storeControl.Controls["pnlOptionDetail"].Visible = true;
            loadDetailOption(itemProduct.ColorItem, itemProduct.SizeItem);
            storeControl.Controls["pnlOptionDetail"].Controls["pnlConfirm"].Controls["lblAvaiable"].Text =
               productDAO.getQuantityProduct(productDAO.getProductById(itemProduct.getIdProduct()).DetailProduct) + " sản phẩm có sẵn";
        }

        public void setProductCurrent()
        {
            storeControl.Controls["pnlCurrent"].Controls["nameCurrent"].Text = itemProduct.getNameProduct();
            storeControl.Controls["pnlCurrent"].Controls["priceCurrent"].Text = itemProduct.getPriceProduct();
            storeControl.setImageCurrent(itemProduct.getImageProduct());
            storeControl.Controls["pnlCurrent"].Visible = true;
        }


        private void setOption(string color, string size, int unit)
        {
            storeControl.resetUnit();
            storeControl.Controls["selectColor"].Text = color;
            storeControl.Controls["selectSize"].Text = size;
            storeControl.Controls["selectUnit"].Text = unit.ToString();
        }

        private void loadDetailOption(List<string> colors, List<string> sizes)
        {
            storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionColor"].Controls.Clear();
            storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionSize"].Controls.Clear();
            if (colors.Count <= 3)
            {
                storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionColor"].Size = new System.Drawing.Size(297, 48);
            }
            else
            {
                storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionColor"].Size = new System.Drawing.Size(297, 97);
            }
            if (sizes.Count <= 3)
            {
                storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionSize"].Size = new System.Drawing.Size(297, 48);
            }
            else
            {
                storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionSize"].Size = new System.Drawing.Size(297, 97);
            }
            foreach (string color in colors)
            {
                ItemColor item = new ItemColor(color);
                item.chooseColor += chooseColor;
                storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionColor"].Controls.Add(item);
            }
            foreach (string size in sizes)
            {
                ItemSize item = new ItemSize(size);
                item.chooseSize += chooseSize;
                storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionSize"].Controls.Add(item);
            }
        }

        private void chooseColor(object color)
        {
            string colorCurrent = storeControl.Controls["selectColor"].Text;
            string colorChoose = ((ItemColor)color).getColor();
            string sizeCurrent = storeControl.Controls["selectSize"].Text;
            if (colorCurrent == colorChoose)
            {
                storeControl.Controls["selectColor"].Text = "";
                foreach (ItemColor item in storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionColor"].Controls)
                {
                    item.setBorder();
                    item.setEnable(true);
                }
                if (sizeCurrent == "")
                {
                    foreach (ItemSize item in storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionSize"].Controls)
                    {
                        item.setBorder();
                        item.setEnable(true);
                    }
                    return;
                }
                foreach (ItemSize item in storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionSize"].Controls)
                {
                    if (!item.getSize().Equals(sizeCurrent))
                        item.setBorder();
                    item.setEnable(true);
                }
                loadColor();
            }
            else
            {
                storeControl.Controls["selectColor"].Text = colorChoose;
                ItemColor item = (ItemColor)color;
                storeControl.Controls["selectColor"].Text = item.getColor();
                setBorder();
                loadSize();
            }
        }
        private void chooseSize(object size)
        {
            string sizeCurrent = storeControl.Controls["selectSize"].Text;
            string sizeChoose = ((ItemSize)size).getSize();
            string colorCurrent = storeControl.Controls["selectColor"].Text;
            if (sizeCurrent.Equals(sizeChoose))
            {
                storeControl.Controls["selectSize"].Text = "";
                foreach (ItemSize item in storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionSize"].Controls)
                {
                    item.setBorder();
                    item.setEnable(true);
                }
                if (colorCurrent == "")
                {
                    foreach (ItemColor item in storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionColor"].Controls)
                    {
                        item.setBorder();
                        item.setEnable(true);
                    }
                    return;
                }
                foreach (ItemColor item in storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionColor"].Controls)
                {
                    if (!item.getColor().Equals(colorCurrent))
                        item.setBorder();
                    item.setEnable(true);
                }
                loadSize();
            }
            else
            {
                storeControl.Controls["selectSize"].Text = sizeChoose;
                ItemSize item = (ItemSize)size;
                storeControl.Controls["selectSize"].Text = item.getSize();
                setBorder();
                loadColor();
            }
        }

        private void setBorder()
        {
            foreach (ItemColor item in storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionColor"].Controls)
            {
                if (item.getColor().Equals(storeControl.Controls["selectColor"].Text))
                    item.setBorder(true);
                else
                    item.setBorder();
            }
            foreach (ItemSize item in storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionSize"].Controls)
            {
                if (item.getSize().Equals(storeControl.Controls["selectSize"].Text))
                    item.setBorder(true);
                else item.setBorder();
            }
        }

        private void setBorderChooseColor(List<string> sizes)
        {
            List<ItemSize> listItemSize = new List<ItemSize>();
            foreach (ItemSize item in storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionSize"].Controls)
            {
                item.setEnable(true);
                listItemSize.Add(item);
                foreach (string size in sizes)
                {
                    if (item.getSize().Equals(size))
                    {
                        listItemSize.Remove(item);
                    }
                }
            }
            foreach (ItemSize item in listItemSize)
            {
                item.setBorder();
                item.setEnable();
                if (storeControl.Controls["selectSize"].Text.Equals(item.getSize()))
                {
                    storeControl.Controls["selectSize"].Text = "";
                }
            }
        }
        private void setBorderChooseSize(List<string> colors)
        {
            List<ItemColor> listItemColor = new List<ItemColor>();
            foreach (ItemColor item in storeControl.Controls["pnlOptionDetail"].Controls["pnlOptionColor"].Controls)
            {
                item.setEnable(true);
                listItemColor.Add(item);
                foreach (string color in colors)
                {
                    if (item.getColor().Equals(color))
                    {
                        listItemColor.Remove(item);
                    }
                }
            }
            foreach (ItemColor item in listItemColor)
            {
                item.setBorder();
                item.setEnable();
                if (storeControl.Controls["selectColor"].Text.Equals(item.getColor()))
                {
                    storeControl.Controls["selectColor"].Text = "";
                }
            }
        }

        public void loadSize()
        {
            string color = storeControl.Controls["selectColor"].Text;
            List<string> listSizeExistColor = productDAO.getSizeExistInColor(itemProduct.getIdProduct(), color);
            setBorderChooseColor(listSizeExistColor);
        }

        public void loadColor()
        {
            string size = storeControl.Controls["selectSize"].Text;
            List<string> listColorExistSize = productDAO.getColorExistInSize(itemProduct.getIdProduct(), size);
            setBorderChooseSize(listColorExistSize);
        }


        private void showProductOfCategory()
        {
            string name = storeControl.Controls["pnlOptionHeader"].Controls["cbCategory"].Text;
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
            storeControl.Controls["pnlContainProduct"].Visible = false;
            if (products == null) products = productDAO.getListProducts();
            storeControl.Controls["pnlContainProduct"].Controls.Clear();
            foreach (Product product in products)
            {
                string idProduct = product.Id;
                string name = product.Name;
                string image = product.Image;
                string price;
                string idCategory = product.IdCategory;
                if (productDAO.getMinPrice(product.DetailProduct) != productDAO.getMaxPrice(product.DetailProduct))
                {
                    price = productDAO.getMinPrice(product.DetailProduct).ToString("#,###") + " - " + productDAO.getMaxPrice(product.DetailProduct).ToString("#,###");

                }
                else
                {
                    price = productDAO.getMinPrice(product.DetailProduct).ToString("#,###");
                }
                string quantity = productDAO.getQuantityProduct(product.DetailProduct).ToString();
                List<string> colors = productDAO.getListColorOfProduct(product.Id);
                colors.Sort();
                List<string> sizes = productDAO.getListSizeOfProduct(product.Id);
                sizes.Sort();
                storeControl.Controls["pnlContainProduct"].Controls.Add(new ItemProduct(idProduct, name, image, price, quantity, idCategory, colors, sizes));

            }
            storeControl.Controls["pnlContainProduct"].Visible = true;
            EventSelectItemProduct();
        }
    }
}
