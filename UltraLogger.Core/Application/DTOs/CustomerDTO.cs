namespace UltraLogger.Core.Application.DTOs;

public class CustomerDTO
{
    public long Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string? Description { get; set; }
}
