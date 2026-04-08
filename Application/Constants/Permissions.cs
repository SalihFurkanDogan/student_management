using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class Permissions
    {
        public static class Students
        {
            public const string View = "Students.View";
            public const string Create = "Students.Create";
            public const string Edit = "Students.Edit";
            public const string Delete = "Students.Delete";
        }
        public static class Instructors
        {
            public const string View = "Instructors.View";
            public const string Create = "Instructors.Create";
            public const string Edit = "Instructors.Edit";
            public const string Delete = "Instructors.Delete";
        }
        public static class ClassRooms
        {
            public const string View = "ClassRooms.View";
            public const string Create = "ClassRooms.Create";
            public const string Edit = "ClassRooms.Edit";
            public const string Delete = "ClassRooms.Delete";
            public const string AssignInstructor = "ClassRooms.AssignInstructor"; 
        }
        public static class Announcements
        {
            public const string View = "Announcements.View";
            public const string Create = "Announcements.Create";
            public const string Edit = "Announcements.Edit";
            public const string Delete = "Announcements.Delete";
        }
        public static class Attendance
        {
            public const string View = "Attendance.View";
            public const string Create = "Attendance.Create";
            public const string Edit = "Attendance.Edit";
            public const string Delete = "Attendance.Delete";
        }
        public static class Courses
        {
            public const string View = "Courses.View";
            public const string Create = "Courses.Create";
            public const string Edit = "Courses.Edit";
            public const string Delete = "Courses.Delete";
        }
        public static class CourseSchedules
        {
            public const string View = "CourseSchedules.View";
            public const string Create = "CourseSchedules.Create";
            public const string Edit = "CourseSchedules.Edit";
            public const string Delete = "CourseSchedules.Delete";
        }
        public static class Departments
        {
            public const string View = "Departments.View";
            public const string Create = "Departments.Create";
            public const string Edit = "Departments.Edit";
            public const string Delete = "Departments.Delete";
        }
        public static class Enrollments
        {
            public const string View = "Enrollments.View";
            public const string Create = "Enrollments.Create";
            public const string Edit = "Enrollments.Edit";
            public const string Delete = "Enrollments.Delete";
        }
        public static class Grades
        {
            public const string View = "Grades.View";
            public const string Create = "Grades.Create";
            public const string Edit = "Grades.Edit";
            public const string Delete = "Grades.Delete";
        }
        public static class Roles
        {
            public const string View = "Roles.View";
            public const string Create = "Roles.Create";
            public const string Edit = "Roles.Edit";
            public const string Delete = "Roles.Delete";
        }
        public static class Semesters
        {
            public const string View = "Semesters.View";
            public const string Create = "Semesters.Create";
            public const string Edit = "Semesters.Edit";
            public const string Delete = "Semesters.Delete";
        }
    }
}