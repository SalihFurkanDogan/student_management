using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Attendance;
using Application.Interfaces;

namespace Application.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task AddAttendanceAsync(AttendanceCreateDTO attendanceCreateDTO);
    }
}