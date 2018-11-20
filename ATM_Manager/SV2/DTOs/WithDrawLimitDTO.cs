using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class WithDrawLimitDTO
    {
        public int Value { get; set; }
        public int WDID { get; set; }
        public WithDrawLimitDTO() { }
        public WithDrawLimitDTO(int id, int value)
        {
            this.WDID = id;
            this.Value = value;
        }
    }
}
