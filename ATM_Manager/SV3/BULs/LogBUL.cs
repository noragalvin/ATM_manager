using DALs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULs
{
    public class LogBUL
    {
        LogDAL logDAL = new LogDAL();

        public void StoreLog(int atm_id, string cardNumber, string created_at, int amount, string description, string toCard)
        {
            logDAL.StoreLog(atm_id, cardNumber, created_at, amount, description, toCard);
        }
    }
}
