using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Services
{
    public class CourseRegistrationDomainService : ICourseRegistrationDomainService
    {
        public Enrollment Register(Student student, Course newCourse, IEnumerable<CourseSchedule> studentCurrentSchedules)
        {
            if (newCourse.Enrollments.Any(e => e.StudentId == student.Id))
            {
                throw new InvalidOperationException("Öğrenci bu derse zaten kayıtlı.");
            }

            foreach (var newSchedule in newCourse.CourseSchedules)
            {
                bool isConflict = studentCurrentSchedules.Any(existing => 
                    existing.DayOfWeek == newSchedule.DayOfWeek && 
                    (
                        (newSchedule.StartTime >= existing.StartTime && newSchedule.StartTime < existing.EndTime) ||
                        (newSchedule.EndTime > existing.StartTime && newSchedule.EndTime <= existing.EndTime)
                    ));

                if (isConflict)
                {
                    throw new InvalidOperationException($"Zaman çakışması! '{newCourse.Name}' dersinin programı mevcut programınızla çakışıyor.");
                }
            }

            var enrollment = new Enrollment
            {
                StudentId = student.Id,
                CourseId = newCourse.Id,
                Student = student,
                Course = newCourse,
                EnrollmentDate = DateTime.UtcNow
            };

            newCourse.AddEnrollment(enrollment);
            return enrollment;
        }
    }
}