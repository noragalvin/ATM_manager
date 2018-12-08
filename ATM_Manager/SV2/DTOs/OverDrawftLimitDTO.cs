using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OverDrawftLimitDTO
    {
        public int Value { get; set; }
        public int ODID { get; set; }
        public OverDrawftLimitDTO() { }
        public OverDrawftLimitDTO(int id, int value)
        {
            this.ODID = id;
            this.Value = value;
        }
    }
}
