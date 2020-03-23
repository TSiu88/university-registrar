using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Department
    {
        public Department()
        {
            this.Students = new HashSet<DepartmentStudent>();
            this.Courses = new HashSet<CourseDepartment>();
        }

        public int DepartmentID { get; set; }
        public string DepartmentTitle { get; set; }
        public virtual ICollection<DepartmentStudent> Students { get; set; }
        public virtual ICollection<CourseDepartment> Courses { get; set; }
    }
}