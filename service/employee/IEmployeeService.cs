using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.employee
{
    interface IEmployeeService : IService<Employee>
    {
        List<Employee> findAll();
        Employee find(string id);
        bool update(string id, Employee employee);
        bool remove(string id);
        bool save(Employee employee);
    }
}
