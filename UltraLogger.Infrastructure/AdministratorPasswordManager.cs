using UltraLogger.Core.Application.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure;

public class AdministratorPasswordManager(UnitOfWork uow) : IAdministratorPasswordManager
{
    private readonly UnitOfWork _uow = uow;

    public string GetPasswordHash()
    {
        string? password = _uow.QuerySingleOrDefault<string>("SELECT Value FROM Settings WHERE Key = 'AdminPasswordHash'");

        if (password == null)
            throw new InvalidOperationException("Admin password entry not found");

        return password;
    }

    public void UpdatePasswordHash(string passwordHash)
    {
        int rowsCount = _uow.Execute("UPDATE Settings SET Value = @Value WHERE Key = 'AdminPasswordHash'", new { Value = passwordHash });
        if (rowsCount != 1)
            throw new InvalidOperationException();
        _uow.SaveChanges();
    }
}
