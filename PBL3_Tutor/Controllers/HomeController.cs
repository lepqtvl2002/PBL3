using PBL3_Tutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult ClassList()
        {
            return View();
        }
        // GET
        public ActionResult Register()
        {
            return View();
        }
        // POST
        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            DBModelContext db = new DBModelContext();
            Student student = new Student();
            student.name = collection["name"];
            student.phonenumber = collection["phone"];
            student.address = collection["address"];
            student.note = collection["note"];
            db.Students.Add(student);
            db.SaveChanges();
            return View("ThankYou");
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}