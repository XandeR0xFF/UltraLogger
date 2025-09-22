using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.UTResults
{
    public class UTResult : Entity, IAggregateRoot
    {
        private UTResult()
        {
        }

        public UTResult(
            long id,
            long createdAtTicks,
            long platePartId,
            long userId,
            long evaluationId)
        {
            Id = id;
            CreatedAtTicks = createdAtTicks;
            PlatePartId = platePartId;
            UserId = userId;
            EvaluationId = evaluationId;
        }

        public long CreatedAtTicks { get; private set; }
        public long PlatePartId { get; private set; }
        public long UserId { get; private set; }
        public long EvaluationId { get; private set; }
    }
}
