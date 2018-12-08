using DTOs;
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
    public partial class InSaoKeConfirm : Form
    {
        private ResourceManager rm;
        private CardDTO card;
        private string accountNo;

        public InSaoKeConfirm(ResourceManager rm, CardDTO card = null, string accountNo = null)
        {
            this.rm = rm;
            this.card = card;
            this.accountNo = accountNo;
            InitializeComponent();
        }

        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            myTimer.Stop();
            (new BillSaoKe(this.rm, this.card, this.accountNo)).Show();
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
            (new Confirmation(this.rm, this.card, this.accountNo)).Show();
            this.Hide();
        }

        private void InSaoKeConfirm_Load(object sender, EventArgs e)
        {
            btnYes.Text = rm.GetString("yes");
            btnNo.Text = rm.GetString("no");

            this.CenterToScreen();
        }

        private void btnSideBar3_Click(object sender, EventArgs e)
        {
            (new Confirmation(this.rm, this.card, this.accountNo)).Show();
            this.Hide();
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 2000;
            myTimer.Start();
        }
    }
}
