using BULs;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Validate
{
    public partial class EnterPin : Form
    {
        Bitmap theRa = Properties.Resources.TheVao;
        CardBUL cardBUL = new CardBUL();

        private string accountNo;
        

        public EnterPin(string accountNo)
        {
            this.accountNo = accountNo;
            InitializeComponent();
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

        private void btnNumberEnter_Click(object sender, EventArgs e)
        {
            CardDTO card = cardBUL.getValidCard(txtPIN.Text, this.accountNo);
            if (card != null)
            {
                (new ChooseLanguage(card, this.accountNo)).Show();
                this.Hide();

            }
            else
            {
                this.Hide();
                Validate validateForm = new Validate();
                validateForm.Show();
                validateForm.pbThe.Image = theRa;
            }
        }

        private void EnterPin_Load(object sender, EventArgs e)
        {
            txtPIN.PasswordChar = '*';
            this.CenterToScreen();
        }

        private void btnNumberClear_Click(object sender, EventArgs e)
        {
            txtPIN.Clear();
        }

        private void btnNumberCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Validate validateForm = new Validate();
            validateForm.Show();
            validateForm.pbThe.Image = theRa;
        }
    }
}
