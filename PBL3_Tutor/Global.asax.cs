﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace PBL3_Tutor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Session_Start()
        {   // Admin
            Session["AdminUsername"] = "";
            Session["AdminId"] = "";
            Session["AdminName"] = "";
            Session["AdminEmail"] = "";
            Session["AdminPhone"] = "";
            Session["AdminPassword"] = "";
            // Staff
            Session["StaffUsername"] = "";
            Session["StaffId"] = "";
            Session["StaffName"] = "";
            Session["StaffEmail"] = "";
            Session["StaffPhone"] = "";
            Session["StaffPassword"] = "";
            // Tutor
            Session["TutorUsername"] = "";
            Session["TutorId"] = "";
            Session["ClassId"] = "";
            Session["TutorName"] = "";
            Session["TutorEmail"] = "";
            Session["TutorPhone"] = "";
            Session["TutorPassword"] = "";
            // More
        }
    }
}
