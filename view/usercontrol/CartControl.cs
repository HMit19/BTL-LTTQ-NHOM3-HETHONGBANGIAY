using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol
{
    public partial class CartControl : UserControl
    {
        public event UserEvent removeAllinCart;
        public event UserEventParam findCustomer;
        public CartControl()
        {
            InitializeComponent();
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            removeAllinCart?.Invoke();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            findCustomer?.Invoke(this.txtSearch.Text);
        }
        public void setInformation(string name, string phone, bool man, DateTime birth, string address, string point)
        {
            this.txtNameCustomer.Text = name;
            this.txtPhoneCustomer.Text = phone;
            this.ckbNam.Checked = man;
            this.ckbNu.Checked = !man;
            this.dtBirth.Value = birth;
            this.txtAddress.Text = address;
            this.lblScoreOfCustomer.Text = point;
        }
        public void setGenderCustomer(bool man = true)
        {
            this.ckbNam.Checked = man;
            this.ckbNu.Checked = !man;
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            this.pnlCustomer.BringToFront();
            this.btnInformation.FillColor = Color.Gainsboro;
            this.btnPay.FillColor = Color.White;
            this.btnInformation.CustomBorderThickness = new Padding(0, 0, 0, 2);
            this.btnPay.CustomBorderThickness = new Padding(0, 0, 0, 0);
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            this.pnlPay.BringToFront();
            this.lblNameCustomer.Text = txtNameCustomer.Text; 
            this.btnPay.FillColor = Color.Gainsboro;
            this.btnInformation.FillColor = Color.White;
            this.btnPay.CustomBorderThickness = new Padding(0, 0, 0, 2);
            this.btnInformation.CustomBorderThickness = new Padding(0, 0, 0, 0);
            this.lblDatePay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
