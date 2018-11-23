using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV3
{
    public partial class Feature : Form
    {
        public Feature()
        {
            InitializeComponent();
        }

        private void btnSideBar6_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new NhapSTK()).Show();
            
        }

        private void Feature_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
