using BTL_LTTQ_NHOM3_HETHONGBANGIAY.controller;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.employee;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.admin.product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager
{
    public partial class frmManager : Form
    {
        private StoreController storeController = null;
        private Employee employee = null;
        private frmLogin loginView = null;

        public frmManager(Employee employee, int isAdmin, frmLogin loginView)
        {
            this.employee = employee;
            this.loginView = loginView;
            InitializeComponent();
            loadManager(isAdmin);
        }
        private void loadManager(int isAdmin)
        {
            this.idEmployee.Text = employee.Id;
            this.nameEmployee.Text = employee.Name;
            this.nameRole.Text = isAdmin > 0 ? "Admin" : "";
            this.pnlSidbarOption.Controls.Add(this.btnHome);
            this.pnlSidbarOption.Controls.Add(this.btnSell);
            this.pnlSidbarOption.Controls.Add(this.btnProduct);
            this.pnlSidbarOption.Controls.Add(this.btnBill);
            this.pnlSidbarOption.Controls.Add(this.btnEmployee);
            this.pnlSidbarOption.Controls.Add(this.btnCustomer);
            this.pnlSidbarOption.Controls.Add(this.btnProvider);
            if (isAdmin == 0)
            {
                this.pnlSidbarOption.Controls.Remove(this.btnProduct);
                this.pnlSidbarOption.Controls.Remove(this.btnEmployee);
                this.pnlSidbarOption.Controls.Remove(this.btnProvider);
            }
        }
        private void btnSell_Click(object sender, EventArgs e)
        {
            if (storeController == null)
            {
                storeController = new StoreController(this, storeControl, cartControl);
            }
            showStore();
        }
        public void showStore()
        {
            bringToFontUsercontrol(storeControl);
        }

        public void reLoad()
        {
            storeController.reLoad();
            bringToFontUsercontrol(storeControl);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(homeControl);
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(listProduct);
            listProduct.updateListProduct();
        }

        private void bringToFontUsercontrol(UserControl namePanel)
        {
            namePanel.BringToFront();
        }

        public Employee getEmployee()
        {
            return employee;
        }
        public void showCart()
        {
            bringToFontUsercontrol(cartControl);
        }
        public void showListProduct()
        {
            bringToFontUsercontrol(listProduct);
            listProduct.updateListProduct();
        }
        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(billControl);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(employeeControl);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(customerControl);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(providerControl);
        }
        public void showCreateProduct()
        {
            bringToFontUsercontrol(createProduct);
            createProduct.reset();
        }
        private void listProduct_ButtonCreateProductClick(object sender, EventArgs e)
        {
            showCreateProduct();
        }
        private void listProduct_ButtonEditClick(object sender, EventArgs e)
        {
            bringToFontUsercontrol(editProduct);
            editProduct.LoadEditProduct();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                loginView.Visible = true;
            }
        }
    }
}
