﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBL3_Tutor.Models;

namespace PBL3_Tutor.Areas.Tutors.Controllers
{
    public class ClassesController : Controller
    {
        private DBModelContext db = new DBModelContext();

        // GET: Tutors/Classes
        public ActionResult Index()
        {
            var classes = db.Classes.Include(p => p.Student).Where(p => p.state != true);
            return View(classes.ToList());
        }

        // GET: Tutors/Classes/Details/5
        public ActionResult Details(long id)
        {
            Session["ClassId"] = id;
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }
/*
        // GET: Tutors/Classes/Create
        public ActionResult Create()
        {
            ViewBag.studentId = new SelectList(db.Students, "studentId", "name");
            return View();
        }

        // POST: Tutors/Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "classId,studentId,fee,state")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Classes.Add(@class);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.studentId = new SelectList(db.Students, "studentId", "name", @class.studentId);
            return View(@class);
        }

        // GET: Tutors/Classes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            ViewBag.studentId = new SelectList(db.Students, "studentId", "name", @class.studentId);
            return View(@class);
        }

        // POST: Tutors/Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "classId,studentId,fee,state")] Class @class)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@class).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.studentId = new SelectList(db.Students, "studentId", "name", @class.studentId);
            return View(@class);
        }

        // GET: Tutors/Classes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class @class = db.Classes.Find(id);
            if (@class == null)
            {
                return HttpNotFound();
            }
            return View(@class);
        }

        // POST: Tutors/Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Class @class = db.Classes.Find(id);
            db.Classes.Remove(@class);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult FreeClasses()
        {
            var classes = db.Classes.Where(p => p.fee == 0);
            return View(classes.ToList());
        }
        [HttpPost]
        public ActionResult Filter(FormCollection collection)
        {
            var classes = new List<Class>();
            if (collection["fs[]"] != null)
            {
                string subjects = collection["fs[]"].ToString();
                classes.AddRange(db.Classes.Where(p => subjects.Contains(p.Student.subject)).ToList());
            }

            if (collection["fc[]"] != null)
            {
                string grades = collection["fc[]"].ToString();
                if (grades.Contains("Mần non"))
                {
                    var list = db.Classes.Where(p => p.Student.grade == "Mần non").ToList();
                    foreach(Class i in list)
                    {
                        if (!classes.Contains(i))
                        {
                            classes.Add(i);
                        }
                    }
                }
                if (grades.Contains("Tiểu học"))
                {
                    var list = db.Classes.Where(p => "1, 2, 3, 4, 5, Tiểu học".Contains(p.Student.grade)).ToList();
                    foreach (Class i in list)
                    {
                        if (!classes.Contains(i))
                        {
                            classes.Add(i);
                        }
                    }
                }
                if (grades.Contains("THCS"))
                {
                    var list = db.Classes.Where(p => "6, 7, 8, 9, THCS".Contains(p.Student.grade)).ToList();
                    foreach (Class i in list)
                    {
                        if (!classes.Contains(i))
                        {
                            classes.Add(i);
                        }
                    }
                }
                if (grades.Contains("THPT"))
                {
                    var list = db.Classes.Where(p => p.Student.grade == "10" || p.Student.grade == "11" || p.Student.grade == "12").ToList();
                    foreach (Class i in list)
                    {
                        if (!classes.Contains(i))
                        {
                            classes.Add(i);
                        }
                    }
                }
                if (grades.Contains("Người đi làm"))
                {
                    var list = db.Classes.Where(p => p.Student.grade == "Người đi làm").ToList();
                    foreach (Class i in list)
                    {
                        if (!classes.Contains(i))
                        {
                            classes.Add(i);
                        }
                    }
                }
            }
            if (collection["fy[]"] != null)
            {
                string requirements = collection["fy[]"].ToString();
                var list = db.Classes.Where(p => p.Student.requirement.Contains(requirements)).ToList();
                foreach (Class i in list)
                {
                    if (!classes.Contains(i))
                    {
                        classes.Add(i);
                    }
                }
            }
            if (collection["fk[]"] != null)
            {
                var areas = collection["fk[]"].ToString();
                string[] locations = areas.Split();
                foreach(string s in locations)
                {
                    var list = db.Classes.Where(p => p.Student.requirement.Contains(s)).ToList();
                    foreach (Class i in list)
                    {
                        if (!classes.Contains(i))
                        {
                            classes.Add(i);
                        }
                    }
                }
            }
            return View(classes);
        }
    }
}
