using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OneTrip3G.Results;

namespace OneTrip3G.Web.Extensions
{
    public static class MvcExtensions
    {
        public static FlashResult<TResult> AndFlash<TResult>(this TResult result, string messageFormat, params object[] args) where TResult : ActionResult
        {
            return new FlashResult<TResult>(result, string.Format(messageFormat, args));
        }

        public static AlertResult<TResult> AndAlert<TResult>(this TResult result, string messageFormat, params object[] args) where TResult : ActionResult
        {
            return new AlertResult<TResult>(result, string.Format(messageFormat, args));
        }

        public static NoticeResult<TResult> AndNotice<TResult>(this TResult result, string messageFormat, params object[] args) where TResult : ActionResult
        {
            return new NoticeResult<TResult>(result, string.Format(messageFormat, args));
        }
    }
}