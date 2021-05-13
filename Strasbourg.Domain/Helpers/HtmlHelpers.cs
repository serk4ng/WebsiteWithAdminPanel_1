using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Strasbourg.Domain.Helpers
{
    public static class HtmlHelpers
    {
        public static string MakeActive(this UrlHelper urlHelper, string controller)
        {
            string result = "active";

            string controllerName = urlHelper.RequestContext.RouteData.Values["controller"].ToString();

            if (!controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase))
            {
                result = null;
            }

            return result;
        }

        public static string ActivePage(this HtmlHelper helper, string controller, string action)
        {
            string classValue = "";
            string currentController = helper.ViewContext.Controller.ValueProvider.GetValue("controller").RawValue.ToString();
            string currentAction = helper.ViewContext.Controller.ValueProvider.GetValue("action").RawValue.ToString();
            if (currentController == controller && currentAction == action)
            {
                classValue = "active";
            }
            return classValue;
        }
    }
}
