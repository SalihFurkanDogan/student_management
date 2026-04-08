using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Grade;

namespace Application.Services.Interfaces
{
    public interface IGradeService
    {
        Task ProcessGrade(GradeDTO gradeDTO);
    }
}