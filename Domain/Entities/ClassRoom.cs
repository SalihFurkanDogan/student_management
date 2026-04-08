using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ClassRoom : BaseEntity
    {
        public string ClassRoomName { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public Instructor Instructor { get; set; } = null!;
    }
}