using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Defectograms;

public interface IDefectogramRepository : IRepository<Defectogram>
{
    Defectogram Add(Defectogram defectogram);
    void Update(Defectogram defectogram);
    void Delete(Defectogram defectogram);
    Defectogram? GetById(long id);
    IEnumerable<Defectogram> GetAll();
}
