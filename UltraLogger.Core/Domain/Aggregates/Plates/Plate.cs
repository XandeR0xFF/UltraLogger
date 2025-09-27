using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Plates;

public class Plate : Entity, IAggregateRoot
{
    private List<PlatePart> _parts = new List<PlatePart>();

    private Plate()
    {
    }

    public Plate(
        long id,
        long defectogramId,
        int meltYear,
        int meltNumber,
        int slabNumber,
        long? reportId = null)
    {
        Id = id;
        DefectogramId = defectogramId;
        MeltYear = meltYear;
        MeltNumber = meltNumber;
        SlabNumber = slabNumber;
        ReportId = reportId;
    }

    public long DefectogramId { get; private set; }
    public long? ReportId { get; private set; }
    public int MeltYear { get; private set; }
    public int MeltNumber { get; private set; }
    public int SlabNumber { get; private set; }
    public IEnumerable<PlatePart> Parts => _parts;

    public void ChangePlateNumber(int meltYear, int meltNumber, int slabNumber)
    {
        MeltYear = meltYear;
        MeltNumber = meltNumber;
        SlabNumber = slabNumber;
    }

    public void IncludeToReport(long reportId)
    {
        ReportId = reportId;
    }

    public void ExcludeFromReport()
    {
        ReportId = null;
    }

    public void AddPlatePart(int number, int x, int y, int width, int length, long id = 0)
    {
        PlatePart newPlatePart = new PlatePart(id, number, x, y, width, length, Id);
        _parts.Add(newPlatePart);
    }

    public PlatePart? GetPlatePartById(long id)
    {
        return _parts.Find(p => Id == id);
    }

    public PlatePart? GetPlatePartByNumber(int platePartNumber)
    {
        return _parts.Find(p => p.Number == platePartNumber);
    }

    public void RemovePlatePart(PlatePart part)
    {
        _parts.Remove(part);
    }
}
