using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AccountDTO
    {
        public int AccountID { get; set; }
        public int CustID { get; set; }
        public string AccountNo { get; set; }
        public int ODID { get; set; }
        public int WDID { get; set; }
        public int Balance { get; set; }
        public AccountDTO() { }
        public AccountDTO(int balance)
        {
            this.Balance = balance;
        }
        public AccountDTO(string accountNo, int balance)
        {
            this.AccountNo = accountNo;
            this.Balance = balance;
        }
    }
}
