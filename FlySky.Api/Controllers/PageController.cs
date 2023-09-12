using FlySky.Core.Data;
using FlySky.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlySky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IPageService pageService;

        public PageController(IPageService pageService)
        {
            this.pageService = pageService;
        }
        [HttpGet]
        public List<Page> AllPages()
        {
            return pageService.AllPages();
        }
        [HttpPut]
        public bool UpdatePage([FromBody] Page page)
        {
            return pageService.UpdatePage(page);
        }
        [Route("uploadImage")]
        [HttpPost]
        public Useracount UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Useracount user = new Useracount();
            user.Image = fileName;
            return user;
        }
    }
}
