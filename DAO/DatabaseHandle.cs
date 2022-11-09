using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.connectDB;
using Microsoft.SqlServer.Server;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO
{
    class DatabaseHandle : IDatabaseHandle
    {
        SqlConnection connect = null;
        public DatabaseHandle()
        {
            connect = ConnectSQL.getConnect();
            OpenConnect();
        }

        public void OpenConnect()
        {
            if (connect.State != ConnectionState.Open)
                connect.Open();
        }

        public void CloseConnect()
        {
            if (connect.State != ConnectionState.Closed)
            {
                connect.Close();
                connect.Dispose();
            }
        }
        public DataTable dataReader(string sql)
        {
            DataTable tblData = new DataTable();
            OpenConnect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sql, connect);
            sqlData.Fill(tblData);
            CloseConnect();
            return tblData;
        }
        public bool dataChange(string sql)
        {
            int row = 0;
            OpenConnect();
            SqlCommand sqlcomma = new SqlCommand();
            sqlcomma.Connection = connect;
            sqlcomma.CommandText = sql;
            row = sqlcomma.ExecuteNonQuery();
            CloseConnect();
            return row > 0;
        }
    }
}
