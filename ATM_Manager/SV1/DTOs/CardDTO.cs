using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CardDTO
    {
        public string CardNo { get; set; }
        public int Status { get; set; }
        public int AccountID { get; set; }
        public string PIN { get; set; }
        public string StartDate { get; set; }
        public string ExpiredDate { get; set; }
        public int Attemp { get; set; }
        public string Name { get; set; }
        public CardDTO() { }
        public CardDTO(string cardNo, int status, int accountID, string pin, string startDate, string expriredDate, int attemp) {
            this.CardNo = cardNo;
            this.Status = status;
            this.AccountID = accountID;
            this.PIN = pin;
            this.StartDate = startDate;
            this.ExpiredDate = expriredDate;
            this.Attemp = attemp;
        }

        public CardDTO(string cardNo, int status, string name, string pin, string startDate, string expriredDate, int attemp)
        {
            this.CardNo = cardNo;
            this.Status = status;
            this.Name = name;
            this.PIN = pin;
            this.StartDate = startDate;
            this.ExpiredDate = expriredDate;
            this.Attemp = attemp;
        }

    }
}
