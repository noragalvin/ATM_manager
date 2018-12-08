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

namespace SV4
{
    public partial class InSaoKe : Form
    {
        LogBUL logBUL = new LogBUL();
        private string accountNo;

        public InSaoKe(string accountNo = null)
        {
            this.accountNo = accountNo;
            InitializeComponent();
        }

        private void InSaoKe_Load(object sender, EventArgs e)
        {
            string cardNumber = this.accountNo;
            ATMManagerDataSet data = new ATMManagerDataSet();
            logBUL.GetLog(data, cardNumber);

            var empList = data.Tables[0].AsEnumerable().Select(dataRow => new LogDTO
            {
                LogID = dataRow.Field<int>("LogID"),
                LogTypeID = dataRow.Field<int>("LogTypeID"),
                ATMID = dataRow.Field<int>("ATMID"),
                CardNo = dataRow.Field<string>("CardNo"),
                LogDate = (dataRow.Field<DateTime>("LogDate")).ToString(),
                Amout = dataRow.Field<int>("Amout"),
                Details = dataRow.Field<string>("Details"),
                CardNoTo = dataRow.Field<string>("CardNoTo")
            }).ToList();

            List<LogDTO> list = empList;
            DataTable dt = new DataTable();
            dt.Columns.Add("Ngày", typeof(string));
            dt.Columns.Add("Giờ", typeof(string));
            dt.Columns.Add("Nợ", typeof(int));
            dt.Columns.Add("Có", typeof(int));
            foreach (LogDTO item in list)
            {
                DataRow dr = dt.NewRow();
                dr["Ngày"] = item.LogDate.Split(' ')[0];
                dr["Giờ"] = item.LogDate.Split(' ')[1];
                dr["Nợ"] = item.LogTypeID == 2 ? 0 : -item.Amout;
                dr["Có"] = item.LogTypeID == 2 ? item.Amout : 0;
                dt.Rows.Add(dr);
            }

            dataGridView1.DataSource = dt;

            this.CenterToScreen();

        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new InSaoKeConfirm(this.accountNo)).Show();
        }


    }
}
