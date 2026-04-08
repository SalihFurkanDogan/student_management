using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.User;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;

namespace Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> CreateUserAsync(UserCreateDTO userCreateDTO)
        {
            var users = await _userRepository.GetAllAsync();
            var user = users.Where(s => s.Email == userCreateDTO.Email).FirstOrDefault();
            
            if (user != null)
                throw new Exception("User already exists");

            user = new User{
                FirstName = userCreateDTO.FirstName,
                LastName = userCreateDTO.LastName,
                Email = userCreateDTO.Email,
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(userCreateDTO.Password),
                RoleId = userCreateDTO.RoleId,
                CreatedAt = DateTime.Now,
                IsActive = true
            };
            
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            
            return user.Id;
        }
    }
}