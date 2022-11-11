using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view
{
    public partial class ImportBillForm : Form
    {
        public ImportBillForm()
        {
            InitializeComponent();
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            dtpTime.CustomFormat = "dd-MM-yyyy";
        }
    }
}
