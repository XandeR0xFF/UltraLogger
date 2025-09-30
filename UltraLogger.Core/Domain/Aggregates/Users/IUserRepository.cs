using System.Collections.Generic;
using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User Add(User user);
        void Update(User user);
        User? GetById(long id);
        User? GetByLogin(string login);
        IEnumerable<User> GetAll();
    }
}
