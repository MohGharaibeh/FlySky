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
    public class PageRepository : IPageRepository
    {
        private readonly IDbContext _dbContext;

        public PageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Page> AllPages()
        {
            IEnumerable<Page> all = _dbContext.Connection.Query<Page>("Pages_Package.GetAllPages", commandType: CommandType.StoredProcedure);
            return all.ToList();
        }
        public bool UpdatePage(Page page)
        {
            var p = new DynamicParameters();
            p.Add("pID", page.Pagesid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p", page.Paragraph, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("img", page.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t1", page.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t2", page.Text2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t3", page.Text3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t4", page.Text4, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t5", page.Text5, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t6", page.Text6, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("t7", page.Text7, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Pages_Package.UpdatePage", p, commandType: CommandType.StoredProcedure);
            return result < 0;
        }
    }
}
