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

namespace FlySky.Infra.Repository
{
    public class BankRepository: IBankRepository
    {
        private readonly IDbContext _dbContext;
        public BankRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateBank(Virtualbank bank)
        {
            var p = new DynamicParameters();
            p.Add("blnc", bank.Balance, dbType: DbType.Int64, direction: ParameterDirection.Input);
            p.Add("ban", bank.Iban, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cvnum", bank.Cvv, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("xdate", bank.Exdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("BankPackage.CreateBank", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateBank(Virtualbank bank)
        {
            var p = new DynamicParameters();
            p.Add("blnc", bank.Balance, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("ban", bank.Iban, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("cvnum", bank.Cvv, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("xdate", bank.Exdate, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("BankPackage.UpdateBank", p, commandType: CommandType.StoredProcedure);

        }
        public void DeleteBank(int id)
        {

            var p = new DynamicParameters();
            p.Add("cid", id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("BankPackage.DeleteBank", p, commandType: CommandType.StoredProcedure);

        }
        public List<Virtualbank> GetAllBank()
        {
            IEnumerable<Virtualbank> result = _dbContext.Connection.Query<Virtualbank>("BankPackage.GetAllBank", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Virtualbank GetBankById(int id)
        {
            var p = new DynamicParameters();
            p.Add("CID", id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Virtualbank>("BankPackage.GETBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
