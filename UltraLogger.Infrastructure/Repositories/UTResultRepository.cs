using UltraLogger.Core.Domain.Aggregates.Customers;
using UltraLogger.Core.Domain.Aggregates.UTResults;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories;

public class UTResultRepository(UnitOfWork uow) : IUTResultRepository
{
    private readonly UnitOfWork _uow = uow;

    public IUnitOfWork UnitOfWork => _uow;

    public UTResult Add(UTResult utResult)
    {
        UTResult addedResult = utResult;

        if (utResult.IsTransient())
        {
            long newId = _uow.GetNewId("UTResults");
            addedResult = new UTResult(newId, utResult.CreatedAtTicks, utResult.PlatePartId, utResult.UserId, utResult.EvaluationId);
        }

        _uow.Execute(@"INSERT INTO UTResults(Id, CreatedAtTicks, PlatePartId, UserId, EvaluationId)
                       VALUES(@Id, @CreatedAtTicks, @PlatePartId, @UserId, @EvaluationId)", addedResult);

        return addedResult;
    }

    public UTResult? GetLastResultByPlatePartId(long platePartId)
    {
        string sql = "SELECT * FROM UTResults WHERE PlatePartId = @PlatePartId ORDER BY CreatedAtTicks DESC LIMIT 1";
        return _uow.QuerySingleOrDefault<UTResult>(sql, new { PlatePartId = platePartId });
    }
}
