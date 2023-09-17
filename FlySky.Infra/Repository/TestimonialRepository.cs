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
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext _dbContext;

        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TestimonialAndUser> AllTestimonial()
        {
            IEnumerable<TestimonialAndUser> result = _dbContext.Connection.Query<TestimonialAndUser>
                ("Testimonial_Package.GetAllTestimonials", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("Message", testimonial.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("status", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("userID", testimonial.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Testimonial_Package.CreateTestimonial", p, commandType: CommandType.StoredProcedure);
            return result < 0;
        }

        public bool DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("TId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Testimonial_Package.DeleteTestimonial",
                p, commandType: CommandType.StoredProcedure);
            return result < 0;
        }

        public void UpdateTestimonial(Testimonial test)
        {
            var p = new DynamicParameters();
            p.Add("tid",test.Testimonialid, dbType: DbType.Int32, direction:ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Testimonial_Package.UpdateState",p, commandType: CommandType.StoredProcedure);
        }
    }
}
