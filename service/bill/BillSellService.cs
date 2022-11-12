using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.bill
{
    class BillSellService : IBillSellService
    {
        private IDatabaseHandle databaseHandle;

        public BillSellService()
        {
            databaseHandle = new DatabaseHandle();
        }
        public BillSell find(string idBill)
        {
            BillSell billSell = null;
            try
            {
                DataTable dataTable = null;
                string sql = "select * from tBillOfSale where CodeBill = '" + idBill + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    DateTime date = Convert.ToDateTime(row[1]);
                    string method = row[2].ToString();
                    string idEmployee = row[3].ToString();
                    string idCustomer = row[4].ToString();
                    int discount = Convert.ToInt32(row[5]);
                    billSell = new BillSell(idBill, date, method, idEmployee, idCustomer, discount);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get Bill selled by Id");
                databaseHandle.CloseConnect();
            }
            return billSell;
        }

        public List<BillSell> findAll()
        {
            List<BillSell> listBillSell = null;
            try
            {
                listBillSell = new List<BillSell>();
                DataTable dataTable = null;
                string sql = "select * from tBillOfSale";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string idBill = row[0].ToString();
                    DateTime date = Convert.ToDateTime(row[1]);
                    string method = row[2].ToString();
                    string idEmployee = row[3].ToString();
                    string idCustomer = row[4].ToString();
                    int discount = Convert.ToInt32(row[5]);
                    listBillSell.Add(new BillSell(idBill, date, method, idEmployee, idCustomer, discount));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get list Bill selled");
                databaseHandle.CloseConnect();
            }
            return listBillSell;
        }

        public List<BillSell> findByCustomer(string idCustomer)
        {
            List<BillSell> listBillSell = null;
            try
            {
                listBillSell = new List<BillSell>();
                DataTable dataTable = null;
                string sql = "select * from tBillOfSale where CustomerCode = '" + idCustomer + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string idBill = row[0].ToString();
                    DateTime date = Convert.ToDateTime(row[1]);
                    string method = row[2].ToString();
                    string idEmployee = row[3].ToString();
                    int discount = Convert.ToInt32(row[5]);
                    listBillSell.Add(new BillSell(idBill, date, method, idEmployee, idCustomer, discount));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get list Bill selled");
                databaseHandle.CloseConnect();
            }
            return listBillSell;
        }

        public List<BillSell> findByEmployee(string idEmployee)
        {
            List<BillSell> listBillSell = null;
            try
            {
                listBillSell = new List<BillSell>();
                DataTable dataTable = null;
                string sql = "select * from tBillOfSale where EmployeeCode = '" + idEmployee + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string idBill = row[0].ToString();
                    DateTime date = Convert.ToDateTime(row[1]);
                    string method = row[2].ToString();
                    string idCustomer = row[4].ToString();
                    int discount = Convert.ToInt32(row[5]);
                    listBillSell.Add(new BillSell(idBill, date, method, idEmployee, idCustomer, discount));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get list Bill selled");
                databaseHandle.CloseConnect();
            }
            return listBillSell;
        }

        public bool remove(string idBill)
        {
            bool excute = false;
            try
            {
                string sql = "delete from tBillOfSale where CodeBill = '" + idBill + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error remove Bill Selled");
                databaseHandle.CloseConnect();
            }
            return excute;
        }
        public bool save(BillSell billSell)
        {
            bool excute = false;
            try
            {
                string sql = "insert into tBillOfSale values ('" + billSell.Id + "', '" + billSell.Date + "','" + billSell.PayMethod + "','"
                    + billSell.IdEmployee + "', '" + billSell.IdCustomer + "'," + billSell.Discount + ")";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error insert Bill after selled");
                databaseHandle.CloseConnect();
            }
            return excute;
        }

        public bool update(string idBill, BillSell billSell)
        {
            bool excute = false;
            try
            {
                string sql = "update tBillOfSale set DateSale = '" + billSell.Date + "', PaymentMethods = '" + billSell.PayMethod + "', EmployeeCode = '" + billSell.IdEmployee +
                    "', CustomerCode = '" + billSell.IdCustomer + "', Discount = " + billSell.Discount + " where CodeBill = '" + idBill + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error update Bill");
                databaseHandle.CloseConnect();
            }
            return excute;
        }
    }
}
