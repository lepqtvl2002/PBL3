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
    public class StudentsController : BaseController
    {
        private DBModelContext db = new DBModelContext();

        // GET: Admin/Students
        public ActionResult Index()
        {
            return View(db.Students.OrderByDescending(p => p.studentId).ToList());
        }

        // GET: Admin/Students/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Admin/Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "studentId,name,gender,address,subject,phonenumber,grade,academicAbility,school,requirement,note,freeTime,paymentAmount,isConfirm")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Admin/Students/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Admin/Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentId,name,gender,address,subject,phonenumber,grade,academicAbility,school,requirement,note,freeTime,paymentAmount,isConfirm")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Admin/Students/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Admin/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
        public ActionResult Unconfirmed()
        {
            return View(db.Students.Where(p => p.isConfirm != true).OrderByDescending(p => p.studentId).ToList());
        }
        public ActionResult CreateClass(long id)
        {
            ViewBag.Error = "";
            Class classes = new Class();
            classes.studentId = id;
            SelectList listStudent = new SelectList(db.Students, "studentId", "name", "studentId", id);
            ViewBag.studentId = listStudent;
            Student student = db.Students.Find(id);
            if (student.gender == null || student.address == null || student.subject == null
                || student.phonenumber == null || student.grade == null || student.requirement == null
                || student.paymentAmount == null)
            {
                ViewBag.Error = "Chưa đủ thông tin để yêu cầu để tạo lớp.";
            }
            return View(classes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClass(Class model)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(model);
                Student student = db.Students.Find(model.studentId);
                student.isConfirm = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
