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

namespace Validate
{
    public partial class ChooseLanguage : Form
    {
        private ResourceManager rm;
        private CardDTO card;

        public ChooseLanguage(CardDTO card = null)
        {
            this.card = card;
            InitializeComponent();
        }

        private void btnSideBar3_Click(object sender, EventArgs e)
        {
            this.rm = new ResourceManager("Validate.vi", Assembly.GetExecutingAssembly());
            this.Hide();
            (new Term(this.rm, this.card)).Show();
        }

        private void btnSideBar4_Click(object sender, EventArgs e)
        {
            this.rm = new ResourceManager("Validate.en", Assembly.GetExecutingAssembly());
            this.Hide();
            (new Term(this.rm, this.card)).Show();
        }

        private void ChooseLanguage_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            lblNameVi.Text = card.Name;
            lblNameEn.Text = card.Name;
        }

     
    }
}
