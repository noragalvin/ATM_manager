using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV1
{
    public partial class Validation : Form
    {
        public Validation()
        {
            InitializeComponent();
        }

        private void pnDutThe_Click(object sender, EventArgs e)
        {
            ChooseLanguage cl = new ChooseLanguage();
            this.Hide();
            cl.ShowDialog();
            
        }








    }
}
