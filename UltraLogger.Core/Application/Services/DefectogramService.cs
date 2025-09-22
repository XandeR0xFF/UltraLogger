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
    IUSTModeRepository ustModeRepository,
    IPlateRepository plateRepository,
    IUserRepository userRepository,
    IEvaluationRepository evaluationRepository,
    IUTResultRepository utResultRepository)
{
    private readonly IDefectogramRepository _defectogramRepository = defectogramRepository;
    private readonly IUSTModeRepository _ustModeRepository = ustModeRepository;
    private readonly IPlateRepository _plateRepository = plateRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IEvaluationRepository _evaluationRepository = evaluationRepository;
    private readonly IUTResultRepository _utResultRepository = utResultRepository;

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

    private NDTSpecialistDTO? GetDefectogramCreator(long userId)
    {
        User? user = _userRepository.GetById(userId);

        return user == null ? null : MapUserToNDTSpecialistDTO(user);
    }

    private NDTSpecialistDTO MapUserToNDTSpecialistDTO(User user)
    {
        return new NDTSpecialistDTO()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName
        };
    }

    private DefectogramDTO MapDefectogramToDefectogramDTO(Defectogram defectogram)
    {
        List<USTModeDTO> ustModes = new(_ustModeRepository.GetAll().Select(m => MapUSTModeToUSTModeDTO(m)));
        List<PlatePartEvaluationDTO> evaluations = new(_evaluationRepository.GetAll().Select(e => MapEvaluationToPlatePartEvaluationDTO(e)));

        DefectogramDTO defectogramDTO = new DefectogramDTO
        {
            Id = defectogram.Id,
            CreatedAt = new DateTime(defectogram.CreatedAtTicks),
            Name = defectogram.Name,
            Thickness = (float)defectogram.Thickness / 100,
            Width = defectogram.Width,
            Length = defectogram.Length,
            UstMode = ustModes.Find(m => m.Id == defectogram.USTModeId),
            Plate = GetPlateForDefectogram(defectogram.Id),
            Creator = GetDefectogramCreator(defectogram.UserId)
        };

        if (defectogramDTO.Plate != null)
        {
            foreach (PlatePartDTO platePartDTO in defectogramDTO.Plate.Parts)
            {
                UTResult? utResult = _utResultRepository.GetLastResultByPlatePartId(platePartDTO.Id);
                if (utResult != null)
                {
                    platePartDTO.Evaluation = evaluations.Find(e => e.Id == utResult.EvaluationId);
                }
            }
        }
        
        return defectogramDTO;
    }

    private USTModeDTO MapUSTModeToUSTModeDTO(USTMode ustMode)
    {
        return new USTModeDTO { Id = ustMode.Id, Name = ustMode.Name, Description = ustMode.Description };
    }

    private PlateDTO MapPlateToPlateDTO(Plate plate)
    {
        PlateDTO plateDTO = new PlateDTO()
        {
            MeltYear = plate.MeltYear,
            MeltNumber = plate.MeltNumber,
            SlabNumber = plate.SlabNumber
        };

        foreach (var part in plate.Parts)
        {
            plateDTO.Parts.Add(MapPlatePartToPlatePartDTO(part));
        }

        return plateDTO;
    }

    private PlatePartEvaluationDTO MapEvaluationToPlatePartEvaluationDTO(Evaluation evaluation)
    {
        return new PlatePartEvaluationDTO() { Id = evaluation.Id, Name = evaluation.Name };
    }

    private PlatePartDTO MapPlatePartToPlatePartDTO(PlatePart platePart)
    {
        return new PlatePartDTO() { 
            Id = platePart.Id,
            Length = platePart.Length,
            Width = platePart.Width,
            Number = platePart.Number,
            X = platePart.X,
            Y = platePart.Y
        };
    }
}
