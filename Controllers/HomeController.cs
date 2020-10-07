using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using B13_MS_School.Models;
using B13_MS_School.Data;

namespace B13_MS_School.Controllers
{
    public class HomeController : Controller
    {
        private readonly Table _context;
        public HomeController(Table context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(List std)
        {
            var test = _context.Login;
            var model = new List<List>();
            var i = _context.Login.Where(x => x.Email == std.Email && x.Password == std.Password).FirstOrDefault();
            if (i == null)
            {
                ViewBag.Login = "Invalid Login.";
            }
            else
            {
                ViewBag.Login = "Login Successful.";

                var s = new List
                {
                    Email = i.Email,
                    Password = i.Password,
                    Actorid = i.Actorid
                };
                model.Add(s);
                if (s.Actorid == 1)
                { return View("Student", model); }

                else if (s.Actorid == 2)
                {
                    return View("Admin", model);
                }

                else if (s.Actorid == 3)
                {
                    return View("Teacher", model);
                }

                else if (s.Actorid == 4)
                {
                    return View("Accountant", model);
                }

                else if (s.Actorid == 5)
                {
                    return View("Registrar", model);
                }

            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult StuList()
        {
            var Test = _context.Students.FirstOrDefault();



            Students model = new Students
            {
                Id = Test.Id,
                Name = Test.Name

            };

            return View(model);
        }
        [Route("Admin")]
        public IActionResult Admin()
        {
            return View();
        }
        [Route("Registrar")]
        public IActionResult Registrar()
        {
            return View();
        }
        [Route("Accountatnt")]
        public IActionResult Accountant()
        {
            return View();
        }
        [Route("Student")]
        public IActionResult Student()
        {
            return View();
        }
        [Route("Teacher")]
        public IActionResult Teacher()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
