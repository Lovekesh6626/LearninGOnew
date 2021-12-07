using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace LearninGO.Areas.Admin.Controllers
{
    public class InstructorController : Controller
    {
        LearninGODatabaseProjectEntities db = new LearninGODatabaseProjectEntities();
        // GET: Admin/Instructor


        public ActionResult InstructorSignup()
        {
        
            return View();
        }

        [HttpPost]
        public ActionResult InstructorSignup(LearninGO.Areas.Admin.Data.AcountModel obj)
        {
            Account ac = new Account();
            ac.Email = obj.Email;
            ac.FullName = obj.FullName;
            ac.Type = 2;
            ac.Password = obj.Password;
            db.Account.Add(ac);
            db.SaveChanges();

            InstructorProfile i = new InstructorProfile();
            i.InstructorId = ac.Id;
            i.InstructorFullName= ac.FullName;
            i.InstructorPhoneNumber = obj.InstructorPhoneNumber;
            i.InstructorAddress = obj.InstructorAddress;
            i.InstructorAbout = obj.InstructorAbout;
            i.Time = DateTime.Now;
            db.InstructorProfile.Add(i);
            db.SaveChanges();

            SocialMedia fb = new SocialMedia();
            fb.Id = ac.Id;
            fb.SocialMediaType = "facebook";
            fb.socialmediaurl = obj.Facebook;
            db.SocialMedia.Add(fb);
            db.SaveChanges();

            SocialMedia tw = new SocialMedia();
            tw.Id = ac.Id;
            tw.SocialMediaType = "twitter";
            tw.socialmediaurl = obj.Twitter;
            db.SocialMedia.Add(tw);
            db.SaveChanges();



            SocialMedia li = new SocialMedia();
            li.Id = ac.Id;
            li.SocialMediaType = "linkdin";
            li.socialmediaurl = obj.Linkdin;
            db.SocialMedia.Add(li);
            db.SaveChanges();


            return RedirectToAction("Login", "Home");



        }


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


            db.CreateCourse.Add(dat);
            db.SaveChanges();

            //string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);

            //string extention = Path.GetExtension(model.ImageFile.FileName);

            //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;

            //model.CourseImageUrl = "~/App_Data/file" + fileName;

            //fileName = Path.Combine(Server.MapPath("~/App_Data/file"), fileName);

            //model.ImageFile.SaveAs(fileName);

            //db.CreateCourse.Add(model);
            //db.SaveChanges();


            ViewBag.CourseID = new SelectList(db.Category, "Id", "Name");
            return View();
        }



        //By Kuldeeep Kumar (Admin)
        public ActionResult InstructorProfile()
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                //var pp = context.InstructorProfiles.ToList();
                var result = context.Account.Join(context.InstructorProfile, r => r.Id, p => p.InstructorId, (r, p) => new { r, p })
                    //.Where(x => x.p.InstructorId == Id)
                    .Select(x => new LearninGO.Areas.Admin.Data.InstructorModel
                    {
                        Id = x.r.Id,
                        FullName = x.r.FullName,
                        Email = x.r.Email,
                        Password = x.r.Password,
                        InstructorId = x.p.InstructorId,

                        InstructorPhoneNumber = x.p.InstructorPhoneNumber,
                        InstructorAddress = x.p.InstructorAddress,
                        InstructorAbout = x.p.InstructorAbout,
                        Time = x.p.Time,
                    }).ToList();
                return View(result);
            }
        }



        [HttpPost]
        public ActionResult InstructorProfile(string searchtext)
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                //var result = context.InstructorProfile.ToList();
                if (searchtext != null)
                {
                    var FindData = context.Account.Join(context.InstructorProfile, r => r.Id, p => p.InstructorId, (r, p) => new { r, p })
                        .Where(Y => Y.r.FullName.Contains(searchtext)).ToList()
                    .Select(x => new LearninGO.Areas.Admin.Data.InstructorModel
                    {

                        Id = x.r.Id,
                        FullName = x.r.FullName,
                        Email = x.r.Email,
                        Password = x.r.Password,
                        InstructorId = x.p.InstructorId,

                        InstructorPhoneNumber = x.p.InstructorPhoneNumber,
                        InstructorAddress = x.p.InstructorAddress,
                        InstructorAbout = x.p.InstructorAbout,
                        Time = x.p.Time,

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
        [HttpGet]
        public ActionResult OneInstructorProfile(int? id)
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                //var result = context.
                //    .Where(x => x.InstructorId == id)
                //    .Select(x => new InstructorProfile()
                var result = context.Account.Join(context.InstructorProfile, r => r.Id, p => p.InstructorId, (r, p) => new { r, p })
                   .Where(x => x.p.InstructorId == x.r.Id && x.r.Id == id)
                   .Select(x => new LearninGO.Areas.Admin.Data.AcountModel
                   {
                       Id = x.r.Id,
                       FullName = x.r.FullName,
                       Email = x.r.Email,
                       Password = x.r.Password,

                       InstructorPhoneNumber = x.p.InstructorPhoneNumber,
                       InstructorAddress = x.p.InstructorAddress,
                       InstructorAbout = x.p.InstructorAbout,
                       Time = x.p.Time,

                   }).FirstOrDefault();

                return View(result);
            }
        }
        
        public ActionResult DeleteConfirmed(int? idea ,int? id)
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                var result = context.Account.Join(context.InstructorProfile, r => r.Id, p => p.InstructorId, (r, p) => new { r, p })
                   .Where(x => x.p.InstructorId == x.r.Id && x.r.Id == id)
                    .Select(x => new LearninGO.Areas.Admin.Data.AcountModel
                    {
                        Id = x.r.Id,
                        FullName = x.r.FullName,
                        Email = x.r.Email,
                        Password = x.r.Password,

                        InstructorPhoneNumber = x.p.InstructorPhoneNumber,
                        InstructorAddress = x.p.InstructorAddress,
                        InstructorAbout = x.p.InstructorAbout,
                        Time = x.p.Time,

                    }).FirstOrDefault();

                

            }

            db.SaveChanges();
            return RedirectToAction("InstructorProfile");
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
                return RedirectToAction("Message", "Instructor");
            }
            ViewBag.StudentId = new SelectList(db.Account, "Id", "FullName");
            ViewBag.InstructorID = new SelectList(db.Account, "Id", "FullName");
            return View("Message", "Instructor");
        }

         
    }


}
