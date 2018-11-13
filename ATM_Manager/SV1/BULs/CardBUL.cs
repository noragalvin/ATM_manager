using DALs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULs
{
    public class CardBUL
    {
        public bool isValidCard(string pin)
        {
            return (new CardDAL()).isValidCard(pin);
        }
    }
}
