using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Defectograms;

public interface IDefectogramRepository : IRepository<Defectogram>
{
    IEnumerable<Defectogram> GetAll();
}
