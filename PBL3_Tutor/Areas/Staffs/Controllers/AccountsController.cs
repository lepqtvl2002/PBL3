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
    public class AccountsController : BaseController
    {
        private DBModelContext db = new DBModelContext();

        // GET: Staffs/Accounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.Role).Where(p => p.Role.rolename == "Gia sư");
            return View(accounts.ToList());
        }

        // GET: Staffs/Accounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account.Role.rolename == "Gia sư")
            {
                if (account == null)
                {
                    return View("Error_404");
                }
                return View(account);
            }
            return View("Error_404");
        }

        // GET: Staffs/Accounts/Create
        public ActionResult Create()
        {
            ViewBag.roleId = new SelectList(db.Roles, "roleId", "rolename");
            return View();
        }

        // POST: Staffs/Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,password,roleId")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.roleId = new SelectList(db.Roles, "roleId", "rolename", account.roleId);
            return View(account);
        }

        // GET: Staffs/Accounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account.Role.rolename == "Gia sư")
            {
                if (account == null)
                {
                    return View("Error_404", "Dashboard");
                }
                ViewBag.roleId = new SelectList(db.Roles, "roleId", "rolename");
                return View(account);
            }
            return View("Error_404", "Dashboard");
        }

        // POST: Staffs/Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,password,roleId")] Account account)
        {
            if (ModelState.IsValid)
            {
                account.roleId = 3;
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.roleId = new SelectList(db.Roles, "roleId", "rolename", account.roleId);
            return View(account);
        }

        // GET: Staffs/Accounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account.Role.rolename == "Gia sư")
            {
                if (account == null)
                {
                    return View("Error_404", "Dashboard");
                }
                return View(account);
            }
            return View("Error_404", "Dashboard");
        }

        // POST: Staffs/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Account account = db.Accounts.Find(id);
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
