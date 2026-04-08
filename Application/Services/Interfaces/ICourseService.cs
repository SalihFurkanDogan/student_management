using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Course;

namespace Application.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseListDTO>> GetAllCoursesAsync();
        Task AddCourseAsync(CourseCreateDTO course);
    }
}