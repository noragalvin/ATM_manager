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
    public partial class Term : Form
    {
        private ResourceManager rm;
        private CardDTO card;

        public Term(ResourceManager rm, CardDTO card = null)
        {
            this.card = card;
            this.rm = rm;
            InitializeComponent();
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Fee(this.rm, this.card)).Show();
        }

        private void Term_Load(object sender, EventArgs e)
        {
            lblContent.Text = rm.GetString("term_lblContent");
            btnNext.Text = rm.GetString("term_btnNext");
            this.CenterToScreen();
        }
    }
}
