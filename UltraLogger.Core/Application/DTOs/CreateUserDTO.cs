using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraLogger.Core.Application.DTOs;

public class CreateUserDTO
{
    public required string Login { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string MiddleName { get; set; }
    public required string Password { get; set; }
}
