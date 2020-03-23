using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversityRegistrar.Controllers
{
  public class CoursesController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public CoursesController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Courses.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentTitle");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course, int DepartmentId)
    {
      _db.Courses.Add(course);
      _db.CourseDepartment.Add(new CourseDepartment() { DepartmentId = DepartmentId, CourseId = course.CourseId });
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
    ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentTitle");
      var thisCourse = _db.Courses
          .Include(course => course.Students)
          .ThenInclude(join => join.Student)
          .Include(course => course.Departments)
          .ThenInclude(join => join.Department)   
          .FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    public ActionResult Edit(int id)
    {
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentTitle");
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost]
    public ActionResult Edit(Course course)
    {
      _db.Entry(course).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      _db.Courses.Remove(thisCourse);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}