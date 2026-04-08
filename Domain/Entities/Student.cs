using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string StudentNumber { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<Enrollment> Enrollments { get; set; } = new HashSet<Enrollment>();
        public int ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; } = null!;
    }
}