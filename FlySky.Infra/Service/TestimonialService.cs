using FlySky.Core.Data;
using FlySky.Core.Repository;
using FlySky.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _repository;

        public TestimonialService(ITestimonialRepository repository)
        {
            _repository = repository;
        }
        public List<Testimonial> AllTestimonial()
        {
            return _repository.AllTestimonial();
        }
        public bool CreateTestimonial(Testimonial testimonial)
        {
            return _repository.CreateTestimonial(testimonial);
        }
        public bool DeleteTestimonial(int id)
        {
            return _repository.DeleteTestimonial(id);
        }
        public void UpdateTestimonial(Testimonial test)
        {
            _repository.UpdateTestimonial(test);
        }
    }
}
