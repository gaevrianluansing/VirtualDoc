using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace activity4.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required.")]
        public int Age { get; set; }

        [Display(Name = "Gender")]
        public GenderType Type { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "E-mail Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Display(Name = "Birthday")]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }

    public enum GenderType
    {
        Male = 1,
        Female = 2,
        Unknown = 3
    }
}
