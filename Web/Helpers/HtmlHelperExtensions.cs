using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Web.Routing;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// 添加一个为li包含a标签的Html
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        /// <param name="text">显示的文本</param>
        /// <param name="action">action</param>
        /// <param name="controller">controller</param>
        /// <returns></returns>
        public static MvcHtmlString LiMenu(this HtmlHelper helper, string text, string action, string controller)
        {
            TagBuilder li = new TagBuilder("li");
            if (helper.ViewContext.RouteData.Values["controller"].ToString().Equals(controller))
            {
                li.AddCssClass("current");
            }
            li.InnerHtml = helper.ActionLink(text, action, controller).ToString();
            return MvcHtmlString.Create(li.ToString());
        }

        public static MvcHtmlString MenuLink(this HtmlHelper html, string text, string action, string controller)
        {
            //生成的样式为
            //<a id="menu-admin-controller" class="menu-item selected" href="/controller/action">
            //    "text"
            //    <span class="allow"></span>
            //</a>
            var currentController = html.ViewContext.RouteData.Values["controller"].ToString();

            //创建a标签
            TagBuilder a = new TagBuilder("a");
            a.MergeAttribute("href", html.generateUrl(action, controller));
            a.MergeAttribute("title", text);
            a.GenerateId(string.Format("menu-admin-{0}", controller.ToLowerInvariant()));
            a.AddCssClass("menu-item");
            if (currentController.Equals(controller))
            {
                a.AddCssClass("selected");
            }

            //创建span标签
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("allow");

            a.InnerHtml = string.Format("{0}{1}", text, span.ToString());
            return MvcHtmlString.Create(a.ToString());
        }

        private static string generateUrl(this HtmlHelper html, string action, string controller)
        {
            return UrlHelper.GenerateUrl(null, action, controller, new RouteValueDictionary(),
                html.RouteCollection, html.ViewContext.RequestContext, true);
        }
    }
}