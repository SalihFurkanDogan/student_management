using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.DTOs.Enrollment;
using Domain.Interfaces;
using Application.Mappers;
using Application.DTOs.Course;
using Domain.Entities;
using Microsoft.VisualBasic;
using Application.DTOs.Student;

namespace Application.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Enrollment> _enrollmentRepository;

        public EnrollmentService(IRepository<Course> courseRepository, IRepository<Student> studentRepository, IRepository<Enrollment> enrollmentRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _enrollmentRepository = enrollmentRepository;
        }
        public async Task EnrollStudentAsync(EnrollmentCreateDTO enrollmentCreateDTO)
        {
            var student = await _studentRepository.GetByIdAsync(enrollmentCreateDTO.StudentId);
            var course = await _courseRepository.GetByIdAsync(enrollmentCreateDTO.CourseId);

            if(student == null || course == null)
                throw new Exception("Öğrenci veya Ders Bulunamadı!");

            var newEnrollment = new Enrollment
            {
                StudentId = enrollmentCreateDTO.StudentId,
                CourseId = enrollmentCreateDTO.CourseId,
                EnrollmentDate = DateTime.Now,
                IsActive = true
            };

            course.AddEnrollment(newEnrollment);
            await _courseRepository.SaveChangesAsync();
        }
        public async Task<List<CourseListDTO>> GetEnrollmentsByUserId(int id)
        {
            var enrollments = await _enrollmentRepository.GetAllAsync();
            var activeEnrollments = new List<int>();
            foreach(var enrollment in enrollments)
            {
                if (enrollment.StudentId == id && enrollment.IsActive == true)
                {
                    activeEnrollments.Add(enrollment.CourseId);
                }
            }

            var enrolledCourses = new List<CourseListDTO>();
            foreach(var courseId in activeEnrollments)
            {
                var course = await _courseRepository.GetByIdAsync(courseId);
                if(course != null)
                {
                    enrolledCourses.Add(new CourseListDTO(
                        course.Id, course.Name, course.Code, course.Credit, course.Quota));
                }
            }

            return enrolledCourses;
        }
    }
}