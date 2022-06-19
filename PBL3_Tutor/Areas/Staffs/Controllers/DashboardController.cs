using PBL3_Tutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Staffs.Controllers
{
    public class DashboardController : BaseController
    {
        DBModelContext db = new DBModelContext();
        // GET: Staffs/Dashboard
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
        public ActionResult Profile(long id)
        {
            var staff = db.Staffs.Find(id);
            return View(staff);
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
                var ad = db.Staffs.Find(Convert.ToInt32(collection["id"]));
                ad.name = collection["name"];
                ad.email = collection["email"];
                ad.phonenumber = collection["phonenumber"];
                ad.Account.password = collection["password"];
                Session["StaffName"] = ad.name;
                Session["StaffEmail"] = ad.email;
                db.SaveChanges();
            }
            return RedirectToAction("Profile", "Dashboard", new { id = collection["id"] });
        }
        public ActionResult Table()
        {
            return View();
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