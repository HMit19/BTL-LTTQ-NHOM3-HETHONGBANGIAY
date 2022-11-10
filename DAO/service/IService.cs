using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service
{
    interface IService<T>
    {
        List<T> findAll();
        T find(string id);
        bool update(string id, T t);
        bool remove(string id);
        bool save(T t);
    }
}
