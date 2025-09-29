namespace UltraLogger.Core.Application.DTOs;

public class DefectogramPlateDTO
{
    public int MeltYear { get; set; }
    public int MeltNumber { get; set; }
    public int SlabNumber { get; set; }
    public List<DefectogramPlatePartDTO> Parts { get; set; } = new List<DefectogramPlatePartDTO>();
    public long? ReportId { get; set; }
}
