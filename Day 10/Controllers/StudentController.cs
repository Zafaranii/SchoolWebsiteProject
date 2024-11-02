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
    public class StudentController : Controller
    {
        SchoolContext db = new SchoolContext();

        public IActionResult Delete(int id)
        {
            var st = db.Students.Find(id);
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("GetAll");


        }

        public IActionResult Edit(int id)
        {
            var st = db.Students.Include(x=>x.Department).FirstOrDefault(x => x.Id == id);
            var depts = db.Departments.ToList();
            ViewBag.depts = depts;
            return View(st);

        }
        [HttpPost]
        public IActionResult saveEdit(Student s)
        {
            if(ModelState.IsValid)
            {
                db.Students.Update(s);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var st = db.Students.Include(x => x.Department).FirstOrDefault(x => x.Id == s.Id);
            var depts = db.Departments.ToList();
            ViewBag.depts = depts;
            return View("Edit");
        }


        [HttpGet]
        public IActionResult New(Student? s)
        {
            var depts = db.Departments.ToList();
            ViewBag.depts = depts;
            return View(s);

        }
        [HttpPost]
        public IActionResult SaveNew(Student stu)
        {
            if(ModelState.IsValid)
            {
                db.Students.Add(stu);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            var depts = db.Departments.ToList();
            ViewBag.depts = depts;
            return View("New",stu);


        }


        [Route("/Student/GetAll")]
        public IActionResult GetAll()
        {
            var stus = db.Students.ToList();
            return View(stus);
        }

        public IActionResult Details(int id)
        {
            var emp = db.Students.Include(d => d.Department).FirstOrDefault(s => s.Id == id);
            return View(emp);
        }

        public IActionResult TestAge(int age)
        {
            if(age > 3 && age < 25)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}

