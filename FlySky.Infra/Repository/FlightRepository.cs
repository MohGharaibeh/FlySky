using Dapper;
using FlySky.Core.common;
using FlySky.Core.Data;
using FlySky.Core.DTO;
using FlySky.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Infra.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IDbContext _dbContext;
        public FlightRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateFlight(Flight flight)
        {
            var p = new DynamicParameters();
            p.Add("fcapacity", flight.Capacity, dbType: DbType.Int64, direction: ParameterDirection.Input);
            p.Add("fstatus", flight.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("fprice", flight.Price, dbType: DbType.Int64, direction: ParameterDirection.Input);
            p.Add("depdate", flight.Departuredate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("arrdate", flight.Arrivaldate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("fdescription", flight.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("fimage", flight.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("fromc", flight.Fromcountry, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("toc", flight.Tocountry, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("tclass", flight.Travelclass, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("fid", flight.Fromid, dbType: DbType.Int64, direction: ParameterDirection.Input);
            p.Add("tid", flight.Toid, dbType: DbType.Int64, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("flightPackage.createFlight", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateFlight(Flight flight)
        {
            var p = new DynamicParameters();
            p.Add("fid", flight.Flightid, dbType: DbType.Int64, direction: ParameterDirection.Input);
            p.Add("fcapacity", flight.Capacity, dbType: DbType.Int64, direction: ParameterDirection.Input);
            p.Add("fstatus", flight.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("fprice", flight.Price, dbType: DbType.Int64, direction: ParameterDirection.Input);
            p.Add("depdate", flight.Departuredate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("arrdate", flight.Arrivaldate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("fdescription", flight.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("fimage", flight.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("fromc", flight.Fromcountry, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("toc", flight.Tocountry, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("tclass", flight.Travelclass, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("frmid", flight.Fromid, dbType: DbType.Int64, direction: ParameterDirection.Input);
            p.Add("tid", flight.Toid, dbType: DbType.Int64, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("flightPackage.updateFlight", p, commandType: CommandType.StoredProcedure);

        }
        public void DeleteFlight(int id)
        {

            var p = new DynamicParameters();
            p.Add("fid", id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("flightPackage.deleteFlight", p, commandType: CommandType.StoredProcedure);

        }
        public List<FlightAndAorport> GetAllFlight()
        {
            IEnumerable<FlightAndAorport> result = _dbContext.Connection.Query<FlightAndAorport>("flightPackage.getAllFlight", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public FlightAndAorport GetFlightById(int id)
        {
            var p = new DynamicParameters();
            p.Add("fid", id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<FlightAndAorport>("flightPackage.getFlightByID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
