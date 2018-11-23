using DALs;
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

        public void GetLog(DataSet data)
        {
            logDAL.GetLog(data);
        }
    }
}
