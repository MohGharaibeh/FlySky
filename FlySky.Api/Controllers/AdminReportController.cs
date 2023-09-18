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
        public List<AdminReport> SearchDate(AdminReport admin)  //commnet
        {
           return _adminReportService.SearchDate(admin);
        }

        [HttpPost]
        [Route("searchFlight")]
        public List<Flight> SearchDateFlight(Flight admin)  //commnet
        {
            return _adminReportService.SearchDateFlight(admin);
        }

        [HttpGet]
        [Route("chart")]
        public List<Chart> FullChart()
        {
            return _adminReportService.FullChart();
        }

    }
}
