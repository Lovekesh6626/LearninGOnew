using System.Web.Mvc;

namespace LearninGO.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "", id = UrlParameter.Optional }
                );
            context.MapRoute("Admin","Admin/Admin/InstructorProfile", 
                new { action = "InstructorProfile", Controller ="Instructor" }
                );
        }
    }
}