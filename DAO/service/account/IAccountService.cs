using BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service
{
    interface IAccountService : IService<Account>
    {
        List<Account> findAll();
        Account find(string username);
        bool update(string username, Account account);
        bool remove(string username);
        bool save(Account account);
    }
}
