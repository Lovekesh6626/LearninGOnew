using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearninGO.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        LearninGODatabaseProjectEntities db = new LearninGODatabaseProjectEntities();
        // GET: Home

        public ActionResult StudentCart(int? stuid)
        {
            var content = db.StudentCart.Where(p => p.StudentId == stuid).ToList();

            ViewBag.cart = db.StudentCart.Where(x => x.StudentId == stuid).ToList();
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








        public ActionResult Category(int? idol)
        {

            var course = db.Category.Where(p => p.Id == idol).FirstOrDefault();


            return View(course);
        }

        public ActionResult CourseDetails(int? id)
        {

            var course = db.CreateCourse.Where(p => p.CourseId == id).FirstOrDefault();


            return View(course);
        }


        public ActionResult Coursecontent(int? idea)
        {
            var contentdisplay = db.CreateCourse.Where(p => p.CourseId == idea).FirstOrDefault();

            return View(contentdisplay);
        }



        public ActionResult CreateCart(int ?buy,int ?id)
        {

            StudentCart stu = new StudentCart();
            stu.StudentId = id;
            stu.CourseID = buy;
            stu.Time = DateTime.Now;

            db.StudentCart.Add(stu);
            db.SaveChanges();
            return RedirectToAction("CourseAddedPage");
        }


        public ActionResult CourseAddedPage()
        {
            return View();
        }







        public ActionResult Login()
        {
            return View();
        }





        //public ActionResult Login(Account pop)
        //{

        //    using (var context = new LearninGODatabaseProjectEntities())
        //    {

        //        bool isValid = context.Account.Any(x => x.Email == pop.Email && x.Password == pop.Password && x.Type == 1);

        //        if (isValid)
        //        {


        //            Session["id"] = pop.Id;
        //            Session["name"] = pop.FullName;
        //            Session["email"] = pop.Email;


        //            return RedirectToAction("Dashboard", "Admin");

        //        }


        //        bool isValid1 = context.Account.Any(x => x.Email == pop.Email && x.Password == pop.Password && x.Type == 2);

        //        if (isValid1)
        //        {


        //            Session["id"] = pop.Id;
        //            Session["name"] = pop.FullName;
        //            Session["email"] = pop.Email;

        //            return RedirectToAction("Dashbord", "Instructor");

        //        }
        //        bool isValid2 = context.Account.Any(x => x.Email == pop.Email && x.Password == pop.Password && x.Type == 3);

        //        if (isValid2)
        //        {
        //            var obj = db.Account.Where(a => a.Email.Equals(pop.Email) && a.Password.Equals(pop.Password)).FirstOrDefault();
        //            if (obj != null)
        //            {
        //                Session["UserID"] = obj.Id.ToString();
        //                Session["UserName"] = obj.FullName.ToString();
        //                Session["email"] = obj.Email.ToString();

        //                return RedirectToAction("MyProfile", "Student", new { item = 101 });
        //            }


        //            //Session["id"] = pop.Id;
        //            //Session["name"] = pop.FullName;
        //            //Session["email"] = pop.Email;





        //            return RedirectToAction("MyProfile", "Student", new { item = 101 });
                  

        //        }


        //        ModelState.AddModelError("", "INVALID USERNAME AND PASSWORD");
        //        return View();

        //    }
        //}

     [HttpPost]
        public ActionResult Login(LearninGO.Areas.Admin.Data.AcountModel pop)
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {

                bool isValid = context.Account.Any(x => x.Email == pop.Email && x.Password == pop.Password && x.Type == 1);

                if (isValid)
                {


                    var obj = db.Account.Where(a => a.Email.Equals(pop.Email) && a.Password.Equals(pop.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.FullName.ToString();
                        Session["email"] = obj.Email.ToString();

                        return RedirectToAction("Dashboard", "Admin", new { item = Session["UserID"] });
                    }

                }


                bool isValid1 = context.Account.Any(x => x.Email == pop.Email && x.Password == pop.Password && x.Type == 2);

                if (isValid1)
                {


                    var obj = db.Account.Where(a => a.Email.Equals(pop.Email) && a.Password.Equals(pop.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.FullName.ToString();
                        Session["email"] = obj.Email.ToString();

                        return RedirectToAction("Dashbord", "Instructor", new { item = Session["UserID"] });
                    }

                }
                bool isValid2 = context.Account.Any(x => x.Email == pop.Email && x.Password == pop.Password && x.Type == 3);

                if (isValid2)
                {

                    var obj = db.Account.Where(a => a.Email.Equals(pop.Email) && a.Password.Equals(pop.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.Id.ToString();
                        Session["UserName"] = obj.FullName.ToString();
                        Session["email"] = obj.Email.ToString();

                        return RedirectToAction("MyProfile", "Student", new { item = Session["UserID"] });
                    }

                   




                   

                }



                ModelState.AddModelError("", "INVALID USERNAME AND PASSWORD");
                return View();

            }

            return View();
        }

        public ActionResult Index()
        {
            var category = db.Category.ToList();
            return View(category);
        }

        public ActionResult AllCourse()
        {
            using (var context = new LearninGODatabaseProjectEntities())
            {

                //var result = context.CreateCourse
                //    .Select(X => new LearninGO.CreateCourse()
                //    {
                //        CourseId = X.CourseId,
                //        CourseTitle = X.CourseTitle,
                //        CourseLevel = X.CourseLevel
                //    }).ToList();
                //return View(result);
                return View();

            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}
