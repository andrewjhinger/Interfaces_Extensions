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
    public class StudentsController : Controller
    {
        private IStudentsRepository studRepo;

        public StudentsController()
        {
            this.studRepo = new StudentsRepository(new InterfacesContext());
        }

        public StudentsController(IStudentsRepository studRepo)
        {
            this.studRepo = studRepo;
        }

        public ActionResult Filters(string filterParams = "")
        {
            return View(studRepo.Filter(filterParams));
        }

        public ActionResult OrderByName(char letter)
        {
            ViewBag.letter = letter;
            return View(studRepo.OrderByName(letter));
        }

        //
        // GET: /Students/

        public ActionResult Index()
        {
            return View(studRepo.getStudents());
        }

        protected override void Dispose(bool disposing)
        {
            studRepo.Dispose();
            base.Dispose(disposing);
        }
    }
}