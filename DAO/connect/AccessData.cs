using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.connect
{
    public class AccessData
    {
        string strConnect =
          "Data Source=DESKTOP-80GA5O2\\SQLEXPRESS;" +
          "Initial Catalog=QLCHBanGiay;" +
          "Integrated Security=SSPI;";
        SqlConnection sqlConnect = null;
        public void openConnect()
        {
            sqlConnect = new SqlConnection(strConnect);
            if (sqlConnect.State != ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }
        public void closeConnect()
        {
            if (sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }
        public string RunSQL(string sql)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            closeConnect();
            string res = Convert.ToString(result);
            return res;
        }
        public DataTable DataReader(string sqlSelect)
        {
            DataTable dt = new DataTable();
            openConnect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelect, sqlConnect);
            sqlData.Fill(dt);
            closeConnect();
            return dt;
        }
    }
}
