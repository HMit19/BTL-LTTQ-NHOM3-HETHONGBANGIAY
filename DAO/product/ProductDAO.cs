using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.category;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.detailProduct;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.product;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.admin.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.product
{
    class ProductDAO
    {
        private List<Product> products = null;
        private List<Product> productsDefault = null;
        private List<Category> categories = null;
        IProductService productService = null;
        ICategoryService categoryService = null;
        IDetailProductService detailProductService = null;
        public ProductDAO()
        {
            productService = new ProductService();
            categoryService = new CategoryService();
            detailProductService = new DetailProductService();
            products = productService.findAll();
            productsDefault = products;
            categories = categoryService.findAll();
            loadDetailProduct();
        }

        public List<Product> getListProductsDefault()
        {
            return productsDefault;
        }
        public List<DetailProduct> getListDetailProductByIdProduct(string idProduct)
        {
            foreach (Product product in productsDefault)
            {
                if (product.Id.Equals(idProduct))
                {
                    return product.DetailProduct;
                }
            }
            return null;
        }

        public string getIdDetailProduct(string idProduct, string color, string size)
        {
            Product product = getProductById(idProduct);
            foreach (DetailProduct detailProduct in product.DetailProduct)
            {
                if (detailProduct.Color.Equals(color) && detailProduct.Size.ToString().Equals(size))
                {
                    return detailProduct.IdProductDetail;
                }
            }
            return null;
        }

        public List<string> getSizeExistInColor(string idProduct, string color)
        {
            HashSet<string> sizes = new HashSet<string>();
            foreach (DetailProduct detailProduct in getListDetailProductByIdProduct(idProduct))
            {
                if (detailProduct.Color.Equals(color))
                    sizes.Add(detailProduct.Size.ToString());
            }
            return new List<string>(sizes);
        }
        public List<string> getColorExistInSize(string idProduct, string size)
        {
            HashSet<string> colors = new HashSet<string>();
            foreach (DetailProduct detailProduct in getListDetailProductByIdProduct(idProduct))
            {
                if (detailProduct.Size.ToString().Equals(size))
                    colors.Add(detailProduct.Color);
            }
            return new List<string>(colors);
        }
        public List<string> getListColorOfProduct(string idProduct)
        {
            HashSet<string> colors = new HashSet<string>();
            foreach (DetailProduct detailProduct in getListDetailProductByIdProduct(idProduct))
            {
                colors.Add(detailProduct.Color);
            }
            return new List<string>(colors);
        }


        public List<string> getListSizeOfProduct(string idProduct)
        {
            HashSet<string> sizes = new HashSet<string>();
            foreach (DetailProduct detailProduct in getListDetailProductByIdProduct(idProduct))
            {
                sizes.Add(detailProduct.Size.ToString());
            }
            return new List<string>(sizes);
        }

        public List<Product> getListProducts()
        {
            return products;
        }
        public Product getProductById(string id)
        {
            foreach (Product product in productsDefault)
            {
                if (product.Id.Equals(id))
                {
                    return product;
                }
            }
            return null;
        }

        public DetailProduct getDetailProductById(string id)
        {
            foreach (Product product in productsDefault)
            {
                foreach (DetailProduct detailProduct in product.DetailProduct)
                {
                    if (detailProduct.IdProductDetail.Equals(id))
                    {
                        return detailProduct;
                    }
                }
            }
            return null;
        }

        public void setListProducts(List<Product> products)
        {
            this.products = products;
        }

        public void productOfCategory(string nameCategory)
        {
            string codeCategory = "";
            foreach (Category category in categories)
            {
                if (category.Name.Equals(nameCategory))
                {
                    codeCategory = category.Id;
                    break;
                }
            }
            List<Product> listProducts = new List<Product>();
            foreach (Product product in productsDefault)
            {
                if (product.IdCategory.Equals(codeCategory))
                {
                    listProducts.Add(product);
                }
            }
            products = listProducts;
        }

        public bool searchByName(string nameProduct)
        {
            List<Product> listProducts = new List<Product>();
            foreach (Product product in productsDefault)
            {
                if (product.Name.ToLower().Contains(nameProduct.ToLower()))
                    listProducts.Add(product);
            }
            products = listProducts;
            return listProducts.Count == 0;
        }

        public void sortProductByPrice(bool reverse = false)
        {
            if (reverse)
            {
                products = products.OrderBy(p => getMinPrice(p.DetailProduct)).ToList();
            }
            else
            {
                products = products.OrderByDescending(p => getMinPrice(p.DetailProduct)).ToList();
            }
        }
        public void sortProductByQuantity()
        {
            products = products.OrderBy(p => getQuantityProduct(p.DetailProduct)).ToList();
        }
        public double getMinPrice(List<DetailProduct> detailProducts)
        {
            double price = 100000000;
            foreach (DetailProduct detailProduct in detailProducts)
            {
                price = detailProduct.PriceOut < price ? detailProduct.PriceOut : price;
            }
            return price;
        }
        public double getMaxPrice(List<DetailProduct> detailProducts)
        {
            double price = 0;
            foreach (DetailProduct detailProduct in detailProducts)
            {
                price = detailProduct.PriceOut > price ? detailProduct.PriceOut : price;
            }
            return price;
        }
        public long getQuantityProduct(List<DetailProduct> detailProducts)
        {
            long quantity = 0;
            foreach (DetailProduct detailProduct in detailProducts)
            {
                quantity += detailProduct.Quantity;
            }
            return quantity;
        }
        public List<string> getNameCategory()
        {
            List<string> data = new List<string>();
            data.Add("Tất cả");
            foreach (Category category in categories)
            {
                data.Add(category.Name);
            }
            return data;
        }
        private void loadDetailProduct()
        {
            foreach (Product product in productsDefault)
            {
                List<DetailProduct> details = detailProductService.findAllByProduct(product.Id);
                product.DetailProduct = details;
            }
        }
    }
}
