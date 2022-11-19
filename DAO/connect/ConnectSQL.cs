using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.connectDB
{
    internal class ConnectSQL
    {
        private static string server = @"DESKTOP-89QSK5E";
        private static string database = "QLCuaHangBanGiay";
        SqlConnection sqlConnection = null;
        public  SqlConnection getConnect()
        {
            string strConnection = "Data Source=" + server + ";Initial Catalog=" + database + ";Integrated Security= True";
            SqlConnection sqlConnection = new SqlConnection(strConnection);
            sqlConnection.Open();
            return sqlConnection;
        }
        public void CloseConnect()
        {
            if (sqlConnection.State != ConnectionState.Closed)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }
}
