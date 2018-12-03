using DALs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULs
{
    public class CardBUL
    {
        CardDAL card = new CardDAL();
        public CardDTO getValidCard(string pin, string stk)
        {
            return card.getValidCard(pin, stk);
        }

        public void UpdatePIN(string stk, string pin)
        {
            card.UpdatePIN(stk, pin);
        }

        public CardDTO CheckCard(string stk)
        {
            return card.CheckCard(stk);
        }
    }
}
