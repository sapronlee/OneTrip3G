using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OneTrip3G.Models;
using OneTrip3G.IProviders;

namespace OneTrip3G.Web.Extensions
{
    public static class MarkupExtensions
    {
        public static SettingModel GlobalSettings(this HtmlHelper html)
        {
            return DependencyResolver
                .Current
                .GetService<ISettingProvider>()
                .GetGlobalSettings<SettingModel>();
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

            var urlHelper = new UrlHelper(html.ViewContext.RequestContext, html.RouteCollection);

            a.MergeAttribute("href", urlHelper.Action(action, controller));
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
    }
}
