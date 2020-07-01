using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SmoothCoffeeRoastersCodeFirst.Models;

namespace SmoothCoffeeRoastersCodeFirst.DataAccessLayer
{
    public class CoffeeInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<CoffeeContext>
    {
        protected override void Seed(CoffeeContext context)
        {
            var masterRoasters = new List<MasterRoaster>
            {
                new MasterRoaster{FirstName="Garrett",LastName="Perkins",EmploymentDate=DateTime.Parse("1994-04-01")},
                new MasterRoaster{FirstName="Miles",LastName="Ferguson",EmploymentDate=DateTime.Parse("1994-04-01")},
                new MasterRoaster{FirstName="Vanessa",LastName="Timmons",EmploymentDate=DateTime.Parse("1998-02-21")},
                new MasterRoaster{FirstName="Violet",LastName="Summers",EmploymentDate=DateTime.Parse("1998-03-10")},
                new MasterRoaster{FirstName="Gil",LastName="Simon",EmploymentDate=DateTime.Parse("1999-05-15")},
                new MasterRoaster{FirstName="Megan",LastName="Floyd",EmploymentDate=DateTime.Parse("2000-12-30")},
                new MasterRoaster{FirstName="Steven",LastName="Fields",EmploymentDate=DateTime.Parse("2014-03-09")},
                new MasterRoaster{FirstName="Gilroy",LastName="McCabe",EmploymentDate=DateTime.Parse("2014-03-12")},
            };

            masterRoasters.ForEach(s => context.MasterRoasters.Add(s));
            context.SaveChanges();

            var experiences = new List<Experience>
            {
                new Experience{ExperienceID=101,Job="Cashier",RoasterCredits=1},
                new Experience{ExperienceID=201,Job="Floor Lead",RoasterCredits=3},
                new Experience{ExperienceID=401,Job="Store Manager",RoasterCredits=8},
                new Experience{ExperienceID=501,Job="Regional Manger",RoasterCredits=20},
                new Experience{ExperienceID=701,Job="Coffee Bean Roaster",RoasterCredits=40}
            };
            experiences.ForEach(s => context.Experiences.Add(s));
            context.SaveChanges();

            var employees = new List<Employee>
            {
                new Employee{MasterRoasterID=1001,ExperienceID=101,RoasterRating=RoasterRating.A},
                new Employee{MasterRoasterID=2001,ExperienceID=201,RoasterRating=RoasterRating.A},
                new Employee{MasterRoasterID=4001,ExperienceID=401,RoasterRating=RoasterRating.AA},
                new Employee{MasterRoasterID=5001,ExperienceID=501,RoasterRating=RoasterRating.AA},
                new Employee{MasterRoasterID=7001,ExperienceID=701,RoasterRating=RoasterRating.AAA}
            };
            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();
        }

    }
}