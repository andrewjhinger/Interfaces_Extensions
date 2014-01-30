using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Interfaces_Extensions.Models;
using Interfaces_Extensions.IE_Context;
using Interfaces_Extensions.Repositories;
using Interfaces_Extensions.Interfaces;

namespace Interfaces_Extensions.Controllers
{
    public class CoursesController : Controller
    {
        private ICourseRepository courseRepo;

        public CoursesController()
        {
            this.courseRepo = new CoursesRepository(new InterfacesContext());
        }

        public CoursesController(ICourseRepository courseRepo)
        {
            this.courseRepo = courseRepo;
        }

        //
        // GET: /Courses/

        public ActionResult Index()
        {
            var courses = courseRepo.GetAllCourses();
            return View(courses);
        }

        //
        // GET: /Courses/Details/5

        public ActionResult Details(int id = 0)
        {
            Courses courses = courseRepo.GetByCourseNumber(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        //
        // GET: /Courses/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Courses/Create

        [HttpPost]
        public ActionResult Create(Courses courses)
        {
            if (ModelState.IsValid)
            {
                courseRepo.AddCourse(courses);
                courseRepo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courses);
        }

        //
        // GET: /Courses/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Courses courses = courseRepo.GetByCourseNumber(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        //
        // POST: /Courses/Edit/5

        [HttpPost]
        public ActionResult Edit(Courses courses)
        {
            if (ModelState.IsValid)
            {
                courseRepo.EditCourse(courses);
                courseRepo.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courses);
        }

        //
        // GET: /Courses/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Courses courses = courseRepo.GetByCourseNumber(id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            return View(courses);
        }

        //
        // POST: /Courses/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            courseRepo.DeleteCourse(id);
            courseRepo.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            courseRepo.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult GetRange(string val_1 = "", string val_2 = "")
        {
            int val_a, val_b;
            bool tryParse = int.TryParse(val_1, out val_a);
            if (tryParse && val_a > 99 && val_a < 1000)
            {
                tryParse = int.TryParse(val_2, out val_b);
                if (tryParse && val_b > 99 && val_b < 1000)
                {
                    if (val_a > val_b)
                    {
                        int temp = val_a;
                        val_a = val_b;
                        val_b = temp;
                    }
                    var CourseRange = courseRepo.GetCourseRange(val_a, val_b).ToList();
                    return View("Index", CourseRange);
                }
                else
                {
                    ViewBag.Error = "Second input value is invalid. Must be an integer: " + val_2;
                    return View("Index", courseRepo.GetAllCourses());
                }
            }
            else
            {
                ViewBag.Error = "First input value is invalid. Must be a valid integer: " + val_1;
                return View("Index", courseRepo.GetAllCourses());
            }
        }

        public ActionResult QueryCourses(string queryString = "")
        {
            if (!String.IsNullOrEmpty(queryString))
            {
                var courseSearch = courseRepo.SearchCourses(x => x.CourseName.ToUpper() == queryString.ToUpper());
                return View("Index", courseSearch);
            }
            else
            {
                var courses = courseRepo.GetAllCourses();
                return View("Index", courses);
            }
        }

        public ActionResult LooseQuery(string queryString = "")
        {
            if (!String.IsNullOrEmpty(queryString))
            {
                var courseSearch = courseRepo.CheckIfCourseExists(x => x.CourseName.ToUpper() == queryString.ToUpper(), queryString);
                return View("Index", courseSearch);
            }
            else
            {
                var courses = courseRepo.GetAllCourses();
                return View("Index", courses);
            }
        }
    }
}