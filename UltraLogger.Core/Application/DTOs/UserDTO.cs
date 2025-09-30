namespace UltraLogger.Core.Application.DTOs;

public class UserDTO
{
    public long Id { get; set; }
    public required string Login { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string MiddleName { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
}
