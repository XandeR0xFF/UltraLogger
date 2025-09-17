using UltraLogger.Core.Domain.Aggregates.USTModes;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories;

public class USTModeRepository(UnitOfWork uow) : IUSTModeRepository
{
    private readonly UnitOfWork _uow = uow;

    public IUnitOfWork UnitOfWork => _uow;

    public IEnumerable<USTMode> GetAll()
    {
        string sql = @"SELECT * FROM USTModes ORDER BY Id";
        return _uow.Query<USTMode>(sql);
    }
}
