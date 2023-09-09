using FlySky.Core.Data;
using FlySky.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlySky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservedFlightController : ControllerBase
    {
        private readonly IReservedFlightService _reservedFlightService;

        public ReservedFlightController(IReservedFlightService reservedFlightService)
        {
            _reservedFlightService = reservedFlightService;
        }
        [HttpGet]
        public List<Reservedflight> AllReserved()
        {
            return _reservedFlightService.AllReserved();
        }
        [HttpPost]
        public bool CreateReserved(Reservedflight reservedflight)
        {
            return _reservedFlightService.CreateReserved(reservedflight);
        }
        [HttpPut]
        public bool UpdateReserved(Reservedflight reservedflight)
        {
            return _reservedFlightService.UpdateReserved(reservedflight);
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public bool DeleteReserved(int id)
        {
            return _reservedFlightService.DeleteReserved(id);
        }
        [Route("get/{id}")]
        [HttpGet]
        public Reservedflight ReservedById(int id)
        {
            return _reservedFlightService.ReservedById(id);
        }
    }
}
