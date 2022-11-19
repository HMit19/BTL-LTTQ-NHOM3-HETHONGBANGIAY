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
using System.Windows.Forms;
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
        public void Day()
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
            int a = sum / 1500000;

            
            if (d1 == "Monday")
            {
                btnSellMonday.Size = new Size(btnSellMonday.Width, btnSellMonday.Height+a);
                btnSellMonday.Location= new Point(btnSellMonday.Location.X, btnSellMonday.Location.Y-a);
            }
            else if (d1 == "Tuesday")
            {
                btnSellTuesday.Size= new Size(btnSellTuesday.Width, btnSellTuesday.Height+a);
                btnSellTuesday.Location= new Point(btnSellTuesday.Location.X, btnSellTuesday.Location.Y-a);
            }
            else if (d1 == "Wednesday")
            {
                btnSellWednesday.Location= new Point(btnSellWednesday.Location.X, btnSellWednesday.Location.Y-a);
                btnSellWednesday.Size= new Size(btnSellWednesday.Width, btnSellWednesday.Height+a);
            }
            else if (d1 == "Thursday")
            {
                btnThursday.Size = new Size(btnThursday.Width, btnThursday.Height + a);
                btnThursday.Location = new Point(btnThursday.Location.X, btnThursday.Location.Y - a);
            }
            else if (d1 == "Friday")
            {
                btnSellFriday.Size = new Size(btnSellFriday.Width, btnSellFriday.Height + a);
                btnSellFriday.Location = new Point(btnSellFriday.Location.X, btnSellFriday.Location.Y - a);
            }
            else if (d1 == "Saturday")
            {
                btnSellSaturday.Size = new Size(btnSellSaturday.Width, btnSellSaturday.Height + a);
                btnSellSaturday.Location = new Point(btnSellSaturday.Location.X, btnSellSaturday.Location.Y - a);
            }
            else if(d1 == "Sunday")
            {
                btnSellSunday.Size = new Size(btnSellSunday.Width, btnSellSunday.Height + a);
                btnSellSunday.Location = new Point(btnSellSunday.Location.X, btnSellSunday.Location.Y - a);
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
