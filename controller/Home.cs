using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.Content
{
    public class Home
    {
        string strConnect =
          "Data Source=DESKTOP-89QSK5E;" +
          "Initial Catalog=QLCHBanGiay;" +
          "Integrated Security=SSPI;";
        SqlConnection sqlConnect = null;
        public void OpenConnect()
        {
            sqlConnect = new SqlConnection(strConnect);
            if (sqlConnect.State != ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }
        public void CloseConnect()
        {
            if (sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }

        public string TotalQuantity()
        {
            string sql = " Select Sum ( Quantity ) from dbo.tDetailProduct ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            CloseConnect();
            string res = Convert.ToString(result) + " (Sản phẩm) ";
            return res;
        }
       public string SellQuantity()
        {
            string sql = " select sum(Quantity) from dbo.tDetailBillOfSale ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            CloseConnect();
            string res = Convert.ToString(result) + " (Sản phẩm) ";
            return res;

        }
        public string TotaSum()
        {
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            CloseConnect();
            string res = Convert.ToString(result) + " (VND) ";
            return res;
        }
        public string TotalCustomer()
        {
            string sql = " select count(CustomerCode) from dbo.tCustomer ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            CloseConnect();
            string res = Convert.ToString(result) + " (Khách) ";
            return res;
        }
        public string DailyTotalCustomer()
        {
            DateTime d= DateTime.Now;
            string day = d.ToString("yyyy-MM-dd");
            string sql = " select count(CodeBill) from dbo.tBillOfSale where DateSale = '"+day+"' ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            CloseConnect();
            string res = Convert.ToString(result) + " (Đơn) ";
            return res;
        }
        public string DailyTotalIncome()
        {
            DateTime d = DateTime.Now;
            string day = d.ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '"+day+"' ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            CloseConnect();
            string sum = Convert.ToString(result);
            string res;
            if (sum == "")
            {
                res = " 0 (VND)";
                return res;
            }
            else
            {
                res = sum + " (VND) ";
                return res;
            }
        }

      


    }
}
