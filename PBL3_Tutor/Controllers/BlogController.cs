using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Views.Blog
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult TutorBlog()
        {
            ViewBag.Message = "Articles for tutors.";
            return View();
        }
        public ActionResult StudentBlog()
        {
            ViewBag.Message = "Articles for students.";
            return View();
        }
        public ActionResult ParentBlog()
        {
            ViewBag.Message = "Articles for parents.";
            return View();
        }
    }
}