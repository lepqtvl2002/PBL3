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
    public class StaffsController : BaseController
    {
        private DBModelContext db = new DBModelContext();

        // GET: Admin/Staffs
        public ActionResult Index()
        {
            var staffs = db.Staffs.Include(s => s.Account);
            return View(staffs.ToList());
        }

        // GET: Admin/Staffs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Admin/Staffs/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: Admin/Staffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "staffId,name,gender,username,email,phonenumber,address")] Staff staff, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.username = staff.username;
                account.password = collection["password"];
                account.roleId = 2;
                if (db.Accounts.Find(staff.username) == null)
                {
                    db.Accounts.Add(account);
                    db.Staffs.Add(staff);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "<div class='text-danger'>Tên tài khoản đã tồn tại</div>";
                    return View(staff);
                }
            }

            return View(staff);
        }

        // GET: Admin/Staffs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Admin/Staffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "staffId,name,gender,username,email,phonenumber,address")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        // GET: Admin/Staffs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Admin/Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Staff staff = db.Staffs.Find(id);
            Account account = db.Accounts.Find(staff.username);
            db.Staffs.Remove(staff);
            db.Accounts.Remove(account);
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
