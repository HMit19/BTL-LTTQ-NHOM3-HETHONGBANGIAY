using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.item
{
    interface IBillDetailService:IService<DetailBillSell>
    {
        List<DetailBillSell> findAll();
        DetailBillSell find(string id);
        List<DetailBillSell> findByBill(string idBill);
        bool update(string id, DetailBillSell detailBillSell);
        bool remove(string id);
        bool save(DetailBillSell detailBillSell);
    }
}
