namespace UltraLogger.Core.Application.DTOs;

public class UTResultDTO
{
    public DateTime CreatedAt { get; set; }
    public NDTSpecialistDTO? NDTSpecialist { get; set; }
    public EvaluationDTO? Evaluation { get; set; }
}
