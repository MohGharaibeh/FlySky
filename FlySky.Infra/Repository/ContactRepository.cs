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
    public class ContactRepository: IContactRepository
    {
        private readonly IDbContext _dbContext;
        public ContactRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateContact(Contact contact)
        {
            var p = new DynamicParameters();
            p.Add("eml", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phn", contact.Phone, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("msg", contact.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("img", contact.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("sbjct", contact.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("snddt", contact.Senddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("ContactPackage.CreateContact", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateContact(Contact contact)
        {
            var p = new DynamicParameters();
            p.Add("cID", contact.Contactid, dbType: DbType.Int64, direction: ParameterDirection.Input);
            p.Add("eml", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phn", contact.Phone, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("msg", contact.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("img", contact.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("sbjct", contact.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("snddt", contact.Senddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("ContactPackage.UpdateContact", p, commandType: CommandType.StoredProcedure);

        }
        public void DeleteContact(int id)
        {

            var p = new DynamicParameters();
            p.Add("cid", id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("ContactPackage.DeleteContact", p, commandType: CommandType.StoredProcedure);

        }
        public List<Contact> GetAllContact()
        {
            IEnumerable<Contact> result = _dbContext.Connection.Query<Contact>("ContactPackage.GetAllContact", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public Contact GetContactById(int id)
        {
            var p = new DynamicParameters();
            p.Add("CID", id, dbType: DbType.Int64, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Query<Contact>("ContactPackage.GETBYID", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
