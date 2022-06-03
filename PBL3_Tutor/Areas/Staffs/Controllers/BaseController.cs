using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Staffs.Controllers
{
    public class BaseController : Controller
    {
        // GET: Staffs/Base
        public BaseController()
        {
            if (System.Web.HttpContext.Current.Session["StaffUsername"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Staffs/login");
            }
        }
    }
}