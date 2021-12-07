using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace LearninGO.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        // GET: Admin/Student

        LearninGODatabaseProjectEntities db = new LearninGODatabaseProjectEntities();

        public ActionResult MyProfile( int ?item)

        {
            var mydata = db.StudentProfile.Where(x=> x.Id==item).FirstOrDefault();
            return View(mydata);
        }

        public ActionResult StudentCart(int ?id )
        {
            var content = db.CreateCourse.Where(p => p.CourseId == id).FirstOrDefault();

            /*  var result = context.CreateCourse.Join(context.StudentCart, u => u.CourseId,
                 uir => uir.CourseID, (u, uir) => new { u, uir })
                   .Where(x => x.u.CourseId == id)
                   .Select(x => new LearningGO.Models.AllDetail
                   {


                       CourseTitle = x.u.CourseTitle,
                       CourseLevel = x.u.CourseLevel,
                       Details = x.u.Details

                   }).FirstOrDefault();
            */
            return View(content);

        }






        //public ActionResult StudentCart(int? stuid)
        //{
        //    var content = db.StudentCart.Where(p => p.StudentId == stuid).FirstOrDefault();

        //    /*  var result = context.CreateCourse.Join(context.StudentCart, u => u.CourseId,
        //          uir => uir.CourseID, (u, uir) => new { u, uir })
        //           .Where(x => x.u.CourseId == id)
        //           .Select(x => new LearningGO.Models.AllDetail
        //           {


        //               CourseTitle = x.u.CourseTitle,
        //               CourseLevel = x.u.CourseLevel,
        //               Details = x.u.Details

        //           }).FirstOrDefault();
        //    */
        //    return View(content);

        //}





        public ActionResult Notification()
        {
            return View();
        }

        public ActionResult ProfileEdit(int ?stuid)
        {

            StudentProfile StudentProfile = db.StudentProfile.Where(x=> x.Id == stuid).FirstOrDefault();
           
            return View(StudentProfile);
        }

        [HttpPost]
        public ActionResult ProfileEdit(StudentProfile StudentProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(StudentProfile).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyProfile");
            }


            return View(StudentProfile);
        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentSignup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentSignup(LearninGO.Areas.Admin.Data.AcountModel obj)
        {
            Account a = new Account();
            a.Email = obj.Email;
            a.FullName = obj.FullName;
            a.Type = 3;

            a.Password = obj.Password;
            db .Account.Add(a);
            db.SaveChanges();

            StudentProfile s = new StudentProfile();
            s.Id = a.Id;
            s.StudentFullName = a.FullName;
            s.PhoneNumber = obj.PhoneNumber;
            s.About = obj.About;
           
            string fileName = Path.GetFileNameWithoutExtension(obj.ImageFile.FileName);

            string extention = Path.GetExtension(obj.ImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;

            obj.ImageUrl = "~/file" + fileName;

            fileName = Path.Combine(Server.MapPath("~/file"), fileName);

            obj.ImageFile.SaveAs(fileName);

            db.StudentProfile.Add(s);
            db.SaveChanges();
            db.StudentProfile.Add(s);
            db.SaveChanges();

               SocialMedia fb = new SocialMedia();
                fb.Id = a.Id;
                fb.SocialMediaType = "facebook";
                fb.socialmediaurl = obj.Facebook;
                db.SocialMedia.Add(fb);
                db.SaveChanges();

                SocialMedia tw = new SocialMedia();
                tw.Id = a.Id;
                tw.SocialMediaType = "twitter";
                tw.socialmediaurl = obj.Twitter;
                db.SocialMedia.Add(tw);
                db.SaveChanges();



                SocialMedia li = new SocialMedia();
                li.Id = a.Id;
                li.SocialMediaType= "linkdin";
                li.socialmediaurl = obj.Linkdin;
                db.SocialMedia.Add(li);
                db.SaveChanges();

                


            return RedirectToAction("Login","Home");



        }



        //By Kuldeeep Kumar (Admin)
        public ActionResult StudentProfile()
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                //var pp = context.InstructorProfiles.ToList();
                var result = context.Account.Join(context.StudentProfile, r => r.Id, p => p.Id, (r, p) => new { r, p })
                    //.Where(x => x.p.InstructorId == Id)
                    .Select(x => new LearninGO.Areas.Admin.Data.StudentModel
                    {
                        FullName = x.r.FullName,
                        Id=x.r.Id,
                        PhoneNumber = x.p.PhoneNumber,
                        ImageUrl = x.p.ImageUrl,
                        About = x.p.About,
                        //Password = x.Password,
                        //Time = x.Time,
                        //NoOfCourses = x.NoOfCourses,
                    }).ToList();

                return View(result);
            }
        }


        //By Kuldeeep Kumar (Admin)
        [HttpPost]
        public ActionResult StudentProfile(string searchtext)
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                //var result = context.InstructorProfile.ToList();
                if (searchtext != null)
                {
                    var FindData = context.Account.Join(context.StudentProfile, r => r.Id, p => p.Id, (r, p) => new { r, p })
                        .Where(Y => Y.r.FullName.Contains(searchtext)).ToList()
                    .Select(x => new LearninGO.Areas.Admin.Data.StudentModel
                    {
                        FullName = x.r.FullName,
                        PhoneNumber = x.p.PhoneNumber,
                        Id = x.r.Id,

                        About = x.p.About,
                        ImageUrl = x.p.ImageUrl,
                    }).ToList();

                    if (FindData.Count == 0)
                    {
                        ViewBag.Msg = "Data Not Found";
                        return View();
                    }
                    else
                    {
                        return View(FindData);
                    }

                }

                //var obj = context.InstructorProfile.ToList();
                return View();
            }
        }

        //By Kuldeeep Kumar (Admin)
        //[HttpGet]
        public ActionResult OneStudentProfile(int? idstu)
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                
                var result = context.Account.Join(context.StudentProfile, r => r.Id, p => p.Id, (r, p) => new { r, p })
                   .Where(x => x.p.Id== x.r.Id && x.r.Id == idstu)
                   .Select(x => new LearninGO.Areas.Admin.Data.AcountModel
                   {
                       Id = x.r.Id,
                       FullName = x.r.FullName,
                       Email = x.r.Email,
                       Password = x.r.Password,

                       PhoneNumber = x.p.PhoneNumber,
                       StudentAddress = x.p.StudentAddress,
                       About = x.p.About,
                       ImageUrl = x.p.ImageUrl,

                   }).FirstOrDefault();

                return View(result);
            }
        }

        public ActionResult Message()
        {
            ViewBag.InstructorID = new SelectList(db.Account.Where(x => x.Type > 1 && x.Type < 3), "Id", "FUllName");
            ViewBag.StudentID = new SelectList(db.Account.Where(x => x.Type > 2), "Id", "FullName");



            return View();
        }

        [HttpPost]
        public ActionResult Message([Bind(Include = "StudentId,InstructorID,StudentChat,sno,InstructorChat,chatmessagetime")] Message message)
        {

            if (ModelState.IsValid)
            {
                message.chatmessagetime = DateTime.Now;
                db.Message.Add(message);
                db.SaveChanges();
                return RedirectToAction("Message", "Student");
            }

            ViewBag.InstructorID = new SelectList(db.Account, "Id", "Id");
            ViewBag.StudentID = new SelectList(db.Account, "Id", "Id");
            return View("Message", "Student");
        }

    }
}