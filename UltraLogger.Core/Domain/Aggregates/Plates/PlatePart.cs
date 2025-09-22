using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Plates;

public class PlatePart : Entity
{
    private PlatePart()
    {
    }

    public PlatePart(
        long id,
        int number,
        int x,
        int y,
        int width,
        int length)
    {
        Id = id;
        Number = number;
        X = x;
        Y = y;
        Width = width;
        Length = length;
    }

    public int Number { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Width { get; private set; }
    public int Length { get; private set; }

    public void ChangeLocation(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void ChangeDimensions(int width, int length)
    {
        Width = width;
        Length = length;
    }
}
