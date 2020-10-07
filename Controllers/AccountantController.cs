using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B13_MS_School.Data;
using B13_MS_School.Models;
using B13_MS_School.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace B13_MS_School.Controllers
{
    public class AccountantController : Controller
    {
        private readonly Table DB;
        public AccountantController(Table context)
        {
            DB = context;
        }
        public IActionResult StudentFee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentFee(Payment model)
        {

            Payment Pay = new Payment
            {
                ID = model.ID,
                SID = model.SID,
                ScID = model.ScID,
                Amount = model.Amount,
                PaymentDate = model.PaymentDate
            };

            DB.Payment.Add(Pay);
            DB.SaveChanges();
            ViewBag.Success = "Data has been saved to database.";

            return View(model);
        }

        public IActionResult AccountStatus()
        {
            var x = DB.Payment.ToList();
            var y = DB.Student.ToList();
            var z = DB.Schedule.ToList();
            var i = new List<ViewModels.ViewStudent>();

            var query = from p in x
                        join s in y on p.SID equals s.ID
                        join f in z on p.ScID equals f.ID
                        select new
                        {
                            StudentID = p.SID,
                            PayItem = f.Item,
                            PayFee = p.Amount
                        };

            Int64 netfee=0,count=0,t=0;
            var std = DB.Student.ToList();
            foreach (var item in std)
            {
                ViewModels.ViewStudent v = new ViewModels.ViewStudent();
                foreach (var st in query)
                {
                    if(item.ID == st.StudentID)
                    {
                        if(count==0)
                        {
                            netfee = st.PayFee;
                            t = st.StudentID;
                            count = 1;
                        }
                        else if(t == st.StudentID)
                        {
                            netfee = netfee + st.PayFee;
                        }
                    }
                }
                count = 0;
                v.FirstName = item.FirstName;
                v.LastName = item.LastName;
                v.ID = item.ID;
                DateTime now = DateTime.UtcNow;
                int months = 12 * (now.Year - item.AdmissionDate.Year) +now.Month - item.AdmissionDate.Month;
                v.Due = (2000 + (1000*months)) - netfee ;
                if(v.Due<0)
                {
                    v.Due = 0;
                }
                netfee = 0;
                i.Add(v);
            }
                      
            return View(i);

        }
    }
}
