using UltraLogger.Core.Domain.Aggregates.Customers;
using UltraLogger.Core.Domain.Aggregates.Reports;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories
{
    internal class ReportRepository(UnitOfWork uow) : IReportRepository
    {
        private readonly UnitOfWork _uow = uow;

        public IUnitOfWork UnitOfWork => _uow;

        public Report Add(Report report)
        {
            Report addedReport = report;

            if (report.IsTransient())
            {
                long newId = _uow.GetNewId("Customers");
                addedReport = new Report(newId, report.CreatedAtTicks, report.OrderId);
            }

            _uow.Execute(@"INSERT INTO Reports(Id, CreatedAtTicks, OrderId)
                       VALUES(@Id, @CreatedAtTicks, @OrderId)", addedReport);

            return addedReport;
        }

        public void Update(Report report)
        {
            if (report.IsTransient())
                throw new InvalidOperationException("Updated customer is transient.");

            _uow.Execute(@"UPDATE Reports
                     SET
                        CreatedAtTicks = @CreatedAtTicks,
                        OrderId = @OrderId
                     WHERE Id = @Id", report);
        }

        public void Delete(Report report)
        {
            _uow.Execute("DELETE FROM Reports WHERE Id = @Id", report);
        }

        public Report? GetById(long id)
        {
            return _uow.QuerySingleOrDefault<Report>("SELECT * FROM Reports WHERE Id = @Id", new { Id = id });
        }

        public IEnumerable<Report> GetAll()
        {
            return _uow.Query<Report>("SELECT * FROM Reports ORDER BY CreatedAtTicks");
        }
    }
}
