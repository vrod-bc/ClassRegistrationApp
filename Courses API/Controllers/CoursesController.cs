using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsoleApp1;
using ConsoleApp1.Models;
using ConsoleApp1.Database;

namespace Courses_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        IDbService Idb;
        public CoursesController (IDbService db)
        {
            Idb = db;
        }

        [HttpGet]
        public List<Courses> GetCourses()
        {
            return Idb.GetCourses();
        }

        [HttpGet("{id}", Name = "GetCourses")]
        public Courses GetCoursesById(int id)
        {
            return Idb.GetCoursesById(id);
        }

        [HttpGet("GetCourseByDeptId/{id}")]
        public List<Courses> GetCourseByDeptID(int id)
        {
            return Idb.GetCoursesByDeptId(id);
        }

        [HttpGet("GetUserAndCourseInfo/{id}")]
        public User GetUserandCourseInfo(int id)
        {

            return Idb.GetCoursesByUserID(id);
                
        }

        [HttpGet("GetCoursesDESC")]
        public List<Courses> GetCoursesDESC()
        {
            return Idb.GetCoursesDESC();
        }

        [HttpGet("GetCoursesByType/{input}")]
        public List<Courses> GetCoursesByType(string input)
        {
            return Idb.GetCoursesByType(input);
        }

        //// GET: api/Courses
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Courses/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Courses
        [HttpPost]
        public bool Post(Courses course)
        {
            return Idb.SaveCourse(course);
        }

        //// PUT: api/Courses/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
