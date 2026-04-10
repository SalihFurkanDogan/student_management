using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEnrollmentRepository : IRepository<Enrollment>
    {
        Task<List<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId);
        Task<List<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId);
    }
}