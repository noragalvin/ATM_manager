using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class LogTypeDTO
    {
        public int LogTypeID { get; set; }
        public string Description { get; set; }
        public LogTypeDTO() { }
        public LogTypeDTO(int logTypeID, string description)
        {
            this.LogTypeID = logTypeID;
            this.Description = description;
        }
    }
}
