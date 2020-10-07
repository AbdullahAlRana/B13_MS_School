using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace B13_MS_School.Models
{
    public class Student
    {
        [Required]
        [Key]
        [Display(Name = "ID")]
        public Int64 ID { get; set; }
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "PresentAddress")]
        public string PresentAddress { get; set; }
        [Required]
        [Display(Name = "PreAddress")]
        public string PreAddress { get; set; }
        [Required]
        [Display(Name = "AdmissionDate")]
        public DateTime AdmissionDate { get; set; }
    }
}
