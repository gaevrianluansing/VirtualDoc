using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace activity4.Models
{
    public class Doctorsform
    {
        [Key]
        public int DoctorID { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage = "Doctor Type is required")]
        [Display(Name = "Doctor Type")]
        public DoctorType DoctorType { get; set; }

        [Required(ErrorMessage = "Schedule is required")]
        [Display(Name = "Schedule")]
        public string Schedule { get; set; }

        [Required(ErrorMessage = "MOP is required")]
        [Display(Name = "Mode Of Payment")]
        public string MOP { get; set; }

    }

    public enum DoctorType { 
        Alpha = 1,
        Bravo = 2
    }
}
