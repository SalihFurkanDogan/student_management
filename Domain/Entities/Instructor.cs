using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Instructor : BaseEntity
    {
        public string InstructorNumber { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<ClassRoom> ClassRooms { get; set; } = new HashSet<ClassRoom>();
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}