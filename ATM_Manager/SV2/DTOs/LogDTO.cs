using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class Log
    {
        public int LogID { get; set; }
        public int LogTypeID { get; set; }
        public int ATMID { get; set; }
        public string CardNo { get; set; }
        public string LogDate { get; set; }
        public int Amout { get; set; }
        public string Details { get; set; }
        public string CardNoTo { get; set; }
        public Log() { }
        public Log(int logID, int logTypeID, int atmID, string cardNo, string logDate, int amout, string details, string cardNoTo)
        {
            this.LogID = logID;
            this.LogTypeID = logTypeID;
            this.ATMID = atmID;
            this.CardNo = cardNo;
            this.LogDate = logDate;
            this.Amout = amout;
            this.Details = details;
            this.CardNoTo = cardNoTo;
        }
    }
}
