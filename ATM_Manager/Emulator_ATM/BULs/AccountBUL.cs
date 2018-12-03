using DALs;
using DTOs;
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

        public bool ChuyenKhoan(string stkChuyen, string stkNhan, int soTien)
        {
            return accountDAL.ChuyenKhoan(stkChuyen, stkNhan, soTien);
        }

        public AccountDTO VanTinSoDu(string stk)
        {
            return accountDAL.VanTinSoDu(stk);
        }

        public AccountDTO GetAccount(string accountNo)
        {
            return accountDAL.GetAccount(accountNo);
        }
    }
}
