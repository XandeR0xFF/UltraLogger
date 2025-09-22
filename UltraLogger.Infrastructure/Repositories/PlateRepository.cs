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
            string plateSql = "SELECT * FROM Plates WHERE DefectogramId = @DefectogramId";

            Plate? plate = _uow.QuerySingleOrDefault<Plate>(plateSql, new { DefectogramId = defectogramId });

            if (plate != null)
            {
                string platePartSql = "SELECT * FROM PlateParts WHERE PlateId = @PlateId ORDER BY \"Number\"";
                IEnumerable<PlatePart> parts = _uow.Query<PlatePart>(platePartSql, new { PlateId = plate.Id });

                foreach (var platePart in parts)
                {
                    plate.AddPart(platePart);
                }
            }

            return plate;
        }
    }
}
