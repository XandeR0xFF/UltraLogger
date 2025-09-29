using UltraLogger.Core.Domain.Aggregates.Plates;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories
{
    public class PlateRepository(UnitOfWork uow) : IPlateRepository
    {
        private readonly UnitOfWork _uow = uow;
        public IUnitOfWork UnitOfWork => _uow;

        public Plate Add(Plate plate)
        {
            if (!plate.IsTransient())
                throw new InvalidOperationException();

            long newPlateId = _uow.GetNewId("Plates");
            Plate addedPlate = new Plate(newPlateId, plate.DefectogramId, plate.MeltYear, plate.MeltNumber, plate.SlabNumber, plate.ReportId);

            _uow.Execute("INSERT INTO Plates(Id, DefectogramId, MeltYear, MeltNumber, SlabNumber, ReportId) " +
                         "VALUES(@Id, @DefectogramId, @MeltYear, @MeltNumber, @SlabNumber, @ReportId)", addedPlate);

            foreach (PlatePart part in plate.Parts)
            {
                PlatePart addedPart = AddPlatePart(newPlateId, part);
                addedPlate.AddPlatePart(addedPart.Number, addedPart.X, addedPart.Y, addedPart.Width, addedPart.Length, addedPart.Id);
            }

            return addedPlate;
        }

        public void Update(Plate plate)
        {
            if (plate.IsTransient())
                throw new InvalidOperationException("Plate is transient.");

            _uow.Execute(@"UPDATE Plates
                         SET
                            DefectogramId = @DefectogramId,
                            MeltYear = @MeltYear,
                            MeltNumber = @MeltNumber,
                            SlabNumber = @SlabNumber,
                            ReportId = @ReportId
                         WHERE Id = @Id", plate);

            _uow.Execute("DELETE FROM PlateParts WHERE PlateId = @PlateId", new { PlateId = plate.Id });

            foreach (PlatePart part in plate.Parts)
            {
                AddPlatePart(plate.Id, part);
            }
        }

        public void Delete(Plate plate)
        {
            _uow.Execute("DELETE FROM Plates WHERE Id = @Id", plate);
        }

        public Plate? GetByDefectogramId(long defectogramId)
        {
            Plate? plate = _uow.QuerySingleOrDefault<Plate>("SELECT * FROM Plates WHERE DefectogramId = @DefectogramId",
                new { DefectogramId = defectogramId });
            LoadPlateParts(plate);

            return plate;
        }

        public Plate? GetById(long id)
        {
            Plate? plate = _uow.QuerySingleOrDefault<Plate>("SELECT * FROM Plates WHERE Id = @Id", new { Id = id });
            LoadPlateParts(plate);
            return plate;
        }

        public IEnumerable<Plate> GetByReportId(long reportId)
        {
            IEnumerable<Plate> plates = _uow.Query<Plate>("SELECT * FROM Plates WHERE ReportId = @ReportId", new { ReportId = reportId });
            foreach (var plate in plates)
            {
                LoadPlateParts(plate);
            }
            return plates;
        }

        private void LoadPlateParts(Plate? plate)
        {
            if (plate == null)
                return;
            IEnumerable<PlatePart> parts = _uow.Query<PlatePart>("SELECT * FROM PlateParts WHERE PlateId = @PlateId ORDER BY Number",
                new { PlateId = plate.Id });

            foreach (var platePart in parts)
            {
                plate.AddPlatePart(platePart.Number, platePart.X, platePart.Y, platePart.Width, platePart.Length, platePart.Id);
            }
        }

        private PlatePart AddPlatePart(long plateId, PlatePart platePart)
        {
            PlatePart platePartForInsert = platePart;

            if (platePart.IsTransient())
            {
                long newPartId = _uow.GetNewId("PlateParts");
                platePartForInsert = new PlatePart(newPartId, platePart.Number, platePart.X, platePart.Y, platePart.Width, platePart.Length, plateId);
            }


            _uow.Execute(@"INSERT INTO PlateParts(Id, Number, X, Y, Width, Length, PlateId)
                         VALUES(@Id, @Number, @X, @Y, @Width, @Length, @PlateId)", platePartForInsert);
            return platePartForInsert;
        }
    }
}
