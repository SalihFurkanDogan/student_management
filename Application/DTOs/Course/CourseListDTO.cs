using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Course
{
    public record CourseListDTO(
        int Id,
        string Name, 
        string Code, 
        int Credit, 
        int Quota
    );
}