using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using OneTrip3G.Models;
using OneTrip3G.IServices;
using System.Linq.Expressions;
using System.ComponentModel;

namespace OneTrip3G.Web.Extensions
{
    public static class MarkupExtensions
    {
        public static SettingViewModel GlobalSettings(this HtmlHelper html)
        {
            return MvcApplication.Settings;
        }

        public static bool CheckIsCurrentUser(this HtmlHelper helper, string userName)
        {
            return HttpContext.Current.User.Identity.Name.Equals(userName);
        }

        public static string AdminAction(this UrlHelper helper, string action, string controller)
        {
            return helper.Action(action, controller, new { @area = "Admin" });
        }

        public static string AdminAction(this UrlHelper helper, string action, string controller, int id)
        {
            return helper.Action(action, controller, new { @area = "Admin", @id = id });
        }

        public static string AdminActionAndPage(this UrlHelper helper, string action, string controller, int id, int page)
        {
            if (page == 1)
                return helper.AdminAction(action, controller, id);
            else
                return helper.Action(action, controller, new { @area = "Admin", @id = id, @page = page });
        }

        public static MvcHtmlString MenuLink(this HtmlHelper html, string text, string action, string controller, string area)
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

            a.MergeAttribute("href", urlHelper.Action(action, controller, new { area = area }));
            a.MergeAttribute("title", text);
            a.GenerateId(string.Format("menu-admin-{0}", controller.ToLowerInvariant()));
            a.AddCssClass("menu-item");
            if (html.GetAreaName() != null && html.GetAreaName().Equals("Admin") && currentController.Equals(controller))
            {
                a.AddCssClass("selected");
            }

            //创建span标签
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("allow");

            a.InnerHtml = string.Format("{0}{1}", text, span.ToString());
            return MvcHtmlString.Create(a.ToString());
        }

        public static string GetAreaName(this HtmlHelper html)
        {
            object outArea;
            if (html.ViewContext.RouteData.DataTokens.TryGetValue("area", out outArea))
            {
                return outArea.ToString();
            }
            return null;
        }

        public static IHtmlString HintFor<TModel>(this HtmlHelper<TModel> html, Expression<Func<TModel, object>> property)
        {
            var message = "";
            WhenEncountering<DescriptionAttribute>(property, d => message = d.Description);
            message = (message ?? string.Empty).Trim();
            if (message.Length == 0)
            {
                return new HtmlString(string.Empty);
            }
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass("hint");
            span.InnerHtml = message;
            return MvcHtmlString.Create(span.ToString());
        }

        private static void WhenEncountering<TAttribute>(LambdaExpression expression, Action<TAttribute> callback)
        {
            var member = expression.Body as MemberExpression;
            if (member == null)
            {
                var unary = expression.Body as UnaryExpression;
                if (unary == null)
                    return;

                member = unary.Operand as MemberExpression;
            }
            foreach (var instance in member.Member.GetCustomAttributes(true).OfType<TAttribute>())
            {
                callback(instance);
            }
        }

        public static string CurrentController(this HtmlHelper html)
        {
            return html.ViewContext.RouteData.Values["controller"].ToString().ToLowerInvariant();
        }

        public static MvcHtmlString FileUploadFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var name = ExpressionHelper.GetExpressionText(expression);
            var fullName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(fullName))
                throw new ArgumentException("name不能为null或空值");

            TagBuilder input = new TagBuilder("input");
            input.MergeAttributes(htmlAttributes);
            input.MergeAttribute("type", "file");
            input.MergeAttribute("name", fullName, true);
            input.GenerateId(name);

            ModelState modelState;
            if (html.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                    input.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            }

            input.MergeAttributes(html.GetUnobtrusiveValidationAttributes(name, metadata));
            return MvcHtmlString.Create(input.ToString(TagRenderMode.SelfClosing));
        }

        public static string Host(this UrlHelper url)
        {
            return url.RequestContext.HttpContext.Request.Url.Host;
        }
    }
}
