using FlySky.Core.Data;
using FlySky.Core.DTO;
using FlySky.Core.Service;
using FlySky.Infra.Invoice;
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
        public async Task<bool> CreateReserved(RequestData request)
        {
            return await _reservedFlightService.CreateReserved(request);
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
