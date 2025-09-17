using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Plates;

public interface IPlateRepository : IRepository<Plate>
{
    Plate? GetByDefectogramId(long defectogramId);
}
