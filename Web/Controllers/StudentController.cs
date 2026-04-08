using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Constants;
using Application.DTOs.Student;
using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web.Filters;
using Application.DTOs.Enrollment;
using Application.DTOs.Course;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IEnrollmentService _enrollmentService;
        private readonly ICourseService _courseService;

        public StudentController(IStudentService studentService, IEnrollmentService enrollmentService, ICourseService courseService)
        {
            _studentService = studentService;
            _enrollmentService = enrollmentService;
            _courseService =  courseService;
        }
        [HttpGet]
        public IActionResult Dashboard(StudentDashboardDTO studentDashboardDto)
        {

            return View(studentDashboardDto);
        }
        [HttpGet]
        [RequireClaim("Permission", Permissions.ClassRooms.View)]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [RequireClaim("Permission", Permissions.ClassRooms.Create)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreateDTO studentCreateDTO)
        {
            if(!ModelState.IsValid)
            {
                return View(studentCreateDTO);
            }
            try
            {
                await _studentService.CreateStudentAsync(studentCreateDTO);
                return RedirectToAction("Index", "Course");
            }
            catch(Exception ex)
            {
                return Content("Hata Oluştu : " + ex.Message);
            }
        }
        [HttpGet]
        [RequireClaim("Permission", Permissions.Enrollments.View)]
        public async Task<IActionResult> Enrollment()
        {
            return View();
        }
        [HttpPost]
        [RequireClaim("Permission", Permissions.Enrollments.Create)]
        public async Task<IActionResult> Enrollment(StudentDashboardDTO studentDashboardDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(studentDashboardDTO);
            }

            var enrolledCourses = new List<CourseListDTO>();
            //Fonksiyonu tekrar düzenle yapılması gereken kayıtlı kursları solda
            //gösterecek listeyi oluştur listele ve
            //aktif olarak listelenebilecek kursları listele  

            return View();
        }

    }
}