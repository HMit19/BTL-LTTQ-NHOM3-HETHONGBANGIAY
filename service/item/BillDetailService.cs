using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.item
{
    class BillDetailService : IBillDetailService
    {
        private DatabaseHandle databaseHandle = null;
        public BillDetailService()
        {
            databaseHandle = new DatabaseHandle();
        }
        public DetailBillSell find(string id)
        {
            throw new NotImplementedException();
        }

        public List<DetailBillSell> findAll()
        {
            List<DetailBillSell> listDetailBillSell = null;
            try
            {
                listDetailBillSell = new List<DetailBillSell>();
                DataTable dataTable = null;
                string sql = "select * from tDetailBillOfSale";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string idProductDetail = row[0].ToString();
                    string idBill = row[1].ToString();
                    int quantity = Convert.ToInt32(row[2]);
                    listDetailBillSell.Add(new DetailBillSell(idProductDetail, idBill, quantity));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get Detail Bill Sell by Id");
                databaseHandle.closeConnect();
            }
            return listDetailBillSell;
        }

        public List<DetailBillSell> findByBill(string idBill)
        {
            List<DetailBillSell> listDetailBillSell = null;
            try
            {
                listDetailBillSell = new List<DetailBillSell>();
                DataTable dataTable = null;
                string sql = "select * from tDetailBillOfSale where CodeBill = '" + idBill + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string idProductDetail = row[0].ToString();
                    int quantity = Convert.ToInt32(row[2]);
                    listDetailBillSell.Add(new DetailBillSell(idProductDetail, idBill, quantity));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get Detail Bill Sell by IdBill");
                databaseHandle.closeConnect();
            }
            return listDetailBillSell;
        }

        public bool remove(string idBill)
        {
            bool excute = false;
            try
            {
                string sql = "delete from tDetailBillOfSale where CodeBill = '" + idBill + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error remove Detail Bill Sell by IdBill");
                databaseHandle.closeConnect();
            }
            return excute;
        }

        public bool save(DetailBillSell detailBillSell)
        {
            bool excute = false;
            try
            {
                string sql = "insert into tDetailBillOfSale values('" + detailBillSell.IdProductDetail + "', '" + detailBillSell.IdBill + "', " + detailBillSell.Quantity + ")";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error save Detail Bill Sell");
                databaseHandle.closeConnect();
            }
            return excute;
        }

        public bool update(string idBill, DetailBillSell detailBillSell)
        {
            bool excute = false;
            try
            {
                string sql = "update tDetailBillOfSale set DetailProductCode = '" + detailBillSell.IdProductDetail + "', Quantity = " + detailBillSell.Quantity + " where CodeBill = '" + idBill + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error update Detail Bill Sell");
                databaseHandle.closeConnect();
            }
            return excute;
        }
    }
}
