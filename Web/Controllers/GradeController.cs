using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Grade;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeService _gradeService;
        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        [HttpGet]
        public async Task<IActionResult> EnterGrade()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnterGrade(GradeDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);

            try
            {
                await _gradeService.ProcessGrade(dto);
                TempData["SuccessMessage"] = "Notlar başarıyla girildi ve ortalama hesaplandı!";
                return RedirectToAction("Index", "Course");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(dto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Not girilirken bir hata oluştu." + ex.Message);
                return View(dto);
            }
        }               
    }
}