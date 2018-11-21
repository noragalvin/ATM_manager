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

namespace GUIs
{
    public partial class Bill : Form
    {
        LogBUL logBUL = new LogBUL();
        private int cardNo;

        public Bill(int cardNo = 0)
        {
            this.cardNo = cardNo;
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
            LogDTO log = logBUL.GetLastLog(cardNo);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] {
                new ReportParameter("time", log.LogDate),
                new ReportParameter("atmID", log.ATMID.ToString()),
                new ReportParameter("logNo", log.LogID.ToString()),
                new ReportParameter("cardNumber", log.CardNo),
                new ReportParameter("money", log.Amout.ToString()),
                new ReportParameter("soDu", "1"),
            });

            reportViewer1.RefreshReport();
        }
    }
}
