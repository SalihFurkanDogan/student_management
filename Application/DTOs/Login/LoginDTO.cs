using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Login
{
    public record LoginDTO(
        string Email,
        string Password
    );
}