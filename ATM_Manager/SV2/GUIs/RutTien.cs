using BULs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
            myTimer.Stop();
            if (!CheckOpened("loadingForm"))
            {
                loadingForm.Hide();
                if (errorMessage != null)
                {
                    Confirmation confirmationForm = new Confirmation(errorMessage);
                    confirmationForm.Closed += (s, args) => this.Close();
                    confirmationForm.Show();
                }
                else
                {
                    InHoaDon inHoaDonForm = new InHoaDon();
                    inHoaDonForm.Closed += (s, args) => this.Close();
                    inHoaDonForm.Show();
                }
                
            }
        }

        public RutTien()
        {
            InitializeComponent();
        }

        private void btnSideBar5_Click(object sender, EventArgs e)
        {
            int status = withDraw(200000);
            string created_at = DateTime.Now.ToString();
            string cardNumber = "123";
            int atm_id = 1;
            processWithDraw(status, atm_id, cardNumber, created_at, 200000);
        }

        private void btnSideBar6_Click(object sender, EventArgs e)
        {
            int status = withDraw(500000);
            string created_at = DateTime.Now.ToString();
            string cardNumber = "123";
            int atm_id = 1;
            processWithDraw(status, atm_id, cardNumber, created_at, 500000);
        }

        private void btnSideBar7_Click(object sender, EventArgs e)
        {
            int status = withDraw(1000000);
            string created_at = DateTime.Now.ToString();
            string cardNumber = "123";
            int atm_id = 1;
            processWithDraw(status, atm_id, cardNumber, created_at, 1000000);
        }

        private void btnSideBar1_Click(object sender, EventArgs e)
        {
            int status = withDraw(2000000);
            string created_at = DateTime.Now.ToString();
            string cardNumber = "123";
            int atm_id = 1;
            processWithDraw(status, atm_id, cardNumber, created_at, 2000000);
        }

        private void btnSideBar2_Click(object sender, EventArgs e)
        {
            int status = withDraw(5000000);
            string created_at = DateTime.Now.ToString();
            string cardNumber = "123";
            int atm_id = 1;
            processWithDraw(status, atm_id, cardNumber, created_at, 5000000);
        }

        private int withDraw(int money)
        {
            return stockBUL.WithDraw(money);
        }

        private void processWithDraw(int status, int atm_id, string cardNumber, string created_at, int amount)
        {
            switch (status)
            {
                case 0:
                    this.Hide();
                    errorMessage = "Số tiền phải chia hết cho 50000";
                    loadingForm = new Loading();
                    loadingForm.Show();
                    myTimer.Tick += new EventHandler(TimerEventProcessor);
                    myTimer.Interval = 2000;
                    myTimer.Start();

                    break;
                case 1:
                    this.Hide();
                    errorMessage = "Số tiền trong tài khoản của quý khách không đủ";
                    loadingForm = new Loading();
                    loadingForm.Show();
                    myTimer.Tick += new EventHandler(TimerEventProcessor);
                    myTimer.Interval = 2000;
                    myTimer.Start();

                    break;
                case 2:
                    this.Hide();
                    errorMessage = "Quý khách chỉ được rút tối đa 5.000.000đ";
                    loadingForm = new Loading();
                    loadingForm.Show();
                    myTimer.Tick += new EventHandler(TimerEventProcessor);
                    myTimer.Interval = 2000;
                    myTimer.Start();

                    break;
                case 3:
                    this.Hide();
                    errorMessage = "Số tiền trong máy không đủ để thực hiện giao dịch này";
                    loadingForm = new Loading();
                    loadingForm.Show();
                    myTimer.Tick += new EventHandler(TimerEventProcessor);
                    myTimer.Interval = 2000;
                    myTimer.Start();

                    break;
                case 4:
                    this.Hide();
                    errorMessage = null;
                    loadingForm = new Loading();
                    loadingForm.Show();
                    myTimer.Tick += new EventHandler(TimerEventProcessor);
                    myTimer.Interval = 2000;
                    myTimer.Start();
                    logBUL.StoreLog(atm_id, cardNumber, created_at, amount);
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

        }
    }
}
