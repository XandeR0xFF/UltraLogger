using UltraLogger.Core.Domain.Aggregates.Defectograms;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories;

public class DefectogramRepository(UnitOfWork uow) : IDefectogramRepository
{
    private readonly UnitOfWork _uow = uow;
    public IUnitOfWork UnitOfWork => _uow;

    public IEnumerable<Defectogram> GetAll()
    {
        string sql = @"SELECT * FROM Defectograms ORDER BY ""CreatedAtTicks""";
        return _uow.Query<Defectogram>(sql);
    }
}
