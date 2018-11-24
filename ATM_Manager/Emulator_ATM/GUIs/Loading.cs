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
    public partial class Loading : Form
    {
        private ResourceManager rm;
        private CardDTO card;
        private string accountNo;

        public Loading(ResourceManager rm, CardDTO card = null, string accountNo = null)
        {
            this.rm = rm;
            this.card = card;
            this.accountNo = accountNo;
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            label1.Text = rm.GetString("loading_txt1");
            label2.Text = rm.GetString("loading_txt2");

        }
    }
}
