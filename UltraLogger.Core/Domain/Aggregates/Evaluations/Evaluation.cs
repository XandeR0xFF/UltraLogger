using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Evaluations;

public class Evaluation : Entity, IAggregateRoot
{
    private Evaluation()
    {
        Name = string.Empty;
    }

    public Evaluation(long id, string name, string? description = null)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }
    public string? Description { get; set; }
}
