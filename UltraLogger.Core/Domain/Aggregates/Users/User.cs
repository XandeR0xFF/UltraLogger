using System;
using System.Text;
using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Users;

public class User : Entity, IAggregateRoot
{
    public string Login { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string MiddleName { get; private set; }
    public string PasswordHash { get; private set; }
    public bool IsActive { get; private set; }
    public long CreatedAtTicks { get; private set; }

    private User()
    {
        Login = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        MiddleName = string.Empty;
        PasswordHash = string.Empty;
    }

    public User(string login,
        string firstName,
        string lastName,
        string middleName,
        string passwordHash)
    {
        Login = login;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        PasswordHash = passwordHash;
        IsActive = true;
        CreatedAtTicks = DateTime.UtcNow.Ticks;
    }

    public User(long id,
        string login,
        string firstName,
        string lastName,
        string middleName,
        string passwordHash,
        bool isActive,
        long createdAtTicks) : this(login, firstName, lastName, middleName, passwordHash)
    {
        Id = id;
        IsActive = isActive;
        CreatedAtTicks = createdAtTicks;
    }

    public void UpdatePersonalInfo(string firstName, string lastName, string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
    }

    public void ChangePassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
    }

    public void Activate() => IsActive = true;

    public void Deactivate() => IsActive = false;

    public string GetShortName()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(FirstName.Trim());

        string lastName = LastName.Trim();
        if (lastName.Length != 0)
            builder.Append($" {lastName[0]}.");

        if (MiddleName != null)
        {
            string middleName = MiddleName.Trim();
            if (middleName.Length != 0)
                builder.Append($" {middleName[0]}.");
        }

        return builder.ToString();
    }

    private void ValidateFirstName(string value)
    {

    }

    private void ValidateLastName(string value)
    {

    }
}
