﻿using BULs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV3
{
    public partial class SoTienChuyen : Form
    {
        private string stk_nhan_tien;
        private string stk_chuyen_tien = "11111111";
        private AccountBUL accountBUL = new AccountBUL();
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        Loading loadingForm;

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            myTimer.Stop();
            if (!CheckOpened("loadingForm"))
            {
                loadingForm.Hide();
                InHoaDonChuyenTien inHoaDonForm = new InHoaDonChuyenTien(this.stk_chuyen_tien);
                inHoaDonForm.Closed += (s, args) => this.Close();
                inHoaDonForm.Show();

            }
        }

        public SoTienChuyen(string stk_nhan_tien = null)
        {
            this.stk_nhan_tien = stk_nhan_tien;
            InitializeComponent();
        }

        private void btnNumberEnter_Click(object sender, EventArgs e)
        {
            if (accountBUL.ChuyenKhoan(stk_chuyen_tien, stk_nhan_tien, int.Parse(txtMoney.Text)) == true)
            {
                this.Hide();
                loadingForm = new Loading();
                loadingForm.Show();
                myTimer.Tick += new EventHandler(TimerEventProcessor);
                myTimer.Interval = 2000;
                myTimer.Start();
            }
            else
            {
                MessageBox.Show("Số tiền trong tài khoản không đủ");
            }
            
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
    }
}
