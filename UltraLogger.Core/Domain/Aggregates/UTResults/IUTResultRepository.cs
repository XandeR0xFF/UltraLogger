using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.UTResults;

public interface IUTResultRepository : IRepository<UTResult>
{
    UTResult Add(UTResult utResult);
    UTResult? GetLastResultByPlatePartId(long platePartId);
}
