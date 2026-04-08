using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Course
{
        public record CourseCreateDTO(
            string Name, 
            string Code, 
            int Credits, 
            int Quota, 
            int DepartmentId, 
            int InstructorId
        );
}