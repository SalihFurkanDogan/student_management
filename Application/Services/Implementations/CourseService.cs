using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Course;
using Application.Interfaces;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Application.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _repository;
        private readonly IMapper _mapper;

        public CourseService(IRepository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseListDTO>> GetAllCoursesAsync()
        {
            var courses = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseListDTO>>(courses);
        }

        public async Task AddCourseAsync(CourseCreateDTO courseCreateDTO)
        {
            var newCourse = new Course{
                Name = courseCreateDTO.Name,
                Code = courseCreateDTO.Code,
                Credit = courseCreateDTO.Credits,
                Quota = courseCreateDTO.Quota,
                InstructorId = courseCreateDTO.InstructorId,
                DepartmentId = courseCreateDTO.DepartmentId,
                CreatedAt = DateTime.Now,
                IsActive = true
            };
            
            await _repository.AddAsync(newCourse);
            await _repository.SaveChangesAsync();
        }
    }
}