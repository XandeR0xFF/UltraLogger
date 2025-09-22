using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Evaluations;

public interface IEvaluationRepository : IRepository<Evaluation>
{
    IEnumerable<Evaluation> GetAll();
}
