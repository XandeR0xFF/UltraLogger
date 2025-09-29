using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Domain.Aggregates.Evaluations;
using UltraLogger.Core.Domain.Aggregates.Plates;
using UltraLogger.Core.Domain.Aggregates.UTResults;

namespace UltraLogger.Core.Application.Services;

public class PlateService(IPlateRepository plateRepository, IUTResultRepository resultRepository, IEvaluationRepository evaluationRepository)
{
    private readonly IPlateRepository _plateRepository = plateRepository;
    private readonly IUTResultRepository _resultRepository = resultRepository;
    private readonly IEvaluationRepository _evaluationRepository = evaluationRepository;


    public Result UpdatePlate(PlateDTO plateDTO)
    {
        Plate? plateForUpdate = _plateRepository.GetById(plateDTO.Id);
        if (plateForUpdate == null)
            return Error.None;

        plateForUpdate.RemoveAllPlateParts();

        plateForUpdate.ChangePlateNumber(plateDTO.MeltYear, plateDTO.MeltNumber, plateDTO.SlabNumber);
        if (plateDTO.ReportId != null)
        {
            plateForUpdate.IncludeToReport(plateDTO.ReportId.Value);
        }
        else
        {
            plateForUpdate.ExcludeFromReport();
        }

        foreach (PlatePartDTO partDTO in plateDTO.Parts)
        {
            UTResult? lastResult = _resultRepository.GetLastResultByPlatePartId(partDTO.Id);
            if (lastResult == null && partDTO.InspectionResult != null)
            {
                UTResult newResult = new(0, partDTO.InspectionResult.CreatedAt.Ticks, partDTO.Id, partDTO.InspectionResult.UserId, partDTO.InspectionResult.EvaluationId);
                _resultRepository.Add(newResult);
            }

            plateForUpdate.AddPlatePart(partDTO.Number, partDTO.X, partDTO.Y, partDTO.Width, partDTO.Length, partDTO.Id);
        }

        _plateRepository.Update(plateForUpdate);
        _plateRepository.UnitOfWork.SaveChanges();

        return Result.Success();
    }

    public IEnumerable<PlateDTO> GetForReport(long reportID)
    {
        List<PlateDTO> plateDTOs = new List<PlateDTO>();

        IEnumerable<Plate> plates = _plateRepository.GetByReportId(reportID);
        foreach (Plate plate in plates)
        {
            plateDTOs.Add(MapPlateToPlateDTO(plate));
        }

        return plateDTOs;
    }

    public IEnumerable<EvaluationDTO> GetEvaluations()
    {
        List<EvaluationDTO> evaluationDTOs = new List<EvaluationDTO>();
        IEnumerable<Evaluation> evaluations = _evaluationRepository.GetAll();

        foreach (Evaluation evaluation in evaluations)
        {
            evaluationDTOs.Add(MapEvaluationToEvaluationDTO(evaluation));
        }

        return evaluationDTOs;
    }

    private PlateDTO MapPlateToPlateDTO(Plate plate)
    {
        return new PlateDTO()
        {
            Id = plate.Id,
            DefectogramId = plate.DefectogramId,
            MeltNumber = plate.MeltNumber,
            MeltYear = plate.MeltYear,
            SlabNumber = plate.SlabNumber,
            ReportId = plate.ReportId,
            Parts = MapPlatePartsToPlatePartsDTOList(plate.Parts)
        };
    }

    private List<PlatePartDTO> MapPlatePartsToPlatePartsDTOList(IEnumerable<PlatePart> parts)
    {
        List<PlatePartDTO> platePartDTOs = new List<PlatePartDTO>();
        foreach (var part in parts)
        {
            UTResult? utResult = _resultRepository.GetLastResultByPlatePartId(part.Id);
            InspectionResultDTO? inspectionResultDTO = utResult != null ? MapUTResultToInspectionResultDTO(utResult) : null;

            platePartDTOs.Add(new PlatePartDTO()
            {
                Id = part.Id,
                Length = part.Length,
                Number = part.Number,
                Width = part.Width,
                X = part.X,
                Y = part.Y,
                InspectionResult = inspectionResultDTO
            });
        }

        return platePartDTOs;
    }

    private InspectionResultDTO MapUTResultToInspectionResultDTO(UTResult utResult)
    {
        return new InspectionResultDTO()
        {
            Id = utResult.Id,
            CreatedAt = new DateTime(utResult.CreatedAtTicks),
            EvaluationId = utResult.EvaluationId,
            UserId = utResult.UserId
        };
    }

    private EvaluationDTO MapEvaluationToEvaluationDTO(Evaluation evaluation)
    {
        return new EvaluationDTO()
        {
            Id = evaluation.Id,
            Name = evaluation.Name
        };
    }
}
