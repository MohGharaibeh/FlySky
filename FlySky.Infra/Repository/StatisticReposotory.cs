using Dapper;
using FlySky.Core.common;
using FlySky.Core.Data;
using FlySky.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FlySky.Infra.Repository
{
    public class StatisticReposotory : IStatisticReposotory
    {
        private readonly IDbContext _dbContext;

        public StatisticReposotory(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int GetAllAirport()
        {
            int result = _dbContext.Connection.QueryFirstOrDefault<int>("statistic.viewAirport", commandType: CommandType.StoredProcedure);
            return result;
        }

        public int GetAllviewRegisterUsers()
        {       
            int result = _dbContext.Connection.QueryFirstOrDefault<int>("statistic.viewRegisterUsers", commandType: CommandType.StoredProcedure);
            return result;
        }

        public string maxReserveFlight()
        {
            string result = _dbContext.Connection.QueryFirstOrDefault<string>("statistic.maxReserveFlight", commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
