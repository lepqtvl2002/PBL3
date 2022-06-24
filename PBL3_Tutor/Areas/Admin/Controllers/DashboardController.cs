using PBL3_Tutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        DBModelContext db = new DBModelContext();
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            Session["Customers"] = db.Students.Where(p => p.isConfirm != true).Count();
            Session["Tutors"] = db.Tutors.Count();
            Session["Classes"] = db.Classes.Where(p => p.state != true).Count();
            return View();
        }
        public ActionResult Dashboard()
        {
            Session["Customers"] = db.Students.Where(p => p.isConfirm != true).Count();
            Session["Tutors"] = db.Tutors.Count();
            Session["Classes"] = db.Classes.Where(p => p.state != true).Count();
            var list = db.Registrations.ToList();
            return View(list);
        }
        public ActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        public new ActionResult Profile(FormCollection collection)
        {
            if (collection == null)
            {
                return View("Error_404");
            }
            else
            {
                if (Session["Role"] == "Admin")
                {
                    var ad = db.Admins.Find(Convert.ToInt32(collection["id"]));
                    ad.name = collection["name"];
                    ad.email = collection["email"];
                    ad.phonenumber = collection["phonenumber"];
                    ad.Account.password = collection["password"];

                    Session["Name"] = ad.name;
                    Session["Email"] = ad.email;
                    Session["Password"] = ad.Account.password;
                    Session["PhoneNumber"] = ad.phonenumber;
                    db.SaveChanges();
                }
                else
                {
                    var staff = db.Staffs.Find(Convert.ToInt32(collection["id"]));
                    staff.name = collection["name"];
                    staff.email = collection["email"];
                    staff.phonenumber = collection["phonenumber"];
                    staff.Account.password = collection["password"];
                    
                    Session["Name"] = collection["name"];
                    Session["Email"] = collection["email"];
                    Session["Password"] = collection["password"];
                    Session["PhoneNumber"] = collection["phonenumber"];
                    
                }
                
            }
            return RedirectToAction("Profile", "Dashboard");
        }
        public ActionResult Table()
        {
            var listAccount = db.Accounts.Where(p => p.Role.rolename == "Admin" || p.Role.rolename == "Nhân viên").ToList();
            return View(listAccount);
        }
        public ActionResult Map()
        {
            return View();
        }
        public ActionResult Error_404()
        {
            return View();
        }
    }
}