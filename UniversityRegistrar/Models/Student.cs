using System;
using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<CourseStudent>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }

        public DateTime EnrollmentDate {get; set;}
        public string Major { get; set;}
        public ICollection<CourseStudent> Courses { get;}
    }
}