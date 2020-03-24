using System;
using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<CourseStudent>();
            // this.Departments = new HashSet<DepartmentStudent>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }

        public DateTime EnrollmentDate {get; set;}
        public DepartmentStudent Department { get; set;}
        
        public virtual ApplicationUser User { get; set; }
        public ICollection<CourseStudent> Courses { get;}
        // public ICollection<DepartmentStudent> Departments { get;}
    }
}