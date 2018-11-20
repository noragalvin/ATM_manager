using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIs
{
    public partial class Confirmation : Form
    {
        private string errorMessage;
        public Confirmation(string errorMessage = null)
        {
            this.errorMessage = errorMessage;
            InitializeComponent();
        }

        private void btnSideBar3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Feature featureForm = new Feature();
            featureForm.Show();
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Confirmation_Load(object sender, EventArgs e)
        {
            lbError.Text = this.errorMessage;
        }

 

    }
}
