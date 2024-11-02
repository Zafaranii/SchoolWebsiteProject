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
    public class DepartmentController : Controller
    {
        SchoolContext db = new SchoolContext();

        public IActionResult Delete(int id)
        {
            var d = db.Departments.Find(id);
            db.Departments.Remove(d);
            db.SaveChanges();
            return RedirectToAction("GetAll");


        }

        public IActionResult Edit()
        {
            return View();

        }
        [HttpPost]
        public IActionResult saveEdit(Department s)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Update(s);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }
            return View("Edit");
        }


        [HttpGet]
        public IActionResult New(Department? s)
        {
            return View(s);

        }
        [HttpPost]
        public IActionResult SaveNew(Department d)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(d);
                db.SaveChanges();
                return RedirectToAction("GetAll");
            }

            return View("New", d);


        }


        [Route("/Department/GetAll")]
        public IActionResult GetAll()
        {
            var d = db.Departments.ToList();
            return View(d);
        }

        public IActionResult Details(int id)
        {
            var d = db.Departments.FirstOrDefault(s => s.Id == id);
            return View(d);
        }
    }
}

