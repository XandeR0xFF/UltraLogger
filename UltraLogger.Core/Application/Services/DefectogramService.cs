using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Domain.Aggregates.Defectograms;
using UltraLogger.Core.Domain.Aggregates.Evaluations;
using UltraLogger.Core.Domain.Aggregates.Plates;
using UltraLogger.Core.Domain.Aggregates.Users;
using UltraLogger.Core.Domain.Aggregates.USTModes;
using UltraLogger.Core.Domain.Aggregates.UTResults;

namespace UltraLogger.Core.Application.Services;

public class DefectogramService(
    IDefectogramRepository defectogramRepository,
    IUSTModeRepository ustModeRepository)
{
    private readonly IDefectogramRepository _defectogramRepository = defectogramRepository;
    private readonly IUSTModeRepository _ustModeRepository = ustModeRepository;

    public Result<long> CreateDefectogram(CreateDefectogramDTO createDefectogramDTO)
    {
        Defectogram defectogramForInsert = new Defectogram(
            0,
            createDefectogramDTO.CreatedAt.Ticks,
            createDefectogramDTO.Name,
            createDefectogramDTO.UstModeId,
            createDefectogramDTO.UserId,
            (int)(createDefectogramDTO.Thickness * 100.0F),
            createDefectogramDTO.Width,
            createDefectogramDTO.Length);
        long newId = _defectogramRepository.Add(defectogramForInsert).Id;
        _defectogramRepository.UnitOfWork.SaveChanges();
        return newId;
    }

    public Result UpdateDefectogram(DefectogramDTO defectogramDTO)
    {
        return Result.Success();
    }

    public Result DeleteDefectogram(long id)
    {
        Defectogram? defectogramForDelete = _defectogramRepository.GetById(id);
        if (defectogramForDelete == null)
            return Result.Failure(DefectogramServiceErrors.DefectogramIdNotFound);

        _defectogramRepository.Delete(defectogramForDelete);
        _defectogramRepository.UnitOfWork.SaveChanges();
        return Result.Success();
    }

    public Result<DefectogramDTO> GetById(long defectogramId)
    {
        Defectogram? defectogram = _defectogramRepository.GetById(defectogramId);
        if (defectogram == null)
            return DefectogramServiceErrors.DefectogramIdNotFound;

        return MapDefectogramToDefectogramDTO(defectogram);
    }

    public IEnumerable<DefectogramDTO> GetAll()
    {
        IEnumerable<Defectogram> defectograms = _defectogramRepository.GetAll();
        return defectograms.Select((d, dto) => MapDefectogramToDefectogramDTO(d));
    }

    public IEnumerable<USTModeDTO> GetUSTModes()
    {
        IEnumerable<USTMode> modes = _ustModeRepository.GetAll();
        List<USTModeDTO> modesDTO = new List<USTModeDTO>();
        foreach (USTMode mode in modes)
        {
            modesDTO.Add(MapUSTModeToUSTModeDTO(mode));
        }
        return modesDTO;
    }

    private DefectogramDTO MapDefectogramToDefectogramDTO(Defectogram defectogram)
    {
        return new DefectogramDTO()
        {
            Id = defectogram.Id,
            Name = defectogram.Name,
            UserId = defectogram.UserId,
            Thickness = defectogram.Thickness / 100.0F,
            Width = defectogram.Width,
            Length = defectogram.Length,
            UstModeId = defectogram.USTModeId,
            CreatedAt = new DateTime(defectogram.CreatedAtTicks) };
    }

    private USTModeDTO MapUSTModeToUSTModeDTO(USTMode ustMode)
    {
        return new USTModeDTO { Id = ustMode.Id, Name = ustMode.Name, Description = ustMode.Description };
    }
}

internal static class DefectogramServiceErrors
{
    public static Error DefectogramIdNotFound = new Error(nameof(DefectogramIdNotFound), "ID дефектограммы не найден.");
}
