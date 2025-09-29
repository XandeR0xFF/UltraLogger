using UltraLogger.Core.Domain.Aggregates.Defectograms;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories;

public class DefectogramRepository(UnitOfWork uow) : IDefectogramRepository
{
    private readonly UnitOfWork _uow = uow;
    public IUnitOfWork UnitOfWork => _uow;

    public Defectogram Add(Defectogram defectogram)
    {
        Defectogram addedDefectogram = defectogram;

        if (defectogram.IsTransient())
        {
            long newId = _uow.GetNewId("Defectograms");
            addedDefectogram = new Defectogram(
                newId,
                defectogram.CreatedAtTicks,
                defectogram.Name,
                defectogram.USTModeId,
                defectogram.UserId,
                defectogram.Thickness,
                defectogram.Width,
                defectogram.Length);
        }
        _uow.Execute(@"INSERT INTO Defectograms(Id, CreatedAtTicks, Name, Thickness, Width, Length, USTModeId, UserId)
                    VALUES(@Id, @CreatedAtTicks, @Name, @Thickness, @Width, @Length, @USTModeId, @UserId)", addedDefectogram);
        return addedDefectogram;
    }

    public void Update(Defectogram defectogram)
    {
        if (defectogram.IsTransient())
            throw new InvalidOperationException("Updated defectogram is transient.");

        _uow.Execute(@"UPDATE Defectograms 
                    SET 
                        CreatedAtTicks = @CreatedAtTicks,
                        Name = @Name,
                        Thickness = @Thickness,
                        Width = @Width,
                        Length = @Length,
                        USTModeId = @USTModeId,
                        UserId = @UserId
                    WHERE Id = @Id", defectogram);
    }

    public void Delete(Defectogram defectogram)
    {
        if (defectogram.IsTransient())
            throw new InvalidOperationException("Deleted defectogram is transient.");

        _uow.Execute("DELETE FROM Defectograms WHERE Id = @Id", defectogram);
    }

    public Defectogram? GetById(long id)
    {
        return _uow.QuerySingleOrDefault<Defectogram>("SELECT * FROM Defectograms WHERE Id = @Id", new { Id = id });
    }

    public IEnumerable<Defectogram> GetAll()
    {
        string sql = @"SELECT * FROM Defectograms ORDER BY CreatedAtTicks";
        return _uow.Query<Defectogram>(sql);
    }
}
