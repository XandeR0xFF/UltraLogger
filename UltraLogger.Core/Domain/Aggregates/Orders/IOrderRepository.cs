using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Orders;

public interface IOrderRepository : IRepository<Order>
{
    Order Add(Order order);
    void Update(Order order);
    Order? GetById(long id);
    IEnumerable<Order> GetAll();
}
