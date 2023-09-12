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
    public class AboutRepository : IAboutRepository
    {
        private readonly IDbContext _context;

        public AboutRepository(IDbContext context)
        {
            _context = context;
        }

        public bool UpdateAbout(About about)
        {
            var p = new DynamicParameters();
            p.Add("abtid", about.Aboutid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("dsc", about.Descriptions, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("img", about.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t1", about.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t2", about.Text2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t3", about.Text3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t4", about.Text4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t5", about.Text5, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _context.Connection.Execute("aboutpackage.updateabout", p,
                commandType: CommandType.StoredProcedure);
            return result < 0;
        }
        public List<About> GetAll()
        {
            IEnumerable<About> result = _context.Connection.Query<About>("aboutpackage.getAllabout", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
