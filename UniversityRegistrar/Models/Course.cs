using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Course
    {
        public Course()
        {
            this.Students = new HashSet<CourseStudent>();
            this.Departments = new HashSet<CourseDepartment>();
        }

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseNumber { get; set; }
        public virtual ICollection<CourseStudent> Students { get; set; }
        public virtual ICollection<CourseDepartment> Departments { get; set; }
    }
}