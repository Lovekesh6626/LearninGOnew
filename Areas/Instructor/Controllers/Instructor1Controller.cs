using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearninGO.Areas.Instructor.Controllers
{
    public class Instructor1Controller : Controller
    {
        LearninGODatabaseProjectEntities db = new LearninGODatabaseProjectEntities();
        // GET: Instructor/Instructor1
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult NewCourse()
        {

            ViewBag.CourseID = new SelectList(db.Category, "Id", "Name");
            return View();


        }


        [HttpPost]
        public ActionResult NewCourse(CreateCourse model)
        {
            using (var context = new LearninGO.LearninGODatabaseProjectEntities())
            {
                CreateCourse dat = new CreateCourse()
                {

                    CourseTitle = model.CourseTitle,

                    CourseLevel = model.CourseLevel,
                    Details = model.Details,
                    Provider = model.Provider,
                    Tag = model.Tag,
                    Language = model.Language,
                    MetaTitle = model.MetaTitle,
                    MetaDescription = model.MetaDescription,
                    //  Category =model.Category



                };


                context.CreateCourse.Add(dat);
                context.SaveChanges();
                ViewBag.CourseID = new SelectList(db.Category, "Id", "CategoryName");
                return View();
            }




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
                return RedirectToAction("Message", "Instructor");
            }
            ViewBag.StudentId = new SelectList(db.Account, "Id", "FullName");
            ViewBag.InstructorID = new SelectList(db.Account, "Id", "FullName");

            return View("Message", "Instructor");
        }

    }
}