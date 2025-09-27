using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Reports;

public interface IReportRepository : IRepository<Report>
{
    Report Add(Report report);
    void Update(Report report);
    void Delete(Report report);
    Report? GetById(long id);
    IEnumerable<Report> GetAll();
}
