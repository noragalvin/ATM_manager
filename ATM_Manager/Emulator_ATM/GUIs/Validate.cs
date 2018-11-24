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
    public partial class Validate : Form
    {
        Bitmap theVao = Properties.Resources.TheRa;
        private string accountNo = "45010005597808";

        public Validate()
        {
            InitializeComponent();
        }

        private void pbThe_Click(object sender, EventArgs e)
        {
            pbThe.Image = theVao;
            this.Hide();
            (new EnterPin(this.accountNo)).Show();
        }

        private void Validate_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
