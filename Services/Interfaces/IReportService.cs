using Entities.Reports;

namespace Services.Interfaces
{
    public interface IReportService
    {
        byte[] PrintApprovedStudentsReport(ReportParams parameters);
    }
}
