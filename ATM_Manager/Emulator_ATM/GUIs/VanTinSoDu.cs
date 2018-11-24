using BULs;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIs
{
    public partial class VanTinSoDu : Form
    {
        AccountBUL accountBUL = new AccountBUL();
        string stk;
        ResourceManager rm;
        CardDTO card;

        public VanTinSoDu(ResourceManager rm, CardDTO card = null, string stk = null)
        {
            this.stk = stk;
            this.rm = rm;
            this.card = card;
            InitializeComponent();
        }

        private void VanTinSoDu_Load(object sender, EventArgs e)
        {
            AccountDTO acc = accountBUL.VanTinSoDu(stk);
            lblMoney.Text = CurrencyFormat(acc.Balance.ToString());
            this.CenterToScreen();
            label1.Text = rm.GetString("vanTin_txt1");
            label2.Text = rm.GetString("vanTin_txt2");
            btnNext.Text = rm.GetString("next");

        }

        public string CurrencyFormat(string currency)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return double.Parse(currency).ToString("#,###", cul.NumberFormat) + " VND";
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Confirmation(this.rm, this.card, this.stk)).Show();
        }

        private void btnNumberCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Validate()).Show();
        }
    }
}
