using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Grade : BaseEntity
    {
        public decimal? MidtermScore { get; set; }
        public decimal? FinalScore { get; set; }
        public decimal? MakeupScore { get; set; } 
        public decimal? Average { get; set; }
        public string LetterGrade { get; set; } = string.Empty;
        public bool IsPassed { get; set; }
        public int EnrollmentId { get; set; }
        public Enrollment Enrollment { get; set; } = null!;

        public void UpdateMidterm(decimal score)
        {
            if (score < 0 || score > 100)
                throw new ArgumentException("Vize notu 0 ile 100 arasında olmalıdır.");
            
            MidtermScore = score;
            CalculateAverage();
        }

        public void UpdateFinal(decimal score)
        {
            if (score < 0 || score > 100)
                throw new ArgumentException("Final notu 0 ile 100 arasında olmalıdır.");
            
            FinalScore = score;
            CalculateAverage(); 
        }

        private void CalculateAverage()
        {
            if (Enrollment.IsFailedDueToAbsence())
            {
                LetterGrade = "DZ";
                IsPassed = false;
                Average = 0; 
                return;
            }
            if (!MidtermScore.HasValue || !FinalScore.HasValue) return;
            Average = (MidtermScore.Value * (decimal) 0.40) + (FinalScore.Value * (decimal) 0.60);
        
            if (Average >= 90) LetterGrade = "AA";
            else if (Average >= 80) LetterGrade = "BA";
            else if (Average >= 70) LetterGrade = "BB";
            else if (Average >= 60) LetterGrade = "CB";
            else if (Average >= 50) LetterGrade = "CC";
            else LetterGrade = "FF";

            IsPassed = Average >= 50;
        }
    }
}