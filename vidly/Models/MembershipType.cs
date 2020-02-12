using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vidly.Models
{
    public class MembershipType
    {
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte Id { get; set; }
        public byte DiscountRate { get; set; }
    }
}