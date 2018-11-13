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
    public partial class RutTien : Form
    {
        public RutTien()
        {
            InitializeComponent();
        }

        private void RutTien_Load(object sender, EventArgs e)
        {
            btn100.TabStop = false;
            btn100.FlatStyle = FlatStyle.Flat;
            btn100.FlatAppearance.BorderSize = 0;

            btn200.TabStop = false;
            btn200.FlatStyle = FlatStyle.Flat;
            btn200.FlatAppearance.BorderSize = 0;

            btn500.TabStop = false;
            btn500.FlatStyle = FlatStyle.Flat;
            btn500.FlatAppearance.BorderSize = 0;

            btn1000.TabStop = false;
            btn1000.FlatStyle = FlatStyle.Flat;
            btn1000.FlatAppearance.BorderSize = 0;

            btn2000.TabStop = false;
            btn2000.FlatStyle = FlatStyle.Flat;
            btn2000.FlatAppearance.BorderSize = 0;

            btn5000.TabStop = false;
            btn5000.FlatStyle = FlatStyle.Flat;
            btn5000.FlatAppearance.BorderSize = 0;

            btnOther.TabStop = false;
            btnOther.FlatStyle = FlatStyle.Flat;
            btnOther.FlatAppearance.BorderSize = 0;

            btnCancel.TabStop = false;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
        }
    }
}
