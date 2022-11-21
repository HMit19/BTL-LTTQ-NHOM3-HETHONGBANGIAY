using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.category
{
    class CategoryService : ICategoryService
    {
        private IDatabaseHandle databaseHandle;
        public CategoryService()
        {
            databaseHandle = new DatabaseHandle();
        }
        public Category find(string id)
        {
            Category category = null;
            try
            {
                DataTable dataTable = null;
                string sql = "select * from tCategory where CategoryCode = '" + id + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string name = row[1].ToString();
                    string origin = row[2].ToString();
                    category = new Category(id, name, origin);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get Category by Id");
                databaseHandle.closeConnect();
            }
            return category;
        }
        public Category findByName(string name)
        {
            Category category = null;
            try
            {
                DataTable dataTable = null;
                string sql = "select * from tCategory where Brand = '" + name + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string CategoryCode = row[0].ToString();
                    string origin = row[2].ToString();
                    category = new Category(CategoryCode, name, origin);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get Category by Id");
                databaseHandle.closeConnect();
            }
            return category;
        }

        public List<Category> findAll()
        {
            List<Category> listCategory = null;
            try
            {
                listCategory = new List<Category>();
                DataTable dataTable = null;
                string sql = "select * from tCategory";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string categoryCode = row[0].ToString();
                    string name = row[1].ToString();
                    string origin = row[2].ToString();
                    listCategory.Add(new Category(categoryCode, name, origin));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get list Category");
                databaseHandle.closeConnect();
            }
            return listCategory;
        }

        public bool remove(string id)
        {
            bool excute = false;
            try
            {
                string sql = "delete from tCategory where id = '" + id + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error remove Category by Id");
                databaseHandle.closeConnect();
            }
            return excute;
        }

        public bool save(Category category)
        {
            bool excute = false;
            try
            {
                string sql = "insert into tCategory values ('" + category.Id + "', '" + category.Name + "', '" + category.Origin + "')";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error insert Category");
                databaseHandle.closeConnect();
            }
            return excute;
        }

        public bool update(string id, Category category)
        {
            bool excute = false;
            try
            {
                string sql = "update tCategory set Brand = '" + category.Name + "', Origin = '" + category.Origin + "' where id = '" + category.Id + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error update Category by Id");
                databaseHandle.closeConnect();
            }
            return excute;
        }
    }
}
