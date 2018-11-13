using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV2
{
    public partial class ChooseLanguage : Form
    {
        public ChooseLanguage()
        {
            InitializeComponent();
        }

        private void ChooseLanguage_Load(object sender, EventArgs e)
        {
            btnVI.TabStop = false;
            btnVI.FlatStyle = FlatStyle.Flat;
            btnVI.FlatAppearance.BorderSize = 0;

            btnEN.TabStop = false;
            btnEN.FlatStyle = FlatStyle.Flat;
            btnEN.FlatAppearance.BorderSize = 0;
        }


      

    }
}
