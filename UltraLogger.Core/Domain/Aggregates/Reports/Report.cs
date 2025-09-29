using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Reports
{
    public class Report : Entity, IAggregateRoot
    {
        private Report()
        {
        }

        public Report(long id, long createdAtTicks, long orderId, bool isOpen)
        {
            Id = id;
            CreatedAtTicks = createdAtTicks;
            OrderId = orderId;
            IsOpen = isOpen;
        }

        public long CreatedAtTicks { get; private set; }
        public long OrderId { get; private set; }
        public bool IsOpen { get; private set; }

        public void ChangeOrder(long orderId)
        {
            OrderId = orderId;
        }

        public void Open()
        {
            IsOpen = true;
        }

        public void Close()
        {
            IsOpen = false;
        }
    }
}
