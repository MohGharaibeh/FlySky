using System;
using System.Collections.Generic;

namespace FlySky.Core.Data
{
    public partial class Flight
    {
        public Flight()
        {
            Reservedflights = new HashSet<Reservedflight>();
        }

        public decimal Flightid { get; set; }
        public decimal? Capacity { get; set; }
        public string? Status { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Departuredate { get; set; }
        public DateTime? Arrivaldate { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Fromcountry { get; set; }
        public string? Tocountry { get; set; }
        public string? Travelclass { get; set; }
        public decimal? Fromid { get; set; }
        public decimal? Toid { get; set; }

        public virtual Airport? From { get; set; }
        public virtual Airport? To { get; set; }
        public virtual ICollection<Reservedflight> Reservedflights { get; set; }
    }
}
