using FlySky.Core.Data;
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
        List<Flight> GetAllFlight();
        Flight GetFlightById(int id);
    }
}
