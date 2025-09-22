namespace UltraLogger.Core.Application.DTOs;

public class PlatePartDTO
{
    public long Id { get; set; }
    public int Number { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Length { get; set; }
    public PlatePartEvaluationDTO? Evaluation { get; set; }
}
