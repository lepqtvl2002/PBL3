using PBL3_Tutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Tutors.Controllers
{
    public class AuthController : Controller
    {
        DBModelContext db = new DBModelContext();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        public ActionResult DoLogin(FormCollection feild)
        {
            ViewBag.Error = "";
            string username = feild["username"];
            string password = feild["password"];
            var user = db.Tutors.Where(p => p.username == username).FirstOrDefault();
            if (user != null)
            {
                if (user.Account.password.Equals(password))
                {
                    Session["TutorUsername"] = username;
                    Session["TutorId"] = user.tutorId.ToString();
                    Session["TutorName"] = user.name;
                    Session["TutorEmail"] = user.email;
                    Session["TutorPassword"] = user.Account.password;
                    Session["TutorPhone"] = user.phonenumber;
                    return RedirectToAction("Index", "Classes");
                }
                else
                {
                    ViewBag.Error = "<div class='text-danger'>Mật khẩu không chính xác</div>";
                }
            }
            else
            {
                ViewBag.Error = "<div class='text-danger'>Tài khoản không tồn tại</div>";
            }
            return View("Login");
        }
        public ActionResult Logout()
        {
            ViewBag.Error = "";
            Session["TutorUsername"] = "";
            Session["TutorId"] = "";
            Session["TutorName"] = "";
            Session["TutorEmail"] = "";
            Session["TutorPhone"] = "";
            Session["TutorPassword"] = "";
            return RedirectToAction("Index","Document");
        }
    }
}