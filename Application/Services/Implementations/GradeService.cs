using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Application.Services.Interfaces;
using Domain.Entities;
using Application.DTOs.Grade;

namespace Application.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly IRepository<Grade> _gradeRepository;
        private readonly IRepository<Enrollment> _enrollmentRepository;
        public GradeService(IRepository<Enrollment> enrollmentRepository, IRepository<Grade> gradeRepository)
        {
            _gradeRepository = gradeRepository;
            _enrollmentRepository = enrollmentRepository;
        }
        public async Task ProcessGrade(GradeDTO gradeDTO)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(gradeDTO.EnrollmentId);
            if (enrollment == null)
            {
                throw new Exception("Enrollment Bulunamadı!");
            }
            var existingGrade = await _gradeRepository.GetByIdAsync(gradeDTO.EnrollmentId); // Id'lerin birebir eşleştiğini varsayarsak

            if (existingGrade == null)
            {
                existingGrade = new Grade { EnrollmentId = gradeDTO.EnrollmentId };
                await _gradeRepository.AddAsync(existingGrade);
            }
            if (gradeDTO.MidtermScore.HasValue)
            {
                existingGrade.UpdateMidterm(gradeDTO.MidtermScore.Value);
            }
            if (gradeDTO.FinalScore.HasValue)
            {
                existingGrade.UpdateFinal(gradeDTO.FinalScore.Value);
            }
            _gradeRepository.Update(existingGrade);
            await _gradeRepository.SaveChangesAsync();
        }
    }
}