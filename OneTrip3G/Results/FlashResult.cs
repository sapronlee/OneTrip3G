using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace OneTrip3G.Results
{
    public class FlashResult<TResult> : ActionResult where TResult : ActionResult
    {
        protected readonly TResult result;
        protected readonly string message;

        public FlashResult(TResult result, string message)
        {
            this.result = result;
            this.message = message;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.Controller.TempData["Flash"] = message;
            result.ExecuteResult(context);
        }
    }
}
