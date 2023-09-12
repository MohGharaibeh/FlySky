using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.DTO
{
    public class AdminReport
    {
        public string status { get; set; }
        public string fromCountry { get; set; }
        public string toCountry { get; set; }
        public decimal total_price { get; set; }
        public decimal NumberOfPassenger { get; set; }
        public DateTime departuredate { get; set; }
        public DateTime arrivaldate { get; set; }

    }
}
