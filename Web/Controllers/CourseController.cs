using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Course;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Authorization;
using Web.Filters;
using Application.Constants;

namespace Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [RequireClaim("Permission", Permissions.Courses.View)]
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return View(courses);
        }
        [HttpGet]
        [RequireClaim("Permission", Permissions.Courses.View)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [RequireClaim("Permission", Permissions.Courses.Create)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseCreateDTO courseCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(courseCreateDTO);
            }
            try
            {
                await _courseService.AddCourseAsync(courseCreateDTO);
                return RedirectToAction("Index", "Course");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(courseCreateDTO);
            }
        }
    }
}