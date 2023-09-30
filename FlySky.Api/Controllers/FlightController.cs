using FlySky.Core.Data;
using FlySky.Core.DTO;
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
        public Flight UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\DELL\\source\\repos\\FlySkyFE\\src\\assets\\ApiImage", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Flight user = new Flight();
            user.Image = fileName;
            return user;
        }
        [HttpPut]
        public void UpdateFlight(Flight flight)
        {
            _flightService.UpdateFlight(flight);
        }
        [HttpDelete("{id}")]
        public void DeleteFlight(int id)
        {
            _flightService.DeleteFlight(id);
        }
       
        [HttpGet]
        public List<FlightAndAorport> GetAllFlight()
        {
            return _flightService.GetAllFlight();
        }
        [HttpGet]
        [Route("GetByID/{id}")]
        public FlightAndAorport GetFlightById(int id)
        {
            return _flightService.GetFlightById(id);
        }
    }
}
