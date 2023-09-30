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
using FlySky.Core.DTO;

namespace FlySky.Infra.Repository
{
    public class UserAccountReposetory : IUserAccountRepository
    {
        private readonly IDbContext _dbContext;
        public UserAccountReposetory()
        {
            
        }
        public UserAccountReposetory(IDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        public List<Useracount> AllUsers()
        {
            IEnumerable<Useracount> result = _dbContext.Connection.Query<Useracount>
                ("UserAcountPackage.GetAllUserAcount", commandType: CommandType.StoredProcedure);
            _dbContext.Connection.Close();
            return result.ToList();
        }
        public bool CreateUser(Useracount useracount)
        {
            var p = new DynamicParameters();
            p.Add("p_fname", useracount.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_lname", useracount.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", useracount.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_password", useracount.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_image", useracount.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_birthdate", useracount.Birthdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_roleID", useracount.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("UserAcountPackage.createUserAcount", p, commandType: CommandType.StoredProcedure);
            return result < 0;
        }
        public bool UpdateUser(Useracount useracount)
        {
            var p = new DynamicParameters();
            p.Add("p_userAcountid", useracount.Useracountid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_fname", useracount.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_lname", useracount.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_email", useracount.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_password", useracount.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_image", useracount.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_birthdate", useracount.Birthdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_roleID", useracount.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("UserAcountPackage.UpdateUserAcount", p,
                commandType: CommandType.StoredProcedure);
            return result < 0;
        }
        public bool DeleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_userAcountid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("UserAcountPackage.DeleteUserAcount", p,
                commandType: CommandType.StoredProcedure);
            return result < 0;
        }
        public Useracount UserById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_userAcountid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Useracount>("UserAcountPackage.GetUserAcountByID", p,
                commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public Useracount Login(Useracount useracount)
        {
            var p = new DynamicParameters();
            p.Add("uemail", useracount.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("pas", useracount.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Useracount> result = _dbContext.Connection.Query<Useracount>
                ("Authentications.Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
        public List<Flight> SearchByDate(Flight flight)
        {
            var p = new DynamicParameters();
            p.Add("depDate", flight.Departuredate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("arrDate", flight.Arrivaldate, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Flight>("userSearch_package.searchDepArr", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<Flight> SearchByCountry(Flight flight)
        {
            var p = new DynamicParameters();
            p.Add("fcounty", flight.Fromcountry, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("tcountry", flight.Tocountry, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Flight>("userSearch_package.searchFromToCountry", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ReservedFlightByUser> ReservedUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<ReservedFlightByUser> result = _dbContext.Connection.Query<ReservedFlightByUser>
                ("UserAcountPackage.ReservedFlightByUser", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public List<TrackingMap> TrackInMap(int id)
        {
            var p = new DynamicParameters();
            p.Add("uid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<TrackingMap> result = _dbContext.Connection.Query<TrackingMap>
                ("UserAcountPackage.TrackingMap", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
