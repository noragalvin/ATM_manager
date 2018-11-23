﻿using DALs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULs
{
    public class LogBUL
    {
        LogDAL logDAL = new LogDAL();
        AccountDAL accountDAL = new AccountDAL();

        public void GetLog(DataSet data, string cardNumber)
        {
            logDAL.GetLog(data, cardNumber);
        }
    }
}
