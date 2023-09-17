using FlySky.Core.Data;
using FlySky.Core.DTO;
using FlySky.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlySky.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminReportController : ControllerBase
    {
        private readonly IAdminReportService _adminReportService;

        public AdminReportController(IAdminReportService adminReportService)
        {
            _adminReportService = adminReportService;
        }
        // comment
        [HttpGet]
        public List<AdminReport> FullReport()
        {
            return _adminReportService.FullReport();
        }
        [HttpPost]
        [Route("searchReport")]
        public List<AdminReport> SearchDate(AdminReport admin)
        {
           return _adminReportService.SearchDate(admin);
        }
    }
}
