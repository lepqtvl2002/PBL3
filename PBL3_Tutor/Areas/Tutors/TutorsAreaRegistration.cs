using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Tutors
{
    public class TutorsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Tutors";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Tutors_login",
                "Tutors/login",
                new { action = "Login", controller ="Auth", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Tutors_default",
                "Tutors/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}