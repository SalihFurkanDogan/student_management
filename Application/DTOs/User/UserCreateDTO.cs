using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public record UserCreateDTO(
        string FirstName, 
        string LastName, 
        string Email, 
        string Password, 
        int RoleId
    );
}