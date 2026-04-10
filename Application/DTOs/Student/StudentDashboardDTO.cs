using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Student
{
    public record StudentDashboardDTO(
        int Id,
        string FirstName,
        string LastName,
        string Email,
        string StudentNumber,
        int DepartmentId,
        int ClassRoomId,
        int SemesterId
    );
}