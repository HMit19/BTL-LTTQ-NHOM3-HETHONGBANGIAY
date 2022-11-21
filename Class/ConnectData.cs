using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.Classes
{
    internal class ConnectData
    {
        string strConnect = "Data Source=DESKTOP-80GA5O2\\SQLEXPRESS;" +
                "Initial Catalog=QLCHBanGiay;Integrated Security=True";
        SqlConnection sqlConn = null;
        // opening connect method
        void OpenConnect()
        {
            sqlConn = new SqlConnection(strConnect);
            if (sqlConn.State != ConnectionState.Open)
                sqlConn.Open();
        }
        //Closing connect method
        void CloseConnect()
        {
            if (sqlConn.State != ConnectionState.Closed)
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        //insert,update,delete data
        public void UpdateData(string sql)
        {
            OpenConnect();
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConn;
            sqlComm.CommandText = sql;
            sqlComm.ExecuteNonQuery();
            CloseConnect();
            sqlComm.Dispose();
        }
        //Select data to return a DataTable
        public DataTable ReadData(string sqlSelect)
        {
            DataTable dt = new DataTable();
            OpenConnect();
            SqlDataAdapter sqldata = new SqlDataAdapter(sqlSelect, sqlConn);
            sqldata.Fill(dt);
            CloseConnect();
            sqldata.Dispose();
            return dt;
        }
    }
}
