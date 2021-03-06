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

namespace GUIs
{
    public partial class Confirmation : Form
    {
        private ResourceManager rm;
        private CardDTO card;
        private string accountNo;
        private string errorMessage;

        public Confirmation(ResourceManager rm, CardDTO card = null, string accountNo = null, string errorMessage = null)
        {
            this.rm = rm;
            this.card = card;
            this.accountNo = accountNo;
            this.errorMessage = errorMessage;
            InitializeComponent();
        }

        private void btnSideBar3_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Feature(this.rm, this.card, this.accountNo)).Show();
            
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bitmap coTien = Properties.Resources.TienRa;
            (new Validate(coTien)).Show();
        }

        private void Confirmation_Load(object sender, EventArgs e)
        {
            lbError.Text = this.errorMessage;
            lbWelcomeVN.Text = rm.GetString("confirmation_txt1");
            btnYes.Text = rm.GetString("yes");
            btnNo.Text = rm.GetString("no");
            this.CenterToScreen();
        }
    }
}
