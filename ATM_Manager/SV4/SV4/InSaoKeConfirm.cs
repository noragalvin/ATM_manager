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
    public partial class InSaoKeConfirm : Form
    {
        private string accountNo;

        public InSaoKeConfirm(string accountNo = null)
        {
            this.accountNo = accountNo;
            InitializeComponent();
        }

        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            myTimer.Stop();
            (new BillSaoKe(this.accountNo)).Show();
        }

        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            (new Confirmation()).Show();
            this.Hide();
        }

        private void InSaoKeConfirm_Load(object sender, EventArgs e)
        {

            this.CenterToScreen();
        }

        private void btnSideBar3_Click(object sender, EventArgs e)
        {
            (new Confirmation()).Show();
            this.Hide();
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 2000;
            myTimer.Start();
        }
    }
}
