using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Security.Cryptography;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.connect
{
    internal class ConnectData
    {
        string strConnect = "Data Source=DESKTOP-2Vk0QO3\\HSA1PRO;" +
            "Initial Catalog=QLCHBanGiay;" +
            "Integrated Security=SSPI;";
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
        public void FillComboBox(ComboBox comboName, DataTable data, string displayMember, string valueMember)
        {
            comboName.DataSource = data;
            comboName.DisplayMember = displayMember;
            comboName.ValueMember = valueMember;
        }
    }
}
