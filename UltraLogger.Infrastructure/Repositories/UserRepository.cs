using UltraLogger.Core.Domain.Aggregates.Users;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories;

public class UserRepository(UnitOfWork uow) : IUserRepository
{
    private readonly UnitOfWork _uow = uow;

    public IUnitOfWork UnitOfWork => _uow;

    public User Add(User user)
    {
        User userForInsert = user;
        if (user.IsTransient())
        {
            long newId = _uow.GetNewId("Users");
            userForInsert = new User(newId, user.Login, user.FirstName, user.LastName, user.MiddleName, user.PasswordHash, user.IsActive, user.CreatedAtTicks);
        }
        _uow.Execute(@"INSERT INTO Users(Id, Login, FirstName, LastName, MiddleName, PasswordHash, IsActive, CreatedAtTicks)
                       VALUES(@Id, @Login, @FirstName, @LastName, @MiddleName, @PasswordHash, @IsActive, @CreatedAtTicks)", userForInsert);
        return userForInsert;
    }

    public void Update(User user)
    {
        if (user.IsTransient())
            throw new InvalidOperationException("Updated user is transient.");

        _uow.Execute(@"UPDATE Users
                     SET
                        Login = @Login,
                        FirstName = @FirstName,
                        LastName = @LastName,
                        MiddleName = @MiddleName,
                        PasswordHash = @PasswordHash,
                        IsActive = @IsActive,
                        CreatedAtTicks = @CreatedAtTicks
                     WHERE Id = @Id", user);
    }

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
