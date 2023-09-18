using FlySky.Core.Data;
using FlySky.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Service
{
    public interface IAdminReportService
    {
        public List<AdminReport> FullReport();
        public List<AdminReport> SearchDate(AdminReport admin);
        public List<Flight> SearchDateFlight(Flight admin);
        public List<Chart> FullChart();
    }
}
