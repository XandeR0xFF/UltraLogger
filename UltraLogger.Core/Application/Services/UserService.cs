using UltraLogger.Core.Application.Common;
using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Domain.Aggregates.Users;

namespace UltraLogger.Core.Application.Services;

public class UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher _passwordHasher = passwordHasher;

    public Result CreateUser(CreateUserDTO createUserDTO)
    {
        User userForInsert = new User(
            0,
            createUserDTO.Login,
            createUserDTO.FirstName,
            createUserDTO.LastName,
            createUserDTO.MiddleName,
            _passwordHasher.Hash(createUserDTO.Password),
            true, DateTime.Now.Ticks);


        _userRepository.Add(userForInsert);
        _userRepository.UnitOfWork.SaveChanges();
        return Result.Success();
    }

    public Result UpdateUser(UserDTO user)
    {
        User? userForUpdate = _userRepository.GetById(user.Id);
        if (userForUpdate == null)
            return Error.None;

        userForUpdate.UpdatePersonalInfo(user.FirstName, user.LastName, user.MiddleName);
        if (user.IsActive)
            userForUpdate.Activate();
        else
            userForUpdate.Deactivate();

        _userRepository.Update(userForUpdate);
        _userRepository.UnitOfWork.SaveChanges();
        return Result.Success();
    }

    public Result ResetUserPassword(long userId, string newPassword)
    {
        User? userForUpdate = _userRepository.GetById(userId);
        if (userForUpdate == null)
            return Error.None;
        userForUpdate.ChangePassword(_passwordHasher.Hash(newPassword));
        _userRepository.Update(userForUpdate);
        _userRepository.UnitOfWork.SaveChanges();
        return Result.Success();
    }

    public Result<UserDTO> GetById(long userId)
    {
        User? user = _userRepository.GetById(userId);
        if (user == null)
            return Error.None;

        return MapUserToUserDTO(user);
    }

    public IEnumerable<UserDTO> GetAll()
    {
        IEnumerable<User> users = _userRepository.GetAll();
        List<UserDTO> result = new List<UserDTO>();
        foreach (User user in users)
        {
            result.Add(MapUserToUserDTO(user));
        }
        return result;
    }

    private UserDTO MapUserToUserDTO(User user)
    {
        return new UserDTO()
        {
            Id = user.Id,
            CreatedAt = new DateTime(user.CreatedAtTicks),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Login = user.Login,
            MiddleName = user.MiddleName,
            IsActive = user.IsActive
        };
    }
}
