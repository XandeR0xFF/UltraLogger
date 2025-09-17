using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.USTModes
{
    public class USTMode : Entity, IAggregateRoot
    {
        public USTMode()
        {
            Name = String.Empty;
        }

        public USTMode(long id, string name, string? description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string? Description { get; private set; }
    }
}
