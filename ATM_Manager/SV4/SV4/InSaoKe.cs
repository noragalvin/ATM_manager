using BULs;
using DTOs;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV4
{
    public partial class InSaoKe : Form
    {
        LogBUL logBUL = new LogBUL();

        public InSaoKe()
        {
            InitializeComponent();
        }

        private void InSaoKe_Load(object sender, EventArgs e)
        {
            ATMManagerDataSet data = new ATMManagerDataSet();

            logBUL.GetLog(data);

            for (int intCount = 0; intCount < data.Tables[0].Rows.Count; intCount++)
            {

                if (data.Tables[0].Rows[intCount]["LogTypeID"].ToString() == "2")
                {
                    data.Tables[0].Rows[intCount]["Amout"] = -int.Parse(data.Tables[0].Rows[intCount]["Amout"].ToString());
                }
            }

            data.Tables[0].AcceptChanges();


            ReportDataSource rds = new ReportDataSource("DataSet1", data.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            this.CenterToScreen();
        }
    }
}
