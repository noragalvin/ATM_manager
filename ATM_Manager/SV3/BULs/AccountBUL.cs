using DALs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULs
{
    public class AccountBUL
    {
        AccountDAL accountDAL = new AccountDAL();

        public void ChuyenKhoan(string stkChuyen, string stkNhan, int soTien)
        {
            accountDAL.ChuyenKhoan(stkChuyen, stkNhan, soTien);
        }
    }
}
