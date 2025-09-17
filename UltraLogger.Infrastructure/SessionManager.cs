using UltraLogger.Core.Application.Common;
using UltraLogger.Core.Domain.Aggregates.Users;

namespace UltraLogger.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        public User? CurrentUser { get; private set; }
        public void BeginSession(User user)
        {
            CurrentUser = user;
        }

        public void EndSession()
        {
            CurrentUser = null;
        }
    }
}
