using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Domain.Entities;

namespace Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<CourseSchedule> CourseSchedules { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grade>()
                .Property(g => g.MidtermScore)
                .HasColumnType("decimal(5,2)");
            modelBuilder.Entity<Grade>()
                .Property(g => g.FinalScore)
                .HasColumnType("decimal(5,2)");
            modelBuilder.Entity<Grade>()
                .Property(g => g.Average)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Courses)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<CourseSchedule>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseSchedules)
                .HasForeignKey(cs => cs.CourseId);

            modelBuilder.Entity<RolePermission>()
                .HasKey( rp => new {rp.RoleId, rp.PermissionId});

            modelBuilder.Entity<Permission>().HasData(
                    // Öğrenci Yetkileri (Students)
                    new Permission { Id = 1, Name = Application.Constants.Permissions.Students.View, Description = "Öğrenci listesini ve detaylarını görüntüleme yetkisi.", IsActive = true },
                    new Permission { Id = 2, Name = Application.Constants.Permissions.Students.Create, Description = "Sisteme yeni öğrenci ekleme yetkisi.", IsActive = true },
                    new Permission { Id = 3, Name = Application.Constants.Permissions.Students.Edit, Description = "Mevcut öğrenci bilgilerini düzenleme yetkisi.", IsActive = true },
                    new Permission { Id = 4, Name = Application.Constants.Permissions.Students.Delete, Description = "Sistemden öğrenci silme yetkisi.", IsActive = true },

                    // Eğitmen Yetkileri (Instructors)
                    new Permission { Id = 5, Name = Application.Constants.Permissions.Instructors.View, Description = "Eğitmen listesini ve detaylarını görüntüleme yetkisi.", IsActive = true },
                    new Permission { Id = 6, Name = Application.Constants.Permissions.Instructors.Create, Description = "Sisteme yeni eğitmen ekleme yetkisi.", IsActive = true },
                    new Permission { Id = 7, Name = Application.Constants.Permissions.Instructors.Edit, Description = "Mevcut eğitmen bilgilerini düzenleme yetkisi.", IsActive = true },
                    new Permission { Id = 8, Name = Application.Constants.Permissions.Instructors.Delete, Description = "Sistemden eğitmen silme yetkisi.", IsActive = true },

                    // Duyuru Yetkileri (Announcements)
                    new Permission { Id = 9, Name = Application.Constants.Permissions.Announcements.View, Description = "Duyuruları listeleme ve görüntüleme yetkisi.", IsActive = true },
                    new Permission { Id = 10, Name = Application.Constants.Permissions.Announcements.Create, Description = "Sisteme yeni duyuru ekleme/yayınlama yetkisi.", IsActive = true },
                    new Permission { Id = 11, Name = Application.Constants.Permissions.Announcements.Edit, Description = "Mevcut duyuruları düzenleme yetkisi.", IsActive = true },
                    new Permission { Id = 12, Name = Application.Constants.Permissions.Announcements.Delete, Description = "Sistemden duyuru silme/kaldırma yetkisi.", IsActive = true },

                    // Yoklama Yetkileri (Attendance)
                    new Permission { Id = 13, Name = Application.Constants.Permissions.Attendance.View, Description = "Yoklama kayıtlarını görüntüleme yetkisi.", IsActive = true },
                    new Permission { Id = 14, Name = Application.Constants.Permissions.Attendance.Create, Description = "Yeni yoklama kaydı girme yetkisi.", IsActive = true },
                    new Permission { Id = 15, Name = Application.Constants.Permissions.Attendance.Edit, Description = "Mevcut yoklama kayıtlarını düzenleme yetkisi.", IsActive = true },
                    new Permission { Id = 16, Name = Application.Constants.Permissions.Attendance.Delete, Description = "Yoklama kayıtlarını silme yetkisi.", IsActive = true },

                    // Ders Yetkileri (Courses)
                    new Permission { Id = 17, Name = Application.Constants.Permissions.Courses.View, Description = "Ders listesini ve detaylarını görüntüleme yetkisi.", IsActive = true },
                    new Permission { Id = 18, Name = Application.Constants.Permissions.Courses.Create, Description = "Sisteme yeni ders ekleme yetkisi.", IsActive = true },
                    new Permission { Id = 19, Name = Application.Constants.Permissions.Courses.Edit, Description = "Mevcut ders bilgilerini düzenleme yetkisi.", IsActive = true },
                    new Permission { Id = 20, Name = Application.Constants.Permissions.Courses.Delete, Description = "Sistemden ders silme yetkisi.", IsActive = true },

                    // Ders Programı Yetkileri (CourseSchedules)
                    new Permission { Id = 21, Name = Application.Constants.Permissions.CourseSchedules.View, Description = "Ders programlarını görüntüleme yetkisi.", IsActive = true },
                    new Permission { Id = 22, Name = Application.Constants.Permissions.CourseSchedules.Create, Description = "Yeni ders programı oluşturma yetkisi.", IsActive = true },
                    new Permission { Id = 23, Name = Application.Constants.Permissions.CourseSchedules.Edit, Description = "Mevcut ders programlarını düzenleme yetkisi.", IsActive = true },
                    new Permission { Id = 24, Name = Application.Constants.Permissions.CourseSchedules.Delete, Description = "Ders programlarını silme yetkisi.", IsActive = true },

                    // Bölüm Yetkileri (Departments)
                    new Permission { Id = 25, Name = Application.Constants.Permissions.Departments.View, Description = "Bölüm listesini ve detaylarını görüntüleme yetkisi.", IsActive = true },
                    new Permission { Id = 26, Name = Application.Constants.Permissions.Departments.Create, Description = "Sisteme yeni bölüm ekleme yetkisi.", IsActive = true },
                    new Permission { Id = 27, Name = Application.Constants.Permissions.Departments.Edit, Description = "Mevcut bölüm bilgilerini düzenleme yetkisi.", IsActive = true },
                    new Permission { Id = 28, Name = Application.Constants.Permissions.Departments.Delete, Description = "Sistemden bölüm silme yetkisi.", IsActive = true },

                    // Kayıt Yetkileri (Enrollments)
                    new Permission { Id = 29, Name = Application.Constants.Permissions.Enrollments.View, Description = "Öğrenci ders kayıtlarını görüntüleme yetkisi.", IsActive = true },
                    new Permission { Id = 30, Name = Application.Constants.Permissions.Enrollments.Create, Description = "Öğrenciyi bir derse manuel kayıt etme yetkisi.", IsActive = true },
                    new Permission { Id = 31, Name = Application.Constants.Permissions.Enrollments.Edit, Description = "Öğrenci ders kayıt bilgilerini düzenleme yetkisi.", IsActive = true },
                    new Permission { Id = 32, Name = Application.Constants.Permissions.Enrollments.Delete, Description = "Öğrencinin dersten kaydını silme yetkisi.", IsActive = true },

                    // Rol Yetkileri (Roles)
                    new Permission { Id = 33, Name = Application.Constants.Permissions.Roles.View, Description = "Sistemdeki rolleri ve yetkilerini görüntüleme yetkisi.", IsActive = true },
                    new Permission { Id = 34, Name = Application.Constants.Permissions.Roles.Create, Description = "Sisteme yeni rol ekleme yetkisi.", IsActive = true },
                    new Permission { Id = 35, Name = Application.Constants.Permissions.Roles.Edit, Description = "Mevcut rolleri ve rollerin yetkilerini düzenleme yetkisi.", IsActive = true },
                    new Permission { Id = 36, Name = Application.Constants.Permissions.Roles.Delete, Description = "Sistemden rol silme yetkisi.", IsActive = true },

                    // Dönem Yetkileri (Semesters)
                    new Permission { Id = 37, Name = Application.Constants.Permissions.Semesters.View, Description = "Akademik dönemleri görüntüleme yetkisi.", IsActive = true },
                    new Permission { Id = 38, Name = Application.Constants.Permissions.Semesters.Create, Description = "Yeni akademik dönem oluşturma yetkisi.", IsActive = true },
                    new Permission { Id = 39, Name = Application.Constants.Permissions.Semesters.Edit, Description = "Akademik dönem bilgilerini düzenleme yetkisi.", IsActive = true },
                    new Permission { Id = 40, Name = Application.Constants.Permissions.Semesters.Delete, Description = "Akademik dönem silme yetkisi.", IsActive = true },

                    // Sınıf Yetkileri (ClassRooms)
                    new Permission { Id = 41, Name = Application.Constants.Permissions.ClassRooms.View, Description = "Sınıf listesini ve detaylarını görüntüleme yetkisi.", IsActive = true },
                    new Permission { Id = 42, Name = Application.Constants.Permissions.ClassRooms.Create, Description = "Sisteme yeni sınıf ekleme yetkisi.", IsActive = true },
                    new Permission { Id = 43, Name = Application.Constants.Permissions.ClassRooms.Edit, Description = "Mevcut sınıf bilgilerini düzenleme yetkisi.", IsActive = true }, // Düzeltildi
                    new Permission { Id = 44, Name = Application.Constants.Permissions.ClassRooms.Delete, Description = "Sistemden sınıf silme yetkisi.", IsActive = true }, // Düzeltildi
                    new Permission { Id = 45, Name = Application.Constants.Permissions.ClassRooms.AssignInstructor, Description = "Sınıflara eğitmen/sorumlu atama yetkisi.", IsActive = true }
            );

            var adminRolePermissions = Enumerable.Range(1, 45)
            .Select(permissionId => new RolePermission 
            { 
                RoleId = 1,
                PermissionId = permissionId,
                IsActive = true
            })
            .ToArray();
            modelBuilder.Entity<RolePermission>().HasData(adminRolePermissions);
        }
    }
}