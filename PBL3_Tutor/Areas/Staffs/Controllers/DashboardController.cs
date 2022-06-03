using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Staffs.Controllers
{
    public class DashboardController : BaseController
    {
        // GET: Staffs/Dashboard
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
            return View();
        }
        public ActionResult Map()
        {
            return View();
        }
    }
}