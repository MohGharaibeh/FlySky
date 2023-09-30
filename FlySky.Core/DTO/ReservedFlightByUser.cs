using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.DTO
{
    public class ReservedFlightByUser
    {
        public decimal? Numberofticket { get; set; }
        public decimal? Useracountid { get; set; }
        public decimal? Flightid { get; set; }
        public DateTime? Reserveddate { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Status { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Departuredate { get; set; }
        public DateTime? Arrivaldate { get; set; }
        public string? Fromcountry { get; set; }
        public string? Tocountry { get; set; }
    }
}
