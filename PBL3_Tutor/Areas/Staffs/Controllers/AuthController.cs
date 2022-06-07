using PBL3_Tutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Staffs.Controllers
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
            var user = db.Staffs.Where(p => p.username == username).FirstOrDefault();
            if (user != null)
            {
                if (user.Account.password.Equals(password))
                {
                    Session["StaffUsername"] = username;
                    Session["StaffId"] = user.staffId.ToString();
                    Session["StaffName"] = user.name;
                    Session["StaffEmail"] = user.email;
                    Session["StaffPassword"] = user.Account.password;
                    Session["StaffPhone"] = user.phonenumber;
                    return RedirectToAction("Index", "Dashboard");
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
            Session["StaffUsername"] = "";
            Session["StaffId"] = "";
            Session["StaffName"] = "";
            Session["StaffEmail"] = "";
            Session["StaffPhone"] = "";
            Session["StaffPassword"] = "";
            return View("Login");
        }
    }
}