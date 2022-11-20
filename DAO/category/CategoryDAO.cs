using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.category;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.product;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.category
{

    class CategoryDAO
    {
        private List<Category> categories = null;
        ICategoryService categoryService = null;
        IProductService productService = null;
        private List<Product> products = null;
        public CategoryDAO()
        {
            categoryService = new CategoryService();
            categories = categoryService.findAll();
            products = productService.findAll();
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
            foreach (Product product in products)
            {
                if (product.IdCategory.Equals(codeCategory))
                {
                    listProducts.Add(product);
                }
            }
            products = listProducts;
        }   
        public List<Category> getListCategories()
        {
            return categories;
        }
    }
}
