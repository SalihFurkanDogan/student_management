using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICourseRegistrationDomainService
    {
        Enrollment Register(Student student, Course newCourse, IEnumerable<CourseSchedule> studentCurrentSchedules);
    }
}