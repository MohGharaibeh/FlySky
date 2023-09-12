using FlySky.Core.Data;
using FlySky.Core.Service;
using FlySky.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlySky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _service;

        public AboutController(IAboutService service)
        {
            _service = service;
        }

        [HttpPut]
        public void UpdateAbout(About about)
        {
            _service.UpdateAbout(about);
        }
        
        [HttpGet]
        public List<About> GetAllAbout()
        {
            return _service.GetAll();
        }
    }
}
