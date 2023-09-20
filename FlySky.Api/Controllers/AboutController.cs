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
        // abount 

        public AboutController(IAboutService service)
        {
            _service = service;
        }

        [HttpPut]
        public void UpdateAbout(About about)
        {
            _service.UpdateAbout(about);
        }
        [Route("uploadImage")]
        [HttpPost]
        public Useracount UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("D:\\Angular\\Demo\\src\\assets\\ApiImage", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Useracount user = new Useracount();
            user.Image = fileName;
            return user;
        }

        [HttpGet]
        public List<About> GetAllAbout()
        {
            return _service.GetAll();
        }
        [HttpGet]
        [Route("GetId")]
        public About GetById()
        {
            return _service.GetById();
        }
    }
}
