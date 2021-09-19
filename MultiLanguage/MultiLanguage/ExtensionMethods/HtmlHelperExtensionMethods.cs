using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using MultiLanguage.Utilities;

namespace MultiLanguage.ExtensionMethods
{
    public static class HtmlHelperExtensionMethods
    {
        public static string Translate(this IHtmlHelper helper, string key)
        {
            IServiceProvider services = helper.ViewContext.HttpContext.RequestServices;
            SharedViewLocalizer localizer = services.GetRequiredService<SharedViewLocalizer>();
            string result = localizer[key];
            return result;
        }
    }
}
