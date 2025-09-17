using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Domain.Aggregates.Defectograms;
using UltraLogger.Core.Domain.Aggregates.Plates;
using UltraLogger.Core.Domain.Aggregates.USTModes;

namespace UltraLogger.Core.Application.Services;

public class DefectogramService(
    IDefectogramRepository defectogramRepository,
    IUSTModeRepository ustModeRepository,
    IPlateRepository plateRepository)
{
    private readonly IDefectogramRepository _defectogramRepository = defectogramRepository;
    private readonly IUSTModeRepository _ustModeRepository = ustModeRepository;
    private readonly IPlateRepository _plateRepository = plateRepository;

    public IEnumerable<DefectogramDTO> GetAll()
    {
        IEnumerable<Defectogram> defectograms = _defectogramRepository.GetAll();
        return defectograms.Select((d, dto) => MapDefectogramToDefectogramDTO(d));
    }

    private PlateDTO? GetPlateForDefectogram(long defectogramId)
    {
        Plate? plate = _plateRepository.GetByDefectogramId(defectogramId);

        return plate == null ? null : MapPlateToPlateDTO(plate);
    }

    private DefectogramDTO MapDefectogramToDefectogramDTO(Defectogram defectogram)
    {
        List<USTModeDTO> ustModes = new(_ustModeRepository.GetAll().Select(m => MapUSTModeToUSTModeDTO(m)));

        DefectogramDTO defectogramDTO = new DefectogramDTO
        {
            Id = defectogram.Id,
            CreatedAt = new DateTime(defectogram.CreatedAtTicks),
            Name = defectogram.Name,
            Thickness = (float)defectogram.Thickness / 100,
            Width = defectogram.Width,
            Length = defectogram.Length,
            UstMode = ustModes.Find(m => m.Id == defectogram.USTModeId),
            Plate = GetPlateForDefectogram(defectogram.Id)
        };

        return defectogramDTO;
    }

    private USTModeDTO MapUSTModeToUSTModeDTO(USTMode ustMode)
    {
        return new USTModeDTO { Id = ustMode.Id, Name = ustMode.Name, Description = ustMode.Description };
    }

    private PlateDTO MapPlateToPlateDTO(Plate plate)
    {
        return new PlateDTO()
        {
            DefectogramId = plate.DefectogramId,
            MeltYear = plate.MeltYear,
            MeltNumber = plate.MeltNumber,
            SlabNumber = plate.SlabNumber
        };
    }
}
