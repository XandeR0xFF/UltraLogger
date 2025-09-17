using System.Collections.Generic;
using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetByLogin(string login);

    }
}
