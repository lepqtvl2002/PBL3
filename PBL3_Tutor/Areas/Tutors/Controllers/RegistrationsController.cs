using System;
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
    public class RegistrationsController : BaseController
    {
        private DBModelContext db = new DBModelContext();

        // GET: Tutors/Registrations
        public ActionResult Index()
        {
            ViewBag.Notification = "";
            long tutorId = Convert.ToInt64(Session["TutorId"].ToString());
            var registrations = db.Registrations.Include(r => r.Class).Include(r => r.Tutor).Where(p => p.tutorId == tutorId);
            return View(registrations.ToList());
        }

        // GET: Tutors/Registrations/Details/5
        public ActionResult Details(long? classId)
        {
            long tutorId = Convert.ToInt64(Session["TutorId"].ToString());
            var registration = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault();
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: Tutors/Registrations/Create
        public ActionResult Create(long classId)
        {
            ViewBag.Notification = "";
            long tutorId = Convert.ToInt32(Session["TutorId"].ToString());
            Tutor tutor = db.Tutors.Find(tutorId);
            if (tutor.gender == null || tutor.name == null || tutor.phonenumber == null
                || tutor.email == null || tutor.yearOfBirth == null || tutor.university == null
                || tutor.subject == null || tutor.grade == null || tutor.address == null)
            {
                ViewBag.Notification = "Thông tin của bạn chưa đáp ứng được yêu cầu, hãy bổ sung thêm thông tin";
            }
            else
            {
                Registration registration = new Registration();
                Registration registed = db.Registrations.Where(p => p.tutorId == tutorId && p.classId == classId).FirstOrDefault(); 
                if (registed == null)
                {
                    registration.classId = classId;
                    registration.tutorId = tutorId;
                    registration.state = "Chờ xét duyệt";
                    db.Registrations.Add(registration);
                    db.SaveChanges();
                    ViewBag.Notification = "Đăng ký nhận lớp có mã số " + registration.classId + " thành công! " +
                        "Hãy chờ đợi, nếu hồ sơ đạt yêu cầu, chúng tôi sẽ liên lạc với bạn trong thời gian sớm nhất.";
                }
                else
                {
                    ViewBag.Notification = "Bạn đã đăng ký nhận lớp " + registration.classId + " trước đây rồi!";
                    ViewBag.Notification = "<div class=\"text-danger\">Tài khoản không tồn tại</div>";
                }
            }
            
            return RedirectToAction("Index");
        }

        // GET: Tutors/Registrations/Delete/5
        public ActionResult Delete(long? classId)
        {
            if (classId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            long tutorId = Convert.ToInt64(Session["TutorId"].ToString());
            Registration registration = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault();
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: Tutors/Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long classId)
        {
            long tutorId = Convert.ToInt64(Session["TutorId"].ToString());
            Registration registration = db.Registrations.Where(p => p.classId == classId && p.tutorId == tutorId).FirstOrDefault() ;
            db.Registrations.Remove(registration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
