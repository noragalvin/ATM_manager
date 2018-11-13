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
    public partial class Feature : Form
    {
        public Feature()
        {
            InitializeComponent();
        }

        private void Feature_Load(object sender, EventArgs e)
        {
            btnRutTien.TabStop = false;
            btnRutTien.FlatStyle = FlatStyle.Flat;
            btnRutTien.FlatAppearance.BorderSize = 0;

            btnChuyenKhoan.TabStop = false;
            btnChuyenKhoan.FlatStyle = FlatStyle.Flat;
            btnChuyenKhoan.FlatAppearance.BorderSize = 0;

            btnVanTin.TabStop = false;
            btnVanTin.FlatStyle = FlatStyle.Flat;
            btnVanTin.FlatAppearance.BorderSize = 0;

            btnIn.TabStop = false;
            btnIn.FlatStyle = FlatStyle.Flat;
            btnIn.FlatAppearance.BorderSize = 0;

            btnDoiPin.TabStop = false;
            btnDoiPin.FlatStyle = FlatStyle.Flat;
            btnDoiPin.FlatAppearance.BorderSize = 0;
        }
    }
}
