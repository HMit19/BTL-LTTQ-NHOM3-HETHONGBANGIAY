using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.connectDB
{
    internal class ConnectSQL
    {
        private static string server = @"DESKTOP-80GA5O2\SQLEXPRESS";
        private static string database = "BanHang";
        public static SqlConnection getConnect()
        {
            string strConnection = "Data Source=" + server + ";Initial Catalog=" + database + ";Integrated Security= True";
            SqlConnection sqlConnection = new SqlConnection(strConnection);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}
