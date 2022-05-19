using PBL3_Tutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBL3_Tutor.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            var listClass = new DBClassContext().Classes.ToList();
            return View(listClass);
        }

        // GET: Class/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Class/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Class/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Class/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Class/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Class/More/5
        public ActionResult More(int id)
        {
            var context = new DBClassContext();
            var more = context.Classes.Find(id);
            var studentSelect = new SelectList(context.Students, "MaHS");
            ViewBag.MaHS = studentSelect;
            return View(more);
        }

        // POST: Class/More/5
        [HttpPost]
        public ActionResult More(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET CLASS FREE
        public ActionResult ClassFree()
        {
            var context = new DBClassContext();
            var listClass = context.Classes.SqlQuery("select * from Class where PhiNhanLop = '0'").ToList();
            return View(listClass);
        }

        // Register Tutor
        public ActionResult Register()
        {
            return View();
        }
    }
}
