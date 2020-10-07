using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace B13_MS_School.Models
{
    public class Schedule
    {
        [Required]
        [Key]
        [Display(Name = "ID")]
        public Int64 ID { get; set; }
        [Required]
        [Display(Name = "Item")]
        public String Item { get; set; }
        [Required]
        [Display(Name = "Fee")]
        public Int64 Fee { get; set; }
    }
}
