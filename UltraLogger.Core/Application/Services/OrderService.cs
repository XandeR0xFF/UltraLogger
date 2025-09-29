using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Domain.Aggregates.Orders;

namespace UltraLogger.Core.Application.Services;

public class OrderService(IOrderRepository orderRepository)
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public Result CreateOrder(CreateOrderDTO createOrderDTO)
    {
        Order orderForCreate = new Order(
            0,
            createOrderDTO.Number,
            createOrderDTO.CustomerId,
            createOrderDTO.SteelGrade,
            ((int)createOrderDTO.PlateThickness * 100),
            createOrderDTO.PlateWidth,
            createOrderDTO.PlateLength,
            true);
        _orderRepository.Add(orderForCreate);

        _orderRepository.UnitOfWork.SaveChanges();

        return Result.Success();
    }

    public Result UpdateOrder(OrderDTO orderDTO)
    {
        Order? orderForUpdate = _orderRepository.GetById(orderDTO.Id);
        if (orderForUpdate == null)
            return Result.Failure(Error.None);

        orderForUpdate.ChangeCustomer(orderDTO.CustomerId);
        orderForUpdate.ChangeDimensions(((int)orderDTO.PlateThickness * 100), orderDTO.PlateWidth, orderDTO.PlateLength);
        orderForUpdate.ChangeSteelGrade(orderDTO.SteelGrade);
        orderForUpdate.ChangeNumber(orderDTO.Number);

        _orderRepository.Update(orderForUpdate);
        _orderRepository.UnitOfWork.SaveChanges();

        return Result.Success();
    }

    public Result DeleteOrder(long orderId)
    {
        Order? orderForDelete = _orderRepository.GetById(orderId);

        if (orderForDelete == null)
            return Result.Failure(Error.None);

        orderForDelete.Disable();
        _orderRepository.Update(orderForDelete);
        _orderRepository.UnitOfWork.SaveChanges();

        return Result.Success();
    }

    public Result<OrderDTO> GetById(long orderId)
    {
        Order? order = _orderRepository.GetById(orderId);
        if (order == null)
            return Error.None;

        return MapOrderToOrderDTO(order);
    }

    public IEnumerable<OrderDTO> GetAll()
    {
        var orders = _orderRepository.GetAll();
        List<OrderDTO> orderDTOs = new List<OrderDTO>();
        foreach (var order in orders)
        {
            orderDTOs.Add(MapOrderToOrderDTO(order));
        }
        return orderDTOs;
    }

    private OrderDTO MapOrderToOrderDTO(Order order)
    {
        return new OrderDTO()
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            Number = order.Number,
            PlateLength = order.PlateLength,
            PlateThickness = order.PlateThickness / 100.0F,
            PlateWidth = order.PlateWidth,
            SteelGrade = order.SteelGrade
        };
    }
}

