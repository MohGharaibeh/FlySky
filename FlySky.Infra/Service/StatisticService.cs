using FlySky.Core.Data;
using FlySky.Core.DTO;
using FlySky.Core.Repository;
using FlySky.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Infra.Service
{
    public class StatisticService : IStatisticService
    {
        private readonly IStatisticReposotory service;
        public StatisticService(IStatisticReposotory _service)
        {
            service = _service;
        }
        public int GetAllAirport()
        {
            return service.GetAllAirport();
        }

        public int GetAllviewRegisterUsers()
        {
            return service.GetAllviewRegisterUsers();
        }

        public MaxReservedStatistic maxReserveFlight()
        {
            return service.maxReserveFlight();
        }
    }
}
