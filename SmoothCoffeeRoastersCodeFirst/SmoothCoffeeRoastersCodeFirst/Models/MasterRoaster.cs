using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmoothCoffeeRoastersCodeFirst.Models
{
    public class MasterRoaster
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}