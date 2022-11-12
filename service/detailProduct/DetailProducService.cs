using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.detailProduct
{
    class DetailProductService : IDetailProductService
    {
        private IDatabaseHandle databaseHandle = null;
        public DetailProductService()
        {
            databaseHandle = new DatabaseHandle();
        }
        public DetailProduct find(string id)
        {
            DetailProduct product = null;
            try
            {
                DataTable dataTable = null;
                string sql = "select * from tDetailProduct where DetailProductCode = '" + id + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string productCode = row[1].ToString();
                    int size = Convert.ToInt32(row[2]);
                    string color = row[3].ToString();
                    long priceIn = Convert.ToInt64(row[4]);
                    long priceOut = Convert.ToInt64(row[5]);
                    int quantity = Convert.ToInt32(row[6]);
                    bool status = Convert.ToInt32(row[7]) > 0;
                    product = new DetailProduct(id, productCode, size, color, priceIn, priceOut, quantity, status);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get DetailProduct by Id");
                databaseHandle.CloseConnect();
            }
            return product;
        }

        public List<DetailProduct> findAll()
        {
            List<DetailProduct> listProduct = null;
            try
            {
                listProduct = new List<DetailProduct>();
                DataTable dataTable = null;
                string sql = "select * from tDetailProduct";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string detailProductCode = row[0].ToString();
                    string productCode = row[1].ToString();
                    int size = Convert.ToInt32(row[2]);
                    string color = row[3].ToString();
                    long priceIn = Convert.ToInt64(row[4]);
                    long priceOut = Convert.ToInt64(row[5]);
                    int quantity = Convert.ToInt32(row[6]);
                    bool status = Convert.ToInt32(row[7]) > 0;
                    listProduct.Add(new DetailProduct(detailProductCode, productCode, size, color, priceIn, priceOut, quantity, status));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error list DetailProduct");
                databaseHandle.CloseConnect();
            }
            return listProduct;
        }

        public List<DetailProduct> findAllByProduct(string idProduct)
        {
            List<DetailProduct> listProduct = null;
            try
            {
                listProduct = new List<DetailProduct>();
                DataTable dataTable = null;
                string sql = "select * from tDetailProduct where ProductCode = '" + idProduct + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string detailProductCode = row[0].ToString();
                    int size = Convert.ToInt32(row[2]);
                    string color = row[3].ToString();
                    long priceIn = Convert.ToInt64(row[4]);
                    long priceOut = Convert.ToInt64(row[5]);
                    int quantity = Convert.ToInt32(row[6]);
                    bool status = Convert.ToInt32(row[7]) > 0;
                    listProduct.Add(new DetailProduct(detailProductCode, idProduct, size, color, priceIn, priceOut, quantity, status));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error list DetailProduct by Id Product");
                databaseHandle.CloseConnect();
            }
            return listProduct;
        }

        public bool remove(string id)
        {
            bool excute = false;
            try
            {
                string sql = "delete from tDetailProduct where DetailProductCode = '" + id + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error remove DetailProduct by Id");
                databaseHandle.CloseConnect();
            }
            return excute;
        }

        public bool save(DetailProduct detailProduct)
        {
            bool excute = false;
            try
            {
                string sql = "insert into tDetailProduct values ('" + detailProduct.IdProductDetail + "', '" + detailProduct.IdProduct + "', "
                    + detailProduct.Size + ", '" + detailProduct.Color + "', " + detailProduct.PriceIn + ", " + detailProduct.PriceOut + ", " + detailProduct.Quantity + ", " + detailProduct.Status + ")";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error insert DetailProduct");
                databaseHandle.CloseConnect();
            }
            return excute;
        }

        public bool update(string id, DetailProduct detailProduct)
        {
            bool excute = false;
            try
            {
                string sql = "update tDetailProduct set ProductCode = '" + detailProduct.IdProduct + "', Size = " + detailProduct.Size
                    + ", Color = '" + detailProduct.Color + "', importPrice = " + detailProduct.PriceIn + ", Price = " + detailProduct.PriceOut + ", Quantity = " + detailProduct.Quantity
                    + ", Status = " + detailProduct.Status + " where DetailProductCode = '" + id + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error update DetailProduct by Id");
                databaseHandle.CloseConnect();
            }
            return excute;
        }
    }
}
