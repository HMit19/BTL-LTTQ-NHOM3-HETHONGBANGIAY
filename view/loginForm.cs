﻿using BTL_LTTQ_NHOM3_HETHONGBANGIAY.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account account = new Account(textBox1.Text, textBox2.Text);
            //label3.Text = textBox1.Text + " - " + textBox2.Text;
            label3.Text = account.getUsername() + " - " + account.getPassword();
        }
    }
}
