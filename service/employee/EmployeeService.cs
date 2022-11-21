using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.employee
{
    class EmployeeService : IEmployeeService
    {
        private DatabaseHandle databaseHandle = null;
        public EmployeeService()
        {
            databaseHandle = new DatabaseHandle();
        }
        public Employee find(string id)
        {
            Employee employee = null;
            try
            {
                DataTable dataTable = null;
                string sql = "select * from tEmployee where EmployeeCode = '" + id + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string name = row[1].ToString();
                    string cIC = row[2].ToString();
                    string gender = row[3].ToString();
                    DateTime birth = Convert.ToDateTime(row[4]);
                    string address = row[5].ToString();
                    string phone = row[6].ToString();
                    string username = row[7].ToString();
                    bool status = Convert.ToBoolean(row[8]);
                    employee = new Employee(id, name, cIC, gender, birth, address, phone, username, status);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get Employee by Id");
                databaseHandle.closeConnect();
            }
            return employee;
        }

        public Employee findByUsername(string username)
        {
            Employee employee = null;
            try
            {
                DataTable dataTable = null;
                string sql = "select * from tEmployee where UserName = '" + username + "'";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string id = row[0].ToString();
                    string name = row[1].ToString();
                    string cIC = row[2].ToString();
                    string gender = row[3].ToString();
                    DateTime birth = Convert.ToDateTime(row[4]);
                    string address = row[5].ToString();
                    string phone = row[6].ToString();
                    bool status = Convert.ToBoolean(row[8]);
                    employee = new Employee(id, name, cIC, gender, birth, address, phone, username, status);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get Employee by Username");
                databaseHandle.closeConnect();
            }
            return employee;
        }

        public List<Employee> findAll()
        {
            List<Employee> listEmployee = null;
            try
            {
                listEmployee = new List<Employee>();
                DataTable dataTable = null;
                string sql = "select * from tEmployee";
                dataTable = databaseHandle.dataReader(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    string employeeCode = row[0].ToString();
                    string name = row[1].ToString();
                    string cIC = row[2].ToString();
                    string gender = row[3].ToString();
                    DateTime birth = Convert.ToDateTime(row[4]);
                    string address = row[5].ToString();
                    string phone = row[6].ToString();
                    string username = row[7].ToString();
                    bool status = Convert.ToBoolean(row[8]);
                    listEmployee.Add(new Employee(employeeCode, name, cIC, gender, birth, address, phone, username, status));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error get List Employee");
                databaseHandle.closeConnect();
            }
            return listEmployee;
        }

        public bool remove(string id)
        {
            bool excute = false;
            try
            {
                string sql = "delete from tEmployee where EmployeeCode = '" + id + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error remove Employee by Id");
                databaseHandle.closeConnect();
            }
            return excute;
        }

        public bool save(Employee employee)
        {
            bool excute = false;
            try
            {
                string sql = "insert into tEmployee values ('" + employee.Id + "', '" + employee.Name + "', '" + employee.CIC + "', '" + employee.Gender + "', '" + employee.Birth
                    + "', '" + employee.Address + "', '" + employee.Phone + "', '" + employee.Username + "', '" + employee.Status + "')";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error insert Employee");
                databaseHandle.closeConnect();
            }
            return excute;
        }

        public bool update(string id, Employee employee)
        {
            bool excute = false;
            try
            {
                string sql = "update tEmployee set Name = '" + employee.Name + "', ID = '" + employee.CIC + "', Gender = '" + "', DOB = '" + employee.Birth + "', Address = '"
                    + employee.Address + "', PhoneNumber = '" + employee.Phone + "', Username = '" + employee.Username + "', Status = '" + employee.Status
                    + "' where EmployeeCode = '" + id + "'";
                excute = databaseHandle.dataChange(sql);
            }
            catch (Exception)
            {
                MessageBox.Show("Error update Employee");
                databaseHandle.closeConnect();
            }
            return excute;
        }
    }
}
