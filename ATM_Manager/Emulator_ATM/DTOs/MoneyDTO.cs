using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MoneyDTO
    {
        public int MoneyID { get; set; }
        public float MoneyValue { get; set; }
        public MoneyDTO() { }
        public MoneyDTO(int moneyID, float moneyValue)
        {
            this.MoneyID = moneyID;
            this.MoneyValue = moneyValue;
        }
    }
}
