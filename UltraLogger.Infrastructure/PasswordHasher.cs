using UltraLogger.Core.Application.Common;

namespace UltraLogger.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        return password;
    }

    public bool Verify(string hash, string password)
    {
        return hash == Hash(password);
    }
}
