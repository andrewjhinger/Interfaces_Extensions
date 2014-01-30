using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Interfaces_Extensions.Extensions.HtmlExtensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString isCurrentPageActionLink(this HtmlHelper html, string text, string action, string controller)
        {
            var _action_ = html.ViewContext.RouteData.GetRequiredString("action");
            var _controller_ = html.ViewContext.RouteData.GetRequiredString("controller");

            if (action == _action_ && controller == _controller_)
            {
                TagBuilder anchorTag = new TagBuilder("a");
                anchorTag.Attributes["href"] = "#";
                anchorTag.AddCssClass("current-link");
                anchorTag.SetInnerText(text);
                return MvcHtmlString.Create(anchorTag.ToString(TagRenderMode.Normal));
            }
            else
            {
                return html.ActionLink(text, action, controller);
            }
        }
    }
}