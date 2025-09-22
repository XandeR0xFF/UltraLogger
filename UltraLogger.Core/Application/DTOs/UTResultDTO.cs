namespace UltraLogger.Core.Application.DTOs;

public class UTResultDTO
{
    public DateTime CreatedAt { get; set; }
    public NDTSpecialistDTO? NDTSpecialist { get; set; }
    public PlatePartEvaluationDTO? Evaluation { get; set; }
}
