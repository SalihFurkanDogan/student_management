using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Login;

namespace Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<(string Token, string Role)> LoginAsync(LoginDTO loginDTO); 
    }
}