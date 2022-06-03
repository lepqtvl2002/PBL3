using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBL3_Tutor.Models;

namespace PBL3_Tutor.Areas.Tutors.Controllers
{
    public class RegistrationsController : BaseController
    {
        private DBModelContext db = new DBModelContext();

        // GET: Tutors/Registrations
        public ActionResult Index()
        {
            long tutorId = Convert.ToInt64(Session["TutorId"].ToString());
            var registrations = db.Registrations.Include(r => r.Class).Include(r => r.Tutor).Where(p => p.tutorId == tutorId);
            return View(registrations.ToList());
        }

        // GET: Tutors/Registrations/Details/5
        public ActionResult Details(long? classId)
        {
            long tutorId = Convert.ToInt64(Session["TutorId"].ToString());
            var registration = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault();
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: Tutors/Registrations/Create
        public ActionResult Create(long classId)
        {
            Registration registration = new Registration();
            long tutorId = Convert.ToInt32(Session["TutorId"].ToString());
            var registed = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault();
            if (registed == null)
            {
                registration.classId = classId;
                registration.tutorId = tutorId;
                registration.state = "Chờ xét duyệt";
                db.Registrations.Add(registration);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Registrations");
        }

        // GET: Tutors/Registrations/Delete/5
        public ActionResult Delete(long? classId)
        {
            if (classId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            long tutorId = Convert.ToInt64(Session["TutorId"].ToString());
            Registration registration = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault();
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: Tutors/Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long classId)
        {
            long tutorId = Convert.ToInt64(Session["TutorId"].ToString());
            Registration registration = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault() ;
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
