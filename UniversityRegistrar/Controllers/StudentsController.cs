using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace UniversityRegistrar.Controllers
{
  [Authorize]
  public class StudentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public StudentsController(UserManager<ApplicationUser> userManager, UniversityRegistrarContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userStudents = _db.Students.Where(entry => entry.User.Id == currentUser.Id);
      return View(userStudents);
    }

    public ActionResult Create()
    {
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseTitle");
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentTitle");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Student student, int CourseId, int DepartmentId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      student.User = currentUser;
      _db.Students.Add(student);
      if (CourseId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId });
        _db.DepartmentStudent.Add(new DepartmentStudent() { DepartmentId = DepartmentId, StudentId = student.StudentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisStudent = _db.Students
          .Include(student => student.Courses)
          .ThenInclude(join => join.Course)
          .Include(student => student.Department)
          .ThenInclude(join => join.Department)
          .FirstOrDefault(student => student.StudentId == id);
      return View(thisStudent);
    }

    public ActionResult Edit(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseTitle");
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentTitle");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult Edit(Student student, int departmentId)
    {
      var departmentStudentEntry = _db.DepartmentStudent.FirstOrDefault(x => x.StudentId == student.StudentId);
      departmentStudentEntry.DepartmentId = departmentId;
      _db.Entry(student).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCourse(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseTitle");
      return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddCourse(Student student, int CourseId)
    {
      if (CourseId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      _db.Students.Remove(thisStudent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteCourse(int joinId)
    {
      var joinEntry = _db.CourseStudent.FirstOrDefault(entry => entry.CourseStudentId == joinId);
      _db.CourseStudent.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = joinEntry.StudentId});
    }

    [HttpPost]
    public ActionResult CourseCompleted(int joinId)
    {
      var joinEntry = _db.CourseStudent.FirstOrDefault(entry => entry.CourseStudentId == joinId);
      if(joinEntry.IsCompleted == false)
      {
        joinEntry.IsCompleted = true;
      }
      else
      {
        joinEntry.IsCompleted = false;
      }
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = joinEntry.StudentId});
    }
  }
}