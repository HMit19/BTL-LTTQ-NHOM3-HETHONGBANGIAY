using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Xml.Linq;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol
{
    public partial class HomeControl : UserControl
    {
        Content.HomeController control = new Content.HomeController();
        DAO.connect.AcessData data = new DAO.connect.AcessData();
        public HomeControl()
        {
            InitializeComponent();
        }
        private void addUserControl()
        {
            
            string sql = " select distinct top 5 a.Quantity* b.Price as DoanhThu, c.NameProduct,b.Size,b.Color,c.Image from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tProduct c on b.ProductCode =c.ProductCode ";
            DataTable dt = data.DataReader(sql);
            string[] name = new string[10];
            string[] pic = new string[10];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                name[i] = dt.Rows[i]["NameProduct"].ToString();
                pic[i] = dt.Rows[i]["Image"].ToString();
            }

            for (int i = 0; i < 5; i++)
            {
                item.ItemTopProduct it = new item.ItemTopProduct(name[i], pic[i]);
                fpnlTopProduct.Controls.Add(it);
            }
        }
        private int getRevenueToday()
        {
            DateTime d = DateTime.Now;
            string d1 = Convert.ToString(d.DayOfWeek);
            string day = d.ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + day + "' ";
            int sum = int.Parse(data.RunSQL(sql).ToString());
            return sum;
        }


        private void getRevenueMonday()
        {
            int sum = getRevenueToday();
            int a = sum / 55000;
            string sun;
            int total;
            DateTime d = DateTime.Now;
            sun = d.AddDays(-1).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + sun + "' ";
            total = int.Parse(data.RunSQL(sql).ToString());
            if (total > sum)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (sum >= total)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Visible=true;
            btnSellMonday.Size = new Size(btnSellMonday.Width, btnSellMonday.Height + a);
            btnSellMonday.Location = new Point(btnSellMonday.Location.X, btnSellMonday.Location.Y - a);
        }


        private void getRevenueTuesday()
        {
            int sum = getRevenueToday();
            int a = sum / 55000;
            string mon,sun;
            int total,total2;
            DateTime d = DateTime.Now;
            mon = d.AddDays(-1).ToString("yyyy-MM-dd");
            sun = d.AddDays(-2).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + mon + "' ";
            string sql2= " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + sun + "' ";
            total2= int.Parse(data.RunSQL(sql2).ToString()); //sun
            total = int.Parse(data.RunSQL(sql).ToString());  //mon
            int b = total / 55000;
            if (total2 > total)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (total >= total2)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Visible = true;
            btnSellMonday.Size = new Size(btnSellMonday.Width, btnSellMonday.Height + b);
            btnSellMonday.Location = new Point(btnSellMonday.Location.X, btnSellMonday.Location.Y - b);
            if (total > sum)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (sum > total)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 81, 16);
            }
           
            btnSellTuesday.Visible = true;
            btnSellTuesday.Size = new Size(btnSellTuesday.Width, btnSellTuesday.Height + a);
            btnSellTuesday.Location = new Point(btnSellTuesday.Location.X, btnSellTuesday.Location.Y - a);
        }


        private void getRevenueWedneday()
        {
            int sum = getRevenueToday();
            int a = sum / 100000;
            string tue,mon,sun;
            int total,total2,total3;
            DateTime d = DateTime.Now;
            sun = d.AddDays(-3).ToString("yyyy-MM-dd");
            mon = d.AddDays(-2).ToString("yyyy-MM-dd");
            tue = d.AddDays(-1).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + tue + "' ";
            string sql2 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + mon + "' ";
            string sql3 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + sun + "' ";

            total = int.Parse(data.RunSQL(sql).ToString()); //tue
            int c = total / 100000;
            total2 = int.Parse(data.RunSQL(sql2).ToString()); //mon
            int b = total2 / 100000;
            total3= int.Parse(data.RunSQL(sql3).ToString()); //sun
            
            if (total3 > total2)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (total2 >= total3)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Size = new Size(btnSellMonday.Width, btnSellMonday.Height + b);
            btnSellMonday.Location = new Point(btnSellMonday.Location.X, btnSellMonday.Location.Y - b);

            if (total2 > total)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (total > total2)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellTuesday.Size = new Size(btnSellTuesday.Width, btnSellTuesday.Height + c);
            btnSellTuesday.Location = new Point(btnSellTuesday.Location.X, btnSellTuesday.Location.Y - c);

            if (total > sum)
            {
               
                btnSellWednesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (sum > total)
            {
                
                btnSellWednesday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Visible = true;
            btnSellTuesday.Visible = true;
            btnSellWednesday.Visible = true;
            
            btnSellWednesday.Location = new Point(btnSellWednesday.Location.X, btnSellWednesday.Location.Y - a);
            btnSellWednesday.Size = new Size(btnSellWednesday.Width, btnSellWednesday.Height + a);
        }

        private void getRevenueThursday()
        {
            int sum = getRevenueToday();
            int a = sum / 100000;
            string wed,tue,mon,sun;
            int total,t2,t3,t4;
            DateTime d = DateTime.Now;
            sun = d.AddDays(-4).ToString("yyyy-MM-dd");
            mon = d.AddDays(-3).ToString("yyyy-MM-dd");
            tue = d.AddDays(-2).ToString("yyyy-MM-dd");
            wed = d.AddDays(-1).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + wed + "' ";
            string sql2 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + mon + "' ";
            string sql3 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + tue + "' ";
            string sql4 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + sun + "' ";

            total = int.Parse(data.RunSQL(sql).ToString()); //wed
            int e = total / 100000;
            t2 = int.Parse(data.RunSQL(sql2).ToString());   //mon
            int b = t2 / 100000;
            t3 = int.Parse(data.RunSQL(sql3).ToString());   //tue
            int c = t3 / 100000;
            t4 = int.Parse(data.RunSQL(sql4).ToString());   //sun
            

            if (t4 > t2)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t4 < t2)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Size = new Size(btnSellMonday.Width, btnSellMonday.Height + b);
            btnSellMonday.Location = new Point(btnSellMonday.Location.X, btnSellMonday.Location.Y - b);

            if (t2 > t3)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t3 > t2)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellTuesday.Size = new Size(btnSellTuesday.Width, btnSellTuesday.Height + c);
            btnSellTuesday.Location = new Point(btnSellTuesday.Location.X, btnSellTuesday.Location.Y - c);

            if (t3 > total)
            {

                btnSellWednesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (total > t3)
            {

                btnSellWednesday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellWednesday.Location = new Point(btnSellWednesday.Location.X, btnSellWednesday.Location.Y - e);
            btnSellWednesday.Size = new Size(btnSellWednesday.Width, btnSellWednesday.Height + e);
            if (total > sum)
            {
                
                btnThursday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (sum > total)
            {
                
                btnThursday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Visible = true;
            btnSellTuesday.Visible = true;
            btnSellWednesday.Visible = true;
            btnThursday.Visible = true;
            btnThursday.Size = new Size(btnThursday.Width, btnThursday.Height + a);
            btnThursday.Location = new Point(btnThursday.Location.X, btnThursday.Location.Y - a);
        }

        private void getRevenueFriday()
        {

            int sum = getRevenueToday();
            int a = sum / 100000;
            string thu,wed,tue,mon,sun;
            int total;
            DateTime d = DateTime.Now;
            thu = d.AddDays(-1).ToString("yyyy-MM-dd");
            sun = d.AddDays(-5).ToString("yyyy-MM-dd");
            mon = d.AddDays(-4).ToString("yyyy-MM-dd");
            tue = d.AddDays(-3).ToString("yyyy-MM-dd");
            wed = d.AddDays(-2).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + thu + "' ";
            string sql2 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + mon + "' ";
            string sql3 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + tue + "' ";
            string sql4 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + wed + "' ";
            string sql5 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + sun + "' ";

            total = int.Parse(data.RunSQL(sql).ToString());   //thur
            int e = total / 100000;
            int t2 = int.Parse(data.RunSQL(sql2).ToString()); //mon
            int b = t2 / 100000;
            int t3 = int.Parse(data.RunSQL(sql3).ToString()); //tue
            int c = t3 / 100000;
            int t4 = int.Parse(data.RunSQL(sql4).ToString()); //wed
            int d1 = t4 / 100000;
            int t5 = int.Parse(data.RunSQL(sql5).ToString()); //sun
            

            if (t5 > t2)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t2 >= t5)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Size = new Size(btnSellMonday.Width, btnSellMonday.Height + b);
            btnSellMonday.Location = new Point(btnSellMonday.Location.X, btnSellMonday.Location.Y - b);

            if (t2 > t3)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t3 > t2)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellTuesday.Size = new Size(btnSellTuesday.Width, btnSellTuesday.Height + c);
            btnSellTuesday.Location = new Point(btnSellTuesday.Location.X, btnSellTuesday.Location.Y - c);

            if (t3 > t4)
            {

                btnSellWednesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t4 > t3)
            {

                btnSellWednesday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellWednesday.Location = new Point(btnSellWednesday.Location.X, btnSellWednesday.Location.Y - d1);
            btnSellWednesday.Size = new Size(btnSellWednesday.Width, btnSellWednesday.Height + d1);

            if (t4 > total)
            {

                btnThursday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (total > t4)
            {

                btnThursday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnThursday.Size = new Size(btnThursday.Width, btnThursday.Height + e);
            btnThursday.Location = new Point(btnThursday.Location.X, btnThursday.Location.Y - e);
            if (total > sum)
            {
                btnSellFriday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (sum > total)
            {
                btnSellFriday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Visible = true;
            btnSellTuesday.Visible = true;
            btnSellWednesday.Visible = true;
            btnThursday.Visible = true;
            btnSellFriday.Visible = true;
            btnSellFriday.Size = new Size(btnSellFriday.Width, btnSellFriday.Height + a);
            btnSellFriday.Location = new Point(btnSellFriday.Location.X, btnSellFriday.Location.Y - a);
        }

        private void getRevenueSaturday()
        {
            int sum = getRevenueToday();
            int a = sum / 100000;
            string fri,thur,wed,tue,mon,sun;
            int total;
            DateTime d = DateTime.Now;
            fri = d.AddDays(-1).ToString("yyyy-MM-dd");
            thur = d.AddDays(-2).ToString("yyyy-MM-dd");
            sun = d.AddDays(-6).ToString("yyyy-MM-dd");
            mon = d.AddDays(-5).ToString("yyyy-MM-dd");
            tue = d.AddDays(-4).ToString("yyyy-MM-dd");
            wed = d.AddDays(-3).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + fri + "' ";
            string sql2 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + mon + "' ";
            string sql3 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + tue + "' ";
            string sql4 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + wed + "' ";
            string sql5 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + thur + "' ";
            string sql6= " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + sun + "' ";

            total = int.Parse(data.RunSQL(sql).ToString());   //fri
            int e = total / 100000;
            int t2 = int.Parse(data.RunSQL(sql2).ToString()); //mon
            int b = t2 / 100000;
            int t3 = int.Parse(data.RunSQL(sql3).ToString()); //tue
            int c = t3 / 100000;
            int t4 = int.Parse(data.RunSQL(sql4).ToString()); //wed
            int d1 = t4 / 100000;
            int t5 = int.Parse(data.RunSQL(sql5).ToString()); //thur
            int f = t5 / 100000;
            int t6= int.Parse(data.RunSQL(sql6).ToString());
            if (t6 > t2)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t2 >= t6)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Size = new Size(btnSellMonday.Width, btnSellMonday.Height + b);
            btnSellMonday.Location = new Point(btnSellMonday.Location.X, btnSellMonday.Location.Y - b);

            if (t2 > t3)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t3 > t2)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellTuesday.Size = new Size(btnSellTuesday.Width, btnSellTuesday.Height + c);
            btnSellTuesday.Location = new Point(btnSellTuesday.Location.X, btnSellTuesday.Location.Y - c);

            if (t3 > t4)
            {

                btnSellWednesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t4 > t3)
            {

                btnSellWednesday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellWednesday.Location = new Point(btnSellWednesday.Location.X, btnSellWednesday.Location.Y - d1);
            btnSellWednesday.Size = new Size(btnSellWednesday.Width, btnSellWednesday.Height + d1);

            if (t4 > t5)
            {

                btnThursday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t5 > t4)
            {

                btnThursday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnThursday.Size = new Size(btnThursday.Width, btnThursday.Height + e);
            btnThursday.Location = new Point(btnThursday.Location.X, btnThursday.Location.Y - e);
            if (total > t5)
            {
                btnSellFriday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t5 > total)
            {
                btnSellFriday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellFriday.Size = new Size(btnSellFriday.Width, btnSellFriday.Height + f);
            btnSellFriday.Location = new Point(btnSellFriday.Location.X, btnSellFriday.Location.Y - f);
            if (total > sum)
            {
                btnSellSaturday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (sum > total)
            {
                btnSellSaturday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Visible = true;
            btnSellTuesday.Visible = true;
            btnSellWednesday.Visible = true;
            btnThursday.Visible = true;
            btnSellFriday.Visible = true;
            btnSellSaturday.Visible = true;
            btnSellSaturday.Size = new Size(btnSellSaturday.Width, btnSellSaturday.Height + a);
            btnSellSaturday.Location = new Point(btnSellSaturday.Location.X, btnSellSaturday.Location.Y - a);
        }

        private void getRevenueSunday()
        {
            int sum = getRevenueToday();
            int a = sum / 100000;
            string sat,fri,thur,wed,tue,mon,sun;
            int total;
            DateTime d = DateTime.Now;
            sat = d.AddDays(-1).ToString("yyyy-MM-dd");
            fri = d.AddDays(-2).ToString("yyyy-MM-dd");
            thur = d.AddDays(-3).ToString("yyyy-MM-dd");
            sun = d.AddDays(-7).ToString("yyyy-MM-dd");
            mon = d.AddDays(-6).ToString("yyyy-MM-dd");
            tue = d.AddDays(-5).ToString("yyyy-MM-dd");
            wed = d.AddDays(-4).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + sat + "' ";
            string sql2 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + mon + "' ";
            string sql3 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + tue + "' ";
            string sql4 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + wed + "' ";
            string sql5 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + thur + "' ";
            string sql6 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + fri + "' ";
            string sql7 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + sun + "' ";

            total = int.Parse(data.RunSQL(sql).ToString());   //sat
            int e = total / 100000;
            int t2 = int.Parse(data.RunSQL(sql2).ToString()); //mon
            int b = t2 / 100000;
            int t3 = int.Parse(data.RunSQL(sql3).ToString()); //tue
            int c = t3 / 100000;
            int t4 = int.Parse(data.RunSQL(sql4).ToString()); //wed
            int d1 = t4 / 100000;
            int t5 = int.Parse(data.RunSQL(sql5).ToString()); //thur
            int f = t5 / 100000;
            int t6 = int.Parse(data.RunSQL(sql6).ToString()); //fri
            int i = t6 / 100000;
            int t7= int.Parse(data.RunSQL(sql7).ToString());  //sun

            if (t7 > t2)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t2 >= t7)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Size = new Size(btnSellMonday.Width, btnSellMonday.Height + b);
            btnSellMonday.Location = new Point(btnSellMonday.Location.X, btnSellMonday.Location.Y - b);

            if (t2 < t3)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t3 < t2)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellTuesday.Size = new Size(btnSellTuesday.Width, btnSellTuesday.Height + c);
            btnSellTuesday.Location = new Point(btnSellTuesday.Location.X, btnSellTuesday.Location.Y - c);

            if (t3 > t4)
            {

                btnSellWednesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t4 > t3)
            {

                btnSellWednesday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellWednesday.Location = new Point(btnSellWednesday.Location.X, btnSellWednesday.Location.Y - d1);
            btnSellWednesday.Size = new Size(btnSellWednesday.Width, btnSellWednesday.Height + d1);

            if (t4 > t5)
            {

                btnThursday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t5 > t4)
            {

                btnThursday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnThursday.Size = new Size(btnThursday.Width, btnThursday.Height + e);
            btnThursday.Location = new Point(btnThursday.Location.X, btnThursday.Location.Y - e);
            if (t6 > t5)
            {
                btnSellFriday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t5 > t6)
            {
                btnSellFriday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellFriday.Size = new Size(btnSellFriday.Width, btnSellFriday.Height + f);
            btnSellFriday.Location = new Point(btnSellFriday.Location.X, btnSellFriday.Location.Y - f);
            if (total > t6)
            {
                btnSellSaturday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (t6 > total)
            {
                btnSellSaturday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellSaturday.Size = new Size(btnSellSaturday.Width, btnSellSaturday.Height + i);
            btnSellSaturday.Location = new Point(btnSellSaturday.Location.X, btnSellSaturday.Location.Y - i);
            if (total < sum)
            {
                btnSellSunday.BackColor = Color.FromArgb(232, 81, 16);
            }
            else if (sum < total)
            {
                btnSellSunday.BackColor = Color.FromArgb(232, 141, 39);
                
            }
            btnSellMonday.Visible = true;
            btnSellTuesday.Visible = true;
            btnSellWednesday.Visible = true;
            btnThursday.Visible = true;
            btnSellFriday.Visible = true;
            btnSellSaturday.Visible = true;
            btnSellSunday.Visible = true;
            btnSellSunday.Size = new Size(btnSellSunday.Width, btnSellSunday.Height + a);
            btnSellSunday.Location = new Point(btnSellSunday.Location.X, btnSellSunday.Location.Y - a);
        }



        public void getRevenueAllDay()
        {

            DateTime d = DateTime.Now;
            string d1 = Convert.ToString(d.DayOfWeek);
            if (d1 == "Monday")
            {
                getRevenueMonday();
            }
            else if (d1 == "Tuesday")
            {
                getRevenueTuesday();
            }
            else if (d1 == "Wednesday")
            {
                getRevenueWedneday();

            }
            else if (d1 == "Thursday")
            {
                getRevenueThursday();
            }
            else if (d1 == "Friday")
            {
                getRevenueFriday();
            }
            else if (d1 == "Saturday")
            {
                getRevenueSaturday();
            }
            else if (d1 == "Sunday")
            {
                getRevenueSunday();

            }

        }
        private void HomeControl_Load(object sender, EventArgs e)
        {
            lblQuantityProduct.Text = control.totalQuantity();
            lblQuantityProductSelled.Text = control.sellQuantity();
            lblSumTotal.Text = control.totaSum();
            lblQuantityCustomer.Text = control.totalCustomer();
            lblQuantityOrderOfDay.Text=control.dailyTotalCustomer();
            lblRevenueOfDay.Text = control.dailyTotalIncome();
            addUserControl();
            getRevenueAllDay();

           
        }

 
    }
}
