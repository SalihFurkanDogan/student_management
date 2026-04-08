using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Enrollment
{
    public record EnrollmentCreateDTO
    (
        int StudentId,
        int CourseId
    );
}