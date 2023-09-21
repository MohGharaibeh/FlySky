using FlySky.Core.Data;
using FlySky.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Service
{
    public interface IStatisticService
    {
        int GetAllAirport();
        int GetAllviewRegisterUsers();
        MaxReservedStatistic maxReserveFlight();

    }
}
