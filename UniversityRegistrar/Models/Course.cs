using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Course
    {
        public Course()
        {
            this.Students = new HashSet<CourseStudent>();
        }

        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseNumber { get; set; }
        public virtual ICollection<CourseStudent> Students { get; set; }
    }
}