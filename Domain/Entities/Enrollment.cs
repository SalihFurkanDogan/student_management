using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Entities
{
    public class Enrollment : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int SemesterId { get; set; }
        public Semester Semester { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public DateTime? EnrollmentDate { get; set; } = DateTime.UtcNow;
        public Grade? Grade { get; set; }
        public ICollection<Attendance> Attendance { get; set; } = new HashSet<Attendance>();

        //Devamsızlık sayısını hesaplayan bir metot
        public int GetTotalAbsences()
        {
            return Attendance.Count(a => !a.IsPresent);
        }
        public bool IsFailedDueToAbsence()
        {
            // Eğer dersin devam zorunluluğu yoksa direkt false dön (kalmadı)
            if (!Course.IsAttendanceMandatory) return false;

            // Devamsızlık sayısı limiti aştıysa true dön (kaldı)
            return GetTotalAbsences() > Course.MaxAbsenceLimit;
        }
        public void AddAttendance(DateTime date, bool isPresent)
        {
            // İŞ KURALI: Aynı güne iki defa yoklama girilmesini engelle
            if (Attendance.Any(a => a.Date.Date == date.Date))
            {
                throw new InvalidOperationException("Bu tarihe ait yoklama zaten girilmiş!");
            }

            var attendance = new Attendance
            {
                Date = date,
                IsPresent = isPresent,
                EnrollmentId = this.Id,
                Enrollment = this // İşte bahsettiğin eşleştirme burada nesnenin kendi içinde yapılıyor!
            };

            Attendance.Add(attendance);
        }
    }
}