using UltraLogger.Core.Domain.Aggregates.Evaluations;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories;

public class EvaluationRepository(UnitOfWork uow) : IEvaluationRepository
{
    private readonly UnitOfWork _uow = uow;

    public IUnitOfWork UnitOfWork => _uow;

    public IEnumerable<Evaluation> GetAll()
    {
        string sql = "SELECT * FROM Evaluations";
        return _uow.Query<Evaluation>(sql);
    }
}
