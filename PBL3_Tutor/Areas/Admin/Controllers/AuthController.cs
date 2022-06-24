using PBL3_Tutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Admin.Controllers
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
            var user = db.Admins.Where(p => p.username == username).FirstOrDefault();
            if (user != null)
            {
                if (user.Account.password.Equals(password))
                {
                    Session["Username"] = username;
                    Session["Id"] = user.adminId.ToString();
                    Session["Name"] = user.name;
                    Session["Email"] = user.email;
                    Session["Password"] = password;
                    Session["PhoneNumber"] = user.phonenumber;
                    Session["Role"] = "Admin";
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    
                    ViewBag.Error = "<div class='text-danger'>Mật khẩu không chính xác</div>";
                }
            }
            else
            {
                var userStaff = db.Staffs.Where(p => p.username == username).FirstOrDefault();
                if (userStaff == null)
                {
                    ViewBag.Error = "<div class='text-danger'>Tài khoản không tồn tại</div>";
                }
                else
                {
                    if (userStaff.Account.password.Equals(password))
                    {
                        Session["Username"] = username;
                        Session["Id"] = userStaff.staffId.ToString();
                        Session["Name"] = userStaff.name;
                        Session["Email"] = userStaff.email;
                        Session["Password"] = password;
                        Session["PhoneNumber"] = userStaff.phonenumber;
                        Session["Role"] = "Staff";
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {

                        ViewBag.Error = "<div class='text-danger'>Mật khẩu không chính xác</div>";
                    }
                }
            }
            return View("Login");
        }
        public ActionResult Logout()
        {
            ViewBag.Error = "";
            Session["AdminUsername"] = "";
            Session["AdminId"] = "";
            Session["AdminName"] = "";
            Session["AdminEmail"] = "";
            Session["AdminPhone"] = "";
            Session["AdminPassword"] = "";
            return View("Login");
        }
    }
}