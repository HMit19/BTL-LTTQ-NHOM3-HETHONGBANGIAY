using BTL_LTTQ_NHOM3_HETHONGBANGIAY.model;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.manager;
using BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item;
using Guna.UI2.WinForms;
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
        public event UserEventParam inputPoint;
        public event UserEventParam returnMoney;
        public event UserEvent payUp;
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
        public void setInformation(string id, string name, string phone, bool man, DateTime birth, string address, string point)
        {
            this.lblIdCustomer.Text = id;
            this.txtNameCustomer.Text = name;
            this.txtPhoneCustomer.Text = phone;
            this.ckbNam.Checked = man;
            this.ckbNu.Checked = !man;
            string day = birth.Day.ToString();
            string month = birth.Month.ToString();
            string year = birth.Year.ToString();
            this.cbDay.Text = day;
            this.cbMonth.Text = month;
            this.cbYear.Text = year;
            this.txtAddress.Text = address;
            this.lblScoreOfCustomer.Text = point;
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
            if (!checkInformationCustomer())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.pnlPay.BringToFront();
            this.lblNameCustomer.Text = txtNameCustomer.Text;
            this.btnPay.FillColor = Color.Gainsboro;
            this.btnInformation.FillColor = Color.White;
            this.btnPay.CustomBorderThickness = new Padding(0, 0, 0, 2);
            this.btnInformation.CustomBorderThickness = new Padding(0, 0, 0, 0);
            this.lblDatePay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
        private void rdoCash_CheckedChanged(object sender, EventArgs e)
        {
            this.methodPay.Text = "Tiền mặt";
        }

        private void rdoBanking_CheckedChanged(object sender, EventArgs e)
        {
            this.methodPay.Text = "Chuyển khoản";
        }

        private void rdoCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            this.methodPay.Text = "Thẻ tín dụng";
        }

        private void btnPayUp_Click(object sender, EventArgs e)
        {
            payUp?.Invoke();
        }

        private void txtPoint_Leave(object sender, EventArgs e)
        {
            inputPoint?.Invoke(txtPoint.Text);
        }

        private void txtCustomerPayUp_Leave(object sender, EventArgs e)
        {
            returnMoney?.Invoke(txtCustomerPayUp.Text);
        }
        public void resetPoint()
        {
            this.txtPoint.Text = "";
        }
        public void resetMoney()
        {
            this.txtCustomerPayUp.Text = "";
        }
        public string getMoney()
        {
            return this.txtCustomerPayUp.Text;
        }
        public int getPoint()
        {
            string point = txtPoint.Text;
            if (point != "") return Convert.ToInt32(point);
            return 0;
        }

        public void setMoneyReturn(long money)
        {
            this.txtMoneyReturn.Text = money.ToString("#,###");
        }
        private bool checkInformationCustomer()
        {
            if (txtNameCustomer.Text == "")
            {
                txtNameCustomer.Focus();
                return false;
            }
            if (txtPhoneCustomer.Text == "")
            {
                txtPhoneCustomer.Focus();
                return false;
            }
            if (ckbNu.Checked == false && ckbNam.Checked == false)
            {
                return false;
            }
            if (txtAddress.Text == "")
            {
                txtAddress.Focus();
                return false;
            }
            return true;
        }
        private void txtNameCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPhoneCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại 0 - 9!", "Nhập số điện thoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
            if (txtPhoneCustomer.Text.Length == 0 && e.KeyChar != '0')
            {
                MessageBox.Show("Ký tự đầu phải là ký tự 0!", "Nhập số điện thoại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void txtCustomerPayUp_TextChanged(object sender, EventArgs e)
        {
            if (txtCustomerPayUp.Text == "")
            {
                txtMoneyReturn.Text = "";
            }
        }

        private void txtPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                MessageBox.Show("Vui lòng nhập điểm là ký tự 0 - 9!", "Nhập điểm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }

        private void txtCustomerPayUp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                MessageBox.Show("Số tiền chỉ chứa ký tự 0 - 9!", "Nhập số tiền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }
        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(this.cbMonth.Text);
            int year = Convert.ToInt32(this.cbYear.Text);
            int days = DateTime.DaysInMonth(year, month);
            switch (days)
            {
                case 28:
                    this.cbDay.Items.Clear();
                    for (int i = 1; i <= 28; i++)
                    {
                        this.cbDay.Items.Add(i);
                    }
                    break;
                case 29:
                    this.cbDay.Items.Clear();
                    for (int i = 1; i <= 29; i++)
                    {
                        this.cbDay.Items.Add(i);
                    }
                    break;
                case 30:
                    this.cbDay.Items.Clear();
                    for (int i = 1; i <= 30; i++)
                    {
                        this.cbDay.Items.Add(i);
                    }
                    break;
                case 31:
                    this.cbDay.Items.Clear();
                    for (int i = 1; i <= 31; i++)
                    {
                        this.cbDay.Items.Add(i);
                    }
                    break;
            }
        }
        public DateTime getDate()
        {
            return new DateTime(Convert.ToInt32(this.cbYear.Text), Convert.ToInt32(this.cbMonth.Text), Convert.ToInt32(this.cbDay.Text));
        }
        public bool getGender()
        {
            if (ckbNam.Checked) return true;
            return false;
        }
    }
}
