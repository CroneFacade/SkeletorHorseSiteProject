using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkeletorHorseProject.Helpers
{
    public static class HtmlHelperClass
    {
        public static MvcHtmlString DisplayMultiline(this HtmlHelper helper, string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return MvcHtmlString.Empty;
            }
            return MvcHtmlString.Create(str.Split(new string[] { "\n\n", "\n" }, StringSplitOptions.None).Aggregate((a, b) => a + "<br />" + b));
        }
    }
}