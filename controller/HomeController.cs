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
        DAO.connect.AccessData data = new DAO.connect.AccessData();
        public string totalQuantity()
        {
            string sql = " Select Sum ( Quantity ) from dbo.tDetailProduct ";
            string result = data.RunSQL(sql) + " (Sản phẩm) ";
            return result;
        }
        public string sellQuantity()
        {
            string sql = " select sum(Quantity) from dbo.tDetailBillOfSale ";
            string result = data.RunSQL(sql) + " (Sản phẩm) ";
            return result;
        }
        public string totaSum()
        {
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode ";
            string result = data.RunSQL(sql) + " (VND) ";
            return result;
        }
        public string totalCustomer()
        {
            string sql = " select count(CustomerCode) from dbo.tCustomer ";
            string result = data.RunSQL(sql) + " (Khách) ";
            return result;
        }
        public string dailyTotalCustomer()
        {
            DateTime d = DateTime.Now;
            string day = d.ToString("yyyy-MM-dd");
            string sql = " select count(CodeBill) from dbo.tBillOfSale where DateSale = '" + day + "' ";
            string result = data.RunSQL(sql) + " (Đơn ";
            return result;
        }
        public string dailyTotalIncome()
        {
            DateTime d = DateTime.Now;
            string day = d.ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + day + "' ";
            string sum = data.RunSQL(sql);
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
