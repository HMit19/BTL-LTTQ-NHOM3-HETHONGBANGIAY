using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.customer;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.customer
{
    class CustomerDAO
    {
        ICustomerService customerService = null;
        public CustomerDAO()
        {
            customerService = new CustomerService();
        }
        public Customer getCustomerByPhone(string phone)
        {
            return customerService.findByPhone(phone);
        }
        public void save(Customer customer)
        {
            customerService.save(customer);
        }
        public void update(string id, Customer customer)
        {
            customerService.update(id, customer);
        }
    }
}
