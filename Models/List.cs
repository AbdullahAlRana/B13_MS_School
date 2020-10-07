using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace B13_MS_School.Models
{
    public class List
    {
        [Key]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "PassWord")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Actorid")]
        public Int64 Actorid { get; set; }
    }
}
