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
        [HttpGet]
        [Route("GetId")]
        public Page GetPage()
        {
            return pageService.GetPage();
        }
        [HttpPut]
        public bool UpdatePage([FromBody] Page page)
        {
            return pageService.UpdatePage(page);
        }
        [Route("uploadImage")]
        [HttpPost]
        public Page UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\DELL\\source\\repos\\FlySkyFE\\src\\assets\\ApiImage", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Page user = new Page();
            user.Image = fileName;
            return user;
        }
    }
}
