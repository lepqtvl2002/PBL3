using System.Web.Mvc;

namespace PBL3_Tutor.Areas.Staffs
{
    public class StaffsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Staffs";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Staffs_login",
                "Staffs/login",
                new { action = "Login", controller = "Auth", id = UrlParameter.Optional }
            );
            context.MapRoute(
                "Staffs_default",
                "Staffs/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}