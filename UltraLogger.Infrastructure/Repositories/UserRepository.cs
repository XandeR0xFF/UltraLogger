using System.Data.Common;
using UltraLogger.Core.Domain.Aggregates.Users;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories;

public class UserRepository(UnitOfWork uow) : IUserRepository
{
    private readonly UnitOfWork _uow = uow;

    public IUnitOfWork UnitOfWork => _uow;


    public User? GetByLogin(string login)
    {
        string sql = @"SELECT * FROM ""Users""  WHERE ""Login"" COLLATE NOCASE = @userLogin";
        User? user = _uow.QuerySingleOrDefault<User>(sql, new { userLogin = login });
        return user;
    }

}
