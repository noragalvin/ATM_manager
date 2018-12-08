using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SV4
{
    public partial class Feature : Form
    {
        string stk = "11111111";
        public Feature()
        {
            InitializeComponent();
        }

        private void btnSideBar2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new InSaoKe(this.stk)).Show();
        }

        private void Feature_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void btnSideBar1_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new VanTinSoDu(stk)).Show();
        }
    }
}
