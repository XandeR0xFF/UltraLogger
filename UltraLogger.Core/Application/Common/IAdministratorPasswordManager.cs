namespace UltraLogger.Core.Application.Common;

public interface IAdministratorPasswordManager
{
    string GetPasswordHash();
    void UpdatePasswordHash(string password);
}
