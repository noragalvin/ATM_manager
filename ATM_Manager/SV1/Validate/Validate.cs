using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validate
{
    public partial class Validate : Form
    {
        Bitmap theVao = Properties.Resources.TheRa;

        public Validate()
        {
            InitializeComponent();
        }

        private void pbThe_Click(object sender, EventArgs e)
        {
            pbThe.Image = theVao;
            this.Hide();
            (new NhapThe()).Show();
        }

        private void Validate_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
  
    }
}
