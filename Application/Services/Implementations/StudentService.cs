using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Student;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using BCrypt.Net;
using Application.DTOs.User;

namespace Application.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IUserService _userService;
        public StudentService(IUserService userService,IRepository<Student> studentRepository)
        {
            _userService = userService;
            _studentRepository = studentRepository;
        }
        public async Task CreateStudentAsync(StudentCreateDTO createStudentDTO)
        {
            try
            {
                var UserDTO = new UserCreateDTO
                (
                    createStudentDTO.FirstName,
                    createStudentDTO.LastName,
                    createStudentDTO.Email,
                    createStudentDTO.Password,
                    2
                );

                var userId = await _userService.CreateUserAsync(UserDTO);
                if(userId == -1)
                    throw new Exception("User Oluşturma hatası");

                Console.WriteLine(userId);

                var student = new Student
                {
                    UserId = userId,
                    StudentNumber = createStudentDTO.StudentNumber,
                    DepartmentId = createStudentDTO.DepartmentId,
                    ClassRoomId = createStudentDTO.ClassRoomId,
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };
                
                await _studentRepository.AddAsync(student);
                await _studentRepository.SaveChangesAsync();
                }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
    }
}