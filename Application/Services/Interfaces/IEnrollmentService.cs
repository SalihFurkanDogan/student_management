using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

using Application.DTOs.Enrollment;
using Application.DTOs.Course;


namespace Application.Services.Interfaces
{
    public interface IEnrollmentService
    {
        Task EnrollStudentAsync(EnrollmentCreateDTO enrollmentCreateDTO);
        Task<List<CourseListDTO>> GetEnrollmentsByUserId(int id);
    }
}