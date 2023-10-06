using FlySky.Core.Data;
using FlySky.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Repository
{
    public interface IFlightRepository
    {
        void CreateFlight(Flight flight);
        void UpdateFlight(Flight flight);
        void DeleteFlight(int id);
        List<FlightAndAorport> GetAllFlight();
        FlightAndAorport GetFlightById(int id);
        void UpdateCapacity(Flight flight);

    }
}
