using DataAccess.Interfaces;
using Entities.Reports;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Reports.Services.Interfaces;
using Services.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace Services
{
    public class ReportService : IReportService
    {
        private readonly IFinalGradeRepository _finalGradeRepository;
        private readonly IPdfFileGenerator _pdfFileGenerator;
        private readonly ITemplateService _templateService;
        private readonly IConfiguration _configuration;

        public ReportService(
            IFinalGradeRepository finalGradeRepository,
            IPdfFileGenerator pdfFileGenerator,
            ITemplateService templateService,
            IConfiguration configuration) 
        {
            _finalGradeRepository = finalGradeRepository;
            _pdfFileGenerator = pdfFileGenerator;
            _templateService = templateService;
            _configuration = configuration;
        }
        public byte[] PrintApprovedStudentsReport(ReportParams parameters)
        {
            var result = _finalGradeRepository.ListFinalGradeBySemester(parameters.SemesterCode);
            var finalGrades = result.Select(f => new FinalGradeBySemesterReport
            { 
                GivenName = f.GivenName,
                Grade = f.Grade,
                ShortName = f.ShortName,
                Result = f.Grade>=51? "Aprobado" : "Reprobado"
            }).ToList();

            var builder = new BodyBuilder();

            using (StreamReader SourceReader = System.IO.File.OpenText("wwwroot/Templates/Reports/FinalGradeBySemesterReport.html"))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            string htmlBody = builder.HtmlBody
                 .Replace("#Logo#", _configuration["LogoUrl"])
                .Replace("#semester#", result.First().Name);

            htmlBody = _templateService.GenerateTableTemplate<FinalGradeBySemesterReport>(htmlBody, finalGrades);

            return _pdfFileGenerator.GeneratePdf(htmlBody);
        }
    }
}
