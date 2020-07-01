using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmoothCoffeeRoastersCodeFirst.DataAccessLayer;
using SmoothCoffeeRoastersCodeFirst.Models;

namespace SmoothCoffeeRoastersCodeFirst.Controllers
{
    public class MasterRoasterController : Controller
    {
        private CoffeeContext db = new CoffeeContext();

        // GET: MasterRoaster
        public ActionResult Index()
        {
            return View(db.MasterRoasters.ToList());
        }

        // GET: MasterRoaster/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterRoaster masterRoaster = db.MasterRoasters.Find(id);
            if (masterRoaster == null)
            {
                return HttpNotFound();
            }
            return View(masterRoaster);
        }

        // GET: MasterRoaster/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterRoaster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,EmploymentDate")] MasterRoaster masterRoaster)
        {
            if (ModelState.IsValid)
            {
                db.MasterRoasters.Add(masterRoaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterRoaster);
        }

        // GET: MasterRoaster/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterRoaster masterRoaster = db.MasterRoasters.Find(id);
            if (masterRoaster == null)
            {
                return HttpNotFound();
            }
            return View(masterRoaster);
        }

        // POST: MasterRoaster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,EmploymentDate")] MasterRoaster masterRoaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masterRoaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterRoaster);
        }

        // GET: MasterRoaster/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterRoaster masterRoaster = db.MasterRoasters.Find(id);
            if (masterRoaster == null)
            {
                return HttpNotFound();
            }
            return View(masterRoaster);
        }

        // POST: MasterRoaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MasterRoaster masterRoaster = db.MasterRoasters.Find(id);
            db.MasterRoasters.Remove(masterRoaster);
            db.SaveChanges();
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
    }
}
