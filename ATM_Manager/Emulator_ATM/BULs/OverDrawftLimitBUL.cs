using DALs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULs
{
    public class OverDrawftLimitBUL
    {
        OverDrawftLimitDAL overdrawftDAL = new OverDrawftLimitDAL();

        public OverDrawftLimitDTO GetThauChi(string stk)
        {
            return overdrawftDAL.GetThauChi(stk);
        }
    }
}
