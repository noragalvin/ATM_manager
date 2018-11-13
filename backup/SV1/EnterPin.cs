using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV2
{
    public partial class EnterPin : Form
    {
        public EnterPin()
        {
            InitializeComponent();
        }

        private void EnterPin_Load(object sender, EventArgs e)
        {
            txtPIN.PasswordChar = '*';
        }

        private void btnNumber1_Click(object sender, EventArgs e)
        {
            txtPIN.AppendText("1");
        }

        private void btnNumber2_Click(object sender, EventArgs e)
        {
            txtPIN.AppendText("2");
        }

        private void btnNumber3_Click(object sender, EventArgs e)
        {
            txtPIN.AppendText("3");
        }

        private void btnNumber4_Click(object sender, EventArgs e)
        {
            txtPIN.AppendText("4");
        }

        private void btnNumber5_Click(object sender, EventArgs e)
        {
            txtPIN.AppendText("5");
        }

        private void btnNumber6_Click(object sender, EventArgs e)
        {
            txtPIN.AppendText("6");
        }

        private void btnNumber7_Click(object sender, EventArgs e)
        {
            txtPIN.AppendText("7");
        }

        private void btnNumber8_Click(object sender, EventArgs e)
        {
            txtPIN.AppendText("8");
        }

        private void btnNumber9_Click(object sender, EventArgs e)
        {
            txtPIN.AppendText("9");
        }

        private void btnNumber0_Click(object sender, EventArgs e)
        {
            txtPIN.AppendText("0");
        }

       
    }
}
