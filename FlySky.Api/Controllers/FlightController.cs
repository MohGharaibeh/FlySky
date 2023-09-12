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
        public void CreateFlight([FromBody] Flight flight)
        {
            _flightService.CreateFlight(flight);
        }
        [Route("uploadImage")]
        [HttpPost]
        public Useracount UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Useracount user = new Useracount();
            user.Image = fileName;
            return user;
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
