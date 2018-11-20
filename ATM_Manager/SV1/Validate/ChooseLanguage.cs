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
    public partial class ChooseLanguage : Form
    {
        public ChooseLanguage()
        {
            InitializeComponent();
        }



        private void btnSideBar3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Term termForm = new Term();
            termForm.Show();
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Term termForm = new Term();
            termForm.Show();
        }
    }
}
