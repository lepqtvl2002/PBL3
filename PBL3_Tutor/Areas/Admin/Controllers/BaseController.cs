using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            if (System.Web.HttpContext.Current.Session["Username"].Equals(""))
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Admin/login");
            }
        }
    }
}