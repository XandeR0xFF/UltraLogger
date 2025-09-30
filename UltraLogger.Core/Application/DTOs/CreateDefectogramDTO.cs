namespace UltraLogger.Core.Application.DTOs;

public class CreateDefectogramDTO
{
    public DateTime CreatedAt { get; set; }
    public required string Name { get; set; }
    public float Thickness { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }
    public long UstModeId { get; set; }
    public long UserId { get; set; }
}
