using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace activity4.Models
{
    public class DoctorViewModel
    {
        public List<Doctorsform> DoctorsList { get; set; }

        public int DoctorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public DoctorType DoctorType { get; set; }

        public string ContactNo { get; set; }

        [DataType(DataType.MultilineText)]
        public string Schedule { get; set; }

        public string MOP { get; set; }
    }
}
