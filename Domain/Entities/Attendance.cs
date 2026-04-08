using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Attendance : BaseEntity
    {
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public bool IsPresent { get; set; }
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; } = null!;
    }
}