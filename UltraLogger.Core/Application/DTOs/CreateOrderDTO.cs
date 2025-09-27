namespace UltraLogger.Core.Application.DTOs;

public class CreateOrderDTO
{
    public string Number { get; set; } = string.Empty;
    public long CustomerId { get; set; }
    public string SteelGrade { get; set; } = string.Empty;
    public int PlateThickness { get; set; }
    public int PlateWidth { get; set; }
    public int PlateLength { get; set; }
}
