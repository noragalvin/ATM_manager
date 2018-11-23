using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AccountDTO
    {
        public string AccountNo { get; set; }
        public int Balance { get; set; }
        public AccountDTO() { }
        public AccountDTO(string accountNo, int balance)
        {
            this.AccountNo = accountNo;
            this.Balance = balance;
        }
    }
}
