using UltraLogger.Core.Domain.Aggregates.Users;

namespace UltraLogger.Core.Application.Common;

public interface ISessionManager
{
    public User CurrentUser { get; }
    void BeginSession(User user);
    void EndSession();
}
