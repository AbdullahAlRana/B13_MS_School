using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B13_MS_School.Data;
using B13_MS_School.Models;
using Microsoft.AspNetCore.Mvc;

namespace B13_MS_School.Controllers
{
    public class TeacherController : Controller
    {
        private readonly Table _context;
        public TeacherController(Table context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students()
        {
            var j = new List<Student>();
            var i = _context.Student.ToList();
            foreach (var item in i)
            {
                Student stu = new Student
                {
                    ID = item.ID,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    PreAddress = item.PreAddress,
                    PresentAddress = item.PresentAddress
                };
                j.Add(item);
            }
            return View(j);
        }
    }
}
