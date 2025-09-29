namespace UltraLogger.Core.Application.DTOs;

public class InspectionResultDTO
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public long UserId { get; set; }
    public long EvaluationId { get; set; }
}
