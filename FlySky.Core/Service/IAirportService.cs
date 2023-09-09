using FlySky.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Service
{
    public interface IAirportService
    {
        void CreateAirport(Airport airport);
        void UpdateAirport(Airport airport);
        void DeleteAirport(int id);
        List<Airport> GetAllAirports();
        Airport GetAirportById(int id);
    }
}
