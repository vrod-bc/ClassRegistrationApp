using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Models;

namespace ConsoleApp1.Database
{
    public interface IDbService
    {
        List<Departments> GetDepartments();
        Departments GetDeparmentById(int id);
        bool SaveDepartment(Departments obj);
        List<Courses> GetCourses();
        Courses GetCoursesById(int id);
        List<Courses> GetCoursesByDeptId(int id);
        bool SaveCourse(Courses obj);
        User GetUserByID(int id);
        User GetCoursesByUserID(int id);
        string CoursesTaken(int id);
        List<Courses> GetCoursesDESC();
        public List<Courses> GetCoursesByType(string Course); 
    }
}
