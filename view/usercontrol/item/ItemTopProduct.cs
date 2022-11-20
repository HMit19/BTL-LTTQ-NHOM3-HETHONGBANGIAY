using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.view.usercontrol.item
{
    public partial class ItemTopProduct : UserControl
    {  
        public ItemTopProduct(string name, string pic)
        {
            InitializeComponent();
            this.name.Text = name;
            OpenFileDialog odlg = new OpenFileDialog();
            odlg.InitialDirectory = Application.StartupPath.ToString() + "\\Images";
            //image.Image= Image.FromFile(odlg.InitialDirectory+"\\"+pic);
            
        }
    }
}
