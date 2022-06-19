using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBL3_Tutor.Models;

namespace PBL3_Tutor.Areas.Admin.Controllers
{
    public class RegistrationsController : BaseController
    {
        private DBModelContext db = new DBModelContext();

        // GET: Admin/Registrations
        public ActionResult Index()
        {
            var registrations = db.Registrations.Include(r => r.Class).Include(r => r.Tutor);
            return View(registrations.ToList());
        }

        // GET: Admin/Registrations/Details/5
        public ActionResult Details(long classId, long tutorId)
        {
            Registration registration = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault();
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: Admin/Registrations/Create
        public ActionResult Create()
        {
            ViewBag.classId = new SelectList(db.Classes, "classId", "classId");
            ViewBag.tutorId = new SelectList(db.Tutors, "tutorId", "name");
            return View();
        }

        // POST: Admin/Registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tutorId,classId,state")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.classId = new SelectList(db.Classes, "classId", "classId", registration.classId);
            ViewBag.tutorId = new SelectList(db.Tutors, "tutorId", "name", registration.tutorId);
            return View(registration);
        }

        // GET: Admin/Registrations/Edit/5
        public ActionResult Edit(long classId, long tutorId)
        {
            Registration registration = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault();
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.classId = new SelectList(db.Classes, "classId", "classId", registration.classId);
            ViewBag.tutorId = new SelectList(db.Tutors, "tutorId", "name", registration.tutorId);
            return View(registration);
        }

        // POST: Admin/Registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tutorId,classId,state")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.classId = new SelectList(db.Classes, "classId", "classId", registration.classId);
            ViewBag.tutorId = new SelectList(db.Tutors, "tutorId", "name", registration.tutorId);
            return View(registration);
        }

        // GET: Admin/Registrations/Delete/5
        public ActionResult Delete(long classId, long tutorId)
        {
            Registration registration = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault();
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: Admin/Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long classId, long tutorId)
        {
            Registration registration = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault();
            db.Registrations.Remove(registration);
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
