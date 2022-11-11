using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.bill
{
    interface IBillSellService : IService<BillSell>
    {
        List<BillSell> findAll();
        BillSell find(string idBill);
        List<BillSell> findByCustomer(string idCustomer);
        List<BillSell> findByEmployee(string idEmployee);
        bool update(string idBill, BillSell billSell);
        bool remove(string idBill);
        bool save(BillSell billSell);
    }
}
