using BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service
{
    interface IAccountService
    {
        List<Account> getListAccount();
        Account findAccountByUsername(string username);
        bool update(string username, Account account);
        bool remove(string username);
        bool save(Account account);
    }
}
