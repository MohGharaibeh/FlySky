using FlySky.Core.Data;
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
        string maxReserveFlight();

    }
}
