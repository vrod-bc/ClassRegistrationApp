using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1.Models
{
    public class User
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public List<Courses> CoursesList { get; set; }
      
    }
}