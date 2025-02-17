﻿using Entities.Reports;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

//Endpoints del reporte

namespace Support_System_Server_v2.Controllers
{
    [Route("api/report")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        //Post para imprimir el reporte PDF
        [HttpPost]
        [Route("print")]
        public ActionResult Post(ReportParams parameters)
        {
            byte[] reportFile = null;
            reportFile = _reportService.PrintApprovedStudentsReport(parameters);

            return File(reportFile, "application/pdf", "Approved_Report.pdf");
        }
    }
}
