using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service
{
    interface ICustomerService : IService<Customer>
    {
        List<Customer> findAll();
        Customer find(string id);
        Customer findByPhone(string phone);
        bool update(string id, Customer customer);
        bool remove(string id);
        bool save(Customer customer);
    }
}
