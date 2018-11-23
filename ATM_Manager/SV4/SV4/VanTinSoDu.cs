using BULs;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV4
{
    public partial class VanTinSoDu : Form
    {
        AccountBUL accountBUL = new AccountBUL();
        string stk;
        public VanTinSoDu(string stk = null)
        {
            this.stk = stk;
            InitializeComponent();
        }

        private void VanTinSoDu_Load(object sender, EventArgs e)
        {
            AccountDTO acc = accountBUL.VanTinSoDu(stk);
            lblMoney.Text = CurrencyFormat(acc.Balance.ToString());
        }

        public string CurrencyFormat(string currency)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return double.Parse(currency).ToString("#,###", cul.NumberFormat) + " VND";
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Confirmation()).Show();
        }

        private void btnNumberCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
