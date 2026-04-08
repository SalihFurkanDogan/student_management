using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Application.DTOs.Attendance;

namespace Application.Services.Implementations
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IRepository<Enrollment> _enrollmentRepository;
        private readonly IRepository<Attendance> _attendanceRepository;
        public AttendanceService(IRepository<Attendance> AttendanceRepo, IRepository<Enrollment> EnrollmentRepo)
        {
            _enrollmentRepository = EnrollmentRepo;
            _attendanceRepository = AttendanceRepo;
        }
        public async Task AddAttendanceAsync(AttendanceCreateDTO attendanceCreateDTO)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(attendanceCreateDTO.EnrollmentId);
            if (enrollment == null)
            {
                throw new Exception("Enrollment Bulunamadı!");
            }
            enrollment.AddAttendance(attendanceCreateDTO.Date, attendanceCreateDTO.IsPresent);
            _enrollmentRepository.Update(enrollment);
            await _enrollmentRepository.SaveChangesAsync();
        }
    }
}