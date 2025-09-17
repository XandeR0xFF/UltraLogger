namespace UltraLogger.Core.Application.DTOs
{
    public class DefectogramDTO
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Name { get; set; }
        public float Thickness { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public USTModeDTO? UstMode { get; set; }
        public DefectogramUserDTO? MyProperty { get; set; }
        public PlateDTO? Plate { get; set; }
    }
}
