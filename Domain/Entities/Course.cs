using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int Credit { get; set; }
        public int Quota { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public bool IsAttendanceMandatory { get; set; } = true;
        public int MaxAbsenceLimit { get; set; }
        public ICollection<CourseSchedule> CourseSchedules { get; set; } = new HashSet<CourseSchedule>();
        public void AddEnrollment(Enrollment enrollment)
        {
            // Kontenjan kontrolü
            if (Enrollments.Count >= Quota)
            {
                throw new InvalidOperationException($"'{Name}' dersinin kontenjanı dolmuştur. Yeni kayıt alınamaz.");
            }

            // Aynı öğrencinin aynı derse birden fazla kayıt olmasını engelle
            if (Enrollments.Any(e => e.StudentId == enrollment.StudentId))
            {
                throw new InvalidOperationException("Öğrenci bu derse zaten kayıtlı.");
            }
            Enrollments.Add(enrollment);
        }
    }
}