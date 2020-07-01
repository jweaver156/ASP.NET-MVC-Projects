using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmoothCoffeeRoastersCodeFirst.Models
{
    public enum RoasterRating
    {
        A, AA, AAA
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public int ExperienceID { get; set; }
        public int MasterRoasterID { get; set; }
        public RoasterRating? RoasterRating { get; set; }

        public virtual Experience Experience { get; set; }
        public virtual MasterRoaster MasterRoaster { get; set; }
    }
}