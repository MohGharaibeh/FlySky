using FlySky.Core.Data;
using FlySky.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlySky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonial;

        public TestimonialController(ITestimonialService testimonial)
        {
            _testimonial = testimonial;
        }
        [HttpGet]
        public List<Testimonial> AllTestimonial()
        {
            return _testimonial.AllTestimonial();
        }
        [HttpPost]
        public bool CreateTestimonial(Testimonial testimonial)
        {
            return _testimonial.CreateTestimonial(testimonial);
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public bool DeleteTestimonial(int id)
        {
            return _testimonial.DeleteTestimonial(id);
        }
        [HttpPut]
        [Route("updateTest")]
        public void UpdateTestimonial(Testimonial test)
        {
            _testimonial.UpdateTestimonial(test);
        }
    }
}
