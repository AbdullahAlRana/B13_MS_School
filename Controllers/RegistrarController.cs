using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B13_MS_School.Data;
using B13_MS_School.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B13_MS_School.Controllers
{
    public class RegistrarController : Controller
    {
        private readonly Table _context;
        public RegistrarController(Table context)
        {
            _context = context;
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student model)
        {
            Student student = new Student
            {
                ID = model.ID,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PresentAddress = model.PresentAddress,
                PreAddress = model.PreAddress,
                AdmissionDate = model.AdmissionDate
            };

            _context.Student.Add(student);
            _context.SaveChanges();
            ViewBag.Success = "Data has been saved to database.";

            return View(model);
        }

        public IActionResult StudentList()
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
                    PresentAddress = item.PresentAddress,
                    AdmissionDate = item.AdmissionDate
                };
                j.Add(stu);
            }
            return View(j);
        }

        public IActionResult Details(Int64 id)
        {
            var D = _context.Student.FirstOrDefault(m => m.ID == id);
            return View(D);
        }

        public IActionResult Edit(Int64 id)
        {
            var x =_context.Student.Find(id);
            return View(x);
        }

        [HttpPost]
        public IActionResult Edit(Int64 id, Student stu)
        {
            _context.Student.Update(stu);
            _context.SaveChanges();
            return RedirectToAction(nameof(StudentList));
        }

        public IActionResult Delete(Int64 id)
        {
            var x = _context.Student.FirstOrDefault(m => m.ID == id);
            return View(x);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Int64 id)
        {
            var x = _context.Student.Find(id);
            _context.Student.Remove(x);
            _context.SaveChanges();
            return RedirectToAction(nameof(StudentList));
        }
    }
}
