using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Domain.Aggregates.Reports;

namespace UltraLogger.Core.Application.Services
{
    public class ReportService(IReportRepository reportRepository)
    {
        private readonly IReportRepository _reportRepository = reportRepository;

        public Result CreateReport(CreateReportDTO createReportDTO)
        {
            Report reportForCreate = new Report(0, DateTime.Now.Ticks, createReportDTO.OrderId, true);
            _reportRepository.Add(reportForCreate);
            _reportRepository.UnitOfWork.SaveChanges();
            return Result.Success();
        }

        public Result UpdateReport(ReportDTO reportDTO)
        {
            Report? reportForUpdate = _reportRepository.GetById(reportDTO.Id);
            if (reportForUpdate == null)
                return Error.None;

            reportForUpdate.ChangeOrder(reportDTO.OrderId);
            if (reportDTO.IsOpen)
            {
                reportForUpdate.Open();
            }
            else
            {
                reportForUpdate.Close();
            }
            _reportRepository.Update(reportForUpdate);
            _reportRepository.UnitOfWork.SaveChanges();
            return Result.Success();
        }

        public Result DeleteReport(long reportId)
        {
            Report? reportForDelete = _reportRepository.GetById(reportId);
            if (reportForDelete == null)
                return Result.Failure(Error.None);
            _reportRepository.Delete(reportForDelete);
            _reportRepository.UnitOfWork.SaveChanges();
            return Result.Success();
        }

        public Result<ReportDTO> GetById(long reportId)
        {
            Report? report = _reportRepository.GetById(reportId);

            if (report == null)
                return Error.None;

            return MapReportToReportDTO(report);
        }

        public IEnumerable<ReportDTO> GetAll()
        {
            IEnumerable<Report> reports = _reportRepository.GetAll();
            List<ReportDTO> reportDTOs = new List<ReportDTO>();
            foreach (Report report in reports)
            {
                reportDTOs.Add(MapReportToReportDTO(report));
            }
            return reportDTOs;
        }

        public IEnumerable<ReportDTO> GetOpen()
        {
            IEnumerable<Report> reports = _reportRepository.GetByOpenState(true);
            List<ReportDTO> reportDTOs = new List<ReportDTO>();
            foreach (Report report in reports)
            {
                reportDTOs.Add(MapReportToReportDTO(report));
            }
            return reportDTOs;
        }

        private ReportDTO MapReportToReportDTO(Report report)
        {
            return new ReportDTO
            {
                Id = report.Id, CreatedAt = new DateTime(report.CreatedAtTicks), OrderId = report.OrderId, IsOpen = report.IsOpen
            };
        }
    }
}
