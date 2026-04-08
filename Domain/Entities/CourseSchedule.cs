using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CourseSchedule : BaseEntity
    {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public int ClassRoomId { get; set; }
        public ClassRoom Classroom { get; set; } = null!;
    }
}