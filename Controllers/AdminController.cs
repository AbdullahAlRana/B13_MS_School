using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B13_MS_School.Data;
using B13_MS_School.Models;
using Microsoft.AspNetCore.Mvc;

namespace B13_MS_School.Controllers
{
    public class AdminController : Controller
    {
        private readonly Table _context;
        public AdminController(Table context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Models.List model)
        {
            Models.List role = new Models.List
            {
                Email = model.Email,
                Password = model.Password,
                Actorid = model.Actorid
            };

            _context.Login.Add(role);
            _context.SaveChanges();
            ViewBag.Success = "Data has been saved to database.";

            return View(model);
        }

        public IActionResult ViewRole()
        {
            var j = new List<List>();
            var i = _context.Login.ToList();
            foreach (var item in i)
            {
                Models.List stu = new Models.List
                {
                    Email = item.Email,
                    Password = item.Password
                };
                j.Add(item);
            }
            return View(j);
        }

        public IActionResult Details(string email)
        {
            var D = _context.Login.FirstOrDefault(m => m.Email == email);
            return View(D);
        }

        public IActionResult Edit(string email)
        {
            var x = _context.Login.Find(email);
            return View(x);
        }

        [HttpPost]
        public IActionResult Edit(string id, List stu)
        {
            _context.Login.Update(stu);
            _context.SaveChanges();
            return RedirectToAction(nameof(ViewRole));
        }

        public IActionResult Delete(string email)
        {
            var x = _context.Login.FirstOrDefault(m => m.Email == email);
            return View(x);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string email)
        {
            var x = _context.Login.Find(email);
            _context.Login.Remove(x);
            _context.SaveChanges();
            return RedirectToAction(nameof(ViewRole));
        }
    }
}
