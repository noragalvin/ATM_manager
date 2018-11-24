using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIs
{
    public partial class ChooseLanguage : Form
    {
        private ResourceManager rm;
        private CardDTO card;
        private string accountNo;

        public ChooseLanguage(CardDTO card = null, string accountNo = null)
        {
            this.accountNo = accountNo;
            this.card = card;
            InitializeComponent();
        }

        private void btnSideBar3_Click(object sender, EventArgs e)
        {
            this.rm = new ResourceManager("GUIs.vi", Assembly.GetExecutingAssembly());
            this.Hide();
            (new Term(this.rm, this.card, this.accountNo)).Show();
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.rm = new ResourceManager("GUIs.en", Assembly.GetExecutingAssembly());
            this.Hide();
            (new Term(this.rm, this.card, this.accountNo)).Show();
        }

        private void ChooseLanguage_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lblNameVi.Text = card.Name;
            lblNameEn.Text = card.Name;
        }
    }
}
