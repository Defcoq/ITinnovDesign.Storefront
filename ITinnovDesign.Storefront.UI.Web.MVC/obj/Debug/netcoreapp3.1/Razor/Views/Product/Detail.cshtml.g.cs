#pragma checksum "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6eefa47b13d718120f492c14561b43486972ce0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Detail), @"mvc.1.0.view", @"/Views/Product/Detail.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\_ViewImports.cshtml"
using ITinnovDesign.Storefront.UI.Web.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\_ViewImports.cshtml"
using ITinnovDesign.Storefront.UI.Web.MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
using ITinnovDesign.Storefront.Services.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
using ITinnovDesign.Storefront.Controllers.ViewModels.ProductCatalog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
using ITinnovDesign.Storefront.UI.Web.MVC.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6eefa47b13d718120f492c14561b43486972ce0", @"/Views/Product/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83bbbcbbb95bb446ba9415b9cdbe746c61482a39", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ITinnovDesign.Storefront.Controllers.ViewModels.ProductCatalog.ProductDetailView>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_BasketSummary", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
  
    ViewData["Title"] = "Detail";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script type=""text/javascript"">
        function addProductToBasket() {

            showOverlay(""smoverlay"", ""basketSummary"", 5);

           // alert($(""#productsizes"").val());
            var postData = {productId : $(""#productsizes"").val() };
            console.log(JSON.stringify(postData));

            $.ajax({
                url: """);
#nullable restore
#line 21 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
                 Write(Url.Action("AddToBasket", "Basket"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                type: 'POST',
                dataType: 'json',
                data: postData,
                contentType: 'application/x-www-form-urlencoded',
                success: updateBasket,
                error: function (req, status, error) {
                    alert(error);
                }
            });

           // $.post('/Basket/AddToBasket', JSON.stringify(postData), updateBasket, ""json"");
        }

        function updateBasket(basketSummaryView) {

            updateBasketSummary(basketSummaryView);
            hideOverlay(""smoverlay"");
        }
    </script>
");
            }
            );
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 43 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
Write(Model.Product.BrandName);

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
#nullable restore
#line 43 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
                           Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" for only  ");
#nullable restore
#line 43 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
                                                         Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<br/>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e6eefa47b13d718120f492c14561b43486972ce07490", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 45 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = ((BaseProductCatalogPageView)Model).BasketSummary;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div>\r\n    <span style=\"float : left\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e6eefa47b13d718120f492c14561b43486972ce09206", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1585, "~/Content/Images/Products/", 1585, 26, true);
#nullable restore
#line 48 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
AddHtmlAttributeValue("", 1611, Model.Product.Id.ToString(), 1611, 30, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 1641, ".jpg", 1641, 4, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n    <div>\r\n        ");
#nullable restore
#line 50 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
   Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n        ");
#nullable restore
#line 51 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
   Write(Model.Product.BrandName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 51 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
                            Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n        <p>\r\n\r\n            <select id=\"productsizes\">\r\n");
#nullable restore
#line 55 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
                 foreach (ProductSizeOption option in Model.Product.Products)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6eefa47b13d718120f492c14561b43486972ce012214", async() => {
#nullable restore
#line 57 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
                                          Write(option.SizeName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 57 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"
                       WriteLiteral(option.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 58 "C:\Worksapce\Dot.netCoreSample\Agathas.Storefront\ITinnovDesign.Storefront\ITinnovDesign.Storefront.UI.Web.MVC\Views\Product\Detail.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </select>

            <input type=""button"" value=""+ Add to cart"" onclick=""JavaScript:addProductToBasket();"" />
        </p>
        <p>
            * - Rutrum mattis nulla sodales<br />
            * - Duis sodales tempor felis ac<br />
            * - Ut porta metus a metus<br />
        </p>
    </div>
</div>
<div style=""clear: both;"" />

<h3>Returns / Delivery / Info</h3>
<p>
    Pellentesque magna lorem, faucibus quis feugiat non, aliquet in libero. Integer sit amet gravida erat. Duis sodales tempor felis ac adipiscing. Suspendisse non lectus enim.
    Vestibulum aliquet imperdiet posuere. Suspendisse ac diam odio. Ut porta metus a metus rutrum mattis. Nulla sodales, arcu ut mollis vehicula, tellus ante ultricies mauris, ultricies porttitor nunc purus a nisi.
</p>
    Nulla ipsum urna, cursus sed consectetur nec, varius quis diam. Morbi consequat sapien ut leo placerat ornare.");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ITinnovDesign.Storefront.Controllers.ViewModels.ProductCatalog.ProductDetailView> Html { get; private set; }
    }
}
#pragma warning restore 1591
