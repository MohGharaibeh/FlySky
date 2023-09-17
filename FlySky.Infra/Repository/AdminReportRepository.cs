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

        public List<AdminReport> SearchDate(AdminReport admin)
        {
            var p = new DynamicParameters();
            p.Add("DDate", admin.departuredate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("ARDate", admin.arrivaldate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<AdminReport>("Search.SearchReport", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
