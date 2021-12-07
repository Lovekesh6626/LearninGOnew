using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearninGO.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {

        public int? Id { get; private set; }

        // GET: Admin

        LearninGODatabaseProjectEntities db = new LearninGODatabaseProjectEntities();
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
            using (var context = new LearninGODatabaseProjectEntities())
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


        //By Kuldeeep Kumar (Admin)
        public ActionResult Dashboard()
        {
            return View();
        }


        // GET: CourseCategory
        public ActionResult CourseCategory()
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                var result = context.Category
                    .Select(x => new Admin.Data.AdminModel()
                    {
                        Id = x.Id,
                        CategoryName = x.CategoryName,
                        IconUrl = x.IconUrl,

                    }).ToList();

                return View(result);
            }
        }


        //By Kuldeeep Kumar (Admin)

        // GET: HOME
        public ActionResult CreateCourseCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCourseCategory(Category model)
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                Category NewCategory = new Category()
                {
                    CategoryName = model.CategoryName,
                    IconUrl = model.IconUrl
                };
                context.Category.Add(NewCategory);
                context.SaveChanges();
                ModelState.Clear();
                return View();

            }
        }


        //By Kuldeeep Kumar (Admin)
        public ActionResult AllCourseList()
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {
                return View();
            }
        }


        public ActionResult AdminSignup()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AdminSignup(LearninGO.Areas.Admin.Data.AcountModel obj)
        {
            Account ac = new Account();
            ac.Email = obj.Email;
            ac.FullName = obj.FullName;
            ac.Type = 1;
            ac.Password = obj.Password;
            db.Account.Add(ac);
            db.SaveChanges();

           

            return RedirectToAction("Login", "Home");



        }




        public ActionResult AboutUs()
        {
            return View();
        }

        



        public ActionResult InstructorProfileIndex()
        {
            return View();
        }


        public ActionResult StudentIndex()
        {
            return View();
        }



        public ActionResult Index()
        {
            return View();
        }
       
    }
}