using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTTQ_NHOM3_HETHONGBANGIAY.controller
{
    class LoginController
    {
        private frmLogin loginView;

        public LoginController(frmLogin loginView)
        {
            this.loginView = loginView;
            Application.Run(loginView);
        }
    }
}
