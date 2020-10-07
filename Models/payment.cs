using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace B13_MS_School.Models
{
    public class Payment
    {
        [Required]
        [Key]
        [Display(Name = "ID")]
        public Int64 ID { get; set; }
        [Required]
        [Display(Name = "Student ID")]
        public Int64 SID { get; set; }
        [Required]
        [Display(Name = "Schedule ID")]
        public Int64 ScID { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public Int64 Amount { get; set; }
        [Required]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }


    }
}
