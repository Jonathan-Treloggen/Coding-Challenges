using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstCarInsurance.Models;

namespace CodeFirstCarInsurance.Controllers
{
    public class InsuranceQualificationsController : Controller
    {
        private CarInsuranceDBContext db = new CarInsuranceDBContext();

        // GET: InsuranceQualifications
        public ActionResult Index()
        {
            return View(db.InsuranceQualification.ToList());
        }

        // GET: InsuranceQualifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceQualification insuranceQualification = db.InsuranceQualification.Find(id);
            if (insuranceQualification == null)
            {
                return HttpNotFound();
            }
            return View(insuranceQualification);
        }

        // GET: InsuranceQualifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceQualifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Age,DUI,SpeedingTickets")] InsuranceQualification insuranceQualification)
        {
            if (ModelState.IsValid)
            {
                var qualification = 0;
                if (insuranceQualification.Age <= 15)
                {
                    qualification += 1;
                }

                if (insuranceQualification.DUI == true)
                {
                    qualification += 1;
                }

                if (insuranceQualification.SpeedingTickets > 3)
                {
                    qualification += 1;
                }

                if (qualification > 0)
                {
                    return View("NotQualified");
                }

                db.InsuranceQualification.Add(insuranceQualification);
                db.SaveChanges();
                return RedirectToAction("Qualified");
            }

            return View(insuranceQualification);
        }

        // GET: InsuranceQualifications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceQualification insuranceQualification = db.InsuranceQualification.Find(id);
            if (insuranceQualification == null)
            {
                return HttpNotFound();
            }
            return View(insuranceQualification);
        }

        // POST: InsuranceQualifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Age,DUI,SpeedingTickets")] InsuranceQualification insuranceQualification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuranceQualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuranceQualification);
        }

        // GET: InsuranceQualifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InsuranceQualification insuranceQualification = db.InsuranceQualification.Find(id);
            if (insuranceQualification == null)
            {
                return HttpNotFound();
            }
            return View(insuranceQualification);
        }

        // POST: InsuranceQualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InsuranceQualification insuranceQualification = db.InsuranceQualification.Find(id);
            db.InsuranceQualification.Remove(insuranceQualification);
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

        public ActionResult Qualified()
        {
            return View();
        }

        public ActionResult NotQualified()
        {
            return View();
        }
    }
}
