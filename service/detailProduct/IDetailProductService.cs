using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.detailProduct
{
    interface IDetailProductService : IService<DetailProduct>
    {
        List<DetailProduct> findAll();
        List<DetailProduct> findAllByProduct(string idProduct);
        DetailProduct find(string id);
        bool update(string id, DetailProduct detailProduct);
        bool remove(string id);
        bool save(DetailProduct detailProduct);
    }
}
