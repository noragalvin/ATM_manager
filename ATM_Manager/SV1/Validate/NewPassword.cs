﻿using DTOs;
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
    public partial class NewPassword : Form
    {
        private ResourceManager rm;
        private CardDTO card;

        public NewPassword(ResourceManager rm, CardDTO card = null)
        {
            this.rm = rm;
            this.card = card;
            InitializeComponent();
        }

        private void NewPassword_Load(object sender, EventArgs e)
        {
            txtPin.PasswordChar = '*';
            this.CenterToScreen();
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
            this.Hide();
            (new Validate()).Show();
        }

        private void btnNumberEnter_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ConfirmationPassword(this.rm, this.card, txtPin.Text)).Show();
        }
    }
}
