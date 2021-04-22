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
        [Required(ErrorMessage = "Doctor's name is required")]
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }
        [Required(ErrorMessage = "Doctor Type is required")]
        [Display(Name = "Doctor Type")]
        public string DoctorType { get; set; }
        [Required(ErrorMessage = "Contact Number is required")]
        [Display(Name = "Contact Number")]
        public string ContactNum { get; set; }
        [Required(ErrorMessage = "Schedule is required")]
        [Display(Name = "Schedule")]
        public string Schedule { get; set; }
        [Required(ErrorMessage = "MOP is required")]
        [Display(Name = "Mode Of Payment")]
        public string MOP { get; set; }

    }
}
