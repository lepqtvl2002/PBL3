using PBL3_Tutor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Tutors.Controllers
{
    public class TutorAccountController : BaseController
    {
        DBModelContext db = new DBModelContext();
        // GET: Tutors/TutorAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tutors/TutorAccount/Details/5
        public ActionResult Details(int id)
        {
            var information = db.Tutors.Find(id);
            return View(information);
        }

        // GET: Tutors/TutorAccount/Create
        /*public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: Tutors/TutorAccount/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "tutorId,name,gender,address,phonenumber,email,yearOfBirth,education,university,experience,subject,grade,photo,avata,username,Account.password")] Tutor tutor, FormCollection feild)
        {
            // TODO: Add insert logic here
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
                    Session["TutorUsername"] = tutor.username;
                    Session["TutorId"] = tutor.tutorId.ToString();
                    Session["TutorName"] = tutor.name;
                    Session["TutorEmail"] = tutor.email;
                    Session["TutorPassword"] = tutor.Account.password;
                    Session["TutorPhone"] = tutor.phonenumber;
                    return RedirectToAction("Index","Document");
                }
                else
                {
                    ViewBag.Error = "<div class='text-danger'>Tên tài khoản đã tồn tại</div>";
                    return View(tutor);
                }
            }

            return View(tutor);
        }*/

        // GET: Tutors/TutorAccount/Edit/5
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

        // POST: Tutors/TutorAccount/Edit/5
        [HttpPost]
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

        // GET: Tutors/TutorAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tutors/TutorAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: New Password
        public ActionResult ChangeThePassword()
        {
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        public ActionResult ChangeThePassword(FormCollection collection)
        {
            int id = Convert.ToInt32(Session["TutorId"].ToString());
            try
            {
                var tutor = db.Tutors.Find(id);
                if (collection["OldPassword"] == tutor.Account.password)
                {
                    if (collection["NewPassword"] != collection["OldPassword"])
                    {
                        if (collection["NewPassword"] == collection["NewPasswordAgain"])
                        {
                            tutor.Account.password = collection["NewPassword"];
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.Error = "<div class=\"text-danger\">Mật khẩu mới không trùng nhau</div>";
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Error = "<div class=\"text-danger\">Không được nhập mật khẩu trùng nhau</div>";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Error = "<div class=\"text-danger\">Mật khẩu cũ không đúng</div>";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
