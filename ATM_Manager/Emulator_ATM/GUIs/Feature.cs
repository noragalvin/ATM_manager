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
    public partial class Feature : Form
    {
        private ResourceManager rm;
        private CardDTO card;
        private string accountNo;

        public Feature(ResourceManager rm, CardDTO card = null, string accountNo = null)
        {
            this.accountNo = accountNo;
            this.rm = rm;
            this.card = card;
            InitializeComponent();
        }

        private void Feature_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            label1.Text = rm.GetString("feature_txt1");
            btnRutTien.Text = rm.GetString("feature_txt2");
            btnChuyenKhoan.Text = rm.GetString("feature_txt3");
            btnVanTin.Text = rm.GetString("feature_txt4");
            btnIn.Text = rm.GetString("feature_txt5");
            btnDoiPin.Text = rm.GetString("feature_txt6");
        }

        private void btnSideBar3_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new DoiPin(this.rm, this.card, this.accountNo)).Show();
        }

        private void btnSideBar5_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new RutTien(this.rm, this.card, this.accountNo)).Show();
        }

        private void btnSideBar6_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new NhapSTK(this.rm, this.card, this.accountNo)).Show();
        }

        private void btnSideBar1_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new VanTinSoDu(this.rm, this.card, this.accountNo)).Show();
        }

        private void btnSideBar2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new InSaoKe(this.rm, this.card, this.accountNo)).Show();
        }
    }
}
