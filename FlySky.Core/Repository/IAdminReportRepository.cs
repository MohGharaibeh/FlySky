using FlySky.Core.Data;
using FlySky.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Core.Repository
{
    public interface IAdminReportRepository
    {
        public List<AdminReport> FullReport();
        public List<Flight> SearchDate(Flight flight);
    }
}
