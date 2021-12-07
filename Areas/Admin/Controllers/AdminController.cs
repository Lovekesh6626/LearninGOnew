using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearninGO.Areas.Admin.Data;


namespace LearninGO.Controllers
{
    public class AdminController : Controller
    {
        public int? Id { get; private set; }

        // GET: Admin

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult LoginAccess()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginAccess(LoginAccess model)
        {
            using(var context =new LearninGODatabaseProjectEntities())
            {
                LoginAccess log = new LoginAccess()
                {
                    Emailid = model.Emailid,
                    password = model.password,
                    Logintime = model.Logintime

                };
                context.LoginAccess.Add(log);
                context.SaveChanges();
                return View();
            }
            
        }

        public ActionResult AddCourseCategory()
        {
            return View();
        }


        // GET: CourseCategory
        public ActionResult CourseCategoryView()
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                var result = context.Category
                    .Select(x => new Admin()
                    {
                        Id = x.Id,
                        Name = x.CategoryName,
                        IconUrl = x.IconUrl,

                    }).ToList();

                return View(result);
            }
        }



        // GET: HOME
        public ActionResult CreateCourseCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourseCategory(Admin model)
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                Category NewCategory = new Category()
                {
                    CategoryName = model.Name,
                    IconUrl = model.IconUrl
                };
                context.Category.Add(NewCategory);
                context.SaveChanges();
                ModelState.Clear();
                return View();

            }
        }



        public ActionResult CourseIndex()
        {
            return View();
        }

        public ActionResult InstructorProfile()
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                //var pp = context.InstructorProfiles.ToList();
                var result = context.Account.Join(context.InstructorProfile, r=>r.Id, p=>p.InstructorId,(r,p)=> new { r,p})
                    .Where(x => x.p.InstructorId==Id)
                    .Select(x => new LearninGO.Areas.Instructor.Data.Instructor
                    {
                        Id = x.r.Id,
                        FullName = x.r.FullName,
                        Email = x.r.Email,
                        Password = x.r.Password,
                        Type = x.r.Type,

                        InstructorPhoneNumber = x.p.InstructorPhoneNumber,
                        InstructorAddress = x.p.InstructorAddress,
                        InstructorAbout = x.p.InstructorAbout,
                       


                    }).ToList();

                return View(result);
            }


        }



        public ActionResult InstructorProfileIndex()
        {
            return View();
        }


        public ActionResult StudentIndex()
        {
            return View();
        }



        public ActionResult StudentProfile()
        {
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }



    }
}