using FlySky.Core.Data;
using FlySky.Core.DTO;
using FlySky.Infra.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Repository
{
    public interface IReservedFlightRepository
    {
        public List<Reservedflight> AllReserved();
        public Task<bool> CreateReserved(RequestData request);
        public bool UpdateReserved(Reservedflight reservedflight);
        public bool DeleteReserved(int id);
        public Reservedflight ReservedById(int id);
    }
}
