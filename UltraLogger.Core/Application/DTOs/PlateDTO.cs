using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraLogger.Core.Application.DTOs;

public class PlateDTO
{
    public int MeltYear { get; set; }
    public int MeltNumber { get; set; }
    public int SlabNumber { get; set; }
    public List<PlatePartDTO> Parts { get; set; } = new List<PlatePartDTO>();
    //public ReportDTO? Report { get; set; }
}
