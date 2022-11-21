using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH4
{
    internal class AccessData
    {
        string strConnect = @"Data Source=DESKTOP-9TG0LON;Initial Catalog=QLCHBanGiay;Integrated Security=True";
        SqlConnection sqlConnect = null; 
        void openConnect ()
        {
            sqlConnect = new SqlConnection (strConnect);
            if (sqlConnect.State != System.Data.ConnectionState.Open)
                sqlConnect.Open ();
        }
        void closeConnect ()
        {
            if (sqlConnect.State!=System.Data.ConnectionState.Closed)
            {
                sqlConnect.Close ();
                sqlConnect.Dispose();
            }
        }
        public DataTable DataReader (string sqlSelect)
        {
            DataTable dt = new DataTable ();
            openConnect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sqlSelect,sqlConnect);
            sqlData.Fill(dt);
            closeConnect();
            return dt;
        }
        public void DataChange (string sql)
        {
            openConnect();
            SqlCommand sqlcomm = new SqlCommand();
            sqlcomm.Connection = sqlConnect;
            sqlcomm.CommandText = sql;
            sqlcomm.ExecuteNonQuery();
            closeConnect();
        }
    }
    class StaticData
    {
        public static string ProductCode;
        public static string NameProduct;
        public static string Category;
        public static string PathImage;
    }
}
