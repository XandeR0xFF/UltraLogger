using UltraLogger.Core.Domain.Aggregates.Orders;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories;

public class OrderRepository(UnitOfWork uow) : IOrderRepository
{
    private readonly UnitOfWork _uow = uow;

    public IUnitOfWork UnitOfWork => _uow;

    public Order Add(Order order)
    {
        Order addedOrder = order;

        if (order.IsTransient())
        {
            long newId = _uow.GetNewId("Orders");
            addedOrder = new Order(newId,
                order.Number,
                order.CustomerId,
                order.SteelGrade,
                order.PlateThickness,
                order.PlateWidth,
                order.PlateLength);
        }

        _uow.Execute(@"INSERT INTO Orders(Id, Number, CustomerId, SteelGrade, PlateThickness, PlateLength, PlateWidth, PlateLength)
                       VALUES(@Id, @Number, @CustomerId, @SteelGrade, @PlateThickness, @PlateLength, @PlateWidth, @PlateLength)", addedOrder);

        return addedOrder;
    }

    public void Update(Order order)
    {
        if (order.IsTransient())
            throw new InvalidOperationException("Updated order is transient.");

        _uow.Execute(@"UPDATE Orders
                     SET
                        Number = @Number,
                        CustomerId = @CustomerId,
                        SteelGrade = @SteelGrade
                        PlateThickness = @PlateThickness,
                        PlateWidth = @PlateWidth,
                        PlateLength = @PlateLength
                     WHERE Id = @Id", order);
    }

    public Order? GetById(long id)
    {
        return _uow.QuerySingleOrDefault<Order>("SELECT * FROM Orders WHERE Id = @Id", new { Id = id });
    }

    public IEnumerable<Order> GetAll()
    {
        return _uow.Query<Order>("SELECT * FROM Orders ORDER BY Number");
    }
}
