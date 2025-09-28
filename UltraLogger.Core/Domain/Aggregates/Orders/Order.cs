using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Orders;

public class Order : Entity, IAggregateRoot
{
    private Order()
    {
        Number = string.Empty;
        SteelGrade = string.Empty;
    }

    public Order(long id, string number, long customerId, string steelGrade, int plateThickness, int plateWidth, int plateLength, bool isActive)
    {
        Id = id;
        Number = number;
        SteelGrade = steelGrade;
        CustomerId = customerId;
        SteelGrade = steelGrade;
        PlateThickness = plateThickness;
        PlateWidth = plateWidth;
        PlateLength = plateLength;
        IsActive = isActive;
    }

    public string Number { get; private set; }
    public long CustomerId { get; private set; }
    public string SteelGrade { get; private set; }
    public int PlateThickness { get; private set; }
    public int PlateWidth { get; private set; }
    public int PlateLength { get; private set; }
    public bool IsActive { get; private set; }

    public void ChangeDimensions(int thickness, int width, int length)
    {
        PlateThickness = thickness;
        PlateWidth = width;
        PlateLength = length;
    }

    public void ChangeSteelGrade(string steelGrade)
    {
        SteelGrade = steelGrade;
    }

    public void ChangeCustomer(long customerId)
    {
        CustomerId = customerId;
    }

    public void ChangeNumber(string number)
    {
        Number = number;
    }

    public void Disable()
    {
        IsActive = false;
    }

    public void Enable()
    {
        IsActive = true;
    }
}
