using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApplication.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "This field is mandatory")]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "This field is mandatory")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is mandatory")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is mandatory")]
        public string PhoneNumber { get; set; }
        public string Designation { get; set; }
        public string Department { set; get; }
    }
}