﻿using DALs;
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

        public void StoreLog(int atm_id, string cardNumber, string created_at, int amount = 0, int type = 1, string description = null, string toCard = null)
        {
            logDAL.StoreLog(atm_id, cardNumber, created_at, amount, type, description, toCard);
        }

        public LogDTO GetLastLog(string cardNo)
        {
            return logDAL.GetLastLog(cardNo);
        }
    }
}
