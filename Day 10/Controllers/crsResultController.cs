using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day_10.Context;
using Day_10.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day_10.Controllers
{
    public class crsResultController : Controller
    {
        SchoolContext db = new SchoolContext();

        [HttpGet]
        public IActionResult New(crsResult? cr)
        {
            var crs = db.Courses.ToList();
            ViewBag.crs = crs;
            var stus = db.Students.ToList();
            ViewBag.stus = stus;
            return View(cr);

        }
        [HttpPost]
        public IActionResult SaveNew(crsResult cr)
        {
            if (ModelState.IsValid)
            {
                db.crsResults.Add(cr);
                db.SaveChanges();
                return RedirectToAction("GetAll","Student");
            }
            var crs = db.Courses.ToList();
            ViewBag.crs = crs;
            var stus = db.Students.ToList();
            ViewBag.stus = stus;
            return View("New", cr);


        }
    }
}

