using UltraLogger.Core.Domain.Aggregates.Users;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories;

public class UserRepository(UnitOfWork uow) : IUserRepository
{
    private readonly UnitOfWork _uow = uow;

    public IUnitOfWork UnitOfWork => _uow;

    public IEnumerable<User> GetAll()
    {
        return _uow.Query<User>("SELECT * FROM Users");
    }

    public User? GetById(long id)
    {
        string sql = "SELECT * FROM Users WHERE Id = @Id";
        return _uow.QuerySingleOrDefault<User>(sql, new { Id = id });
    }

    public User? GetByLogin(string login)
    {
        string sql = "SELECT * FROM Users  WHERE Login COLLATE NOCASE = @userLogin";
        return _uow.QuerySingleOrDefault<User>(sql, new { userLogin = login });
    }

}
