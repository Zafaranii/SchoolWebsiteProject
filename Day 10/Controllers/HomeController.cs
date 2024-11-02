using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day_10.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            DateTime now = DateTime.Now;
            Response.Cookies.Append("LastVisit", now.ToString(), new CookieOptions
            {
                Expires = now.AddHours(1)
            });

            return View();
        }
    }
}

