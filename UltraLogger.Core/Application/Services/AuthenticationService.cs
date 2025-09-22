using UltraLogger.Core.Application.Common;
using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Domain.Aggregates.Users;

namespace UltraLogger.Core.Application.Services
{
    public class AuthenticationService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ISessionManager sessionManager)
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly ISessionManager _sessionManager = sessionManager;

        public Result LogIn(string login, string password)
        {
            User? user = _userRepository.GetByLogin(login);
            if (user == null)
                return AuthenticationServiceErrors.InvalidCredentialsError;

            if (!user.IsActive || !_passwordHasher.Verify(user.PasswordHash, password))
                return AuthenticationServiceErrors.InvalidCredentialsError;

            _sessionManager.BeginSession(user);
            return Result.Success();
        }

        public Result<UserDTO> GetCurrentUser()
        {
            User? user = _sessionManager.CurrentUser;
            if (user == null)
                return AuthenticationServiceErrors.NoActiveSessions;

            return MapUserToCurrentUserDTO(user);
        }

        private UserDTO MapUserToCurrentUserDTO(User user)
        {
            return new UserDTO
            {
                Login = user.Login
            };
        }
    }

    internal static class AuthenticationServiceErrors
    {
        public static Error InvalidCredentialsError = new Error("Authentication.InvalidCredentials", "Неверный логин или пароль.");
        public static Error NoActiveSessions = new Error("Authentication.NoActiveSessions", "Нет активных пользовательских сессий.");
    }
}
