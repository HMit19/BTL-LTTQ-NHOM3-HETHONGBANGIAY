using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            openConnect();
        }

        public void openConnect()
        {
            if (connect.State != ConnectionState.Open)
                connect.Open();
        }

        public void closeConnect()
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
            try
            {
                openConnect();
                SqlDataAdapter sqlData = new SqlDataAdapter(sql, connect);
                sqlData.Fill(tblData);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                closeConnect();
            }
            return tblData;
        }
        public bool dataChange(string sql)
        {
            int row = 0;
            try
            {
                openConnect();
                SqlCommand sqlcomma = new SqlCommand();
                sqlcomma.Connection = connect;
                sqlcomma.CommandText = sql;
                row = sqlcomma.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                closeConnect();
            }
            return row > 0;
        }
    }
}
