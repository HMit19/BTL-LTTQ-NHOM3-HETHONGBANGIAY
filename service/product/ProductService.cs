using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.admin.product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.product
{
    class ProductService : IProductService
    {
        private IDatabaseHandle databaseHandle = null;
        public ProductService()
        {
            databaseHandle = new DatabaseHandle();
        }
        public Product find(string id)
        {
            Product product = null;
            try
            {
                DataTable dataTable = null;
                string sql = "select * from tProduct where ProductCode = '" + id + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string name = row[1].ToString();
                    string image = row[2].ToString();
                    string idCategory = row[3].ToString();
                    product = new Product(id, name, image, idCategory);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get Product by Id");
                databaseHandle.closeConnect();
            }
            return product;
        }

        public List<Product> findAll()
        {
            List<Product> listProduct = null;
            try
            {
                listProduct = new List<Product>();
                DataTable dataTable = null;
                string sql = "select * from tProduct";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row[0].ToString();
                    string name = row[1].ToString();
                    string image = row[2].ToString();
                    string idCategory = row[3].ToString();
                    bool status = (bool)row[4];
                    listProduct.Add(new Product(id, name, image, idCategory, status));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error list Product");
                databaseHandle.closeConnect();
            }
            return listProduct;
        }
        
        public List<Product> findAllByCategory(string idCategory)
        {
            List<Product> listProduct = null;
            try
            {
                listProduct = new List<Product>();
                DataTable dataTable = null;
                string sql = "select * from tProduct where CategoryCode = '" + idCategory + "'";  
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string productCode = row[0].ToString();
                    string name = row[1].ToString();
                    string image = row[2].ToString();
                    bool status = (bool)row[4];
                    listProduct.Add(new Product(productCode, name, image, idCategory, status));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error list Product by Category");
                databaseHandle.closeConnect();
            }
            return listProduct;
        }

        public bool remove(string id)
        {
            bool excute = false;
            try
            {
                string sql = "delete from tProduct where ProductCode = '" + id + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error remove Product by Id");
                databaseHandle.closeConnect();
            }
            return excute;
        }

        public bool save(Product product)
        {
            bool excute = false;
            try
            {
                string sql = "insert into tProduct values ('" + product.Id + "', '" + product.Name + "', '" + product.Image + "', '" + product.IdCategory + "')";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error insert Product");
                databaseHandle.closeConnect();
            }
            return excute;
        }

        public bool update(string id, Product product)
        {
            bool excute = false;
            try
            {
                string sql = "update tProduct set ProductCode = '" + product.Id + "', NameProduct = '" + product.Name + "', Image = '" + product.Image
                    + "', CategoryCode = '" + product.IdCategory + "' where CustomerCode = '" + id + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error update Product by Id");
                databaseHandle.closeConnect();
            }
            return excute;
        }
    }
}
