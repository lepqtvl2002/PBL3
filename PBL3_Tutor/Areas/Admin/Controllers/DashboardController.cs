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
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
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