using UltraLogger.Core.Application.Common;
using UltraLogger.Core.Application.Common.ResultPattern;

namespace UltraLogger.Core.Application.Services;

public class AdministratorService(IPasswordHasher passwordHasher, IAdministratorPasswordManager administratorPasswordManager)
{
    private readonly IPasswordHasher _passwordHasher = passwordHasher;
    private readonly IAdministratorPasswordManager _administratorPasswordManager = administratorPasswordManager;

    public Result Authenticate(string password)
    {
        string hash = _administratorPasswordManager.GetPasswordHash();
        bool isVerified = _passwordHasher.Verify(hash, password);
        return isVerified ? Result.Success() : AdministratorServiceErrors.InvalidOldPassword;
    }

    public Result ChangePassword(string oldPassword, string newPassword, string confirmPassword)
    {
        if (Authenticate(oldPassword).IsFailure)
            return AdministratorServiceErrors.InvalidOldPassword;

        if (!string.Equals(newPassword, confirmPassword))
            return AdministratorServiceErrors.InvalidConfirmPassword;

        if (string.IsNullOrWhiteSpace(newPassword))
            return AdministratorServiceErrors.NewPasswordIsEmpty;

            string newHash = _passwordHasher.Hash(newPassword);
        _administratorPasswordManager.UpdatePasswordHash(newHash);
        return Result.Success();
    }
}

public static class AdministratorServiceErrors
{
    public static Error InvalidOldPassword = new Error(nameof(InvalidOldPassword), "Неверный пароль.");
    public static Error InvalidConfirmPassword = new Error(nameof(InvalidConfirmPassword), "Новый пароль и подтверждение пароля не совпадают.");
    public static Error NewPasswordIsEmpty = new Error(nameof(NewPasswordIsEmpty), "Пароль не может быть пустым.");
}
