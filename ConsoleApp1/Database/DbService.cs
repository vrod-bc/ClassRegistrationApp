using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ConsoleApp1.Models;

namespace ConsoleApp1.Database
{
    public class DbService: IDbService
    {
        private List<Departments> DepartmentList;
        private List<Courses> CourseList;
        private List<User> UserList;
        private List<StudentToCourse> studentToCoursesList;
        public DbService()
        {
            DepartmentList = new List<Departments>
            {
                new Departments
                {
                    DepartmentName = "Engineering",
                    DepartmentId = 1
                },
                new Departments
                {
                    DepartmentName = "College of the Arts",
                    DepartmentId = 2
                },
                new Departments
                {
                    DepartmentName = "Nursing",
                    DepartmentId = 3
                },
                new Departments
                {
                    DepartmentName = "College of Music",
                    DepartmentId = 4
                }
            };
            CourseList = new List<Courses>
            {
                new Courses
                {
                    CourseName = "Physics",
                    CourseId = 1,
                    DepartmentId = 1
                },
                new Courses
                {
                    CourseName = "Calculus",
                    CourseId = 2,
                    DepartmentId = 1
                },
                new Courses
                {
                    CourseName = "Drawing",
                    CourseId = 3,
                    DepartmentId = 2
                },
                new Courses
                {
                    CourseName = "Photography",
                    CourseId = 4,
                    DepartmentId = 2
                },
                new Courses
                {
                    CourseName = "Anatomy",
                    CourseId = 5,
                    DepartmentId = 3
                },
                new Courses
                {
                    CourseName = "Physiology",
                    CourseId = 6,
                    DepartmentId = 3
                }
            };
            UserList = new List<User>
            { 
                new User
                {
                    UserName = "Grant",
                    UserId = 1,
                },
                new User
                {
                    UserName = "Junior",
                    UserId = 2,
                },
                new User
                {
                    UserName = "Yolanda",
                    UserId = 3,
                }
            };
            studentToCoursesList = new List<StudentToCourse>
            {
                new StudentToCourse
                {
                    StudentId = 1,
                    CourseId = 1
                },
                new StudentToCourse
                {
                    StudentId = 2,
                    CourseId = 2
                },
                new StudentToCourse
                {
                    StudentId = 3,
                    CourseId = 3
                }
            };

        }
        public List<Departments> GetDepartments()
        {
            return DepartmentList;
        }

        public Departments GetDeparmentById(int id)
        {
            return DepartmentList.Find(x => x.DepartmentId == id);
        }

        public bool SaveDepartment(Departments obj)
        {
            try
            {
                DepartmentList.Add(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public List<Courses> GetCourses()
        {
            return CourseList;
        }

        public Courses GetCoursesById(int id)
        {
            return CourseList.Find(x => x.CourseId == id);
        }

    public List<Courses> GetCoursesByDeptId(int id)
        {
           
            List<Courses> CourseDept = new List<Courses>();
            foreach (var course in CourseList)
            {
                if(course.DepartmentId == id)
                {
                    CourseDept.Add(course);
                }
                try
                {
                    GetCourses().Where(x => x.DepartmentId != id);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }
            }
            
            return CourseDept;
        }
  
        public bool SaveCourse(Courses obj)
        {
            try
            {
                CourseList.Add(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public User GetUserByID(int id)
        {
            return UserList.Find(x => x.UserId == id);
        }

        public User GetCoursesByUserID(int id)
        {
            var user = GetUserByID(id);
            List<Courses> CoursesList = new List<Courses>();

            foreach (var item in CourseList)
            {
                if (item.DepartmentId == id)
                {
                    CoursesList.Add(item);
                }
            }
            user.CoursesList = CoursesList;
            return user; 
        }

        public string CoursesTaken(int id)
        {
            var coursedept = GetCoursesByDeptId(id);
  
            List<string> StudentCourses = new List<string>();

            foreach (var item in coursedept)
            {
                var sucess = studentToCoursesList.Find(x => x.CourseId == item.CourseId);
                if (sucess != null)
                {
                    StudentCourses.Add("\r\n" + GetUserByID(sucess.StudentId).UserName + " is taking class " + item.CourseName);
                }
            }
            return string.Concat(StudentCourses);
        }
        
        public List<Courses> GetCoursesDESC()
        {
            return CourseList.OrderByDescending(x => x.CourseName).ToList();
        }

        public List<Courses> GetCoursesByType(string Course)
        {
            return GetCourses().Where(x => x.CourseName.ToLower().Contains(Course.ToLower())).ToList();
            //return GetCourses().Where(x => x.CourseName.Equals(Course, StringComparison.OrdinalIgnoreCase)).ToList();
        } 

    }
}
