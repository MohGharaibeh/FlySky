using Dapper;
using FlySky.Core.common;
using FlySky.Core.DTO;
using FlySky.Core.Repository;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlySky.Core.Data;

namespace FlySky.Infra.Repository
{
    public class AdminReportRepository : IAdminReportRepository
    {
        private readonly IDbContext _dbContext;

        public AdminReportRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AdminReport> FullReport()
        {
            IEnumerable<AdminReport> reports = _dbContext.Connection.Query<AdminReport>("reportpackage.fullreport", commandType: CommandType.StoredProcedure);
            return reports.ToList();
        }

        public List<Flight> SearchDate(Flight flight)
        {
            var p = new DynamicParameters();
            p.Add("DDate", flight.Departuredate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("ARDate", flight.Arrivaldate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Flight>("Search.Search_By_Date", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
