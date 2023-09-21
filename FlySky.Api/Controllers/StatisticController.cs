using FlySky.Core.Data;
using FlySky.Core.DTO;
using FlySky.Core.Service;
using FlySky.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlySky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {

        private readonly IStatisticService statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }

        [HttpGet]
        public int viewRegisterUsers()
        {
            return statisticService.GetAllviewRegisterUsers();
        }
        [HttpGet]
        [Route("viewAirport")]
        public int viewAirport()
        {
            return statisticService.GetAllAirport();
        }
        [HttpGet]
        [Route("maxReserveFlight")]
        public MaxReservedStatistic maxReserveFlight()
        {
            return statisticService.maxReserveFlight();
        }







    }
}
