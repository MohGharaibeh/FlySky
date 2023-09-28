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
using FlySky.Infra.Invoice;
using FlySky.Core.DTO;

namespace FlySky.Infra.Repository
{
    public class ReservedFlightRepository : IReservedFlightRepository
    {
        public BankData? bank = new BankData();
        Email email = new Email();
        UserAccountReposetory ur = new UserAccountReposetory();
        private readonly IDbContext _dbContext;
        public ReservedFlightRepository()
        {
            
        }
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
        private void FillInvoice ( BankData bank)
        {
            
          //  Useracount all= ur.UserById((int)reservedflight.Useracountid);
          //  string emails = all.Email;
          //  bank.ReservedDate = reservedflight.Reserveddate.Value;
            //bank.DepartureDate = reservedflight.Flight.Departuredate.Value;
            //bank.ArrivalDate = reservedflight.Flight.Arrivaldate.Value;
          //  bank.UserEmail = emails;
         //   var r = reservedflight.Flight.Price;
          //  var x = reservedflight.Numberofticket.Value;
          //  bank.TotalPrice = (decimal)r * x;
          email.GenerateFlightBookingPdf(bank);
        }
        public async Task<bool> CreateReserved(RequestData request)
        {
            
           // Task.Run(()=> email.GenerateFlightBookingPdf()) ;

            var p = new DynamicParameters();
            p.Add("numTicket", request.Reservedflight.Numberofticket, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("userid", request.Reservedflight.Useracountid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("fid", request.Reservedflight.Flightid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("resdate", request.Reservedflight.Reserveddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("RESERVEDFLIGHTpackage.createRESERVEDFLIGHT", p, commandType: CommandType.StoredProcedure);
            //  FillInvoice(request.Data);
            email.GenerateFlightBookingPdf(request.Data);
            return result < 0;

        }
        public bool UpdateReserved(Reservedflight reservedflight)
        {
            var p = new DynamicParameters();
            p.Add("reservid", reservedflight.Reservedflightid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("numTicket", reservedflight.Numberofticket, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("userid", reservedflight.Useracountid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("fid", reservedflight.Flightid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("resdate", reservedflight.Reserveddate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

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
