using Entities.Reports;

//Interfaces para el servicio de Reporte (No se usa debido a el deploy gratuito de Azure no permite hacer PDFs)

namespace Services.Interfaces
{
    public interface IReportService
    {
        byte[] PrintApprovedStudentsReport(ReportParams parameters);
    }
}
