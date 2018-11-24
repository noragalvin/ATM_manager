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

namespace GUIs
{
    public partial class NhapSTK : Form
    {
        private ResourceManager rm;
        private CardDTO card;
        private string accountNo;

        public NhapSTK(ResourceManager rm, CardDTO card = null, string accountNo = null)
        {
            this.rm = rm;
            this.card = card;
            this.accountNo = accountNo;
            InitializeComponent();
        }

        private void NhapSTK_Load(object sender, EventArgs e)
        {
            lblStk.Text = this.accountNo;
            this.CenterToScreen();
            label1.Text = rm.GetString("nhapSTK_txt1");
            label2.Text = rm.GetString("nhapSTK_txt2");
            label4.Text = rm.GetString("nhapSTK_txt3");

            lblEnterLeft.Text = rm.GetString("fee_enterLeft");
            lblEnterRight.Text = rm.GetString("fee_enterRight");
            lblCancelLeft.Text = rm.GetString("fee_cancelLeft");
            lblCancelRight.Text = rm.GetString("fee_cancelRight");



        }

        private void btnNumber1_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("1");
        }

        private void btnNumber2_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("2");
        }

        private void btnNumber3_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("3");
        }

        private void btnNumber4_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("4");
        }

        private void btnNumber5_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("5");
        }

        private void btnNumber6_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("6");
        }

        private void btnNumber7_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("7");
        }

        private void btnNumber8_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("8");
        }

        private void btnNumber9_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("9");
        }

        private void btnNumber0_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("0");
        }

        private void btnNumberClear_Click(object sender, EventArgs e)
        {
            txtPin.Clear();
        }

        private void btnNumberCancel_Click(object sender, EventArgs e)
        {
            Bitmap coTien = Properties.Resources.TienRa;
            (new Validate(coTien)).Show();
        }

        private void btnNumberEnter_Click(object sender, EventArgs e)
        {
            this.Hide();
            string stkNhan = txtPin.Text;
            (new SoTienChuyen(this.rm, this.card, this.accountNo, stkNhan)).Show();
        }

    }
}
