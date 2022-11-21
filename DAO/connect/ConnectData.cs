using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.connect
{
    internal class ConnectData
    {
        string strConnect = "Data Source=DESKTOP-9TG0LON;" + // <---Change sever name in here
            "Initial Catalog=QLCHBanGiay;" +
            "Integrated Security=SSPI;";
        SqlConnection sqlConn = null;
        // opening connect method
        void openConnect()
        {
            sqlConn = new SqlConnection(strConnect);
            if (sqlConn.State != ConnectionState.Open)
                sqlConn.Open();
        }
        //Closing connect method
        void closeConnect()
        {
            if (sqlConn.State != ConnectionState.Closed)
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        //insert,update,delete data
        public void updateData(string sql)
        {
            openConnect();
            SqlCommand sqlComm = new SqlCommand();
            sqlComm.Connection = sqlConn;
            sqlComm.CommandText = sql;
            sqlComm.ExecuteNonQuery();
            closeConnect();
            sqlComm.Dispose();
        }
        //Select data to return a DataTable
        public DataTable readData(string sqlSelect)
        {
            DataTable dt = new DataTable();
            openConnect();
            SqlDataAdapter sqldata = new SqlDataAdapter(sqlSelect, sqlConn);
            sqldata.Fill(dt);
            closeConnect();
            sqldata.Dispose();
            return dt;
        }
        public void fillComboBox(ComboBox comboName, DataTable data, string displayMember, string valueMember)
        {
            comboName.DataSource = data;
            comboName.DisplayMember = displayMember;
            comboName.ValueMember = valueMember;
        }
    }
}
