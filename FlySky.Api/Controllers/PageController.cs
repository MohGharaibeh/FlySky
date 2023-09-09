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
        public bool UpdatePage(Page page)
        {
            return pageService.UpdatePage(page);
        }
    }
}
