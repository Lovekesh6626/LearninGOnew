using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearninGO.Areas.Instructor.Data;
using LearninGO;

using System.IO;

namespace OnlineClassManagement.Controllers
{
    public class InstructorController : Controller
    {

        private LearninGO.LearninGODatabaseProjectEntities db = new LearninGO.LearninGODatabaseProjectEntities();

        // GET: Instructor
        public ActionResult Student()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashbord()
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

                    CourseTitle=model.CourseTitle,

                    CourseLevel = model.CourseLevel,
                    Details = model.Details,
                    Provider = model.Provider,
                    Tag = model.Tag,
                    Language = model.Language,
                    MetaTitle  =model.MetaTitle,
                    MetaDescription=model.MetaDescription,
                  //  Category =model.Category

                  

                };
                

                context.CreateCourse.Add(dat);
                context.SaveChanges();
                ViewBag.CourseID = new SelectList(db.Category, "Id", "CategoryName");
                return View();
            }


        }


        public ActionResult AllCourse()
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
        public ActionResult Message( Message    message)
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

        public ActionResult Comment()
        {
            return View();
        }
        public ActionResult QuizCreate()
        {
            return View();
        }

        public ActionResult QuizList()
        {
            return View();
        }
        public ActionResult Myprofile()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ThumbNail()
        {
            ViewBag.CourseID = new SelectList(db.Category, "Id", "Name");
            return View();
           
        }
        [HttpPost]
        public ActionResult ThumbNail(/*[Bind(Include = " content_id,CourseThumbnail,ImagesUrl")]*/ CreateCourse model)
        {
            // Request.Files["ImageFile"];
            string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);

            string extention = Path.GetExtension(model.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;

            model.CourseImageUrl = "~/App_Data/file" + fileName;

            fileName = Path.Combine(Server.MapPath("~/App_Data/file"), fileName);

            model.ImageFile.SaveAs(fileName);

            db.CreateCourse.Add(model);
            db.SaveChanges();
          

      /*    if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);

                string extention = Path.GetExtension(model.ImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;

                model.ImagesUrl = "~/App_Data/file" + fileName;

                fileName = Path.Combine(Server.MapPath("~/App_Data/file"), fileName);

                model.ImageFile.SaveAs(fileName);

                db.coursecontent.Add(model);
                db.SaveChanges();
                return View();
            }

            */
            ViewBag.CourseID = new SelectList(db.Category, "Id", "Name");

            ModelState.Clear();

            return View(model);


        }

        [HttpGet]
        public ActionResult Content()
        {
            ViewBag.CourseID = new SelectList(db.Category, "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Content([Bind(Include = "CourseID, ContentId, ContentType, Url, sno")] Content model)
        {
            if (ModelState.IsValid)
            {
                db.Content.Add(model);
                db.SaveChanges();
                return View();
            }
            ViewBag.CourseID = new SelectList(db.Category, "Id", "Name");
            return View();


          
        }


    }
}