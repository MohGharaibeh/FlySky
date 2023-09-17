using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.DTO
{
    public class FlightAndAorport
    {
        public decimal flightid { get; set; }

        public decimal? Capacity { get; set; }
        public string? Status { get; set; }//1
        public decimal? Price { get; set; }
        public DateTime? Departuredate { get; set; }//2
        public DateTime? Arrivaldate { get; set; }//3
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Fromcountry { get; set; }
        public string? Tocountry { get; set; }
        public string? Travelclass { get; set; }
        public decimal? Fromid { get; set; }
        public decimal? Toid { get; set; }
        public string? ToAirportName { get; set; }//4
        public string? FromAirportName { get; set; }//5


    }
}
