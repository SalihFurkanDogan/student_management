using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}