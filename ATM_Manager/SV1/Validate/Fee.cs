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

namespace Validate
{
    public partial class Fee : Form
    {
        private ResourceManager rm;
        private CardDTO card;

        public Fee(ResourceManager rm, CardDTO card = null)
        {
            this.card = card;
            this.rm = rm;
            InitializeComponent();
        }

        private void btnNumberEnter_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Feature(this.rm, this.card)).Show();
        }

        private void Fee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lbFeeTitle.Text = rm.GetString("fee_txt1");
            lbl00.Text = rm.GetString("fee_txt2");
            lbl10.Text = rm.GetString("fee_txt3");
            lbl20.Text = rm.GetString("fee_txt4");
            lbl01.Text = rm.GetString("fee_txt5");
            lbl11.Text = rm.GetString("fee_txt6");
            lbl21.Text = rm.GetString("fee_txt8");
            lblNote.Text = rm.GetString("fee_txt7");
            lblEnterLeft.Text = rm.GetString("fee_enterLeft");
            lblEnterRight.Text = rm.GetString("fee_enterRight");
            lblCancelLeft.Text = rm.GetString("fee_enterLeft");
            lblCancelRight.Text = rm.GetString("fee_enterRight");


        }
    }
}
