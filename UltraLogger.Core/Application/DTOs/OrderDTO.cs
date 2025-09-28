namespace UltraLogger.Core.Application.DTOs;

public class OrderDTO
{
    public long Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public long CustomerId { get; set; }
    public string SteelGrade { get; set; } = string.Empty;
    public float PlateThickness { get; set; }
    public int PlateWidth { get; set; }
    public int PlateLength { get; set; }
}
