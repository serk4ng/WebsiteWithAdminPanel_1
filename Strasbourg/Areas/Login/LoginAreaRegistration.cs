using System.Web.Mvc;

namespace Strasbourg.UI.Areas.Login
{
    public class LoginAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Login";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
               "admin",
               "admin",
               new { controller = "Login", action = "Index", id = UrlParameter.Optional },
               new[] { "Strasbourg.UI.Areas.Login.Controllers" }

           );

            context.MapRoute(
                "STAdmin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "Strasbourg.UI.Areas.Login.Controllers" }

            );
        }
    }
}