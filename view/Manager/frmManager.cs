using BTL_LTTQ_NHOM3_HETHONGBANGIAY.controller;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.DAO.service.employee;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol;
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
        public frmManager(Employee employee)
        {
            this.employee = employee;
            InitializeComponent();
            this.idEmployee.Text = employee.Id;
        }
        private void btnSell_Click(object sender, EventArgs e)
        {
            if (storeController == null)
            {
                storeController = new StoreController(this, storeControl, cartControl);
            }
            bringToFontUsercontrol(storeControl);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(homeControl);
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            bringToFontUsercontrol(listProduct);
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
        private void btnTurnOff_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
