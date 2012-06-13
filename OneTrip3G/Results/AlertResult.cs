using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace OneTrip3G.Results
{
    public class AlertResult<TResult> : FlashResult<TResult> where TResult : ActionResult
    {
        public AlertResult(TResult result, string message)
            : base(result, message)
        { }

        public override void ExecuteResult(ControllerContext context)
        {
            context.Controller.TempData["Alert"] = message;
            result.ExecuteResult(context);
        }
    }
}
