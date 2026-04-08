using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Attendance;

namespace Web.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AttendanceCreateDTO attendanceCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                var initialDto = new AttendanceCreateDTO(0, DateTime.Today, true);
                return View(initialDto);
            }
            try
            {
                await _attendanceService.AddAttendanceAsync(attendanceCreateDTO);
                TempData["SuccessMessage"] = "Öğrenci derse başarıyla kaydedildi!";
                return RedirectToAction("Index", "Course");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(attendanceCreateDTO); 
            }
        }
    }
}