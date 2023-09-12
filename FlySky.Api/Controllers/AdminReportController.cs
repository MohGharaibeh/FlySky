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

        [HttpGet]
        public List<AdminReport> FullReport()
        {
            return _adminReportService.FullReport();
        }
        [HttpPost]
        public List<Flight> SearchDate(Flight flight)
        {
           return _adminReportService.SearchDate(flight);
        }
    }
}
