using PBL3_Tutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Tutors.Controllers
{
    public class RegisterAccountController : Controller
    {
        DBModelContext db = new DBModelContext();
        // GET: Tutors/RegisterAccount
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
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
                    return RedirectToAction("Index", "Document");
                }
                else
                {
                    ViewBag.Error = "<div class='text-danger'>Tên tài khoản đã tồn tại</div>";
                    return View(tutor);
                }
            }

            return View(tutor);
        }
    }
}