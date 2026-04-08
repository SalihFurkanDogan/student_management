using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Attendance
{
    public record AttendanceCreateDTO(
        int EnrollmentId,
        DateTime Date,
        bool IsPresent
    );
}