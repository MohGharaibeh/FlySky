using Dapper;
using FlySky.Core.common;
using FlySky.Core.Data;
using FlySky.Core.Repository;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Infra.Repository
{
    public class ReservedFlightRepository : IReservedFlightRepository
    {
        private readonly IDbContext _dbContext;

        public ReservedFlightRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Reservedflight> AllReserved()
        {
            IEnumerable<Reservedflight> all = _dbContext.Connection.Query<Reservedflight>
                ("RESERVEDFLIGHTpackage.getAllRESERVEDFLIGHT", commandType: CommandType.StoredProcedure);
            return all.ToList();
        }
        public bool CreateReserved(Reservedflight reservedflight)
        {
            var p = new DynamicParameters();
            p.Add("numTicket", reservedflight.Numberofticket, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("userid", reservedflight.Useracountid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("fid", reservedflight.Flightid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("RESERVEDFLIGHTpackage.createRESERVEDFLIGHT", p, commandType: CommandType.StoredProcedure);
            return result < 0;

        }
        public bool UpdateReserved(Reservedflight reservedflight)
        {
            var p = new DynamicParameters();
            p.Add("reservid", reservedflight.Reservedflightid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("numTicket", reservedflight.Numberofticket, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("userid", reservedflight.Useracountid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("fid", reservedflight.Flightid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("RESERVEDFLIGHTpackage.updateRESERVEDFLIGHT", p, commandType: CommandType.StoredProcedure);
            return result < 0;
        }
        public bool DeleteReserved(int id)
        {
            var p = new DynamicParameters();
            p.Add("reservid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("RESERVEDFLIGHTpackage.deleteRESERVEDFLIGHT", p, commandType: CommandType.StoredProcedure);
            return result < 0;
        }
        public Reservedflight ReservedById(int id)
        {
            var p = new DynamicParameters();
            p.Add("reservid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Reservedflight>("RESERVEDFLIGHTpackage.getRESERVEDFLIGHTbyID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
