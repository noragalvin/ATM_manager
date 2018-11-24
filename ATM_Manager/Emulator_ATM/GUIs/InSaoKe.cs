using BULs;
using DTOs;
using Microsoft.Reporting.WinForms;
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
    public partial class InSaoKe : Form
    {
        LogBUL logBUL = new LogBUL();
        ResourceManager rm;
        CardDTO card;
        string accountNo;

        public InSaoKe(ResourceManager rm, CardDTO card = null, string accountNo = null)
        {
            this.rm = rm;
            this.card = card;
            this.accountNo = accountNo;
            InitializeComponent();
        }

        private void InSaoKe_Load(object sender, EventArgs e)
        {
            btnNext.Text = rm.GetString("next");
            ATMManagerDataSet data = new ATMManagerDataSet();
            string cardNumber = this.accountNo;
            logBUL.GetLog(data, cardNumber);

            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                if (data.Tables[0].Rows[i]["LogTypeID"].ToString() == "2")
                {
                    data.Tables[0].Rows[i]["Amout"] = -int.Parse(data.Tables[0].Rows[i]["Amout"].ToString());
                }

            }

            data.Tables[0].AcceptChanges();


            ReportDataSource rds = new ReportDataSource("LogData", data.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            this.CenterToScreen();
            this.reportViewer1.RefreshReport();
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Confirmation(this.rm)).Show();
        }

        private void btnNumberCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Confirmation(this.rm)).Show();
        }
    }
}
