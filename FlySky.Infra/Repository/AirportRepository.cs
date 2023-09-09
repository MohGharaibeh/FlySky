using Dapper;
using FlySky.Core.Data;
using FlySky.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FlySky.Infra.common;
using FlySky.Core.common;

namespace FlySky.Infra.Repository
{
    public class AirportRepository: IAirportRepository
    {
        private readonly IDbContext _dbContext;
        public AirportRepository(IDbContext dbContext) {
            _dbContext = dbContext;
        }
        public void CreateAirport(Airport airport)
        {
            var p = new DynamicParameters();
            p.Add("cname",airport.Name,dbType: DbType.String,direction: ParameterDirection.Input);
            p.Add("loc", airport.Location,dbType: DbType.String,direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("AirportPackage.CreateAirport", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateAirport(Airport airport)
        {
            var p = new DynamicParameters();
            p.Add("cID", airport.Airportid, dbType: DbType.Int64, direction: ParameterDirection.Input);
            p.Add("cname", airport.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("loc", airport.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("AirportPackage.UpdateAirport", p, commandType: CommandType.StoredProcedure);

        }
        public void DeleteAirport(int id) { 
        
            var p = new DynamicParameters();
            p.Add("cid", id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("AirportPackage.DeleteAirport", p, commandType: CommandType.StoredProcedure);

        }
        public List<Airport> GetAllAirports()
        {
            IEnumerable<Airport> result = _dbContext.Connection.Query<Airport>("AirportPackage.GetAllAirport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Airport GetAirportById(int id)
        {
            var p = new DynamicParameters();
            p.Add("CID", id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Airport>("AirportPackage.GETBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

    }
}
