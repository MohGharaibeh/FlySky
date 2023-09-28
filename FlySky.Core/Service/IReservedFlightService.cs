using FlySky.Core.Data;
using FlySky.Core.DTO;
using FlySky.Core.Service;
using FlySky.Infra.Invoice;
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
        public Task<bool> CreateReserved(RequestData request);
        public bool UpdateReserved(Reservedflight reservedflight);
        public bool DeleteReserved(int id);
        public Reservedflight ReservedById(int id);
    }
}
