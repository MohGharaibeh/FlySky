using FlySky.Core.Data;
using FlySky.Core.Service;
using FlySky.Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlySky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService airportService;
        public AirportController(IAirportService airportService)
        {
            this.airportService = airportService;
        }
        [HttpPost]
        public void CreateAirport(Airport airport)
        {
            airportService.CreateAirport(airport);
        }
        [HttpPut]
        public void UpdateAirport(Airport airport)
        {
            airportService.UpdateAirport(airport);
        }
        [HttpDelete]
        public void DeleteAirport(int id)
        {
            airportService.DeleteAirport(id);
        }
        [HttpGet]
        public List<Airport> GetAllAirports()
        {
            return airportService.GetAllAirports();
        }
        [HttpGet]
        [Route("GetByID/{id}")]
        public Airport GetAirportById(int id)
        {
            return airportService.GetAirportById(id);
        }
    }
}
