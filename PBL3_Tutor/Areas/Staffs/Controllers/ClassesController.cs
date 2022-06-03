using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBL3_Tutor.Models;

namespace PBL3_Tutor.Areas.Staffs.Controllers
{
    public class ClassesController : BaseController
    {
        private DBModelContext db = new DBModelContext();

        // GET: Admin/Classes
        public ActionResult Index()
        {
            var classes = db.Classes.Include(p => p.Student).OrderByDescending(p => p.classId);
            return View(classes.ToList());
        }

        // GET: Admin/Classes/Empty
        public ActionResult Empty()
        {
            var classes = db.Classes.Include(p => p.Student).Where(p => p.state != true).OrderByDescending(p => p.classId);
            return View(classes.ToList());
        }
        // GET: Admin/Classes/Register/id
        public ActionResult Register(int id)
        {
            var classes = db.Registrations.Include(p => p.Class).Where(p => p.classId == id);
            return View(classes.ToList());
        }

        // GET: Admin/Classes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // GET: Admin/Classes/Create
        public ActionResult Create()
        {
            ViewBag.studentId = new SelectList(db.Students, "studentId", "name", "studentId", 1);
            return View();
        }

        // POST: Admin/Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "classId,studentId,fee,state")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.studentId = new SelectList(db.Students, "studentId", "name", @class.studentId);
            return View(@class);
        }

        // GET: Admin/Classes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            ViewBag.studentId = new SelectList(db.Students, "studentId", "name", "studentId", @class.studentId);
            return View(@class);
        }

        // POST: Admin/Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "classId,studentId,fee,state")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.studentId = new SelectList(db.Students, "studentId", "name", @class.studentId);
            return View(@class);
        }

        // GET: Admin/Classes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST: Admin/Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Class classs = db.Classes.Find(id);
            var listRegister = db.Registrations.Where(p => p.classId == id).ToList();
            foreach (var register in listRegister)
            {
                db.Registrations.Remove(register);
            }
            db.Classes.Remove(classs);
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
        public ActionResult Refuse(int classId, int tutorId)
        {
            var register = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault();
            register.state = "Bị từ chối";
            db.SaveChanges();
            return RedirectToAction("Register", new { id = classId });
        }

        public ActionResult Acept(int classId, int tutorId)
        {
            var register = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault();
            register.state = "Được chấp nhận";
            var listRegister = db.Registrations.Where(p => p.classId == classId && p.tutorId != tutorId).ToList();
            foreach (var item in listRegister)
            {
                item.state = "Bị từ chối";
            }
            var classs = db.Classes.Find(classId);
            classs.state = true;
            db.SaveChanges();
            return RedirectToAction("Register", new { id = classId });
        }
    }
}
