using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs.Grade
{
    public record GradeDTO
    (
        int EnrollmentId,
        decimal? MidtermScore,
        decimal? FinalScore
    );
}