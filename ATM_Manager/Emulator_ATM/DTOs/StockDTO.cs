using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class StockDTO
    {
        public int StockID { get; set; }
        public int MoneyID { get; set; }
        public int ATMID { get; set; }
        public int Quantity { get; set; }
        public StockDTO() { }
        public StockDTO(int stockID, int moneyID, int atmID, int quantity)
        {
            this.StockID = stockID;
            this.MoneyID = moneyID;
            this.ATMID = atmID;
            this.Quantity = quantity;
        }

        public StockDTO(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
