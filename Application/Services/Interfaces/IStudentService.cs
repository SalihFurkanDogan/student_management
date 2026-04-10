using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Student;
using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IStudentService
    {
        Task CreateStudentAsync(StudentCreateDTO createStudentDTO);
    }
}