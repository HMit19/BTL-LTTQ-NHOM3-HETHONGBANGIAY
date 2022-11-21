using BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO
{
    interface IDatabaseHandle
    {
        DataTable dataReader(string sql);
        bool dataChange(string sql);
        void closeConnect();
    }
}
