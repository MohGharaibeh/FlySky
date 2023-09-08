using System;
using System.Collections.Generic;

namespace FlySky.Core.Data
{
    public partial class Reservedflight
    {
        public decimal Reservedflightid { get; set; }
        public decimal? Numberofticket { get; set; }
        public decimal? Useracountid { get; set; }
        public decimal? Flightid { get; set; }

        public virtual Flight? Flight { get; set; }
        public virtual Useracount? Useracount { get; set; }
    }
}
