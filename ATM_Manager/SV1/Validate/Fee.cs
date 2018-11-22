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
        }
    }
}
