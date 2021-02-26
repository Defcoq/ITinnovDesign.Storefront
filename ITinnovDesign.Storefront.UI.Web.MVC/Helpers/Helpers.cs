using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITinnovDesign.Storefront.UI.Web.MVC.Helpers
{
    public static class AgathaHtmlHelper
    {

        public static IHtmlContent GetContent(this IHtmlHelper helper, int currentPage,
                                       int totalPages, Func<int, string> pageUrl)
        {
            //StringBuilder result = new StringBuilder();
            var content = new HtmlContentBuilder();
            for (int i = 1; i <= totalPages; i++)
            {
                
                if (i == currentPage)
                {
                    //result.Append("<a class='selected' href='" + pageUrl(i) + "'>");
                    //result.Append(i.ToString());
                    //result.Append(i.ToString());
                    content.AppendHtml("<a class='selected' href='" + pageUrl(i) +"'>")
                                        .AppendHtml(i.ToString())
                                        .AppendHtml("</a>");
                }
                else
                {
                    content.AppendHtml("<a class='notselected' href='" + pageUrl(i) + "'>")
                                        .AppendHtml(i.ToString())
                                        .AppendHtml("</a>");
                }
            }


            return content;
        }
        public static string BuildPageLinksFrom(this IHtmlHelper Html, int currentPage,
                                       int totalPages, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= totalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml.Append(i.ToString());
                if (i == currentPage)
                    tag.AddCssClass("selected");
                else
                    tag.AddCssClass("notselected");
                result.AppendLine(tag.ToString());
            }


           return result.ToString();
        }

        public static string Resolve(this IHtmlHelper Html, string resource, HttpContext ctx)
        {
            return ITinnovDesign.Storefront.Infrastructure.Helpers.UrlHelper.Resolve(resource, ctx);
        }
    }
}
