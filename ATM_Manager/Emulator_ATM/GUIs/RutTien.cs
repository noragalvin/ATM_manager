using BULs;
using DTOs;
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
    public partial class RutTien : Form
    {
        static public string errorMessage;
        StockBUL stockBUL = new StockBUL();
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        Loading loadingForm;
        LogBUL logBUL = new LogBUL();
        private ResourceManager rm;
        private CardDTO card;
        private string accountNo;


        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            myTimer.Stop();
            if (!CheckOpened("loadingForm"))
            {
                loadingForm.Hide();
                if (errorMessage != null)
                {
                    Confirmation confirmationForm = new Confirmation(this.rm, this.card, this.accountNo,errorMessage);
                    confirmationForm.Closed += (s, args) => this.Close();
                    confirmationForm.Show();
                }
                else
                {
                    InHoaDon inHoaDonForm = new InHoaDon(this.rm, this.card, this.accountNo);
                    inHoaDonForm.Closed += (s, args) => this.Close();
                    inHoaDonForm.Show();
                }

            }
        }

        public RutTien(ResourceManager rm, CardDTO card = null, string accountNo = null)
        {
            this.rm = rm;
            this.card = card;
            this.accountNo = accountNo;
            InitializeComponent();
        }

        private void btnSideBar5_Click(object sender, EventArgs e)
        {
            int status = checkWithDraw(200000);
            processWithDraw(status);
        }

        private void btnSideBar6_Click(object sender, EventArgs e)
        {
            int status = checkWithDraw(500000);
            processWithDraw(status);
        }

        private void btnSideBar7_Click(object sender, EventArgs e)
        {
            int status = checkWithDraw(1000000);
            processWithDraw(status);
        }

        private void btnSideBar1_Click(object sender, EventArgs e)
        {
            int status = checkWithDraw(2000000);
            processWithDraw(status);
        }

        private void btnSideBar2_Click(object sender, EventArgs e)
        {
            int status = checkWithDraw(5000000);
            processWithDraw(status);
        }

        private int checkWithDraw(int money)
        {
            return stockBUL.WithDraw(money, this.accountNo);
        }

        private void processWithDraw(int status)
        {
            switch (status)
            {
                case 0:
                    this.Hide();
                    errorMessage = "Số tiền phải chia hết cho 50000";
                    loadingForm = new Loading(this.rm, this.card, this.accountNo);
                    loadingForm.Show();
                    myTimer.Tick += new EventHandler(TimerEventProcessor);
                    myTimer.Interval = 2000;
                    myTimer.Start();

                    break;
                case 1:
                    this.Hide();
                    errorMessage = "Số tiền trong tài khoản của quý khách không đủ";
                    loadingForm = new Loading(this.rm, this.card, this.accountNo);
                    loadingForm.Show();
                    myTimer.Tick += new EventHandler(TimerEventProcessor);
                    myTimer.Interval = 2000;
                    myTimer.Start();

                    break;
                case 2:
                    this.Hide();
                    int minMoney = stockBUL.GetMinWithDraw(this.accountNo);
                    errorMessage = "Quý khách chỉ được rút tối đa " + CurrencyFormat(minMoney.ToString()) + "/1 ngày";
                    loadingForm = new Loading(this.rm, this.card, this.accountNo);
                    loadingForm.Show();
                    myTimer.Tick += new EventHandler(TimerEventProcessor);
                    myTimer.Interval = 2000;
                    myTimer.Start();

                    break;
                case 3:
                    this.Hide();
                    errorMessage = "Số tiền trong máy không đủ để thực hiện giao dịch này";
                    loadingForm = new Loading(this.rm, this.card, this.accountNo);
                    loadingForm.Show();
                    myTimer.Tick += new EventHandler(TimerEventProcessor);
                    myTimer.Interval = 2000;
                    myTimer.Start();

                    break;
                case 4:
                    this.Hide();
                    errorMessage = null;
                    loadingForm = new Loading(this.rm, this.card, this.accountNo);
                    loadingForm.Show();
                    myTimer.Tick += new EventHandler(TimerEventProcessor);
                    myTimer.Interval = 2000;
                    myTimer.Start();
                    
                    break;
            }
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

        private void btnSideBar3_Click(object sender, EventArgs e)
        {
            btn1000.Visible = false;
            btn200.Visible = false;
            btn2000.Visible = false;
            btn500.Visible = false;
            btn5000.Visible = false;
            label1.Visible = false;
            btnOther.Visible = false;
            btnCancel.Visible = false;

            label2.Visible = true;
            txtPin.Visible = true;
            lblCancelLeft.Visible = true;
            lblCancelRight.Visible = true;
            lblEnterLeft.Visible = true;
            lblEnterRight.Visible = true;
            label9.Visible = true;
            label12.Visible = true;
        }

        private void RutTien_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            btnOther.Text = rm.GetString("rutTien_txt1");
            btnCancel.Text = rm.GetString("rutTien_txt2");
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Validate()).Show();
        }

        public static string CurrencyFormat(string currency)
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            return double.Parse(currency).ToString("#,###", cul.NumberFormat) + "đ";
        }

        private void btnNumberEnter_Click(object sender, EventArgs e)
        {
            int status = checkWithDraw(int.Parse(txtPin.Text));
            processWithDraw(status);
        }

        private void btnNumberCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Validate()).Show();
        }

        private void btnNumber1_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("1");
        }

        private void btnNumber2_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("2");
        }

        private void btnNumber3_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("3");
        }

        private void btnNumber4_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("4");
        }

        private void btnNumber5_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("5");
        }

        private void btnNumber6_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("6");
        }

        private void btnNumber7_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("7");
        }

        private void btnNumber8_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("8");
        }

        private void btnNumber9_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("9");
        }

        private void btnNumber0_Click(object sender, EventArgs e)
        {
            txtPin.AppendText("0");
        }
        private void btnNumberClear_Click(object sender, EventArgs e)
        {
            txtPin.Clear();
        }
    }
}
