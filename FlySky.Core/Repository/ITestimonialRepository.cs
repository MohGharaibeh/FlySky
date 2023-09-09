using FlySky.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Repository
{
    public interface ITestimonialRepository
    {
        public List<Testimonial> AllTestimonial();
        public bool CreateTestimonial(Testimonial testimonial);
        public bool DeleteTestimonial(int id);
    }
}
