using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Application.DTOs.Course;
using Application.DTOs.Enrollment;
using Application.DTOs.Attendance;
using Domain.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseListDTO>();
            CreateMap<Course, CourseCreateDTO>();
            CreateMap<Enrollment, EnrollmentCreateDTO>();
            CreateMap<Attendance, AttendanceCreateDTO>();
        }
    }
}