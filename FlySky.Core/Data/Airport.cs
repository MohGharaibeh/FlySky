using System;
using System.Collections.Generic;

namespace FlySky.Core.Data
{
    public partial class Airport
    {
        public Airport()
        {
            FlightFroms = new HashSet<Flight>();
            FlightTos = new HashSet<Flight>();
        }

        public decimal Airportid { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Flight> FlightFroms { get; set; }
        public virtual ICollection<Flight> FlightTos { get; set; }
    }
}
