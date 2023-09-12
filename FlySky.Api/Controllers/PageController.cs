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
        public bool UpdatePage([FromForm] Page page, [FromForm] IFormFile image)
        {
            if (image != null)
            {

                var fileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine("Images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                page.Image = fileName;
            }
            return pageService.UpdatePage(page);
        }
    }
}
