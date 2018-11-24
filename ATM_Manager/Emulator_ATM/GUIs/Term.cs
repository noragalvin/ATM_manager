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
    public partial class Term : Form
    {
        private ResourceManager rm;
        private CardDTO card;
        private string accountNo;

        public Term(ResourceManager rm, CardDTO card = null, string accountNo = null)
        {
            this.accountNo = accountNo;
            this.card = card;
            this.rm = rm;
            InitializeComponent();
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Fee(this.rm, this.card, this.accountNo)).Show();
        }

        private void Term_Load(object sender, EventArgs e)
        {
            lblContent.Text = rm.GetString("term_txt1");
            btnNext.Text = rm.GetString("next");
            this.CenterToScreen();
        }

    }
}
