using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace OneTrip3G.Attributes
{
    public class CustomHandlerErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
                return;

            filterContext.Controller.ViewData.Model = filterContext.Exception;
            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = filterContext.Controller.ViewData
            };

            filterContext.ExceptionHandled = true;
        }
    }
}
