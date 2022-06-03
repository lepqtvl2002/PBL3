using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Tutors.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        public BaseController()
        {
            if (System.Web.HttpContext.Current.Session["TutorUsername"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Tutors/login");
            }
        }
    }
}