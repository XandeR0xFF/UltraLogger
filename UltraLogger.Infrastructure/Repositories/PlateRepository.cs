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

            UpdatePlateParts(plate);
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
            long newPartId = _uow.GetNewId("PlateParts");
            PlatePart addedPlatePart = new PlatePart(newPartId, platePart.Number, platePart.X, platePart.Y, platePart.Width, platePart.Length, plateId);
            _uow.Execute(@"INSERT INTO PlateParts(Id, Number, X, Y, Width, Length, PlateId)
                         VALUES(@Id, @Number, @X, @Y, @Width, @Length, @PlateId)", addedPlatePart);
            return addedPlatePart;
        }

        private void UpdatePlateParts(Plate plate)
        {
            IEnumerable<PlatePart> partsPersist = _uow.Query<PlatePart>("SELECT * FROM PlateParts WHERE PlsteId = @PlateId", new {PlateId = plate.Id});

            foreach (var partPersist in partsPersist)
            {
                if (plate.GetPlatePartById(partPersist.Id) == null)
                    DeletePlatePart(partPersist);
            }

            List<PlatePart> transientPlateParts = new List<PlatePart>();
            foreach (var part in plate.Parts)
            {
                if (part.IsTransient())
                {
                    transientPlateParts.Add(part);
                    PlatePart addedPlatePart = AddPlatePart(plate.Id, part);
                    plate.AddPlatePart(addedPlatePart.Number, addedPlatePart.X, addedPlatePart.Y, addedPlatePart.Width, addedPlatePart.Length, addedPlatePart.Id);
                }
                else
                {
                    UpdatePlatePart(part);
                }
            }

            foreach (var transientPlatePart in transientPlateParts)
            {
                plate.RemovePlatePart(transientPlatePart);
            }
        }

        private void DeletePlatePart(PlatePart platePart)
        {
            _uow.Execute("DELETE FROM PlateParts WHERE Id = @Id", platePart);
        }

        private void UpdatePlatePart(PlatePart platePart)
        {
            _uow.Execute(@"UPDATE PlateParts
                         SET
                            Number = @Number,
                            X = @X,
                            Y = @Y,
                            Width = @Width,
                            Length = @Length,
                            PlateId = @PlateId
                         WHERE Id = @Id", platePart);
        }
    }
}
