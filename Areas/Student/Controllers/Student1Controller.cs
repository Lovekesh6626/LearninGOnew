using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearninGO.Areas.Student.Controllers
{
    public class Student1Controller : Controller
    {
        // GET: Student/Student1
        private LearninGO.LearninGODatabaseProjectEntities db = new LearninGO.LearninGODatabaseProjectEntities();



        // GET: Student
        public ActionResult Notification()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }


        public ActionResult Message()
        {
            ViewBag.InstructorID = new SelectList(db.Account.Where(x => x.Type > 1 && x.Type < 3), "Id", "FUllName");
            ViewBag.StudentID = new SelectList(db.Account.Where(x => x.Type > 2), "Id", "FullName");



            return View();
        }

        [HttpPost]
        public ActionResult Message(Message message)
        {

            if (ModelState.IsValid)
            {

                db.Message.Add(message);
                db.SaveChanges();
                return RedirectToAction("Message", "Student");
            }

            ViewBag.InstructorID = new SelectList(db.Account, "Id", "Id");
            ViewBag.StudentID = new SelectList(db.Account, "Id", "Id");

            return View("Message", "Student");
        }


        public ActionResult MyProfile()
        {
            return View();
        }


        public ActionResult Content()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Content(HttpPostedFileBase file)
        {
            string path = Server.MapPath("~/App_Data/file");
            string fileName = path + file.FileName;
            return View();

        }


    }
}