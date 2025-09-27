using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Plates;

public interface IPlateRepository : IRepository<Plate>
{
    Plate Add(Plate plate);
    void Update(Plate plate);
    void Delete(Plate plate);
    Plate? GetById(long id);
    Plate? GetByDefectogramId(long defectogramId);
    IEnumerable<Plate> GetByReportId(long reportId);
}
