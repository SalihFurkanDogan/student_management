using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Course;
using Domain.Entities;

namespace Application.DTOs.Enrollment
{
    public record EnrollmentDashboardDTO(
        string Name,
        string Code,
        int Credit,
        int Quota,
        int CourseId
    );
}