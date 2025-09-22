using UltraLogger.Core.Domain.Aggregates.UTResults;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories;

public class UTResultRepository(UnitOfWork uow) : IUTResultRepository
{
    private readonly UnitOfWork _uow = uow;

    public IUnitOfWork UnitOfWork => _uow;

    public UTResult? GetLastResultByPlatePartId(long platePartId)
    {
        string sql = "SELECT * FROM UTResults WHERE PlatePartId = @PlatePartId ORDER BY CreatedAtTicks DESC LIMIT 1";
        return _uow.QuerySingleOrDefault<UTResult>(sql, new { PlatePartId = platePartId });
    }
}
