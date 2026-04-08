using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Enrollment;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnrollmentCreateDTO enrollmentCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(enrollmentCreateDTO);
            }
            try
            {
                await _enrollmentService.EnrollStudentAsync(enrollmentCreateDTO);
                TempData["SuccessMessage"] = "Öğrenci derse başarıyla kaydedildi!";
                return RedirectToAction("Index", "Course");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(enrollmentCreateDTO); 
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Kayıt işlemi sırasında beklenmeyen bir hata oluştu.");
                return View(enrollmentCreateDTO);
            }
        }
    }
}