using BULs;
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
    public partial class SoTienChuyen : Form
    {
        private string stk_nhan_tien;
        private string stk_chuyen_tien;
        private AccountBUL accountBUL = new AccountBUL();
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        Loading loadingForm;
        ResourceManager rm;
        CardDTO card;

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            myTimer.Stop();
            if (!CheckOpened("loadingForm"))
            {
                loadingForm.Hide();
                Confirmation confirmationForm = new Confirmation(this.rm, this.card, this.stk_chuyen_tien);
                confirmationForm.Closed += (s, args) => this.Close();
                confirmationForm.Show();

            }
        }

        public SoTienChuyen(ResourceManager rm, CardDTO card = null, string accountNo = null, string stk_nhan_tien = null)
        {
            this.stk_chuyen_tien = accountNo;
            this.rm = rm;
            this.card = card;
            this.stk_nhan_tien = stk_nhan_tien;
            InitializeComponent();
        }

        private void btnNumberEnter_Click(object sender, EventArgs e)
        {
            accountBUL.ChuyenKhoan(stk_chuyen_tien, stk_nhan_tien, int.Parse(txtMoney.Text));
            this.Hide();
            loadingForm = new Loading(this.rm, this.card, this.stk_chuyen_tien);
            loadingForm.Show();
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 2000;
            myTimer.Start();

        }

        private void btnNumberCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNumber1_Click(object sender, EventArgs e)
        {
            txtMoney.AppendText("1");
        }

        private void btnNumber2_Click(object sender, EventArgs e)
        {
            txtMoney.AppendText("2");
        }

        private void btnNumber3_Click(object sender, EventArgs e)
        {
            txtMoney.AppendText("3");
        }

        private void btnNumber4_Click(object sender, EventArgs e)
        {
            txtMoney.AppendText("4");
        }

        private void btnNumber5_Click(object sender, EventArgs e)
        {
            txtMoney.AppendText("5");
        }

        private void btnNumber6_Click(object sender, EventArgs e)
        {
            txtMoney.AppendText("6");
        }

        private void btnNumber7_Click(object sender, EventArgs e)
        {
            txtMoney.AppendText("7");
        }

        private void btnNumber8_Click(object sender, EventArgs e)
        {
            txtMoney.AppendText("8");
        }

        private void btnNumber9_Click(object sender, EventArgs e)
        {
            txtMoney.AppendText("9");
        }

        private void btnNumber0_Click(object sender, EventArgs e)
        {
            txtMoney.AppendText("0");
        }

        private void SoTienChuyen_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            label1.Text = rm.GetString("soTienChuyen_txt1");
            lblEnterLeft.Text = rm.GetString("fee_enterLeft");
            lblEnterRight.Text = rm.GetString("fee_enterRight");
            lblCancelLeft.Text = rm.GetString("fee_cancelLeft");
            lblCancelRight.Text = rm.GetString("fee_cancelRight");
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

        private void btnNumberClear_Click(object sender, EventArgs e)
        {
            txtMoney.Clear();
        }
    }
}
