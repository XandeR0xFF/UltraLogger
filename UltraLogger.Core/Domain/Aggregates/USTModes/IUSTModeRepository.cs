using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.USTModes;

public interface IUSTModeRepository : IRepository<USTMode>
{
    IEnumerable<USTMode> GetAll();
}
