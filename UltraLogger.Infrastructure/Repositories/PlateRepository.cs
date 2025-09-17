using UltraLogger.Core.Domain.Aggregates.Defectograms;
using UltraLogger.Core.Domain.Aggregates.Plates;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories
{
    public class PlateRepository(UnitOfWork uow) : IPlateRepository
    {
        private readonly UnitOfWork _uow = uow;
        public IUnitOfWork UnitOfWork => _uow;

        public Plate? GetByDefectogramId(long defectogramId)
        {
            string sql = "SELECT * FROM Plates WHERE DefectogramId = @DefectogramId";

            return _uow.QuerySingleOrDefault<Plate>(sql, new { DefectogramId = defectogramId });
        }
    }
}
