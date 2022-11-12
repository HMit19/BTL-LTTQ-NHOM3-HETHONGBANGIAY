using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.product
{
    interface IProductService : IService<Product>
    {
        List<Product> findAll();
        List<Product> findAllByCategory(string idCategory);
        Product find(string id);
        bool update(string id, Product product);
        bool remove(string id);
        bool save(Product product);
    }
}
