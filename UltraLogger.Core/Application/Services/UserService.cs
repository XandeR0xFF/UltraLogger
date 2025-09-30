using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Domain.Aggregates.Users;

namespace UltraLogger.Core.Application.Services;

public class UserService(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public Result<UserDTO> GetById(long userId)
    {
        User? user = _userRepository.GetById(userId);
        if (user == null)
            return Error.None;

        return MapUserToUserDTO(user);
    }

    private UserDTO MapUserToUserDTO(User user)
    {
        return new UserDTO()
        {
            CreatedAt = new DateTime(user.CreatedAtTicks),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Login = user.Login,
            MiddleName = user.MiddleName,
            PasswordHash = user.PasswordHash,
            IsActive = user.IsActive
        };
    }
}
