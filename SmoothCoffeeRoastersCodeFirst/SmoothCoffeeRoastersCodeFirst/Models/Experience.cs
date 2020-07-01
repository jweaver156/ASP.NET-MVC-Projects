using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmoothCoffeeRoastersCodeFirst.Models
{
    public class Experience
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExperienceID { get; set; }
        public string Job { get; set; }
        public int RoasterCredits { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
   }
}