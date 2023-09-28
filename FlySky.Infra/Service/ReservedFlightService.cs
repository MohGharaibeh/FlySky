using FlySky.Core.Data;
using FlySky.Core.Repository;
using FlySky.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlySky.Infra.Invoice;
using FlySky.Core.DTO;

namespace FlySky.Infra.Service
{
    public class ReservedFlightService : IReservedFlightService
    {
        private readonly IReservedFlightRepository _reservedFlightRepository;

        public ReservedFlightService(IReservedFlightRepository reservedFlightRepository)
        {
            _reservedFlightRepository = reservedFlightRepository;
        }

        public List<Reservedflight> AllReserved()
        {
            return _reservedFlightRepository.AllReserved();
        }
        public async Task<bool> CreateReserved(RequestData request)
        {
            return await _reservedFlightRepository.CreateReserved(request);
        }
        public bool UpdateReserved(Reservedflight reservedflight)
        {
            return _reservedFlightRepository.UpdateReserved(reservedflight);
        }
        public bool DeleteReserved(int id)
        {
            return _reservedFlightRepository.DeleteReserved(id);
        }
        public Reservedflight ReservedById(int id)
        {
            return _reservedFlightRepository.ReservedById(id);
        }
    }
}
