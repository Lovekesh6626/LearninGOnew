using System.Web.Mvc;

namespace LearninGO.Areas.Instructor
{
    public class InstructorAreaRegistration : AreaRegistration 
    {
        public override string AreaName
        {
            get
            {
                return "Instructor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            //context.MapRoute("Instructor", "Instructor/Newcontroller", new { area = "Instructor", controller = "Instructor", action = "NewCourse" });

            context.MapRoute(
                "Instructor_default",
                "Instructor/{controller}/{action}/{id}",
                new { action = "NewCourse", id = UrlParameter.Optional }
            );

            

        }

    }
}