using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day_10.Context;
using Day_10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day_10.Controllers
{
    public class InstructorController : Controller
    {
        // GET: /<controller>/
        SchoolContext db = new SchoolContext();

        public IActionResult Delete(int id)
        {
            var i = db.Instructors.Find(id);
            db.Instructors.Remove(i);
            db.SaveChanges();
            return RedirectToAction("GetAll");


        }

        public IActionResult Edit(int id)
        {
            var st = db.Instructors.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            var depts = db.Departments.ToList();
            ViewBag.depts = depts;
            return View(st);

        }
        [HttpPost]
        public IActionResult saveEdit(Instructor i)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Update(i);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View("Edit");
        }


        [HttpGet]
        public IActionResult New(Instructor? s)
        {
            var depts = db.Departments.ToList();
            ViewBag.depts = depts;

            return View(s);

        }
        [HttpPost]
        public IActionResult SaveNew(Instructor i)
        {
            if (ModelState.IsValid)
            {
                db.Instructors.Add(i);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View("New", i);


        }


        public IActionResult GetAll()
        {
            var instructors = db.Instructors.ToList();
            if (instructors != null) 
                return View(instructors);
            return View("Error");
        }

        public IActionResult Details(int id)
        {
            return View(db.Instructors.Find(id));
            
        }
    }
}

