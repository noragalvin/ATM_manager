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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV3
{
    public partial class BillChuyenTien : Form
    {
        LogBUL logBUL = new LogBUL();
        AccountBUL accountBUL = new AccountBUL();
        string accountNo;

        public BillChuyenTien(string accountNo = null)
        {
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
            LogDTO log = logBUL.GetLastLog(accountNo);
            AccountDTO account = accountBUL.GetAccount(accountNo);
            double phi = log.Amout * 0.05;
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
