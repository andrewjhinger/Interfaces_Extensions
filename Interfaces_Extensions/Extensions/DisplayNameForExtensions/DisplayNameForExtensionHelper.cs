using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Interfaces_Extensions.Extensions.DisplayNameForExtensions
{
    public static class DisplayNameForExtensionHelper
    {
        public static MvcHtmlString DisplayNameForExtension<ModelType, PropertyType>(this HtmlHelper<IEnumerable<ModelType>> html, Expression<Func<ModelType, PropertyType>> query)
        {
            var expression = GetDisplayName(html, query);
            return getPropertyName<ModelType>(expression);
        }

        public static string GetDisplayName<ModelType, ClassType, PropertyType>(HtmlHelper<ModelType> html, Expression<Func<ClassType, PropertyType>> query)
        {
            var expression = ExpressionHelper.GetExpressionText(query);
            expression = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);
            return expression;
        }

        public static MvcHtmlString getPropertyName<ClassType>(string property)
        {
            var metadata = ModelMetadataProviders.Current.GetMetadataForProperty(() => Activator.CreateInstance<ClassType>(), typeof(ClassType), property);
            return new MvcHtmlString(metadata.DisplayName ?? typeof(ClassType).Name);
        }
    }
}