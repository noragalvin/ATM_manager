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
        public CardDTO getValidCard(string pin)
        {
            return card.getValidCard(pin);
        }
    }
}
