using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using BULs;
using DTOs;
using System.Globalization;

namespace GUIs
{
    public partial class Bill : Form
    {
        LogBUL logBUL = new LogBUL();
        private string accountNo;
        AccountBUL accountBUL = new AccountBUL();

        public Bill(string accountNo = null)
        {
            this.accountNo = accountNo;
            InitializeComponent();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ATMManagerDataSet.tblLog' table. You can move, or remove it, as needed.
            this.tblLogTableAdapter.Fill(this.ATMManagerDataSet.tblLog);
            // TODO: This line of code loads data into the 'ATMManagerDataSet.tblAccount' table. You can move, or remove it, as needed.
            this.tblAccountTableAdapter.Fill(this.ATMManagerDataSet.tblAccount);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            LogDTO log = logBUL.GetLastLog(accountNo);
            AccountDTO account = accountBUL.GetAccount(accountNo);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] {
                new ReportParameter("time", log.LogDate),
                new ReportParameter("atmID", log.ATMID.ToString()),
                new ReportParameter("logNo", log.LogID.ToString()),
                new ReportParameter("cardNumber", log.CardNo),
                new ReportParameter("money", CurrencyFormat(log.Amout.ToString())),
                new ReportParameter("soDu", CurrencyFormat(account.Balance.ToString())),
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
