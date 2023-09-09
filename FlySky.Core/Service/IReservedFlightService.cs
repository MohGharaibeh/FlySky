using FlySky.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Service
{
    public interface IReservedFlightService
    {
        public List<Reservedflight> AllReserved();
        public bool CreateReserved(Reservedflight reservedflight);
        public bool UpdateReserved(Reservedflight reservedflight);
        public bool DeleteReserved(int id);
        public Reservedflight ReservedById(int id);
    }
}
