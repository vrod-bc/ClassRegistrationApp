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
    public class DepartmentController : ControllerBase
    {
        public IDbService Idb; 
        public DepartmentController(IDbService d)
        {
            Idb = d;
        }
     
        [HttpGet]
        public List<Departments> GetDepartments()
        { 
            return Idb.GetDepartments();
        }

        [HttpGet("{id}", Name = "GetDepartment")]
        public Departments GetDepartmentByID(int id)
        {
            return Idb.GetDeparmentById(id);
        }

        [HttpGet("SendEmail/{id}")]
        public string SendEmail(int id)
        {
            return "This is the list of students in Department " + Idb.GetDeparmentById(id).DepartmentName + " : " + Idb.CoursesTaken(id);
        }

        //// GET: api/Department
        //
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Department/5
        //
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST: api/Department
        [HttpPost]
        public bool SaveDepartment(Departments dept)
        {
            return Idb.SaveDepartment(dept);
        }

        //// PUT: api/Department/5
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
