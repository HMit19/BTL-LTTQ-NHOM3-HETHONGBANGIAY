using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.category
{
    interface ICategoryService : IService<Category>
    {
        List<Category> findAll();
        Category find(string id);
        bool update(string id, Category category);
        bool remove(string id);
        bool save(Category category);
    }
}
