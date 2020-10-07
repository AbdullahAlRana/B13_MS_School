using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace B13_MS_School.ViewModels
{
    public class ViewStudent
    {
        [Key]
        [Display(Name = "ID")]
        public Int64 ID { get; set; }
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        public Int64 Due { get; set; }
        

    }
}
