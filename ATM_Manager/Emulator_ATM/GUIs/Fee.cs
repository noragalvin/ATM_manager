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
    public partial class Fee : Form
    {
        private ResourceManager rm;
        private CardDTO card;
        private string accountNo;

        public Fee(ResourceManager rm, CardDTO card = null, string accountNo = null)
        {
            this.accountNo = accountNo;
            this.card = card;
            this.rm = rm;
            InitializeComponent();
        }

        private void btnNumberEnter_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Feature(this.rm, this.card, this.accountNo)).Show();
        }

        private void Fee_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnNumberCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Validate()).Show();
        }
    }
}
