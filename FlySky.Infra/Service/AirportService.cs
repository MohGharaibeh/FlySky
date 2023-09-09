using FlySky.Core.Data;
using FlySky.Core.Repository;
using FlySky.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Infra.Service
{
    public class AirportService: IAirportService
    {
        private readonly IAirportRepository airportRepository;
        public AirportService(IAirportRepository airportRepository)
        {
            this.airportRepository = airportRepository;
        }
        public void CreateAirport(Airport airport)
        {
            airportRepository.CreateAirport(airport);
        }
        public void UpdateAirport(Airport airport)
        {
            airportRepository.UpdateAirport(airport);
        }
        public void DeleteAirport(int id)
        {
            airportRepository.DeleteAirport(id);
        }
        public List<Airport> GetAllAirports()
        {
            return airportRepository.GetAllAirports();
        }
        public Airport GetAirportById(int id)
        {
            return airportRepository.GetAirportById(id);
        }
    }
}
