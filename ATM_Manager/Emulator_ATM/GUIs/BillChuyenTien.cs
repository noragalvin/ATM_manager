using BULs;
using DTOs;
using Microsoft.Reporting.WinForms;
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
    public partial class BillChuyenTien : Form
    {
        private ResourceManager rm;
        private CardDTO card;
        private string accountNo;
        LogBUL logBUL = new LogBUL();
        AccountBUL accountBUL = new AccountBUL();

        public BillChuyenTien(ResourceManager rm, CardDTO card = null, string accountNo = null)
        {
            this.rm = rm;
            this.card = card;
            this.accountNo = accountNo;
            InitializeComponent();
        }

        private void BillChuyenTien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ATMManagerDataSet.tblAccount' table. You can move, or remove it, as needed.
            this.tblAccountTableAdapter.Fill(this.ATMManagerDataSet.tblAccount);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

            AccountDTO account = accountBUL.GetAccount(accountNo);
            LogDTO log = logBUL.GetLastLog(accountNo);
            double phi = log.Amout*0.05/100;
            if (phi < 2000) phi = 2000;
            if (phi > 20000) phi = 20000;
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] {
                new ReportParameter("time", log.LogDate),
                new ReportParameter("atmID", log.ATMID.ToString()),
                new ReportParameter("logNo", log.LogID.ToString()),
                new ReportParameter("cardNumber", log.CardNo),
                new ReportParameter("money", CurrencyFormat(log.Amout.ToString())),
                new ReportParameter("soDu", CurrencyFormat(account.Balance.ToString())),
                new ReportParameter("phi", CurrencyFormat(phi.ToString())),
                new ReportParameter("vat", "500 VND"),
                new ReportParameter("cardNhan", log.CardNoTo.ToString())
            });

            reportViewer1.RefreshReport();
        }

        public string CurrencyFormat(string currency)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return double.Parse(currency).ToString("#,###", cul.NumberFormat) + " VND";
        }
    }
}
