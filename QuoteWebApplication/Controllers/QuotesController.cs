using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuoteWebApplication;

namespace QuoteWebApplication.Controllers
{
    public class QuotesController : Controller
    {
        private QuoteDbEntities db = new QuoteDbEntities();

        public async Task<ActionResult> Index()
        {
            return View(await db.Quotes.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = await db.Quotes.FindAsync(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Email,DateOfBirth,CarYear,CarMake,CarModel,HasDUI,NoOfSpeedingTicket,CoverageOrLiability,CreatedAt")] Quote quote)
        {
            try
            {
                quote.CreatedAt = DateTime.UtcNow;
                if (ModelState.IsValid)
                {

                    var total = CalculateTotal(quote);
                    quote.TotalCost = total;
                    db.Quotes.Add(quote);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(quote);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = await db.Quotes.FindAsync(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Email,DateOfBirth,CarYear,CarMake,CarModel,HasDUI,NoOfSpeedingTicket,CoverageOrLiability,CreatedAt")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(quote);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = await db.Quotes.FindAsync(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Quote quote = await db.Quotes.FindAsync(id);
            db.Quotes.Remove(quote);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public double CalculateTotal(Quote quote)
        {

            // Calculate the total, starting at a minimum of 50
            double total = 50;

            // First, compute the age (in years):
            // subtract the current year (2020) from the person's date of birth (year begins at index 6)
            int age = 2020 - quote.DateOfBirth.Year;
            Console.WriteLine("Age: " + age);

            // If the user's age is under 18, add 100 to the total 
            if (age < 18)
                total += 100;

            // If the user's age is under 25 (but now at least 18 years)
            // also applies if the user's age is over 100
            else if (age < 25 || age > 100)
                total += 25;


            // Second, deal with the car's year

            // If the car year is before 2000 or after 2015, add 25 to the total
            Console.WriteLine("Car year: " + quote.CarYear);
            if (quote.CarYear < 2000 || quote.CarYear > 2015)
                total += 25;

            // Because the app hates Porsches and 911 Carrera, we'll deal with these sequentially
            Console.WriteLine("Car make: " + quote.CarMake + "\nCar model: " + quote.CarModel);
            if (quote.CarMake.ToLower() == "porsche")
            {

                // If the car make is a porsche, add 25
                total += 25;

                // Additionally, if the car model is a 911 Carrera, add another 25 to the total
                if (quote.CarModel.ToLower() == "911 carrera")
                    total += 25;
            }

            // Add 10 x # of speeding tickets to the total 
            Console.WriteLine("# of speeding tickets: " + quote.NoOfSpeedingTicket);
            total += 10 * quote.NoOfSpeedingTicket;

            // If the user has a DUI, add 25%
            Console.WriteLine("Does this person have DUI: " + quote.HasDUI);
            if (quote.HasDUI)
                total += (total * 0.25);

            // If the user has full coverage, add 50%
            // Console.WriteLine("Type of coverage: " + CL);
            // if (CL == 'c')
            //     total += (total * 0.5);

            // Finished, return the total
            return total;
        }
    }

    public enum CoverageList
    {
        Coverage,
        Liability,
    }
}
