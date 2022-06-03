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
    public class TutorsController : BaseController
    {
        private DBModelContext db = new DBModelContext();

        // GET: Admin/Tutors
        public ActionResult Index()
        {
            var tutors = db.Tutors.Include(t => t.Account);
            return View(tutors.ToList());
        }

        // GET: Admin/Tutors/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // GET: Admin/Tutors/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: Admin/Tutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tutorId,name,gender,address,phonenumber,email,yearOfBirth,education,university,experience,subject,grade,photo,avata,username,Account.password")] Tutor tutor, FormCollection feild)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.username = tutor.username;
                account.password = feild["password"];
                account.roleId = 3;
                if (db.Accounts.Find(tutor.username) == null)
                {
                    db.Accounts.Add(account);
                    db.Tutors.Add(tutor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "<div class='text-danger'>Tên tài khoản đã tồn tại</div>";
                    return View("Create");
                }
            }

            ViewBag.username = new SelectList(db.Accounts, "username", "password", tutor.username);
            return View(tutor);
        }

        // GET: Admin/Tutors/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // POST: Admin/Tutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tutorId,name,gender,address,phonenumber,email,yearOfBirth,education,university,experience,subject,grade,photo,avata,username")] Tutor tutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tutor);
        }

        // GET: Admin/Tutors/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutor tutor = db.Tutors.Find(id);
            if (tutor == null)
            {
                return HttpNotFound();
            }
            return View(tutor);
        }

        // POST: Admin/Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Tutor tutor = db.Tutors.Find(id);
            Account account = db.Accounts.Find(tutor.username);
            var listRegister = db.Registrations.Where(p => p.tutorId == id).ToList();
            foreach (var register in listRegister)
            {
                db.Registrations.Remove(register);
            }
            db.Accounts.Remove(account);
            db.Tutors.Remove(tutor);
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
