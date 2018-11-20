using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validate
{
    public partial class Term : Form
    {
        public Term()
        {
            InitializeComponent();
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Fee feeForm = new Fee();
            feeForm.Show();
        }
    }
}
