using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Defectograms;

public class Defectogram : Entity, IAggregateRoot
{
    private Defectogram()
    {
        Name = string.Empty;
    }

    public Defectogram(long id, string name, long ustModeId, long userId, int thickness, int width, int length)
    {
        Id = id;
        Name = name;
        Thickness = thickness;
        Width = width;
        Length = length;
        USTModeId = ustModeId;
        UserId = userId;
    }

    public long CreatedAtTicks { get; private set; }
    public string Name { get; private set; }
    public int Thickness { get; private set; }
    public int Width { get; private set; }
    public int Length { get; private set; }
    public long USTModeId { get; private set; }
    public long UserId { get; private set; }

    public void ChangeName(string name)
    {
        Name = name;
    }

    public void ChangeDimensions(int thickness,  int width, int length)
    {
        Thickness = thickness;
        Width = width;
        Length = length;
    }
}
