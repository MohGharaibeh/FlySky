using FlySky.Core.Data;
using FlySky.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Repository
{
    public interface ITestimonialRepository
    {
        public List<TestimonialAndUser> AllTestimonial();
        public bool CreateTestimonial(Testimonial testimonial);
        public bool DeleteTestimonial(int id);
        public void UpdateTestimonial(Testimonial test);
    }
}
