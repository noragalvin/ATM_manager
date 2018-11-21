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
    public partial class InHoaDon : Form
    {
        public InHoaDon()
        {
            InitializeComponent();
        }


        private void btnSideBar3_Click(object sender, EventArgs e)
        {
            (new Bill()).Show();
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
