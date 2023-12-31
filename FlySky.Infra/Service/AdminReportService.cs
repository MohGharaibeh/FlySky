﻿using FlySky.Core.Data;
using FlySky.Core.DTO;
using FlySky.Core.Repository;
using FlySky.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlySky.Infra.Service
{
    public class AdminReportService : IAdminReportService
    {
        private readonly IAdminReportRepository _adminReportRepository;

        public AdminReportService(IAdminReportRepository adminReportRepository)
        {
            _adminReportRepository = adminReportRepository;
        }

        public List<AdminReport> FullReport()
        {
            return _adminReportRepository.FullReport();
        }

        public List<AdminReport> SearchDate(AdminReport admin)
        {
            return _adminReportRepository.SearchDate(admin);
        }

        public List<FlightAndAorport> SearchDateFlight(FlightAndAorport admin)
        {
            return _adminReportRepository.SearchDateFlight(admin);
        }
        public List<Chart> FullChart()
        {
            return _adminReportRepository.FullChart();
        }

        public Profits AllProfit()
        {
            return _adminReportRepository.AllProfit();
        }
    }
}
