using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChisloIzm
{
    public partial class passwordForm : Form
    {
        mainForm mF;

        public passwordForm(mainForm f)
        {
            InitializeComponent();
            mF = f;
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            mF.user_pass = txtPassword.Text.PadRight(10, '0');
            this.Close();
        }
    }
}
