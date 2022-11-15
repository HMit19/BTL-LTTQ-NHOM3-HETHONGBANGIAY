using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.customer
{
    class CustomerService : ICustomerService
    {
        private IDatabaseHandle databaseHandle = null;
        public CustomerService()
        {
            databaseHandle = new DatabaseHandle();
        }
        public Customer find(string id)
        {
            Customer customer = null;
            try
            {
                DataTable dataTable = null;
                string sql = "select * from tCustomer where CustomerCode = '" + id + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string name = row[1].ToString();
                    string gender = row[2].ToString();
                    string address = row[3].ToString();
                    string phone = row[4].ToString();
                    long point = Convert.ToInt32(row[5]);
                    DateTime birth = Convert.ToDateTime(row[6]);
                    customer = new Customer(id, name, gender, birth, address, phone, point);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get Customer by Id");
                databaseHandle.CloseConnect();
            }
            return customer;
        }
        public Customer findByPhone(string phone)
        {
            Customer customer = null;
            try
            {
                DataTable dataTable = null;
                string sql = "select * from tCustomer where PhoneNumber = '" + phone + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row[0].ToString();
                    string name = row[1].ToString();
                    string gender = row[2].ToString();
                    string address = row[3].ToString();
                    long point = Convert.ToInt32(row[5]);
                    DateTime birth = Convert.ToDateTime(row[6]);
                    customer = new Customer(id, name, gender, birth, address, phone, point);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get Customer by Phone");
                databaseHandle.CloseConnect();
            }
            return customer;
        }

        public List<Customer> findAll()
        {
            List<Customer> listCustomer = null;
            try
            {
                listCustomer = new List<Customer>();
                DataTable dataTable = null;
                string sql = "select * from tCustomer";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string customerCode = row[0].ToString();
                    string name = row[1].ToString();
                    string gender = row[2].ToString();
                    string address = row[3].ToString();
                    string phone = row[4].ToString();
                    long point = Convert.ToInt32(row[5]);
                    DateTime birth = Convert.ToDateTime(row[6]);
                    listCustomer.Add(new Customer(customerCode, name, gender, birth, address, phone, point));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error list Customer");
                databaseHandle.CloseConnect();
            }
            return listCustomer;
        }

        public bool remove(string id)
        {
            bool excute = false;
            try
            {
                string sql = "delete from tCustomer where CustomerCode = '" + id + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error remove Customer by Id");
                databaseHandle.CloseConnect();
            }
            return excute;
        }

        public bool save(Customer customer)
        {
            bool excute = false;
            try
            {
                string sql = "insert into tCustomer values ('" + customer.Id + "', '" + customer.Name + "', '" + customer.Gender + "', '" + customer.Address + "', '" + customer.Phone + "', " + customer.Point + ", '" + customer.Birth + "')";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error insert Customer");
                databaseHandle.CloseConnect();
            }
            return excute;
        }

        public bool update(string id, Customer customer)
        {
            bool excute = false;
            try
            {
                string sql = "update tCustomer set Name = '" + customer.Name + "', Gender = '" + customer.Gender
                    + "', Address = '" + customer.Address + "', Phone = '" + customer.Phone + "', Point = " + customer.Point + " where CustomerCode = '" + id + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error update Customer by Id");
                databaseHandle.CloseConnect();
            }
            return excute;
        }
    }
}
