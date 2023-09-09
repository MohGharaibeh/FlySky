using FlySky.Core.Data;
using FlySky.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlySky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }
        [HttpPost]
        public void CreateFlight([FromForm] Flight flight, [FromForm] IFormFile image)
        {
            if (image != null)
            {
                var fileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine("Images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                flight.Image = fileName;
            }
            _flightService.CreateFlight(flight);
        }
        [HttpPut]
        public void UpdateFlight(Flight flight)
        {
            _flightService.UpdateFlight(flight);
        }
        [HttpDelete]
        public void DeleteFlight(int id)
        {
            _flightService.DeleteFlight(id);
        }
        [HttpGet]
        public List<Flight> GetAllFlight()
        {
            return _flightService.GetAllFlight();
        }
        [HttpGet]
        [Route("GetByID/{id}")]
        public Flight GetFlightById(int id)
        {
            return _flightService.GetFlightById(id);
        }
    }
}
