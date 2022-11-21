using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.Content
{
    public class HomeController
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

        public string totalQuantity()
        {
            string sql = " Select Sum ( Quantity ) from dbo.tDetailProduct ";
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            closeConnect();
            string res = Convert.ToString(result) + " (Sản phẩm) ";
            return res;
        }
        public string sellQuantity()
        {
            string sql = " select sum(Quantity) from dbo.tDetailBillOfSale ";
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            closeConnect();
            string res = Convert.ToString(result) + " (Sản phẩm) ";
            return res;

        }
        public string totaSum()
        {
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode ";
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            closeConnect();
            string res = Convert.ToString(result) + " (VND) ";
            return res;
        }
        public string totalCustomer()
        {
            string sql = " select count(CustomerCode) from dbo.tCustomer ";
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            closeConnect();
            string res = Convert.ToString(result) + " (Khách) ";
            return res;
        }
        public string dailyTotalCustomer()
        {
            DateTime d = DateTime.Now;
            string day = d.ToString("yyyy-MM-dd");
            string sql = " select count(CodeBill) from dbo.tBillOfSale where DateSale = '" + day + "' ";
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            closeConnect();
            string res = Convert.ToString(result) + " (Đơn) ";
            return res;
        }
        public string dailyTotalIncome()
        {
            DateTime d = DateTime.Now;
            string day = d.ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + day + "' ";
            openConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            closeConnect();
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
