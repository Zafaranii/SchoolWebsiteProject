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
    public class CourseController : Controller
    {
        SchoolContext db = new SchoolContext();

        public IActionResult Delete(int id)
        {
            var c = db.Courses.Find(id);
            db.Courses.Remove(c);
            db.SaveChanges();
            return RedirectToAction("GetAll");


        }

        public IActionResult Edit(int id)
        {
            var st = db.Courses.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            var depts = db.Departments.ToList();
            ViewBag.depts = depts;
            return View(st);

        }
        [HttpPost]
        public IActionResult saveEdit(Course c)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Update(c);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var st = db.Courses.Include(x => x.Department).FirstOrDefault(x => x.Id == c.Id);
            var depts = db.Departments.ToList();
            ViewBag.depts = depts;
            return View("Edit");
        }


        [HttpGet]
        public IActionResult New(Course? s)
        {
            var depts = db.Departments.ToList();
            ViewBag.depts = depts;
            return View(s);

        }
        [HttpPost]
        public IActionResult SaveNew(Course stu)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(stu);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var depts = db.Departments.ToList();
            ViewBag.depts = depts;
            return View("New", stu);


        }


        [Route("/Course/GetAll")]
        public IActionResult GetAll()
        {
            var stus = db.Courses.ToList();
            return View(stus);
        }

        public IActionResult Details(int id)
        {
            var emp = db.Courses.Include(d => d.Department).FirstOrDefault(s => s.Id == id);
            return View(emp);
        }
    }
}

