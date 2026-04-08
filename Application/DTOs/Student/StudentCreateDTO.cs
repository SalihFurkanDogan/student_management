using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Application.DTOs.Student
{
    public record StudentCreateDTO(
        string FirstName,
        string LastName,
        string Email,
        string Password,

        string StudentNumber,
        int DepartmentId,
        int ClassRoomId,
        int SemesterId
    );
}