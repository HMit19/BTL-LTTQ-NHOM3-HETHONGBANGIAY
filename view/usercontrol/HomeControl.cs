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
        Content.Home control = new Content.Home();
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

        public HomeControl()
        {
            InitializeComponent();
        }
        private void AddUserControl()
        {
            
            string sql = " select distinct top 5 a.Quantity* b.Price as DoanhThu, c.NameProduct,b.Size,b.Color,c.Image from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tProduct c on b.ProductCode =c.ProductCode ";
            DataTable dt = new DataTable("BestSelled");
            OpenConnect();
            SqlDataAdapter sqlData = new SqlDataAdapter(sql, sqlConnect);
            sqlData.Fill(dt);
            CloseConnect();
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
        private int Today()
        {
            DateTime d = DateTime.Now;
            string d1 = Convert.ToString(d.DayOfWeek);
            string day = d.ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + day + "' ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            CloseConnect();
            int sum = int.Parse(result.ToString());
            return sum;
        }
        private void Monday()
        {
            int sum = Today();
            int a = sum / 500000;
            string sun;
            int total;
            DateTime d = DateTime.Now;
            sun = d.AddDays(-1).ToString("yyyy-MM-dd");
            string sql1 = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + sun + "' ";
            OpenConnect();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = sqlConnect;
            cmd1.CommandText = sql1;
            object result1 = cmd1.ExecuteScalar();
            total = int.Parse(result1.ToString());
            if (total > sum)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (sum > total)
            {
                btnSellMonday.BackColor = Color.FromArgb(232, 81, 16);
            }
            CloseConnect();
            btnSellMonday.Visible = true;
            btnSellMonday.Size = new Size(btnSellMonday.Width, btnSellMonday.Height + a);
            btnSellMonday.Location = new Point(btnSellMonday.Location.X, btnSellMonday.Location.Y - a);
        }
        private void Tuesday()
        {
            int sum = Today();
            int a = sum / 500000;
            string mon;
            int total;
            DateTime d = DateTime.Now;
            mon = d.AddDays(-1).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + mon + "' ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            total = int.Parse(result.ToString());
            if (total > sum)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (sum > total)
            {
                btnSellTuesday.BackColor = Color.FromArgb(232, 81, 16);
            }
            btnSellMonday.Visible = true;
            btnSellTuesday.Visible = true;
            btnSellTuesday.Size = new Size(btnSellTuesday.Width, btnSellTuesday.Height + a);
            btnSellTuesday.Location = new Point(btnSellTuesday.Location.X, btnSellTuesday.Location.Y - a);
        }
        private void Wedneday()
        {
            int sum = Today();
            int a = sum / 500000;
            string tue;
            int total;
            DateTime d = DateTime.Now;
            tue = d.AddDays(-1).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + tue + "' ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            total = int.Parse(result.ToString());
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
        private void Thursday()
        {
            int sum = Today();
            int a = sum / 500000;
            string wed;
            int total;
            DateTime d = DateTime.Now;
            wed = d.AddDays(-1).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + wed + "' ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            total = int.Parse(result.ToString());
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
        private void Friday()
        {

            int sum = Today();
            int a = sum / 500000;
            string thu;
            int total;
            DateTime d = DateTime.Now;
            thu = d.AddDays(-1).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + thu + "' ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            total = int.Parse(result.ToString());
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
        private void Saturday()
        {
            int sum = Today();
            int a = sum / 500000;
            string fri;
            int total;
            DateTime d = DateTime.Now;
            fri = d.AddDays(-1).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + fri + "' ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            total = int.Parse(result.ToString());
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
        private void Sunday()
        {
            int sum = Today();
            int a = sum / 500000;
            string sat;
            int total;
            DateTime d = DateTime.Now;
            sat = d.AddDays(-1).ToString("yyyy-MM-dd");
            string sql = " select sum(a.Quantity* b.Price) from dbo.tDetailBillOfSale a join dbo.tDetailProduct b on a.DetailProductCode= b.DetailProductCode\r\njoin dbo.tBillOfSale c on a.CodeBill=c.CodeBill\r\nwhere c.DateSale= '" + sat + "' ";
            OpenConnect();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnect;
            cmd.CommandText = sql;
            object result = cmd.ExecuteScalar();
            total = int.Parse(result.ToString());
            if (total > sum)
            {
                btnSellSunday.BackColor = Color.FromArgb(232, 141, 39);
            }
            else if (sum > total)
            {
                btnSellSunday.BackColor = Color.FromArgb(232, 81, 16);
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
        public void Day()
        {
            DateTime d = DateTime.Now;
            string d1 = Convert.ToString(d.DayOfWeek);
            string day = d.ToString("yyyy-MM-dd");



            if (d1 == "Monday")
            {
                Monday();
            }
            else if (d1 == "Tuesday")
            {
                Monday();
                Tuesday();
            }
            else if (d1 == "Wednesday")
            {
                Monday();
                Tuesday();
                Wedneday();
            }
            else if (d1 == "Thursday")
            {
                Monday();
                Tuesday();
                Wedneday();
                Thursday();
            }
            else if (d1 == "Friday")
            {
                Monday();
                Tuesday();
                Wedneday();
                Thursday();
                Friday();
            }
            else if (d1 == "Saturday")
            {
                Monday();
                Tuesday();
                Wedneday();
                Thursday();
                Friday();
                Saturday();
            }
            else if(d1 == "Sunday")
            {
                Monday();
                Tuesday();
                Wedneday();
                Thursday();
                Friday();
                Saturday();
                Sunday();
            }

        }

        private void HomeControl_Load(object sender, EventArgs e)
        {
            lblQuantityProduct.Text = control.TotalQuantity();
            lblQuantityProductSelled.Text = control.SellQuantity();
            lblSumTotal.Text = control.TotaSum();
            lblQuantityCustomer.Text = control.TotalCustomer();
            lblQuantityOrderOfDay.Text=control.DailyTotalCustomer();
            lblRevenueOfDay.Text = control.DailyTotalIncome();
            AddUserControl();
            //btnSellSunday.Size = new Size(btnSellSunday.Width, btnSellSunday.Height + 10);
            //btnSellSunday.Location = new Point(btnSellSunday.Location.X, btnSellSunday.Location.Y - 10);
            Day();
        }

 
    }
}
